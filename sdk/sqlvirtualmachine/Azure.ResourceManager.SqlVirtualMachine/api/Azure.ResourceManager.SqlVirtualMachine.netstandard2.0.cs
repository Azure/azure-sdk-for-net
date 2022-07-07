namespace Azure.ResourceManager.SqlVirtualMachine
{
    public partial class AvailabilityGroupListenerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>, System.Collections.IEnumerable
    {
        protected AvailabilityGroupListenerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string availabilityGroupListenerName, Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string availabilityGroupListenerName, Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> Get(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> GetAsync(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvailabilityGroupListenerData : Azure.ResourceManager.Models.ResourceData
    {
        public AvailabilityGroupListenerData() { }
        public string AvailabilityGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SqlVirtualMachine.Models.AgReplica> AvailabilityGroupReplicas { get { throw null; } }
        public bool? CreateDefaultAvailabilityGroupIfNotExist { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SqlVirtualMachine.Models.LoadBalancerConfiguration> LoadBalancerConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration> MultiSubnetIPConfigurations { get { throw null; } }
        public int? Port { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class AvailabilityGroupListenerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvailabilityGroupListenerResource() { }
        public virtual Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVirtualMachineGroupName, string availabilityGroupListenerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected SqlVirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlVirtualMachineName, Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlVirtualMachineName, Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlVirtualMachineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlVirtualMachineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> Get(string sqlVirtualMachineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>> GetAsync(string sqlVirtualMachineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlVirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SqlVirtualMachineData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AssessmentSettings AssessmentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupSettings AutoBackupSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AutoPatchingSettings AutoPatchingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.KeyVaultCredentialSettings KeyVaultCredentialSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.ServerConfigurationsManagementSettings ServerConfigurationsManagementSettings { get { throw null; } set { } }
        public string SqlImageOffer { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku? SqlImageSku { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode? SqlManagement { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public string SqlVirtualMachineGroupResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.StorageConfigurationSettings StorageConfigurationSettings { get { throw null; } set { } }
        public string VirtualMachineResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.WsfcDomainCredentials WsfcDomainCredentials { get { throw null; } set { } }
        public string WsfcStaticIP { get { throw null; } set { } }
    }
    public static partial class SqlVirtualMachineExtensions
    {
        public static Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource GetAvailabilityGroupListenerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> GetSqlVirtualMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVirtualMachineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>> GetSqlVirtualMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVirtualMachineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> GetSqlVirtualMachineGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVirtualMachineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>> GetSqlVirtualMachineGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVirtualMachineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource GetSqlVirtualMachineGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupCollection GetSqlVirtualMachineGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> GetSqlVirtualMachineGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> GetSqlVirtualMachineGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource GetSqlVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineCollection GetSqlVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> GetSqlVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> GetSqlVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlVirtualMachineGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>, System.Collections.IEnumerable
    {
        protected SqlVirtualMachineGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlVirtualMachineGroupName, Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlVirtualMachineGroupName, Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlVirtualMachineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlVirtualMachineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> Get(string sqlVirtualMachineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>> GetAsync(string sqlVirtualMachineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlVirtualMachineGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SqlVirtualMachineGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.ClusterConfiguration? ClusterConfiguration { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.ClusterManagerType? ClusterManagerType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.ScaleType? ScaleType { get { throw null; } }
        public string SqlImageOffer { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku? SqlImageSku { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.WsfcDomainProfile WsfcDomainProfile { get { throw null; } set { } }
    }
    public partial class SqlVirtualMachineGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlVirtualMachineGroupResource() { }
        public virtual Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVirtualMachineGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> GetAvailabilityGroupListener(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> GetAvailabilityGroupListenerAsync(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerCollection GetAvailabilityGroupListeners() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> GetSqlVirtualMachinesBySqlVmGroup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> GetSqlVirtualMachinesBySqlVmGroupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVirtualMachineGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVirtualMachineGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlVirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlVirtualMachineResource() { }
        public virtual Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVirtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartAssessment(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAssessmentAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SqlVirtualMachine.Models
{
    public partial class AgReplica
    {
        public AgReplica() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.Commit? Commit { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.Failover? Failover { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary? ReadableSecondary { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.Role? Role { get { throw null; } set { } }
        public string SqlVirtualMachineInstanceId { get { throw null; } set { } }
    }
    public enum AssessmentDayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public partial class AssessmentSettings
    {
        public AssessmentSettings() { }
        public bool? Enable { get { throw null; } set { } }
        public bool? RunImmediately { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.Schedule Schedule { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoBackupDaysOfWeek : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoBackupDaysOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek left, Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek left, Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutoBackupSettings
    {
        public AutoBackupSettings() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType? BackupScheduleType { get { throw null; } set { } }
        public bool? BackupSystemDbs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SqlVirtualMachine.Models.AutoBackupDaysOfWeek> DaysOfWeek { get { throw null; } }
        public bool? Enable { get { throw null; } set { } }
        public bool? EnableEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType? FullBackupFrequency { get { throw null; } set { } }
        public int? FullBackupStartTime { get { throw null; } set { } }
        public int? FullBackupWindowHours { get { throw null; } set { } }
        public int? LogBackupFrequency { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public int? RetentionPeriod { get { throw null; } set { } }
        public string StorageAccessKey { get { throw null; } set { } }
        public System.Uri StorageAccountUri { get { throw null; } set { } }
        public string StorageContainerName { get { throw null; } set { } }
    }
    public partial class AutoPatchingSettings
    {
        public AutoPatchingSettings() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.DayOfWeek? DayOfWeek { get { throw null; } set { } }
        public bool? Enable { get { throw null; } set { } }
        public int? MaintenanceWindowDuration { get { throw null; } set { } }
        public int? MaintenanceWindowStartingHour { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupScheduleType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupScheduleType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType Automated { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType left, Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType left, Azure.ResourceManager.SqlVirtualMachine.Models.BackupScheduleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterConfiguration : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.ClusterConfiguration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterConfiguration(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ClusterConfiguration Domainful { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.ClusterConfiguration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.ClusterConfiguration left, Azure.ResourceManager.SqlVirtualMachine.Models.ClusterConfiguration right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.ClusterConfiguration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.ClusterConfiguration left, Azure.ResourceManager.SqlVirtualMachine.Models.ClusterConfiguration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterManagerType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.ClusterManagerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterManagerType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ClusterManagerType Wsfc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.ClusterManagerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.ClusterManagerType left, Azure.ResourceManager.SqlVirtualMachine.Models.ClusterManagerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.ClusterManagerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.ClusterManagerType left, Azure.ResourceManager.SqlVirtualMachine.Models.ClusterManagerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterSubnetType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterSubnetType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType MultiSubnet { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType SingleSubnet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType left, Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType left, Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Commit : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.Commit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Commit(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.Commit AsynchronousCommit { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.Commit SynchronousCommit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.Commit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.Commit left, Azure.ResourceManager.SqlVirtualMachine.Models.Commit right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.Commit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.Commit left, Azure.ResourceManager.SqlVirtualMachine.Models.Commit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectivityType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectivityType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType Local { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType Private { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType left, Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType left, Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DayOfWeek
    {
        Everyday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskConfigurationType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType ADD { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType Extend { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType NEW { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType left, Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType left, Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Failover : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.Failover>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Failover(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.Failover Automatic { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.Failover Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.Failover other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.Failover left, Azure.ResourceManager.SqlVirtualMachine.Models.Failover right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.Failover (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.Failover left, Azure.ResourceManager.SqlVirtualMachine.Models.Failover right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FullBackupFrequencyType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FullBackupFrequencyType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType Daily { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType left, Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType left, Azure.ResourceManager.SqlVirtualMachine.Models.FullBackupFrequencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultCredentialSettings
    {
        public KeyVaultCredentialSettings() { }
        public System.Uri AzureKeyVaultUri { get { throw null; } set { } }
        public string CredentialName { get { throw null; } set { } }
        public bool? Enable { get { throw null; } set { } }
        public string ServicePrincipalName { get { throw null; } set { } }
        public string ServicePrincipalSecret { get { throw null; } set { } }
    }
    public partial class LoadBalancerConfiguration
    {
        public LoadBalancerConfiguration() { }
        public string LoadBalancerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.PrivateIPAddress PrivateIPAddress { get { throw null; } set { } }
        public int? ProbePort { get { throw null; } set { } }
        public string PublicIPAddressResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SqlVirtualMachineInstances { get { throw null; } }
    }
    public partial class MultiSubnetIPConfiguration
    {
        public MultiSubnetIPConfiguration(Azure.ResourceManager.SqlVirtualMachine.Models.PrivateIPAddress privateIPAddress, string sqlVirtualMachineInstance) { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.PrivateIPAddress PrivateIPAddress { get { throw null; } set { } }
        public string SqlVirtualMachineInstance { get { throw null; } set { } }
    }
    public partial class PrivateIPAddress
    {
        public PrivateIPAddress() { }
        public string IPAddress { get { throw null; } set { } }
        public string SubnetResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReadableSecondary : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReadableSecondary(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary ALL { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary NO { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary ReadOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary left, Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary left, Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondary right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Role : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.Role>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Role(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.Role Primary { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.Role Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.Role other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.Role left, Azure.ResourceManager.SqlVirtualMachine.Models.Role right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.Role (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.Role left, Azure.ResourceManager.SqlVirtualMachine.Models.Role right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.ScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ScaleType HA { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.ScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.ScaleType left, Azure.ResourceManager.SqlVirtualMachine.Models.ScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.ScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.ScaleType left, Azure.ResourceManager.SqlVirtualMachine.Models.ScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Schedule
    {
        public Schedule() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AssessmentDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public bool? Enable { get { throw null; } set { } }
        public int? MonthlyOccurrence { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public int? WeeklyInterval { get { throw null; } set { } }
    }
    public partial class ServerConfigurationsManagementSettings
    {
        public ServerConfigurationsManagementSettings() { }
        public bool? IsRServicesEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings SqlConnectivityUpdateSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SQLInstanceSettings SqlInstanceSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings SqlStorageUpdateSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType? SqlWorkloadType { get { throw null; } set { } }
    }
    public partial class SqlConnectivityUpdateSettings
    {
        public SqlConnectivityUpdateSettings() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.ConnectivityType? ConnectivityType { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string SqlAuthUpdatePassword { get { throw null; } set { } }
        public string SqlAuthUpdateUserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlImageSku : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlImageSku(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Developer { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Enterprise { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Express { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Standard { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SQLInstanceSettings
    {
        public SQLInstanceSettings() { }
        public string Collation { get { throw null; } set { } }
        public bool? IsIfiEnabled { get { throw null; } set { } }
        public bool? IsLpimEnabled { get { throw null; } set { } }
        public bool? IsOptimizeForAdHocWorkloadsEnabled { get { throw null; } set { } }
        public int? MaxDop { get { throw null; } set { } }
        public int? MaxServerMemoryMB { get { throw null; } set { } }
        public int? MinServerMemoryMB { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlManagementMode : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlManagementMode(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode Full { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode LightWeight { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode NoAgent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerLicenseType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType Ahub { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType DR { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SQLStorageSettings
    {
        public SQLStorageSettings() { }
        public string DefaultFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Luns { get { throw null; } }
    }
    public partial class SqlStorageUpdateSettings
    {
        public SqlStorageUpdateSettings() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType? DiskConfigurationType { get { throw null; } set { } }
        public int? DiskCount { get { throw null; } set { } }
        public int? StartingDeviceId { get { throw null; } set { } }
    }
    public partial class SQLTempDbSettings
    {
        public SQLTempDbSettings() { }
        public int? DataFileCount { get { throw null; } set { } }
        public int? DataFileSize { get { throw null; } set { } }
        public int? DataGrowth { get { throw null; } set { } }
        public string DefaultFilePath { get { throw null; } set { } }
        public int? LogFileSize { get { throw null; } set { } }
        public int? LogGrowth { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Luns { get { throw null; } }
        public bool? PersistFolder { get { throw null; } set { } }
        public string PersistFolderPath { get { throw null; } set { } }
    }
    public partial class SqlVirtualMachineGroupPatch
    {
        public SqlVirtualMachineGroupPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SqlVirtualMachinePatch
    {
        public SqlVirtualMachinePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmGroupImageSku : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmGroupImageSku(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku Developer { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku Enterprise { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlWorkloadType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlWorkloadType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType DW { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType General { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType Oltp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageConfigurationSettings
    {
        public StorageConfigurationSettings() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.DiskConfigurationType? DiskConfigurationType { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SQLStorageSettings SqlDataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SQLStorageSettings SqlLogSettings { get { throw null; } set { } }
        public bool? SqlSystemDbOnDataDisk { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SQLTempDbSettings SqlTempDbSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType? StorageWorkloadType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageWorkloadType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageWorkloadType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType DW { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType General { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType Oltp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.StorageWorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WsfcDomainCredentials
    {
        public WsfcDomainCredentials() { }
        public string ClusterBootstrapAccountPassword { get { throw null; } set { } }
        public string ClusterOperatorAccountPassword { get { throw null; } set { } }
        public string SqlServiceAccountPassword { get { throw null; } set { } }
    }
    public partial class WsfcDomainProfile
    {
        public WsfcDomainProfile() { }
        public string ClusterBootstrapAccount { get { throw null; } set { } }
        public string ClusterOperatorAccount { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.ClusterSubnetType? ClusterSubnetType { get { throw null; } set { } }
        public string DomainFqdn { get { throw null; } set { } }
        public string FileShareWitnessPath { get { throw null; } set { } }
        public string OuPath { get { throw null; } set { } }
        public string SqlServiceAccount { get { throw null; } set { } }
        public string StorageAccountPrimaryKey { get { throw null; } set { } }
        public System.Uri StorageAccountUri { get { throw null; } set { } }
    }
}
