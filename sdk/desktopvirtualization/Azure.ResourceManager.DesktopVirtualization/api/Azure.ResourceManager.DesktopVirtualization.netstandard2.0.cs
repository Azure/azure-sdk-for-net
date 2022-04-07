namespace Azure.ResourceManager.DesktopVirtualization
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.DesktopVirtualization.HostPool GetHostPool(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.MsixPackage GetMsixPackage(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlan GetScalingPlan(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.SessionHost GetSessionHost(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.UserSession GetUserSession(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplication GetVirtualApplication(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup GetVirtualApplicationGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualDesktop GetVirtualDesktop(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace GetVirtualWorkspace(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HostPool : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HostPool() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.HostPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage> ExpandMsixImages(Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri msixImageUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage> ExpandMsixImagesAsync(Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri msixImageUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage> GetMsixPackage(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage>> GetMsixPackageAsync(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.MsixPackageCollection GetMsixPackages() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> GetScalingPlans(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> GetScalingPlansAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost> GetSessionHost(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost>> GetSessionHostAsync(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostCollection GetSessionHosts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.UserSession> GetUserSessions(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.UserSession> GetUserSessionsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.Models.RegistrationInfo> RetrieveRegistrationToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.Models.RegistrationInfo>> RetrieveRegistrationTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool> Update(Azure.ResourceManager.DesktopVirtualization.Models.PatchableHostPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.PatchableHostPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostPoolCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPool>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPool>, System.Collections.IEnumerable
    {
        protected HostPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.HostPool> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostPoolName, Azure.ResourceManager.DesktopVirtualization.HostPoolData hostPool, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.HostPool>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostPoolName, Azure.ResourceManager.DesktopVirtualization.HostPoolData hostPool, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool> Get(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.HostPool> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.HostPool> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool>> GetAsync(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool> GetIfExists(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool>> GetIfExistsAsync(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.HostPool> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPool>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.HostPool> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPool>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HostPoolData : Azure.ResourceManager.DesktopVirtualization.Models.ResourceModelWithAllowedPropertySet
    {
        public HostPoolData(Azure.Core.AzureLocation location, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType hostPoolType, Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType loadBalancerType, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType preferredAppGroupType) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<string> ApplicationGroupReferences { get { throw null; } }
        public bool? CloudPcResource { get { throw null; } }
        public string CustomRdpProperty { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType HostPoolType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType LoadBalancerType { get { throw null; } set { } }
        public int? MaxSessionLimit { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.MigrationRequestProperties MigrationRequest { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? PersonalDesktopAssignmentType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType PreferredAppGroupType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.RegistrationInfo RegistrationInfo { get { throw null; } set { } }
        public int? Ring { get { throw null; } set { } }
        public string SsoadfsAuthority { get { throw null; } set { } }
        public string SsoClientId { get { throw null; } set { } }
        public string SsoClientSecretKeyVaultPath { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType? SsoSecretType { get { throw null; } set { } }
        public bool? StartVmOnConnect { get { throw null; } set { } }
        public bool? ValidationEnvironment { get { throw null; } set { } }
        public string VmTemplate { get { throw null; } set { } }
    }
    public partial class MsixPackage : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MsixPackage() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.MsixPackageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName, string msixPackageFullName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage> Update(Azure.ResourceManager.DesktopVirtualization.Models.PatchableMsixPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.PatchableMsixPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MsixPackageCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.MsixPackage>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.MsixPackage>, System.Collections.IEnumerable
    {
        protected MsixPackageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.MsixPackage> CreateOrUpdate(Azure.WaitUntil waitUntil, string msixPackageFullName, Azure.ResourceManager.DesktopVirtualization.MsixPackageData msixPackage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.MsixPackage>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string msixPackageFullName, Azure.ResourceManager.DesktopVirtualization.MsixPackageData msixPackage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage> Get(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.MsixPackage> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.MsixPackage> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage>> GetAsync(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage> GetIfExists(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackage>> GetIfExistsAsync(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.MsixPackage> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.MsixPackage>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.MsixPackage> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.MsixPackage>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MsixPackageData : Azure.ResourceManager.Models.ResourceData
    {
        public MsixPackageData() { }
        public string DisplayName { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } set { } }
        public bool? IsRegularRegistration { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications> PackageApplications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies> PackageDependencies { get { throw null; } }
        public string PackageFamilyName { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public string PackageRelativePath { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool> GetHostPool(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPool>> GetHostPoolAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.HostPoolCollection GetHostPools(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> GetScalingPlan(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>> GetScalingPlanAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlanCollection GetScalingPlans(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> GetVirtualApplicationGroup(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>> GetVirtualApplicationGroupAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupCollection GetVirtualApplicationGroups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> GetVirtualWorkspace(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>> GetVirtualWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceCollection GetVirtualWorkspaces(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class ScalingPlan : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScalingPlan() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scalingPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> Update(Azure.ResourceManager.DesktopVirtualization.Models.PatchableScalingPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.PatchableScalingPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScalingPlanCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>, System.Collections.IEnumerable
    {
        protected ScalingPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> CreateOrUpdate(Azure.WaitUntil waitUntil, string scalingPlanName, Azure.ResourceManager.DesktopVirtualization.ScalingPlanData scalingPlan, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scalingPlanName, Azure.ResourceManager.DesktopVirtualization.ScalingPlanData scalingPlan, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> Get(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>> GetAsync(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> GetIfExists(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>> GetIfExistsAsync(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScalingPlanData : Azure.ResourceManager.DesktopVirtualization.Models.ResourceModelWithAllowedPropertySet
    {
        public ScalingPlanData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public string ExclusionTag { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference> HostPoolReferences { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType? HostPoolType { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule> Schedules { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class SessionHost : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SessionHost() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSession> GetUserSession(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSession>> GetUserSessionAsync(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.UserSessionCollection GetUserSessions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost> Update(Azure.ResourceManager.DesktopVirtualization.Models.PatchableSessionHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.PatchableSessionHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SessionHostCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.SessionHost>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.SessionHost>, System.Collections.IEnumerable
    {
        protected SessionHostCollection() { }
        public virtual Azure.Response<bool> Exists(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost> Get(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.SessionHost> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.SessionHost> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost>> GetAsync(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost> GetIfExists(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHost>> GetIfExistsAsync(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.SessionHost> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.SessionHost>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.SessionHost> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.SessionHost>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SessionHostData : Azure.ResourceManager.Models.ResourceData
    {
        public SessionHostData() { }
        public string AgentVersion { get { throw null; } set { } }
        public bool? AllowNewSession { get { throw null; } set { } }
        public string AssignedUser { get { throw null; } set { } }
        public System.DateTimeOffset? LastHeartBeat { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdateTime { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public string OSVersion { get { throw null; } set { } }
        public string ResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport> SessionHostHealthCheckResults { get { throw null; } }
        public int? Sessions { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? StatusTimestamp { get { throw null; } }
        public string SxSStackVersion { get { throw null; } set { } }
        public string UpdateErrorMessage { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.UpdateState? UpdateState { get { throw null; } set { } }
        public string VirtualMachineId { get { throw null; } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.HostPool> GetHostPools(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.HostPool> GetHostPoolsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> GetScalingPlans(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlan> GetScalingPlansAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> GetVirtualApplicationGroups(this Azure.ResourceManager.Resources.Subscription subscription, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> GetVirtualApplicationGroupsAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> GetVirtualWorkspaces(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> GetVirtualWorkspacesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserSession : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserSession() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.UserSessionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, string userSessionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disconnect(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisconnectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSession> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSession>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendMessage(Azure.ResourceManager.DesktopVirtualization.Models.SendMessage sendMessage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendMessageAsync(Azure.ResourceManager.DesktopVirtualization.Models.SendMessage sendMessage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserSessionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.UserSession>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.UserSession>, System.Collections.IEnumerable
    {
        protected UserSessionCollection() { }
        public virtual Azure.Response<bool> Exists(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSession> Get(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.UserSession> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.UserSession> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSession>> GetAsync(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSession> GetIfExists(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSession>> GetIfExistsAsync(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.UserSession> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.UserSession>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.UserSession> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.UserSession>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UserSessionData : Azure.ResourceManager.Models.ResourceData
    {
        public UserSessionData() { }
        public string ActiveDirectoryUserName { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType? ApplicationType { get { throw null; } set { } }
        public System.DateTimeOffset? CreateTime { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionState? SessionState { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
    }
    public partial class VirtualApplication : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualApplication() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationGroupName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> Update(Azure.ResourceManager.DesktopVirtualization.Models.PatchableVirtualApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.PatchableVirtualApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualApplicationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>, System.Collections.IEnumerable
    {
        protected VirtualApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData application, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData application, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualApplicationData : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualApplicationData(Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting commandLineSetting) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType? ApplicationType { get { throw null; } set { } }
        public string CommandLineArguments { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting CommandLineSetting { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public byte[] IconContent { get { throw null; } }
        public string IconHash { get { throw null; } }
        public int? IconIndex { get { throw null; } set { } }
        public string IconPath { get { throw null; } set { } }
        public string MsixPackageApplicationId { get { throw null; } set { } }
        public string MsixPackageFamilyName { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public bool? ShowInPortal { get { throw null; } set { } }
    }
    public partial class VirtualApplicationGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualApplicationGroup() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.Models.StartMenuItem> GetStartMenuItems(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.Models.StartMenuItem> GetStartMenuItemsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication> GetVirtualApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplication>> GetVirtualApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualApplicationCollection GetVirtualApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop> GetVirtualDesktop(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop>> GetVirtualDesktopAsync(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualDesktopCollection GetVirtualDesktops() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> Update(Azure.ResourceManager.DesktopVirtualization.Models.PatchableVirtualApplicationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.PatchableVirtualApplicationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualApplicationGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>, System.Collections.IEnumerable
    {
        protected VirtualApplicationGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationGroupName, Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData applicationGroup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationGroupName, Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData applicationGroup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> Get(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>> GetAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> GetIfExists(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>> GetIfExistsAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualApplicationGroupData : Azure.ResourceManager.DesktopVirtualization.Models.ResourceModelWithAllowedPropertySet
    {
        public VirtualApplicationGroupData(Azure.Core.AzureLocation location, string hostPoolArmPath, Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType applicationGroupType) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType ApplicationGroupType { get { throw null; } set { } }
        public bool? CloudPcResource { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string HostPoolArmPath { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.MigrationRequestProperties MigrationRequest { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public string WorkspaceArmPath { get { throw null; } }
    }
    public partial class VirtualDesktop : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualDesktop() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationGroupName, string desktopName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop> Update(Azure.ResourceManager.DesktopVirtualization.Models.PatchableVirtualDesktopData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.PatchableVirtualDesktopData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualDesktopCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop>, System.Collections.IEnumerable
    {
        protected VirtualDesktopCollection() { }
        public virtual Azure.Response<bool> Exists(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop> Get(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop>> GetAsync(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop> GetIfExists(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop>> GetIfExistsAsync(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktop>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualDesktopData : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualDesktopData() { }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public byte[] IconContent { get { throw null; } }
        public string IconHash { get { throw null; } }
        public string ObjectId { get { throw null; } }
    }
    public partial class VirtualWorkspace : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualWorkspace() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> Update(Azure.ResourceManager.DesktopVirtualization.Models.PatchableVirtualWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.PatchableVirtualWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualWorkspaceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>, System.Collections.IEnumerable
    {
        protected VirtualWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData workspace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData workspace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspace>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualWorkspaceData : Azure.ResourceManager.DesktopVirtualization.Models.ResourceModelWithAllowedPropertySet
    {
        public VirtualWorkspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> ApplicationGroupReferences { get { throw null; } }
        public bool? CloudPcResource { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
    }
}
namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationGroupType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationGroupType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType Desktop { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType RemoteApp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType left, Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType left, Azure.ResourceManager.DesktopVirtualization.Models.ApplicationGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType Desktop { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType RemoteApp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType left, Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType left, Azure.ResourceManager.DesktopVirtualization.Models.ApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommandLineSetting : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommandLineSetting(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting Allow { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting DoNotAllow { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting Require { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting left, Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting left, Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationSku
    {
        public DesktopVirtualizationSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSkuTier? Tier { get { throw null; } set { } }
    }
    public enum DesktopVirtualizationSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class ExpandMsixImage : Azure.ResourceManager.Models.ResourceData
    {
        public ExpandMsixImage() { }
        public string DisplayName { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } set { } }
        public bool? IsRegularRegistration { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public string PackageAlias { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications> PackageApplications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies> PackageDependencies { get { throw null; } set { } }
        public string PackageFamilyName { get { throw null; } set { } }
        public string PackageFullName { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public string PackageRelativePath { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthCheckName : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthCheckName(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName AppAttachHealthCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName DomainJoinedCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName DomainReachable { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName DomainTrustCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName FSLogixHealthCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName MetaDataServiceCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName MonitoringAgentCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName SupportedEncryptionCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName SxSStackListenerCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName UrlsAccessibleCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName WebRTCRedirectorCheck { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName left, Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName left, Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthCheckResult : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthCheckResult(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult HealthCheckFailed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult HealthCheckSucceeded { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult SessionHostShutdown { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult left, Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult left, Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPoolType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPoolType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType BYODesktop { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType Personal { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType Pooled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadBalancerType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadBalancerType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType BreadthFirst { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType DepthFirst { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType Persistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType left, Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType left, Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationOperation : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationOperation(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Complete { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Hide { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Revoke { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Start { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Unhide { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation left, Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation left, Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationRequestProperties
    {
        public MigrationRequestProperties() { }
        public string MigrationPath { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation? Operation { get { throw null; } set { } }
    }
    public partial class MsixImageUri
    {
        public MsixImageUri() { }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MsixPackageApplications
    {
        public MsixPackageApplications() { }
        public string AppId { get { throw null; } set { } }
        public string AppUserModelId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string IconImageName { get { throw null; } set { } }
        public byte[] RawIcon { get { throw null; } set { } }
        public byte[] RawPng { get { throw null; } set { } }
    }
    public partial class MsixPackageDependencies
    {
        public MsixPackageDependencies() { }
        public string DependencyName { get { throw null; } set { } }
        public string MinVersion { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public partial class PatchableHostPoolData : Azure.ResourceManager.Models.ResourceData
    {
        public PatchableHostPoolData() { }
        public string CustomRdpProperty { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.LoadBalancerType? LoadBalancerType { get { throw null; } set { } }
        public int? MaxSessionLimit { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? PersonalDesktopAssignmentType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType? PreferredAppGroupType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.RegistrationInfoPatch RegistrationInfo { get { throw null; } set { } }
        public int? Ring { get { throw null; } set { } }
        public string SsoadfsAuthority { get { throw null; } set { } }
        public string SsoClientId { get { throw null; } set { } }
        public string SsoClientSecretKeyVaultPath { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType? SsoSecretType { get { throw null; } set { } }
        public bool? StartVmOnConnect { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? ValidationEnvironment { get { throw null; } set { } }
        public string VmTemplate { get { throw null; } set { } }
    }
    public partial class PatchableMsixPackageData : Azure.ResourceManager.Models.ResourceData
    {
        public PatchableMsixPackageData() { }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } set { } }
        public bool? IsRegularRegistration { get { throw null; } set { } }
    }
    public partial class PatchableScalingPlanData
    {
        public PatchableScalingPlanData() { }
        public string Description { get { throw null; } set { } }
        public string ExclusionTag { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference> HostPoolReferences { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType? HostPoolType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule> Schedules { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class PatchableSessionHostData : Azure.ResourceManager.Models.ResourceData
    {
        public PatchableSessionHostData() { }
        public bool? AllowNewSession { get { throw null; } set { } }
        public string AssignedUser { get { throw null; } set { } }
    }
    public partial class PatchableVirtualApplicationData
    {
        public PatchableVirtualApplicationData() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType? ApplicationType { get { throw null; } set { } }
        public string CommandLineArguments { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.CommandLineSetting? CommandLineSetting { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public int? IconIndex { get { throw null; } set { } }
        public string IconPath { get { throw null; } set { } }
        public string MsixPackageApplicationId { get { throw null; } set { } }
        public string MsixPackageFamilyName { get { throw null; } set { } }
        public bool? ShowInPortal { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PatchableVirtualApplicationGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public PatchableVirtualApplicationGroupData() { }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PatchableVirtualDesktopData
    {
        public PatchableVirtualDesktopData() { }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PatchableVirtualWorkspaceData
    {
        public PatchableVirtualWorkspaceData() { }
        public System.Collections.Generic.IList<string> ApplicationGroupReferences { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalDesktopAssignmentType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalDesktopAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType Automatic { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType Direct { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType left, Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType left, Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreferredAppGroupType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreferredAppGroupType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType Desktop { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType None { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType RailApplications { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType left, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType left, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistrationInfo
    {
        public RegistrationInfo() { }
        public System.DateTimeOffset? ExpirationTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation? RegistrationTokenOperation { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
    }
    public partial class RegistrationInfoPatch
    {
        public RegistrationInfoPatch() { }
        public System.DateTimeOffset? ExpirationTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation? RegistrationTokenOperation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegistrationTokenOperation : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegistrationTokenOperation(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation None { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation left, Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation left, Azure.ResourceManager.DesktopVirtualization.Models.RegistrationTokenOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteApplicationType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType InBuilt { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType MsixApplication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType left, Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType left, Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceModelWithAllowedPropertySet : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ResourceModelWithAllowedPropertySet(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ResourceModelWithAllowedPropertySetSku Sku { get { throw null; } set { } }
    }
    public partial class ResourceModelWithAllowedPropertySetSku : Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku
    {
        public ResourceModelWithAllowedPropertySetSku(string name) : base (default(string)) { }
    }
    public partial class ScalingHostPoolReference
    {
        public ScalingHostPoolReference() { }
        public string HostPoolArmPath { get { throw null; } set { } }
        public bool? ScalingPlanEnabled { get { throw null; } set { } }
    }
    public partial class ScalingSchedule
    {
        public ScalingSchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem> DaysOfWeek { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? OffPeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public System.DateTimeOffset? OffPeakStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? PeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public System.DateTimeOffset? PeakStartTime { get { throw null; } set { } }
        public int? RampDownCapacityThresholdPct { get { throw null; } set { } }
        public bool? RampDownForceLogoffUsers { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? RampDownLoadBalancingAlgorithm { get { throw null; } set { } }
        public int? RampDownMinimumHostsPct { get { throw null; } set { } }
        public string RampDownNotificationMessage { get { throw null; } set { } }
        public System.DateTimeOffset? RampDownStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen? RampDownStopHostsWhen { get { throw null; } set { } }
        public int? RampDownWaitTimeMinutes { get { throw null; } set { } }
        public int? RampUpCapacityThresholdPct { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? RampUpLoadBalancingAlgorithm { get { throw null; } set { } }
        public int? RampUpMinimumHostsPct { get { throw null; } set { } }
        public System.DateTimeOffset? RampUpStartTime { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScalingScheduleDaysOfWeekItem : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScalingScheduleDaysOfWeekItem(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Friday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Monday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Saturday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Sunday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Thursday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Tuesday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem left, Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem left, Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SendMessage
    {
        public SendMessage() { }
        public string MessageBody { get { throw null; } set { } }
        public string MessageTitle { get { throw null; } set { } }
    }
    public partial class SessionHostHealthCheckFailureDetails
    {
        internal SessionHostHealthCheckFailureDetails() { }
        public int? ErrorCode { get { throw null; } }
        public System.DateTimeOffset? LastHealthCheckDateTime { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class SessionHostHealthCheckReport
    {
        internal SessionHostHealthCheckReport() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails AdditionalFailureDetails { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckName? HealthCheckName { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HealthCheckResult? HealthCheckResult { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostLoadBalancingAlgorithm : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostLoadBalancingAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm BreadthFirst { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm DepthFirst { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostStatus : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostStatus(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Available { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus DomainTrustRelationshipLost { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus FSLogixNotHealthy { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus NeedsAssistance { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus NoHeartbeat { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus NotJoinedToDomain { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Shutdown { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus SxSStackListenerNotReady { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Unavailable { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionState : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionState(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionState Active { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionState LogOff { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionState Pending { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionState Unknown { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionState UserProfileDiskMounted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionState left, Azure.ResourceManager.DesktopVirtualization.Models.SessionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionState left, Azure.ResourceManager.DesktopVirtualization.Models.SessionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsoSecretType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsoSecretType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType Certificate { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType CertificateInKeyVault { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType SharedKey { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType SharedKeyInKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType left, Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType left, Azure.ResourceManager.DesktopVirtualization.Models.SsoSecretType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StartMenuItem : Azure.ResourceManager.Models.ResourceData
    {
        public StartMenuItem() { }
        public string AppAlias { get { throw null; } set { } }
        public string CommandLineArguments { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public int? IconIndex { get { throw null; } set { } }
        public string IconPath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StopHostsWhen : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StopHostsWhen(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen ZeroActiveSessions { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen ZeroSessions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen left, Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen left, Azure.ResourceManager.DesktopVirtualization.Models.StopHostsWhen right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateState : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.UpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateState(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UpdateState Failed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UpdateState Initial { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UpdateState Pending { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UpdateState Started { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UpdateState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.UpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.UpdateState left, Azure.ResourceManager.DesktopVirtualization.Models.UpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.UpdateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.UpdateState left, Azure.ResourceManager.DesktopVirtualization.Models.UpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
