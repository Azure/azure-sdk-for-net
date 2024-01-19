namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public partial class MigrationRecoveryPointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>, System.Collections.IEnumerable
    {
        protected MigrationRecoveryPointCollection() { }
        public virtual Azure.Response<bool> Exists(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> Get(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>> GetAsync(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> GetIfExists(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>> GetIfExistsAsync(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationRecoveryPointData : Azure.ResourceManager.Models.ResourceData
    {
        internal MigrationRecoveryPointData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointProperties Properties { get { throw null; } }
    }
    public partial class MigrationRecoveryPointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationRecoveryPointResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string migrationItemName, string migrationRecoveryPointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectionContainerMappingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>, System.Collections.IEnumerable
    {
        protected ProtectionContainerMappingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mappingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mappingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> Get(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>> GetAsync(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetIfExists(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>> GetIfExistsAsync(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProtectionContainerMappingData : Azure.ResourceManager.Models.ResourceData
    {
        internal ProtectionContainerMappingData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProperties Properties { get { throw null; } }
    }
    public partial class ProtectionContainerMappingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectionContainerMappingResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string mappingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RemoveProtectionContainerMappingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RemoveProtectionContainerMappingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RecoveryServicesSiteRecoveryExtensions
    {
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource GetMigrationRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource GetProtectionContainerMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMappings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMappingsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationAppliance> GetReplicationAppliances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationAppliance> GetReplicationAppliancesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> GetReplicationEligibilityResult(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>> GetReplicationEligibilityResultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource GetReplicationEligibilityResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultCollection GetReplicationEligibilityResults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource GetReplicationProtectedItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetReplicationProtectedItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetReplicationProtectedItemsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> GetReplicationProtectionIntent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>> GetReplicationProtectionIntentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource GetReplicationProtectionIntentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentCollection GetReplicationProtectionIntents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails> GetReplicationVaultHealth(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails>> GetReplicationVaultHealthAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> GetSiteRecoveryAlert(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>> GetSiteRecoveryAlertAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource GetSiteRecoveryAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertCollection GetSiteRecoveryAlerts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource> GetSiteRecoveryEvent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource>> GetSiteRecoveryEventAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource GetSiteRecoveryEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventCollection GetSiteRecoveryEvents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> GetSiteRecoveryFabric(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> GetSiteRecoveryFabricAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource GetSiteRecoveryFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricCollection GetSiteRecoveryFabrics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> GetSiteRecoveryJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>> GetSiteRecoveryJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource GetSiteRecoveryJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobCollection GetSiteRecoveryJobs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource GetSiteRecoveryLogicalNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource GetSiteRecoveryMigrationItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> GetSiteRecoveryMigrationItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> GetSiteRecoveryMigrationItemsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource GetSiteRecoveryNetworkMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> GetSiteRecoveryNetworkMappings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> GetSiteRecoveryNetworkMappingsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource GetSiteRecoveryNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> GetSiteRecoveryNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> GetSiteRecoveryNetworksAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource GetSiteRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyCollection GetSiteRecoveryPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> GetSiteRecoveryPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>> GetSiteRecoveryPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource GetSiteRecoveryPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource GetSiteRecoveryProtectableItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource GetSiteRecoveryProtectionContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> GetSiteRecoveryProtectionContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> GetSiteRecoveryProtectionContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> GetSiteRecoveryRecoveryPlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> GetSiteRecoveryRecoveryPlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource GetSiteRecoveryRecoveryPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanCollection GetSiteRecoveryRecoveryPlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource GetSiteRecoveryServicesProviderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> GetSiteRecoveryServicesProviders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> GetSiteRecoveryServicesProvidersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> GetSiteRecoveryVaultSetting(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>> GetSiteRecoveryVaultSettingAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource GetSiteRecoveryVaultSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingCollection GetSiteRecoveryVaultSettings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource GetSiteRecoveryVCenterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> GetSiteRecoveryVCenters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> GetSiteRecoveryVCentersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource GetStorageClassificationMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetStorageClassificationMappings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetStorageClassificationMappingsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource GetStorageClassificationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassifications(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassificationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOperatingSystems> GetSupportedOperatingSystem(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string instanceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOperatingSystems>> GetSupportedOperatingSystemAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string instanceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails> RefreshReplicationVaultHealth(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails>> RefreshReplicationVaultHealthAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationEligibilityResultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>, System.Collections.IEnumerable
    {
        protected ReplicationEligibilityResultCollection() { }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> GetIfExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>> GetIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicationEligibilityResultData : Azure.ResourceManager.Models.ResourceData
    {
        internal ReplicationEligibilityResultData() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationEligibilityResultProperties Properties { get { throw null; } }
    }
    public partial class ReplicationEligibilityResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicationEligibilityResultResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationProtectedItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>, System.Collections.IEnumerable
    {
        protected ReplicationProtectedItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicatedProtectedItemName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicatedProtectedItemName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> Get(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> GetAsync(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetIfExists(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> GetIfExistsAsync(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicationProtectedItemData : Azure.ResourceManager.Models.ResourceData
    {
        internal ReplicationProtectedItemData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemProperties Properties { get { throw null; } }
    }
    public partial class ReplicationProtectedItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicationProtectedItemResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> AddDisks(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAddDisksContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> AddDisksAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAddDisksContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> ApplyRecoveryPoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> ApplyRecoveryPointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string replicatedProtectedItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> FailoverCancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> FailoverCancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> FailoverCommit(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> FailoverCommitAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource> GetSiteRecoveryPoint(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource>> GetSiteRecoveryPointAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointCollection GetSiteRecoveryPoints() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TargetComputeSize> GetTargetComputeSizesByReplicationProtectedItems(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TargetComputeSize> GetTargetComputeSizesByReplicationProtectedItemsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> PlannedFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> PlannedFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> RemoveDisks(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RemoveDisksContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> RemoveDisksAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RemoveDisksContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> RepairReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> RepairReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> Reprotect(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> ReprotectAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> ResolveHealthErrors(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResolveHealthContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> ResolveHealthErrorsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResolveHealthContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> SwitchProvider(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProviderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> SwitchProviderAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProviderContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> TestFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> TestFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> TestFailoverCleanup(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> TestFailoverCleanupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> UnplannedFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> UnplannedFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> UpdateAppliance(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> UpdateApplianceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> UpdateMobilityService(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateMobilityServiceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> UpdateMobilityServiceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateMobilityServiceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationProtectionIntentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>, System.Collections.IEnumerable
    {
        protected ReplicationProtectionIntentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string intentObjectName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string intentObjectName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> Get(string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> GetAll(string skipToken = null, string takeToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> GetAllAsync(string skipToken = null, string takeToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>> GetAsync(string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> GetIfExists(string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>> GetIfExistsAsync(string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicationProtectionIntentData : Azure.ResourceManager.Models.ResourceData
    {
        internal ReplicationProtectionIntentData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentProperties Properties { get { throw null; } }
    }
    public partial class ReplicationProtectionIntentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicationProtectionIntentResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string intentObjectName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryAlertCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertSettingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAlertCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertSettingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAlertCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> Get(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>> GetAsync(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> GetIfExists(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>> GetIfExistsAsync(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryAlertData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryAlertData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAlertProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryAlertResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string alertSettingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAlertCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAlertCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryEventCollection() { }
        public virtual Azure.Response<bool> Exists(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource> Get(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource>> GetAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource> GetIfExists(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource>> GetIfExistsAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryEventData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryEventData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryEventResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryEventResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string eventName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryFabricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryFabricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fabricName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryFabricCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fabricName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryFabricCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> Get(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> GetAsync(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> GetIfExists(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> GetIfExistsAsync(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryFabricData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryFabricData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryFabricProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryFabricResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryFabricResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> CheckConsistency(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> CheckConsistencyAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> Get(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> GetAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource> GetSiteRecoveryLogicalNetwork(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource>> GetSiteRecoveryLogicalNetworkAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkCollection GetSiteRecoveryLogicalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> GetSiteRecoveryNetwork(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource>> GetSiteRecoveryNetworkAsync(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkCollection GetSiteRecoveryNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> GetSiteRecoveryProtectionContainer(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>> GetSiteRecoveryProtectionContainerAsync(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerCollection GetSiteRecoveryProtectionContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> GetSiteRecoveryServicesProvider(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>> GetSiteRecoveryServicesProviderAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderCollection GetSiteRecoveryServicesProviders() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> GetSiteRecoveryVCenter(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>> GetSiteRecoveryVCenterAsync(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterCollection GetSiteRecoveryVCenters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassification(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>> GetStorageClassificationAsync(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationCollection GetStorageClassifications() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MigrateToAad(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MigrateToAadAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> ReassociateGateway(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverProcessServerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> ReassociateGatewayAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverProcessServerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> RenewCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RenewCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> RenewCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RenewCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryFabricCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryFabricCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryJobCollection() { }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> GetIfExists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>> GetIfExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryJobData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryJobData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryJobResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> Export(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>> ExportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> Resume(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationResumeJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>> ResumeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationResumeJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryLogicalNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryLogicalNetworkCollection() { }
        public virtual Azure.Response<bool> Exists(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource> Get(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource>> GetAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource> GetIfExists(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource>> GetIfExistsAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryLogicalNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryLogicalNetworkData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLogicalNetworkProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryLogicalNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryLogicalNetworkResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string logicalNetworkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryMigrationItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryMigrationItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string migrationItemName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationItemCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string migrationItemName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationItemCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> Get(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> GetAll(string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> GetAllAsync(string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> GetAsync(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> GetIfExists(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> GetIfExistsAsync(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryMigrationItemData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryMigrationItemData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationItemProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryMigrationItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryMigrationItemResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string migrationItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string deleteOption = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string deleteOption = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> GetMigrationRecoveryPoint(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>> GetMigrationRecoveryPointAsync(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointCollection GetMigrationRecoveryPoints() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> Migrate(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> MigrateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> PauseReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PauseReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> PauseReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PauseReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> ResumeReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> ResumeReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> Resync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemResyncContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> ResyncAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemResyncContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> TestMigrate(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> TestMigrateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> TestMigrateCleanup(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> TestMigrateCleanupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationItemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationItemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryNetworkCollection() { }
        public virtual Azure.Response<bool> Exists(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> Get(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource>> GetAsync(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> GetIfExists(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource>> GetIfExistsAsync(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryNetworkData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryNetworkMappingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryNetworkMappingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkMappingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkMappingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> Get(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>> GetAsync(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> GetIfExists(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>> GetIfExistsAsync(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryNetworkMappingData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryNetworkMappingData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkMappingProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryNetworkMappingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryNetworkMappingResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string networkName, string networkMappingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkMappingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkMappingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryNetworkResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string networkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> GetSiteRecoveryNetworkMapping(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource>> GetSiteRecoveryNetworkMappingAsync(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingCollection GetSiteRecoveryNetworkMappings() { throw null; }
    }
    public partial class SiteRecoveryPointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryPointCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource> Get(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource>> GetAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource> GetIfExists(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource>> GetIfExistsAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryPointData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryPointData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryPointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryPointResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string replicatedProtectedItemName, string recoveryPointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> GetIfExists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>> GetIfExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryPolicyData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPolicyProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryPolicyResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryProtectableItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryProtectableItemCollection() { }
        public virtual Azure.Response<bool> Exists(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource> Get(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource> GetAll(string filter = null, string take = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource> GetAllAsync(string filter = null, string take = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource>> GetAsync(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource> GetIfExists(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource>> GetIfExistsAsync(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryProtectableItemData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryProtectableItemData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectableItemProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryProtectableItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryProtectableItemResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string protectableItemName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryProtectionContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryProtectionContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectionContainerName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectionContainerName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> Get(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>> GetAsync(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> GetIfExists(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>> GetIfExistsAsync(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryProtectionContainerData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryProtectionContainerData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionContainerProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryProtectionContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryProtectionContainerResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> DiscoverProtectableItem(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiscoverProtectableItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>> DiscoverProtectableItemAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiscoverProtectableItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMapping(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>> GetProtectionContainerMappingAsync(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingCollection GetProtectionContainerMappings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetReplicationProtectedItem(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> GetReplicationProtectedItemAsync(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemCollection GetReplicationProtectedItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> GetSiteRecoveryMigrationItem(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource>> GetSiteRecoveryMigrationItemAsync(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemCollection GetSiteRecoveryMigrationItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource> GetSiteRecoveryProtectableItem(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource>> GetSiteRecoveryProtectableItemAsync(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemCollection GetSiteRecoveryProtectableItems() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> SwitchProtection(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>> SwitchProtectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryRecoveryPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryRecoveryPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string recoveryPlanName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRecoveryPlanCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string recoveryPlanName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRecoveryPlanCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> Get(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> GetAsync(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> GetIfExists(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> GetIfExistsAsync(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryRecoveryPlanData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryRecoveryPlanData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRecoveryPlanProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryRecoveryPlanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryRecoveryPlanResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string recoveryPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> FailoverCancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> FailoverCancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> FailoverCommit(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> FailoverCommitAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> PlannedFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPlannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> PlannedFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPlannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> Reprotect(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> ReprotectAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> TestFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> TestFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> TestFailoverCleanup(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> TestFailoverCleanupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> UnplannedFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanUnplannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> UnplannedFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanUnplannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRecoveryPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRecoveryPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryServicesProviderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryServicesProviderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServicesProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServicesProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> Get(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>> GetAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> GetIfExists(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>> GetIfExistsAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryServicesProviderData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryServicesProviderData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServicesProviderProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryServicesProviderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryServicesProviderResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string providerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> RefreshProvider(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>> RefreshProviderAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServicesProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServicesProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryVaultSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryVaultSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultSettingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVaultSettingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultSettingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVaultSettingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> Get(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>> GetAsync(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> GetIfExists(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>> GetIfExistsAsync(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryVaultSettingData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryVaultSettingData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVaultSettingProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryVaultSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryVaultSettingResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string vaultSettingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVaultSettingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVaultSettingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteRecoveryVCenterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>, System.Collections.IEnumerable
    {
        protected SiteRecoveryVCenterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vCenterName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVCenterCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vCenterName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVCenterCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> Get(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>> GetAsync(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> GetIfExists(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>> GetIfExistsAsync(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteRecoveryVCenterData : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoveryVCenterData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVCenterProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryVCenterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteRecoveryVCenterResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string vCenterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageClassificationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>, System.Collections.IEnumerable
    {
        protected StorageClassificationCollection() { }
        public virtual Azure.Response<bool> Exists(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> Get(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>> GetAsync(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetIfExists(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>> GetIfExistsAsync(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageClassificationData : Azure.ResourceManager.Models.ResourceData
    {
        internal StorageClassificationData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string StorageClassificationFriendlyName { get { throw null; } }
    }
    public partial class StorageClassificationMappingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>, System.Collections.IEnumerable
    {
        protected StorageClassificationMappingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageClassificationMappingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageClassificationMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageClassificationMappingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageClassificationMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageClassificationMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageClassificationMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> Get(string storageClassificationMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>> GetAsync(string storageClassificationMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetIfExists(string storageClassificationMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>> GetIfExistsAsync(string storageClassificationMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageClassificationMappingData : Azure.ResourceManager.Models.ResourceData
    {
        internal StorageClassificationMappingData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetStorageClassificationId { get { throw null; } }
    }
    public partial class StorageClassificationMappingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageClassificationMappingResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string storageClassificationName, string storageClassificationMappingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageClassificationMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageClassificationMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageClassificationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageClassificationResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string storageClassificationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetStorageClassificationMapping(string storageClassificationMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>> GetStorageClassificationMappingAsync(string storageClassificationMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingCollection GetStorageClassificationMappings() { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Mocking
{
    public partial class MockableRecoveryServicesSiteRecoveryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesSiteRecoveryArmClient() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource GetMigrationRecoveryPointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource GetProtectionContainerMappingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource GetReplicationEligibilityResultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource GetReplicationProtectedItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource GetReplicationProtectionIntentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource GetSiteRecoveryAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource GetSiteRecoveryEventResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource GetSiteRecoveryFabricResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource GetSiteRecoveryJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkResource GetSiteRecoveryLogicalNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource GetSiteRecoveryMigrationItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource GetSiteRecoveryNetworkMappingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource GetSiteRecoveryNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointResource GetSiteRecoveryPointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource GetSiteRecoveryPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemResource GetSiteRecoveryProtectableItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource GetSiteRecoveryProtectionContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource GetSiteRecoveryRecoveryPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource GetSiteRecoveryServicesProviderResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource GetSiteRecoveryVaultSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource GetSiteRecoveryVCenterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource GetStorageClassificationMappingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource GetStorageClassificationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRecoveryServicesSiteRecoveryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesSiteRecoveryResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMappings(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMappingsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationAppliance> GetReplicationAppliances(string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationAppliance> GetReplicationAppliancesAsync(string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> GetReplicationEligibilityResult(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>> GetReplicationEligibilityResultAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultCollection GetReplicationEligibilityResults(string virtualMachineName) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetReplicationProtectedItems(string resourceName, string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetReplicationProtectedItemsAsync(string resourceName, string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource> GetReplicationProtectionIntent(string resourceName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentResource>> GetReplicationProtectionIntentAsync(string resourceName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentCollection GetReplicationProtectionIntents(string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails> GetReplicationVaultHealth(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails>> GetReplicationVaultHealthAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource> GetSiteRecoveryAlert(string resourceName, string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertResource>> GetSiteRecoveryAlertAsync(string resourceName, string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertCollection GetSiteRecoveryAlerts(string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource> GetSiteRecoveryEvent(string resourceName, string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventResource>> GetSiteRecoveryEventAsync(string resourceName, string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventCollection GetSiteRecoveryEvents(string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource> GetSiteRecoveryFabric(string resourceName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricResource>> GetSiteRecoveryFabricAsync(string resourceName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricCollection GetSiteRecoveryFabrics(string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource> GetSiteRecoveryJob(string resourceName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobResource>> GetSiteRecoveryJobAsync(string resourceName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobCollection GetSiteRecoveryJobs(string resourceName) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> GetSiteRecoveryMigrationItems(string resourceName, string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemResource> GetSiteRecoveryMigrationItemsAsync(string resourceName, string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> GetSiteRecoveryNetworkMappings(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingResource> GetSiteRecoveryNetworkMappingsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> GetSiteRecoveryNetworks(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkResource> GetSiteRecoveryNetworksAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyCollection GetSiteRecoveryPolicies(string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource> GetSiteRecoveryPolicy(string resourceName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyResource>> GetSiteRecoveryPolicyAsync(string resourceName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> GetSiteRecoveryProtectionContainers(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerResource> GetSiteRecoveryProtectionContainersAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource> GetSiteRecoveryRecoveryPlan(string resourceName, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanResource>> GetSiteRecoveryRecoveryPlanAsync(string resourceName, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanCollection GetSiteRecoveryRecoveryPlans(string resourceName) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> GetSiteRecoveryServicesProviders(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderResource> GetSiteRecoveryServicesProvidersAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource> GetSiteRecoveryVaultSetting(string resourceName, string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingResource>> GetSiteRecoveryVaultSettingAsync(string resourceName, string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingCollection GetSiteRecoveryVaultSettings(string resourceName) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> GetSiteRecoveryVCenters(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterResource> GetSiteRecoveryVCentersAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetStorageClassificationMappings(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetStorageClassificationMappingsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassifications(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassificationsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOperatingSystems> GetSupportedOperatingSystem(string resourceName, string instanceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOperatingSystems>> GetSupportedOperatingSystemAsync(string resourceName, string instanceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails> RefreshReplicationVaultHealth(Azure.WaitUntil waitUntil, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails>> RefreshReplicationVaultHealthAsync(Azure.WaitUntil waitUntil, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class A2AAddDisksContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAddDisksProviderSpecificContent
    {
        public A2AAddDisksContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmDiskDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmManagedDiskDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2AApplyRecoveryPointContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointProviderSpecificContent
    {
        public A2AApplyRecoveryPointContent() { }
    }
    public partial class A2AContainerCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerCreationContent
    {
        public A2AContainerCreationContent() { }
    }
    public partial class A2AContainerMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerMappingContent
    {
        public A2AContainerMappingContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AutomationAccountArmId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } set { } }
    }
    public partial class A2ACreateNetworkMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreateNetworkMappingContent
    {
        public A2ACreateNetworkMappingContent(Azure.Core.ResourceIdentifier primaryNetworkId) { }
        public Azure.Core.ResourceIdentifier PrimaryNetworkId { get { throw null; } }
    }
    public partial class A2ACreateProtectionIntentContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryCreateProtectionIntentProviderDetail
    {
        public A2ACreateProtectionIntentContent(Azure.Core.ResourceIdentifier fabricObjectId, Azure.Core.AzureLocation primaryLocation, Azure.Core.AzureLocation recoveryLocation, string recoverySubscriptionId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType recoveryAvailabilityType, Azure.Core.ResourceIdentifier recoveryResourceGroupId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AutomationAccountArmId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? AutoProtectionOfDataDisk { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } set { } }
        public string MultiVmGroupName { get { throw null; } set { } }
        public Azure.Core.AzureLocation PrimaryLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails PrimaryStagingStorageAccountCustomContent { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionProfileCustomDetails ProtectionProfileCustomContent { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryAvailabilitySetCustomDetails RecoveryAvailabilitySetCustomContent { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType RecoveryAvailabilityType { get { throw null; } }
        public string RecoveryAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails RecoveryBootDiagStorageAccount { get { throw null; } set { } }
        public Azure.Core.AzureLocation RecoveryLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryProximityPlacementGroupCustomDetails RecoveryProximityPlacementGroupCustomContent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryResourceGroupId { get { throw null; } }
        public string RecoverySubscriptionId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryVirtualNetworkCustomDetails RecoveryVirtualNetworkCustomContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentDiskDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentManagedDiskDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2ACrossClusterMigrationApplyRecoveryPointContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointProviderSpecificContent
    {
        public A2ACrossClusterMigrationApplyRecoveryPointContent() { }
    }
    public partial class A2ACrossClusterMigrationContainerCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerCreationContent
    {
        public A2ACrossClusterMigrationContainerCreationContent() { }
    }
    public partial class A2ACrossClusterMigrationEnableProtectionContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificContent
    {
        public A2ACrossClusterMigrationEnableProtectionContent() { }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryContainerId { get { throw null; } set { } }
    }
    public partial class A2ACrossClusterMigrationPolicyCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent
    {
        public A2ACrossClusterMigrationPolicyCreationContent() { }
    }
    public partial class A2ACrossClusterMigrationReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal A2ACrossClusterMigrationReplicationDetails() { }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string LifecycleId { get { throw null; } }
        public string OSType { get { throw null; } }
        public Azure.Core.AzureLocation? PrimaryFabricLocation { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class A2AEnableProtectionContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificContent
    {
        public A2AEnableProtectionContent(Azure.Core.ResourceIdentifier fabricObjectId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } set { } }
        public string MultiVmGroupName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryAvailabilitySetId { get { throw null; } set { } }
        public string RecoveryAvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryAzureNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryBootDiagStorageAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryCapacityReservationGroupId { get { throw null; } set { } }
        public string RecoveryCloudServiceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation RecoveryExtendedLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryResourceGroupId { get { throw null; } set { } }
        public string RecoverySubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryVirtualMachineScaleSetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmDiskDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmManagedDiskDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2AEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails
    {
        internal A2AEventDetails() { }
        public Azure.Core.AzureLocation? FabricLocation { get { throw null; } }
        public string FabricName { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public Azure.Core.AzureLocation? RemoteFabricLocation { get { throw null; } }
        public string RemoteFabricName { get { throw null; } }
    }
    public partial class A2AExtendedLocationDetails
    {
        internal A2AExtendedLocationDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation PrimaryExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation RecoveryExtendedLocation { get { throw null; } }
    }
    public partial class A2AFabricSpecificLocationDetails
    {
        internal A2AFabricSpecificLocationDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation InitialPrimaryExtendedLocation { get { throw null; } }
        public Azure.Core.AzureLocation? InitialPrimaryFabricLocation { get { throw null; } }
        public string InitialPrimaryZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation InitialRecoveryExtendedLocation { get { throw null; } }
        public Azure.Core.AzureLocation? InitialRecoveryFabricLocation { get { throw null; } }
        public string InitialRecoveryZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation PrimaryExtendedLocation { get { throw null; } }
        public Azure.Core.AzureLocation? PrimaryFabricLocation { get { throw null; } }
        public string PrimaryZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation RecoveryExtendedLocation { get { throw null; } }
        public Azure.Core.AzureLocation? RecoveryFabricLocation { get { throw null; } }
        public string RecoveryZone { get { throw null; } }
    }
    public partial class A2ANetworkMappingSettings : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingFabricSpecificSettings
    {
        internal A2ANetworkMappingSettings() { }
        public Azure.Core.AzureLocation? PrimaryFabricLocation { get { throw null; } }
        public Azure.Core.AzureLocation? RecoveryFabricLocation { get { throw null; } }
    }
    public partial class A2APolicyCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent
    {
        public A2APolicyCreationContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus multiVmSyncStatus) { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } set { } }
    }
    public partial class A2APolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal A2APolicyDetails() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } }
        public string MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } }
    }
    public partial class A2AProtectedDiskDetails
    {
        internal A2AProtectedDiskDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedDiskLevelOperation { get { throw null; } }
        public double? DataPendingAtSourceAgentInMB { get { throw null; } }
        public double? DataPendingInStagingStorageAccountInMB { get { throw null; } }
        public Azure.Core.ResourceIdentifier DekKeyVaultArmId { get { throw null; } }
        public long? DiskCapacityInBytes { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskState { get { throw null; } }
        public string DiskType { get { throw null; } }
        public System.Uri DiskUri { get { throw null; } }
        public string FailoverDiskName { get { throw null; } }
        public bool? IsDiskEncrypted { get { throw null; } }
        public bool? IsDiskKeyEncrypted { get { throw null; } }
        public bool? IsResyncRequired { get { throw null; } }
        public Azure.Core.ResourceIdentifier KekKeyVaultArmId { get { throw null; } }
        public string KeyIdentifier { get { throw null; } }
        public string MonitoringJobType { get { throw null; } }
        public int? MonitoringPercentageCompletion { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryDiskAzureStorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryStagingAzureStorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAzureStorageAccountId { get { throw null; } }
        public System.Uri RecoveryDiskUri { get { throw null; } }
        public string SecretIdentifier { get { throw null; } }
        public string TfoDiskName { get { throw null; } }
    }
    public partial class A2AProtectedManagedDiskDetails
    {
        internal A2AProtectedManagedDiskDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedDiskLevelOperation { get { throw null; } }
        public double? DataPendingAtSourceAgentInMB { get { throw null; } }
        public double? DataPendingInStagingStorageAccountInMB { get { throw null; } }
        public Azure.Core.ResourceIdentifier DekKeyVaultArmId { get { throw null; } }
        public long? DiskCapacityInBytes { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskState { get { throw null; } }
        public string DiskType { get { throw null; } }
        public string FailoverDiskName { get { throw null; } }
        public bool? IsDiskEncrypted { get { throw null; } }
        public bool? IsDiskKeyEncrypted { get { throw null; } }
        public bool? IsResyncRequired { get { throw null; } }
        public Azure.Core.ResourceIdentifier KekKeyVaultArmId { get { throw null; } }
        public string KeyIdentifier { get { throw null; } }
        public string MonitoringJobType { get { throw null; } }
        public int? MonitoringPercentageCompletion { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryDiskEncryptionSetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryStagingAzureStorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryDiskEncryptionSetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryOrignalTargetDiskId { get { throw null; } }
        public string RecoveryReplicaDiskAccountType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryReplicaDiskId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryResourceGroupId { get { throw null; } }
        public string RecoveryTargetDiskAccountType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryTargetDiskId { get { throw null; } }
        public string SecretIdentifier { get { throw null; } }
        public string TfoDiskName { get { throw null; } }
    }
    public partial class A2AProtectionContainerMappingDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProviderSpecificDetails
    {
        internal A2AProtectionContainerMappingDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier AutomationAccountArmId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } }
        public string JobScheduleName { get { throw null; } }
        public string ScheduleName { get { throw null; } }
    }
    public partial class A2AProtectionIntentDiskDetails
    {
        public A2AProtectionIntentDiskDetails(System.Uri diskUri) { }
        public System.Uri DiskUri { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails PrimaryStagingStorageAccountCustomContent { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails RecoveryAzureStorageAccountCustomContent { get { throw null; } set { } }
    }
    public partial class A2AProtectionIntentManagedDiskDetails
    {
        public A2AProtectionIntentManagedDiskDetails(string diskId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails PrimaryStagingStorageAccountCustomContent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryDiskEncryptionSetId { get { throw null; } set { } }
        public string RecoveryReplicaDiskAccountType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryResourceGroupCustomDetails RecoveryResourceGroupCustomContent { get { throw null; } set { } }
        public string RecoveryTargetDiskAccountType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct A2ARecoveryAvailabilityType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public A2ARecoveryAvailabilityType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType AvailabilitySet { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType AvailabilityZone { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class A2ARecoveryPointDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProviderSpecificRecoveryPointDetails
    {
        internal A2ARecoveryPointDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> Disks { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType? RecoveryPointSyncType { get { throw null; } }
    }
    public partial class A2ARemoveDisksContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RemoveDisksProviderSpecificContent
    {
        public A2ARemoveDisksContent() { }
        public System.Collections.Generic.IList<System.Uri> VmDisksUris { get { throw null; } }
        public System.Collections.Generic.IList<string> VmManagedDisksIds { get { throw null; } }
    }
    public partial class A2AReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal A2AReplicationDetails() { }
        public System.DateTimeOffset? AgentCertificateExpireOn { get { throw null; } }
        public System.DateTimeOffset? AgentExpireOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? AutoProtectionOfDataDisk { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected? ChurnOptionSelected { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation InitialPrimaryExtendedLocation { get { throw null; } }
        public Azure.Core.AzureLocation? InitialPrimaryFabricLocation { get { throw null; } }
        public string InitialPrimaryZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation InitialRecoveryExtendedLocation { get { throw null; } }
        public Azure.Core.AzureLocation? InitialRecoveryFabricLocation { get { throw null; } }
        public string InitialRecoveryZone { get { throw null; } }
        public bool? IsReplicationAgentCertificateUpdateRequired { get { throw null; } }
        public bool? IsReplicationAgentUpdateRequired { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeat { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public string LifecycleId { get { throw null; } }
        public string ManagementId { get { throw null; } }
        public string MonitoringJobType { get { throw null; } }
        public int? MonitoringPercentageCompletion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption? MultiVmGroupCreateOption { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public string OSType { get { throw null; } }
        public string PrimaryAvailabilityZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation PrimaryExtendedLocation { get { throw null; } }
        public Azure.Core.AzureLocation? PrimaryFabricLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedManagedDiskDetails> ProtectedManagedDisks { get { throw null; } }
        public string RecoveryAvailabilitySet { get { throw null; } }
        public string RecoveryAvailabilityZone { get { throw null; } }
        public string RecoveryAzureGeneration { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAzureResourceGroupId { get { throw null; } }
        public string RecoveryAzureVmName { get { throw null; } }
        public string RecoveryAzureVmSize { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryBootDiagStorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryCapacityReservationGroupId { get { throw null; } }
        public string RecoveryCloudService { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation RecoveryExtendedLocation { get { throw null; } }
        public Azure.Core.AzureLocation? RecoveryFabricLocation { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryFabricObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryProximityPlacementGroupId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryVirtualMachineScaleSetId { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public Azure.Core.ResourceIdentifier SelectedRecoveryAzureNetworkId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SelectedTfoAzureNetworkId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TestFailoverRecoveryFabricObjectId { get { throw null; } }
        public string TfoAzureVmName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AUnprotectedDiskDetails> UnprotectedDisks { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType? VmEncryptionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmSyncedConfigDetails VmSyncedConfigDetails { get { throw null; } }
    }
    public partial class A2AReplicationIntentDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentProviderSpecificSettings
    {
        internal A2AReplicationIntentDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier AutomationAccountArmId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? AutoProtectionOfDataDisk { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionInfo DiskEncryptionInfo { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public Azure.Core.AzureLocation? PrimaryLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails PrimaryStagingStorageAccount { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionProfileCustomDetails ProtectionProfile { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryAvailabilitySetCustomDetails RecoveryAvailabilitySet { get { throw null; } }
        public string RecoveryAvailabilityType { get { throw null; } }
        public string RecoveryAvailabilityZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails RecoveryBootDiagStorageAccount { get { throw null; } }
        public Azure.Core.AzureLocation? RecoveryLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryProximityPlacementGroupCustomDetails RecoveryProximityPlacementGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryResourceGroupId { get { throw null; } }
        public string RecoverySubscriptionId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryVirtualNetworkCustomDetails RecoveryVirtualNetwork { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentDiskDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentManagedDiskDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2AReprotectContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificContent
    {
        public A2AReprotectContent() { }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryAvailabilitySetId { get { throw null; } set { } }
        public string RecoveryCloudServiceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryContainerId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryResourceGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmDiskDetails> VmDisks { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct A2ARpRecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public A2ARpRecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType Latest { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType LatestApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType LatestCrashConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType LatestProcessed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class A2ASwitchProtectionContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionProviderSpecificContent
    {
        public A2ASwitchProtectionContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryAvailabilitySetId { get { throw null; } set { } }
        public string RecoveryAvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryBootDiagStorageAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryCapacityReservationGroupId { get { throw null; } set { } }
        public string RecoveryCloudServiceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryContainerId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryVirtualMachineScaleSetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmDiskDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmManagedDiskDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2ATestFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificContent
    {
        public A2ATestFailoverContent() { }
        public string CloudServiceCreationOption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
    }
    public partial class A2AUnplannedFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificContent
    {
        public A2AUnplannedFailoverContent() { }
        public string CloudServiceCreationOption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
    }
    public partial class A2AUnprotectedDiskDetails
    {
        internal A2AUnprotectedDiskDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? DiskAutoProtectionStatus { get { throw null; } }
        public int? DiskLunId { get { throw null; } }
    }
    public partial class A2AUpdateContainerMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificUpdateContainerMappingContent
    {
        public A2AUpdateContainerMappingContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AutomationAccountArmId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } set { } }
    }
    public partial class A2AUpdateNetworkMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificUpdateNetworkMappingContent
    {
        public A2AUpdateNetworkMappingContent() { }
        public Azure.Core.ResourceIdentifier PrimaryNetworkId { get { throw null; } set { } }
    }
    public partial class A2AUpdateReplicationProtectedItemContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderContent
    {
        public A2AUpdateReplicationProtectedItemContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmManagedDiskUpdateDetails> ManagedDiskUpdateDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryBootDiagStorageAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryCapacityReservationGroupId { get { throw null; } set { } }
        public string RecoveryCloudServiceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryVirtualMachineScaleSetId { get { throw null; } set { } }
        public string TfoAzureVmName { get { throw null; } set { } }
    }
    public partial class A2AVmDiskDetails
    {
        public A2AVmDiskDetails(System.Uri diskUri, Azure.Core.ResourceIdentifier recoveryAzureStorageAccountId, Azure.Core.ResourceIdentifier primaryStagingAzureStorageAccountId) { }
        public System.Uri DiskUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryStagingAzureStorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAzureStorageAccountId { get { throw null; } }
    }
    public partial class A2AVmManagedDiskDetails
    {
        public A2AVmManagedDiskDetails(string diskId, Azure.Core.ResourceIdentifier primaryStagingAzureStorageAccountId, Azure.Core.ResourceIdentifier recoveryResourceGroupId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryStagingAzureStorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryDiskEncryptionSetId { get { throw null; } set { } }
        public string RecoveryReplicaDiskAccountType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryResourceGroupId { get { throw null; } }
        public string RecoveryTargetDiskAccountType { get { throw null; } set { } }
    }
    public partial class A2AVmManagedDiskUpdateDetails
    {
        public A2AVmManagedDiskUpdateDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public string FailoverDiskName { get { throw null; } set { } }
        public string RecoveryReplicaDiskAccountType { get { throw null; } set { } }
        public string RecoveryTargetDiskAccountType { get { throw null; } set { } }
        public string TfoDiskName { get { throw null; } set { } }
    }
    public partial class A2AVmSyncedConfigDetails
    {
        internal A2AVmSyncedConfigDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEndpoint> VmEndpoints { get { throw null; } }
    }
    public partial class A2AZoneDetails
    {
        internal A2AZoneDetails() { }
        public string Source { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentUpgradeBlockedReason : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentUpgradeBlockedReason(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason AgentNoHeartbeat { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason AlreadyOnLatestVersion { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason DistroIsNotReported { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason DistroNotSupportedForUpgrade { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason IncompatibleApplianceVersion { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason InvalidAgentVersion { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason InvalidDriverVersion { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason MissingUpgradePath { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason NotProtected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason ProcessServerNoHeartbeat { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason RcmProxyNoHeartbeat { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason RebootRequired { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason Unknown { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason UnsupportedProtectionScenario { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlternateLocationRecoveryOption : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlternateLocationRecoveryOption(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption CreateVmIfNotFound { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption NoAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplianceMonitoringDetails
    {
        internal ApplianceMonitoringDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails CpuDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataStoreUtilizationDetails> DatastoreSnapshot { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails DisksReplicationDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails EsxiNfcBuffer { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails NetworkBandwidth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails RamDetails { get { throw null; } }
    }
    public partial class ApplianceResourceDetails
    {
        internal ApplianceResourceDetails() { }
        public long? Capacity { get { throw null; } }
        public double? ProcessUtilization { get { throw null; } }
        public string Status { get { throw null; } }
        public double? TotalUtilization { get { throw null; } }
    }
    public static partial class ArmRecoveryServicesSiteRecoveryModelFactory
    {
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ACrossClusterMigrationReplicationDetails A2ACrossClusterMigrationReplicationDetails(Azure.Core.ResourceIdentifier fabricObjectId = null, Azure.Core.AzureLocation? primaryFabricLocation = default(Azure.Core.AzureLocation?), string osType = null, string vmProtectionState = null, string vmProtectionStateDescription = null, string lifecycleId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AEventDetails A2AEventDetails(string protectedItemName = null, Azure.Core.ResourceIdentifier fabricObjectId = null, string fabricName = null, Azure.Core.AzureLocation? fabricLocation = default(Azure.Core.AzureLocation?), string remoteFabricName = null, Azure.Core.AzureLocation? remoteFabricLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AExtendedLocationDetails A2AExtendedLocationDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation primaryExtendedLocation = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation recoveryExtendedLocation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AFabricSpecificLocationDetails A2AFabricSpecificLocationDetails(string initialPrimaryZone = null, string initialRecoveryZone = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation initialPrimaryExtendedLocation = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation initialRecoveryExtendedLocation = null, Azure.Core.AzureLocation? initialPrimaryFabricLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? initialRecoveryFabricLocation = default(Azure.Core.AzureLocation?), string primaryZone = null, string recoveryZone = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation primaryExtendedLocation = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation recoveryExtendedLocation = null, Azure.Core.AzureLocation? primaryFabricLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? recoveryFabricLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ANetworkMappingSettings A2ANetworkMappingSettings(Azure.Core.AzureLocation? primaryFabricLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? recoveryFabricLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2APolicyDetails A2APolicyDetails(int? recoveryPointThresholdInMinutes = default(int?), int? recoveryPointHistory = default(int?), int? appConsistentFrequencyInMinutes = default(int?), string multiVmSyncStatus = null, int? crashConsistentFrequencyInMinutes = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedDiskDetails A2AProtectedDiskDetails(System.Uri diskUri = null, Azure.Core.ResourceIdentifier recoveryAzureStorageAccountId = null, Azure.Core.ResourceIdentifier primaryDiskAzureStorageAccountId = null, System.Uri recoveryDiskUri = null, string diskName = null, long? diskCapacityInBytes = default(long?), Azure.Core.ResourceIdentifier primaryStagingAzureStorageAccountId = null, string diskType = null, bool? isResyncRequired = default(bool?), int? monitoringPercentageCompletion = default(int?), string monitoringJobType = null, double? dataPendingInStagingStorageAccountInMB = default(double?), double? dataPendingAtSourceAgentInMB = default(double?), string diskState = null, System.Collections.Generic.IEnumerable<string> allowedDiskLevelOperation = null, bool? isDiskEncrypted = default(bool?), string secretIdentifier = null, Azure.Core.ResourceIdentifier dekKeyVaultArmId = null, bool? isDiskKeyEncrypted = default(bool?), string keyIdentifier = null, Azure.Core.ResourceIdentifier kekKeyVaultArmId = null, string failoverDiskName = null, string tfoDiskName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedManagedDiskDetails A2AProtectedManagedDiskDetails(string diskId = null, Azure.Core.ResourceIdentifier recoveryResourceGroupId = null, Azure.Core.ResourceIdentifier recoveryTargetDiskId = null, Azure.Core.ResourceIdentifier recoveryReplicaDiskId = null, Azure.Core.ResourceIdentifier recoveryOrignalTargetDiskId = null, string recoveryReplicaDiskAccountType = null, string recoveryTargetDiskAccountType = null, Azure.Core.ResourceIdentifier recoveryDiskEncryptionSetId = null, Azure.Core.ResourceIdentifier primaryDiskEncryptionSetId = null, string diskName = null, long? diskCapacityInBytes = default(long?), Azure.Core.ResourceIdentifier primaryStagingAzureStorageAccountId = null, string diskType = null, bool? isResyncRequired = default(bool?), int? monitoringPercentageCompletion = default(int?), string monitoringJobType = null, double? dataPendingInStagingStorageAccountInMB = default(double?), double? dataPendingAtSourceAgentInMB = default(double?), string diskState = null, System.Collections.Generic.IEnumerable<string> allowedDiskLevelOperation = null, bool? isDiskEncrypted = default(bool?), string secretIdentifier = null, Azure.Core.ResourceIdentifier dekKeyVaultArmId = null, bool? isDiskKeyEncrypted = default(bool?), string keyIdentifier = null, Azure.Core.ResourceIdentifier kekKeyVaultArmId = null, string failoverDiskName = null, string tfoDiskName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionContainerMappingDetails A2AProtectionContainerMappingDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus? agentAutoUpdateStatus = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus?), Azure.Core.ResourceIdentifier automationAccountArmId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? automationAccountAuthenticationType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType?), string scheduleName = null, string jobScheduleName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryPointDetails A2ARecoveryPointDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType? recoveryPointSyncType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType?), System.Collections.Generic.IEnumerable<string> disks = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AReplicationDetails A2AReplicationDetails(Azure.Core.ResourceIdentifier fabricObjectId, string initialPrimaryZone, Azure.Core.AzureLocation? initialPrimaryFabricLocation, string initialRecoveryZone, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation initialPrimaryExtendedLocation, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation initialRecoveryExtendedLocation, Azure.Core.AzureLocation? initialRecoveryFabricLocation, string multiVmGroupId, string multiVmGroupName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption? multiVmGroupCreateOption, string managementId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedDiskDetails> protectedDisks, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AUnprotectedDiskDetails> unprotectedDisks, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedManagedDiskDetails> protectedManagedDisks, Azure.Core.ResourceIdentifier recoveryBootDiagStorageAccountId, Azure.Core.AzureLocation? primaryFabricLocation, Azure.Core.AzureLocation? recoveryFabricLocation, string osType, string recoveryAzureVmSize, string recoveryAzureVmName, Azure.Core.ResourceIdentifier recoveryAzureResourceGroupId, string recoveryCloudService, string recoveryAvailabilitySet, Azure.Core.ResourceIdentifier selectedRecoveryAzureNetworkId, Azure.Core.ResourceIdentifier selectedTfoAzureNetworkId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmSyncedConfigDetails vmSyncedConfigDetails, int? monitoringPercentageCompletion, string monitoringJobType, System.DateTimeOffset? lastHeartbeat, string agentVersion, System.DateTimeOffset? agentExpireOn, bool? isReplicationAgentUpdateRequired, System.DateTimeOffset? agentCertificateExpireOn, bool? isReplicationAgentCertificateUpdateRequired, Azure.Core.ResourceIdentifier recoveryFabricObjectId, string vmProtectionState, string vmProtectionStateDescription, string lifecycleId, Azure.Core.ResourceIdentifier testFailoverRecoveryFabricObjectId, long? rpoInSeconds, System.DateTimeOffset? lastRpoCalculatedOn, string primaryAvailabilityZone, string recoveryAvailabilityZone, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation primaryExtendedLocation, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation recoveryExtendedLocation, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType? vmEncryptionType, string tfoAzureVmName, string recoveryAzureGeneration, Azure.Core.ResourceIdentifier recoveryProximityPlacementGroupId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? autoProtectionOfDataDisk, Azure.Core.ResourceIdentifier recoveryVirtualMachineScaleSetId, Azure.Core.ResourceIdentifier recoveryCapacityReservationGroupId) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AReplicationDetails A2AReplicationDetails(Azure.Core.ResourceIdentifier fabricObjectId = null, string initialPrimaryZone = null, Azure.Core.AzureLocation? initialPrimaryFabricLocation = default(Azure.Core.AzureLocation?), string initialRecoveryZone = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation initialPrimaryExtendedLocation = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation initialRecoveryExtendedLocation = null, Azure.Core.AzureLocation? initialRecoveryFabricLocation = default(Azure.Core.AzureLocation?), string multiVmGroupId = null, string multiVmGroupName = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption? multiVmGroupCreateOption = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption?), string managementId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedDiskDetails> protectedDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AUnprotectedDiskDetails> unprotectedDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedManagedDiskDetails> protectedManagedDisks = null, Azure.Core.ResourceIdentifier recoveryBootDiagStorageAccountId = null, Azure.Core.AzureLocation? primaryFabricLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? recoveryFabricLocation = default(Azure.Core.AzureLocation?), string osType = null, string recoveryAzureVmSize = null, string recoveryAzureVmName = null, Azure.Core.ResourceIdentifier recoveryAzureResourceGroupId = null, string recoveryCloudService = null, string recoveryAvailabilitySet = null, Azure.Core.ResourceIdentifier selectedRecoveryAzureNetworkId = null, Azure.Core.ResourceIdentifier selectedTfoAzureNetworkId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmSyncedConfigDetails vmSyncedConfigDetails = null, int? monitoringPercentageCompletion = default(int?), string monitoringJobType = null, System.DateTimeOffset? lastHeartbeat = default(System.DateTimeOffset?), string agentVersion = null, System.DateTimeOffset? agentExpireOn = default(System.DateTimeOffset?), bool? isReplicationAgentUpdateRequired = default(bool?), System.DateTimeOffset? agentCertificateExpireOn = default(System.DateTimeOffset?), bool? isReplicationAgentCertificateUpdateRequired = default(bool?), Azure.Core.ResourceIdentifier recoveryFabricObjectId = null, string vmProtectionState = null, string vmProtectionStateDescription = null, string lifecycleId = null, Azure.Core.ResourceIdentifier testFailoverRecoveryFabricObjectId = null, long? rpoInSeconds = default(long?), System.DateTimeOffset? lastRpoCalculatedOn = default(System.DateTimeOffset?), string primaryAvailabilityZone = null, string recoveryAvailabilityZone = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation primaryExtendedLocation = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation recoveryExtendedLocation = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType? vmEncryptionType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType?), string tfoAzureVmName = null, string recoveryAzureGeneration = null, Azure.Core.ResourceIdentifier recoveryProximityPlacementGroupId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? autoProtectionOfDataDisk = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk?), Azure.Core.ResourceIdentifier recoveryVirtualMachineScaleSetId = null, Azure.Core.ResourceIdentifier recoveryCapacityReservationGroupId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected? churnOptionSelected = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AReplicationIntentDetails A2AReplicationIntentDetails(Azure.Core.ResourceIdentifier fabricObjectId = null, Azure.Core.AzureLocation? primaryLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? recoveryLocation = default(Azure.Core.AzureLocation?), string recoverySubscriptionId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentDiskDetails> vmDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentManagedDiskDetails> vmManagedDisks = null, Azure.Core.ResourceIdentifier recoveryResourceGroupId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionProfileCustomDetails protectionProfile = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails primaryStagingStorageAccount = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryAvailabilitySetCustomDetails recoveryAvailabilitySet = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryVirtualNetworkCustomDetails recoveryVirtualNetwork = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryProximityPlacementGroupCustomDetails recoveryProximityPlacementGroup = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? autoProtectionOfDataDisk = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk?), string multiVmGroupName = null, string multiVmGroupId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails recoveryBootDiagStorageAccount = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionInfo diskEncryptionInfo = null, string recoveryAvailabilityZone = null, string recoveryAvailabilityType = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus? agentAutoUpdateStatus = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus?), Azure.Core.ResourceIdentifier automationAccountArmId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? automationAccountAuthenticationType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AUnprotectedDiskDetails A2AUnprotectedDiskDetails(int? diskLunId = default(int?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? diskAutoProtectionStatus = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmSyncedConfigDetails A2AVmSyncedConfigDetails(System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEndpoint> vmEndpoints = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AZoneDetails A2AZoneDetails(string source = null, string target = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceMonitoringDetails ApplianceMonitoringDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails cpuDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails ramDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataStoreUtilizationDetails> datastoreSnapshot = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails disksReplicationDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails esxiNfcBuffer = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails networkBandwidth = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceResourceDetails ApplianceResourceDetails(long? capacity = default(long?), double? processUtilization = default(double?), double? totalUtilization = default(double?), string status = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AsrJobDetails AsrJobDetails(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AsrTask AsrTask(string taskId = null, string name = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> allowedActions = null, string friendlyName = null, string state = null, string stateDescription = null, string taskType = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryTaskTypeDetails customDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryGroupTaskDetails groupTaskCustomDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobErrorDetails> errors = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationRunbookTaskDetails AutomationRunbookTaskDetails(string name = null, string cloudServiceName = null, string subscriptionId = null, string accountName = null, string runbookId = null, string runbookName = null, Azure.Core.ResourceIdentifier jobId = null, string jobOutput = null, bool? isPrimarySideScript = default(bool?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ConsistencyCheckTaskDetails ConsistencyCheckTaskDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InconsistentVmDetails> vmDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CriticalJobHistoryDetails CriticalJobHistoryDetails(string jobName = null, Azure.Core.ResourceIdentifier jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), string jobStatus = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentJobDetails CurrentJobDetails(string jobName = null, Azure.Core.ResourceIdentifier jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentScenarioDetails CurrentScenarioDetails(string scenarioName = null, Azure.Core.ResourceIdentifier jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataStoreUtilizationDetails DataStoreUtilizationDetails(long? totalSnapshotsSupported = default(long?), long? totalSnapshotsCreated = default(long?), string dataStoreName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobDetails ExportJobDetails(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, System.Uri blobUri = null, string sasToken = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricReplicationGroupTaskDetails FabricReplicationGroupTaskDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobEntity jobTask = null, string skippedReason = null, string skippedReasonString = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverJobDetails FailoverJobDetails(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverReplicationProtectedItemDetails> protectedItemDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverReplicationProtectedItemDetails FailoverReplicationProtectedItemDetails(string name = null, string friendlyName = null, string testVmName = null, string testVmFriendlyName = null, string networkConnectionStatus = null, string networkFriendlyName = null, string subnet = null, Azure.Core.ResourceIdentifier recoveryPointId = null, System.DateTimeOffset? recoveryPointOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.GatewayOperationDetails GatewayOperationDetails(string state = null, int? progressPercentage = default(int?), long? timeElapsed = default(long?), long? timeRemaining = default(long?), long? uploadSpeed = default(long?), string hostName = null, System.Collections.Generic.IEnumerable<string> dataStores = null, long? vmwareReadThroughput = default(long?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorSummary HealthErrorSummary(string summaryCode = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory? category = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity? severity = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity?), string summaryMessage = null, string affectedResourceType = null, string affectedResourceSubtype = null, System.Collections.Generic.IEnumerable<string> affectedResourceCorrelationIds = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVHostDetails HyperVHostDetails(string id = null, string name = null, string marsAgentVersion = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVIPConfigDetails HyperVIPConfigDetails(string name = null, bool? isPrimary = default(bool?), string subnetName = null, System.Net.IPAddress staticIPAddress = null, string ipAddressType = null, bool? isSeletedForFailover = default(bool?), string recoverySubnetName = null, System.Net.IPAddress recoveryStaticIPAddress = null, string recoveryIPAddressType = null, Azure.Core.ResourceIdentifier recoveryPublicIPAddressId = null, System.Collections.Generic.IEnumerable<string> recoveryLBBackendAddressPoolIds = null, string tfoSubnetName = null, System.Net.IPAddress tfoStaticIPAddress = null, Azure.Core.ResourceIdentifier tfoPublicIPAddressId = null, System.Collections.Generic.IEnumerable<string> tfoLBBackendAddressPoolIds = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplica2012EventDetails HyperVReplica2012EventDetails(string containerName = null, string fabricName = null, string remoteContainerName = null, string remoteFabricName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplica2012R2EventDetails HyperVReplica2012R2EventDetails(string containerName = null, string fabricName = null, string remoteContainerName = null, string remoteFabricName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureEventDetails HyperVReplicaAzureEventDetails(string containerName = null, string fabricName = null, string remoteContainerName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureManagedDiskDetails HyperVReplicaAzureManagedDiskDetails(string diskId = null, string seedManagedDiskId = null, string replicaDiskType = null, Azure.Core.ResourceIdentifier diskEncryptionSetId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzurePolicyDetails HyperVReplicaAzurePolicyDetails(int? recoveryPointHistoryDurationInHours = default(int?), int? applicationConsistentSnapshotFrequencyInHours = default(int?), int? replicationInterval = default(int?), string onlineReplicationStartTime = null, string encryption = null, Azure.Core.ResourceIdentifier activeStorageAccountId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureReplicationDetails HyperVReplicaAzureReplicationDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmDiskDetails> azureVmDiskDetails, string recoveryAzureVmName, string recoveryAzureVmSize, string recoveryAzureStorageAccount, Azure.Core.ResourceIdentifier recoveryAzureLogStorageAccountId, System.DateTimeOffset? lastReplicatedOn, long? rpoInSeconds, System.DateTimeOffset? lastRpoCalculatedOn, string vmId, string vmProtectionState, string vmProtectionStateDescription, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails initialReplicationDetails, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics, Azure.Core.ResourceIdentifier selectedRecoveryAzureNetworkId, string selectedSourceNicId, string encryption, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDetails osDetails, int? sourceVmRamSizeInMB, int? sourceVmCpuCount, string enableRdpOnTargetOption, Azure.Core.ResourceIdentifier recoveryAzureResourceGroupId, Azure.Core.ResourceIdentifier recoveryAvailabilitySetId, string targetAvailabilityZone, Azure.Core.ResourceIdentifier targetProximityPlacementGroupId, string useManagedDisks, string licenseType, string sqlServerLicenseType, System.DateTimeOffset? lastRecoveryPointReceived, System.Collections.Generic.IReadOnlyDictionary<string, string> targetVmTags, System.Collections.Generic.IReadOnlyDictionary<string, string> seedManagedDiskTags, System.Collections.Generic.IReadOnlyDictionary<string, string> targetManagedDiskTags, System.Collections.Generic.IReadOnlyDictionary<string, string> targetNicTags, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureManagedDiskDetails> protectedManagedDisks) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureReplicationDetails HyperVReplicaAzureReplicationDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmDiskDetails> azureVmDiskDetails = null, string recoveryAzureVmName = null, string recoveryAzureVmSize = null, string recoveryAzureStorageAccount = null, Azure.Core.ResourceIdentifier recoveryAzureLogStorageAccountId = null, System.DateTimeOffset? lastReplicatedOn = default(System.DateTimeOffset?), long? rpoInSeconds = default(long?), System.DateTimeOffset? lastRpoCalculatedOn = default(System.DateTimeOffset?), string vmId = null, string vmProtectionState = null, string vmProtectionStateDescription = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails initialReplicationDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics = null, Azure.Core.ResourceIdentifier selectedRecoveryAzureNetworkId = null, string selectedSourceNicId = null, string encryption = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDetails osDetails = null, int? sourceVmRamSizeInMB = default(int?), int? sourceVmCpuCount = default(int?), string enableRdpOnTargetOption = null, Azure.Core.ResourceIdentifier recoveryAzureResourceGroupId = null, Azure.Core.ResourceIdentifier recoveryAvailabilitySetId = null, string targetAvailabilityZone = null, Azure.Core.ResourceIdentifier targetProximityPlacementGroupId = null, string useManagedDisks = null, string licenseType = null, string sqlServerLicenseType = null, System.DateTimeOffset? lastRecoveryPointReceived = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> targetVmTags = null, System.Collections.Generic.IReadOnlyDictionary<string, string> seedManagedDiskTags = null, System.Collections.Generic.IReadOnlyDictionary<string, string> targetManagedDiskTags = null, System.Collections.Generic.IReadOnlyDictionary<string, string> targetNicTags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureManagedDiskDetails> protectedManagedDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.OSUpgradeSupportedVersions> allAvailableOSUpgradeConfigurations = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaBaseEventDetails HyperVReplicaBaseEventDetails(string containerName = null, string fabricName = null, string remoteContainerName = null, string remoteFabricName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaBasePolicyDetails HyperVReplicaBasePolicyDetails(int? recoveryPoints = default(int?), int? applicationConsistentSnapshotFrequencyInHours = default(int?), string compression = null, string initialReplicationMethod = null, string onlineReplicationStartTime = null, string offlineReplicationImportPath = null, string offlineReplicationExportPath = null, int? replicationPort = default(int?), int? allowedAuthenticationType = default(int?), string replicaDeletionOption = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaBaseReplicationDetails HyperVReplicaBaseReplicationDetails(System.DateTimeOffset? lastReplicatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics = null, string vmId = null, string vmProtectionState = null, string vmProtectionStateDescription = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails initialReplicationDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails> vmDiskDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaBluePolicyDetails HyperVReplicaBluePolicyDetails(int? replicationFrequencyInSeconds = default(int?), int? recoveryPoints = default(int?), int? applicationConsistentSnapshotFrequencyInHours = default(int?), string compression = null, string initialReplicationMethod = null, string onlineReplicationStartTime = null, string offlineReplicationImportPath = null, string offlineReplicationExportPath = null, int? replicationPort = default(int?), int? allowedAuthenticationType = default(int?), string replicaDeletionOption = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaBlueReplicationDetails HyperVReplicaBlueReplicationDetails(System.DateTimeOffset? lastReplicatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics = null, string vmId = null, string vmProtectionState = null, string vmProtectionStateDescription = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails initialReplicationDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails> vmDiskDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaPolicyDetails HyperVReplicaPolicyDetails(int? recoveryPoints = default(int?), int? applicationConsistentSnapshotFrequencyInHours = default(int?), string compression = null, string initialReplicationMethod = null, string onlineReplicationStartTime = null, string offlineReplicationImportPath = null, string offlineReplicationExportPath = null, int? replicationPort = default(int?), int? allowedAuthenticationType = default(int?), string replicaDeletionOption = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaReplicationDetails HyperVReplicaReplicationDetails(System.DateTimeOffset? lastReplicatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics = null, string vmId = null, string vmProtectionState = null, string vmProtectionStateDescription = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails initialReplicationDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails> vmDiskDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVSiteDetails HyperVSiteDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVHostDetails> hyperVHosts = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDetails HyperVVmDetails(string sourceItemId = null, string generation = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDetails osDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails> diskDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus? hasPhysicalDisk = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus? hasFibreChannelAdapter = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus? hasSharedVhd = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus?), string hyperVHostId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails IdentityProviderDetails(System.Guid? tenantId = default(System.Guid?), string applicationId = null, string objectId = null, string audience = null, string aadAuthority = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InconsistentVmDetails InconsistentVmDetails(string vmName = null, string cloudName = null, System.Collections.Generic.IEnumerable<string> details = null, System.Collections.Generic.IEnumerable<string> errorIds = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails InitialReplicationDetails(string initialReplicationType = null, string initialReplicationProgressPercentage = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InlineWorkflowTaskDetails InlineWorkflowTaskDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AsrTask> childTasks = null, System.Collections.Generic.IEnumerable<string> workflowIds = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAgentDetails InMageAgentDetails(string agentVersion = null, string agentUpdateStatus = null, string postUpdateRebootStatus = null, System.DateTimeOffset? agentExpireOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2EventDetails InMageAzureV2EventDetails(string eventType = null, string category = null, string component = null, string correctiveAction = null, string details = null, string summary = null, string siteName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ManagedDiskDetails InMageAzureV2ManagedDiskDetails(string diskId = null, string seedManagedDiskId = null, string replicaDiskType = null, Azure.Core.ResourceIdentifier diskEncryptionSetId = null, string targetDiskName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2PolicyDetails InMageAzureV2PolicyDetails(int? crashConsistentFrequencyInMinutes = default(int?), int? recoveryPointThresholdInMinutes = default(int?), int? recoveryPointHistory = default(int?), int? appConsistentFrequencyInMinutes = default(int?), string multiVmSyncStatus = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ProtectedDiskDetails InMageAzureV2ProtectedDiskDetails(string diskId = null, string diskName = null, string protectionStage = null, string healthErrorCode = null, long? rpoInSeconds = default(long?), string resyncRequired = null, int? resyncProgressPercentage = default(int?), long? resyncDurationInSeconds = default(long?), long? diskCapacityInBytes = default(long?), long? fileSystemCapacityInBytes = default(long?), double? sourceDataInMegaBytes = default(double?), double? psDataInMegaBytes = default(double?), double? targetDataInMegaBytes = default(double?), string diskResized = null, System.DateTimeOffset? lastRpoCalculatedOn = default(System.DateTimeOffset?), long? resyncProcessedBytes = default(long?), long? resyncTotalTransferredBytes = default(long?), long? resyncLast15MinutesTransferredBytes = default(long?), System.DateTimeOffset? resyncLastDataTransferOn = default(System.DateTimeOffset?), System.DateTimeOffset? resyncStartOn = default(System.DateTimeOffset?), string progressHealth = null, string progressStatus = null, long? secondsToTakeSwitchProvider = default(long?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2RecoveryPointDetails InMageAzureV2RecoveryPointDetails(string isMultiVmSyncPoint = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ReplicationDetails InMageAzureV2ReplicationDetails(string infrastructureVmId, string vCenterInfrastructureId, string protectionStage, string vmId, string vmProtectionState, string vmProtectionStateDescription, int? resyncProgressPercentage, long? rpoInSeconds, double? compressedDataRateInMB, double? uncompressedDataRateInMB, System.Net.IPAddress ipAddress, string agentVersion, System.DateTimeOffset? agentExpireOn, string isAgentUpdateRequired, string isRebootAfterUpdateRequired, System.DateTimeOffset? lastHeartbeat, System.Guid? processServerId, string processServerName, string multiVmGroupId, string multiVmGroupName, string multiVmSyncStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ProtectedDiskDetails> protectedDisks, string diskResized, string masterTargetId, int? sourceVmCpuCount, int? sourceVmRamSizeInMB, string osType, string vhdName, string osDiskId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmDiskDetails> azureVmDiskDetails, string recoveryAzureVmName, string recoveryAzureVmSize, string recoveryAzureStorageAccount, Azure.Core.ResourceIdentifier recoveryAzureLogStorageAccountId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics, Azure.Core.ResourceIdentifier selectedRecoveryAzureNetworkId, Azure.Core.ResourceIdentifier selectedTfoAzureNetworkId, string selectedSourceNicId, string discoveryType, string enableRdpOnTargetOption, System.Collections.Generic.IEnumerable<string> datastores, string targetVmId, Azure.Core.ResourceIdentifier recoveryAzureResourceGroupId, Azure.Core.ResourceIdentifier recoveryAvailabilitySetId, string targetAvailabilityZone, Azure.Core.ResourceIdentifier targetProximityPlacementGroupId, string useManagedDisks, string licenseType, string sqlServerLicenseType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> validationErrors, System.DateTimeOffset? lastRpoCalculatedOn, System.DateTimeOffset? lastUpdateReceivedOn, string replicaId, string osVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ManagedDiskDetails> protectedManagedDisks, System.DateTimeOffset? lastRecoveryPointReceived, string firmwareType, string azureVmGeneration, bool? isAdditionalStatsAvailable, long? totalDataTransferred, string totalProgressHealth, System.Collections.Generic.IReadOnlyDictionary<string, string> targetVmTags, System.Collections.Generic.IReadOnlyDictionary<string, string> seedManagedDiskTags, System.Collections.Generic.IReadOnlyDictionary<string, string> targetManagedDiskTags, System.Collections.Generic.IReadOnlyDictionary<string, string> targetNicTags, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderBlockingErrorDetails> switchProviderBlockingErrorDetails, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderDetails switchProviderDetails) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ReplicationDetails InMageAzureV2ReplicationDetails(string infrastructureVmId = null, string vCenterInfrastructureId = null, string protectionStage = null, string vmId = null, string vmProtectionState = null, string vmProtectionStateDescription = null, int? resyncProgressPercentage = default(int?), long? rpoInSeconds = default(long?), double? compressedDataRateInMB = default(double?), double? uncompressedDataRateInMB = default(double?), System.Net.IPAddress ipAddress = null, string agentVersion = null, System.DateTimeOffset? agentExpireOn = default(System.DateTimeOffset?), string isAgentUpdateRequired = null, string isRebootAfterUpdateRequired = null, System.DateTimeOffset? lastHeartbeat = default(System.DateTimeOffset?), System.Guid? processServerId = default(System.Guid?), string processServerName = null, string multiVmGroupId = null, string multiVmGroupName = null, string multiVmSyncStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ProtectedDiskDetails> protectedDisks = null, string diskResized = null, string masterTargetId = null, int? sourceVmCpuCount = default(int?), int? sourceVmRamSizeInMB = default(int?), string osType = null, string vhdName = null, string osDiskId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmDiskDetails> azureVmDiskDetails = null, string recoveryAzureVmName = null, string recoveryAzureVmSize = null, string recoveryAzureStorageAccount = null, Azure.Core.ResourceIdentifier recoveryAzureLogStorageAccountId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics = null, Azure.Core.ResourceIdentifier selectedRecoveryAzureNetworkId = null, Azure.Core.ResourceIdentifier selectedTfoAzureNetworkId = null, string selectedSourceNicId = null, string discoveryType = null, string enableRdpOnTargetOption = null, System.Collections.Generic.IEnumerable<string> datastores = null, string targetVmId = null, Azure.Core.ResourceIdentifier recoveryAzureResourceGroupId = null, Azure.Core.ResourceIdentifier recoveryAvailabilitySetId = null, string targetAvailabilityZone = null, Azure.Core.ResourceIdentifier targetProximityPlacementGroupId = null, string useManagedDisks = null, string licenseType = null, string sqlServerLicenseType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> validationErrors = null, System.DateTimeOffset? lastRpoCalculatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdateReceivedOn = default(System.DateTimeOffset?), string replicaId = null, string osVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ManagedDiskDetails> protectedManagedDisks = null, System.DateTimeOffset? lastRecoveryPointReceived = default(System.DateTimeOffset?), string firmwareType = null, string azureVmGeneration = null, bool? isAdditionalStatsAvailable = default(bool?), long? totalDataTransferred = default(long?), string totalProgressHealth = null, System.Collections.Generic.IReadOnlyDictionary<string, string> targetVmTags = null, System.Collections.Generic.IReadOnlyDictionary<string, string> seedManagedDiskTags = null, System.Collections.Generic.IReadOnlyDictionary<string, string> targetManagedDiskTags = null, System.Collections.Generic.IReadOnlyDictionary<string, string> targetNicTags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderBlockingErrorDetails> switchProviderBlockingErrorDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderDetails switchProviderDetails = null, System.Collections.Generic.IEnumerable<string> supportedOSVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.OSUpgradeSupportedVersions> allAvailableOSUpgradeConfigurations = null, string osName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderBlockingErrorDetails InMageAzureV2SwitchProviderBlockingErrorDetails(string errorCode = null, string errorMessage = null, string possibleCauses = null, string recommendedAction = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorMessageParameters = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorTags = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderDetails InMageAzureV2SwitchProviderDetails(Azure.Core.ResourceIdentifier targetVaultId = null, Azure.Core.ResourceIdentifier targetResourceId = null, Azure.Core.ResourceIdentifier targetFabricId = null, string targetApplianceId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageBasePolicyDetails InMageBasePolicyDetails(int? recoveryPointThresholdInMinutes = default(int?), int? recoveryPointHistory = default(int?), int? appConsistentFrequencyInMinutes = default(int?), string multiVmSyncStatus = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskDetails InMageDiskDetails(string diskId = null, string diskName = null, string diskSizeInMB = null, string diskType = null, string diskConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskVolumeDetails> volumeList = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageFabricSwitchProviderBlockingErrorDetails InMageFabricSwitchProviderBlockingErrorDetails(string errorCode = null, string errorMessage = null, string possibleCauses = null, string recommendedAction = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorMessageParameters = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorTags = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMagePolicyDetails InMagePolicyDetails(int? recoveryPointThresholdInMinutes = default(int?), int? recoveryPointHistory = default(int?), int? appConsistentFrequencyInMinutes = default(int?), string multiVmSyncStatus = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageProtectedDiskDetails InMageProtectedDiskDetails(string diskId = null, string diskName = null, string protectionStage = null, string healthErrorCode = null, long? rpoInSeconds = default(long?), string resyncRequired = null, int? resyncProgressPercentage = default(int?), long? resyncDurationInSeconds = default(long?), long? diskCapacityInBytes = default(long?), long? fileSystemCapacityInBytes = default(long?), double? sourceDataInMB = default(double?), double? psDataInMB = default(double?), double? targetDataInMB = default(double?), string diskResized = null, System.DateTimeOffset? lastRpoCalculatedOn = default(System.DateTimeOffset?), long? resyncProcessedBytes = default(long?), long? resyncTotalTransferredBytes = default(long?), long? resyncLast15MinutesTransferredBytes = default(long?), System.DateTimeOffset? resyncLastDataTransferTimeUTC = default(System.DateTimeOffset?), System.DateTimeOffset? resyncStartOn = default(System.DateTimeOffset?), string progressHealth = null, string progressStatus = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmAgentUpgradeBlockingErrorDetails InMageRcmAgentUpgradeBlockingErrorDetails(string errorCode = null, string errorMessage = null, string possibleCauses = null, string recommendedAction = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorMessageParameters = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorTags = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmApplianceDetails InMageRcmApplianceDetails(string id = null, string name = null, Azure.Core.ResourceIdentifier fabricArmId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServerDetails processServer = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmProxyDetails rcmProxy = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PushInstallerDetails pushInstaller = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAgentDetails replicationAgent = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReprotectAgentDetails reprotectAgent = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MarsAgentDetails marsAgent = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDraDetails dra = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFabricSwitchProviderBlockingErrorDetails> switchProviderBlockingErrorDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmApplianceSpecificDetails InMageRcmApplianceSpecificDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmApplianceDetails> appliances = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmDiscoveredProtectedVmDetails InMageRcmDiscoveredProtectedVmDetails(string vCenterId = null, string vCenterFqdn = null, System.Collections.Generic.IEnumerable<string> datastores = null, System.Collections.Generic.IEnumerable<System.Net.IPAddress> ipAddresses = null, string vmwareToolsStatus = null, string powerStatus = null, string vmFqdn = null, string osName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), bool? isDeleted = default(bool?), System.DateTimeOffset? lastDiscoveryTimeInUtc = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmEventDetails InMageRcmEventDetails(string protectedItemName = null, string vmName = null, string latestAgentVersion = null, Azure.Core.ResourceIdentifier jobId = null, string fabricName = null, string applianceName = null, string serverType = null, string componentDisplayName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFabricSpecificDetails InMageRcmFabricSpecificDetails(Azure.Core.ResourceIdentifier vmwareSiteId = null, Azure.Core.ResourceIdentifier physicalSiteId = null, string serviceEndpoint = null, Azure.Core.ResourceIdentifier serviceResourceId = null, string serviceContainerId = null, System.Uri dataPlaneUri = null, System.Uri controlPlaneUri = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails sourceAgentIdentityDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServerDetails> processServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmProxyDetails> rcmProxies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PushInstallerDetails> pushInstallers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAgentDetails> replicationAgents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReprotectAgentDetails> reprotectAgents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MarsAgentDetails> marsAgents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDraDetails> dras = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentDetails> agentDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFabricSwitchProviderBlockingErrorDetails InMageRcmFabricSwitchProviderBlockingErrorDetails(string errorCode = null, string errorMessage = null, string possibleCauses = null, string recommendedAction = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorMessageParameters = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorTags = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackDiscoveredProtectedVmDetails InMageRcmFailbackDiscoveredProtectedVmDetails(string vCenterId = null, string vCenterFqdn = null, System.Collections.Generic.IEnumerable<string> datastores = null, System.Collections.Generic.IEnumerable<System.Net.IPAddress> ipAddresses = null, string vmwareToolsStatus = null, string powerStatus = null, string vmFqdn = null, string osName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), bool? isDeleted = default(bool?), System.DateTimeOffset? lastDiscoveredOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackEventDetails InMageRcmFailbackEventDetails(string protectedItemName = null, string vmName = null, string applianceName = null, string serverType = null, string componentDisplayName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackMobilityAgentDetails InMageRcmFailbackMobilityAgentDetails(string version = null, string latestVersion = null, string driverVersion = null, string latestUpgradableVersionWithoutReboot = null, System.DateTimeOffset? agentVersionExpireOn = default(System.DateTimeOffset?), System.DateTimeOffset? driverVersionExpireOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason> reasonsBlockingUpgrade = null, string isUpgradeable = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackNicDetails InMageRcmFailbackNicDetails(string macAddress = null, string networkName = null, string adapterType = null, System.Net.IPAddress sourceIPAddress = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackPolicyDetails InMageRcmFailbackPolicyDetails(int? appConsistentFrequencyInMinutes = default(int?), int? crashConsistentFrequencyInMinutes = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackProtectedDiskDetails InMageRcmFailbackProtectedDiskDetails(string diskId = null, string diskName = null, string isOSDisk = null, long? capacityInBytes = default(long?), string diskUuid = null, double? dataPendingInLogDataStoreInMB = default(double?), double? dataPendingAtSourceAgentInMB = default(double?), string isInitialReplicationComplete = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackSyncDetails irDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackSyncDetails resyncDetails = null, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackReplicationDetails InMageRcmFailbackReplicationDetails(string internalIdentifier = null, Azure.Core.ResourceIdentifier azureVirtualMachineId = null, string multiVmGroupName = null, string reprotectAgentId = null, string reprotectAgentName = null, string osType = null, Azure.Core.ResourceIdentifier logStorageAccountId = null, string targetVCenterId = null, string targetDataStoreName = null, string targetVmName = null, int? initialReplicationProgressPercentage = default(int?), long? initialReplicationProcessedBytes = default(long?), long? initialReplicationTransferredBytes = default(long?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth? initialReplicationProgressHealth = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth?), int? resyncProgressPercentage = default(int?), long? resyncProcessedBytes = default(long?), long? resyncTransferredBytes = default(long?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth? resyncProgressHealth = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth?), string resyncRequired = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState? resyncState = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackProtectedDiskDetails> protectedDisks = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackMobilityAgentDetails mobilityAgentDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackNicDetails> vmNics = null, System.DateTimeOffset? lastPlannedFailoverStartOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus? lastPlannedFailoverStatus = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackDiscoveredProtectedVmDetails discoveredVmDetails = null, Azure.Core.ResourceIdentifier lastUsedPolicyId = null, string lastUsedPolicyFriendlyName = null, bool? isAgentRegistrationSuccessfulAfterFailover = default(bool?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackSyncDetails InMageRcmFailbackSyncDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth? progressHealth = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth?), long? transferredBytes = default(long?), long? last15MinutesTransferredBytes = default(long?), System.DateTimeOffset? lastDataTransferOn = default(System.DateTimeOffset?), long? processedBytes = default(long?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshedOn = default(System.DateTimeOffset?), int? progressPercentage = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmLastAgentUpgradeErrorDetails InMageRcmLastAgentUpgradeErrorDetails(string errorCode = null, string errorMessage = null, string possibleCauses = null, string recommendedAction = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorMessageParameters = null, System.Collections.Generic.IReadOnlyDictionary<string, string> errorTags = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmMobilityAgentDetails InMageRcmMobilityAgentDetails(string version = null, string latestVersion = null, string latestAgentReleaseDate = null, string driverVersion = null, string latestUpgradableVersionWithoutReboot = null, System.DateTimeOffset? agentVersionExpireOn = default(System.DateTimeOffset?), System.DateTimeOffset? driverVersionExpireOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason> reasonsBlockingUpgrade = null, string isUpgradeable = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmNicDetails InMageRcmNicDetails(string nicId = null, string isPrimaryNic = null, string isSelectedForFailover = null, System.Net.IPAddress sourceIPAddress = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? sourceIPAddressType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType?), Azure.Core.ResourceIdentifier sourceNetworkId = null, string sourceSubnetName = null, System.Net.IPAddress targetIPAddress = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? targetIPAddressType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType?), string targetSubnetName = null, string testSubnetName = null, System.Net.IPAddress testIPAddress = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? testIPAddressType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmPolicyDetails InMageRcmPolicyDetails(int? recoveryPointHistoryInMinutes = default(int?), int? appConsistentFrequencyInMinutes = default(int?), int? crashConsistentFrequencyInMinutes = default(int?), string enableMultiVmSync = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmProtectedDiskDetails InMageRcmProtectedDiskDetails(string diskId = null, string diskName = null, string isOSDisk = null, long? capacityInBytes = default(long?), Azure.Core.ResourceIdentifier logStorageAccountId = null, Azure.Core.ResourceIdentifier diskEncryptionSetId = null, string seedManagedDiskId = null, System.Uri seedBlobUri = null, string targetManagedDiskId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? diskType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType?), double? dataPendingInLogDataStoreInMB = default(double?), double? dataPendingAtSourceAgentInMB = default(double?), string isInitialReplicationComplete = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmSyncDetails irDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmSyncDetails resyncDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmProtectionContainerMappingDetails InMageRcmProtectionContainerMappingDetails(string enableAgentAutoUpgrade = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmRecoveryPointDetails InMageRcmRecoveryPointDetails(string isMultiVmSyncPoint = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmReplicationDetails InMageRcmReplicationDetails(string internalIdentifier = null, string fabricDiscoveryMachineId = null, string multiVmGroupName = null, string discoveryType = null, System.Guid? processServerId = default(System.Guid?), int? processorCoreCount = default(int?), double? allocatedMemoryInMB = default(double?), string processServerName = null, string runAsAccountId = null, string osType = null, string firmwareType = null, System.Net.IPAddress primaryNicIPAddress = null, string targetGeneration = null, string licenseType = null, Azure.Core.ResourceIdentifier storageAccountId = null, string targetVmName = null, string targetVmSize = null, Azure.Core.ResourceIdentifier targetResourceGroupId = null, string targetLocation = null, Azure.Core.ResourceIdentifier targetAvailabilitySetId = null, string targetAvailabilityZone = null, Azure.Core.ResourceIdentifier targetProximityPlacementGroupId = null, Azure.Core.ResourceIdentifier targetBootDiagnosticsStorageAccountId = null, Azure.Core.ResourceIdentifier targetNetworkId = null, Azure.Core.ResourceIdentifier testNetworkId = null, Azure.Core.ResourceIdentifier failoverRecoveryPointId = null, System.DateTimeOffset? lastRecoveryPointReceived = default(System.DateTimeOffset?), long? lastRpoInSeconds = default(long?), System.DateTimeOffset? lastRpoCalculatedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier lastRecoveryPointId = null, int? initialReplicationProgressPercentage = default(int?), long? initialReplicationProcessedBytes = default(long?), long? initialReplicationTransferredBytes = default(long?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth? initialReplicationProgressHealth = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth?), int? resyncProgressPercentage = default(int?), long? resyncProcessedBytes = default(long?), long? resyncTransferredBytes = default(long?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth? resyncProgressHealth = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth?), string resyncRequired = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState? resyncState = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState? agentUpgradeState = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState?), string lastAgentUpgradeType = null, string agentUpgradeJobId = null, string agentUpgradeAttemptToVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmProtectedDiskDetails> protectedDisks = null, string isLastUpgradeSuccessful = null, bool? isAgentRegistrationSuccessfulAfterFailover = default(bool?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmMobilityAgentDetails mobilityAgentDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmLastAgentUpgradeErrorDetails> lastAgentUpgradeErrorDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmAgentUpgradeBlockingErrorDetails> agentUpgradeBlockingErrorDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmNicDetails> vmNics = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmDiscoveredProtectedVmDetails discoveredVmDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmSyncDetails InMageRcmSyncDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth? progressHealth = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth?), long? transferredBytes = default(long?), long? last15MinutesTransferredBytes = default(long?), string lastDataTransferTimeUtc = null, long? processedBytes = default(long?), System.DateTimeOffset? staStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshedOn = default(System.DateTimeOffset?), int? progressPercentage = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageReplicationDetails InMageReplicationDetails(string activeSiteType = null, int? sourceVmCpuCount = default(int?), int? sourceVmRamSizeInMB = default(int?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDiskDetails osDetails = null, string protectionStage = null, string vmId = null, string vmProtectionState = null, string vmProtectionStateDescription = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails resyncDetails = null, System.DateTimeOffset? retentionWindowStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? retentionWindowEndOn = default(System.DateTimeOffset?), double? compressedDataRateInMB = default(double?), double? uncompressedDataRateInMB = default(double?), long? rpoInSeconds = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageProtectedDiskDetails> protectedDisks = null, System.Net.IPAddress ipAddress = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), System.Guid? processServerId = default(System.Guid?), string masterTargetId = null, System.Collections.Generic.IReadOnlyDictionary<string, System.DateTimeOffset> consistencyPoints = null, string diskResized = null, string rebootAfterUpdateStatus = null, string multiVmGroupId = null, string multiVmGroupName = null, string multiVmSyncStatus = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAgentDetails agentDetails = null, string vCenterInfrastructureId = null, string infrastructureVmId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> vmNics = null, string discoveryType = null, Azure.Core.ResourceIdentifier azureStorageAccountId = null, System.Collections.Generic.IEnumerable<string> datastores = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> validationErrors = null, System.DateTimeOffset? lastRpoCalculatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdateReceivedOn = default(System.DateTimeOffset?), string replicaId = null, string osVersion = null, bool? isAdditionalStatsAvailable = default(bool?), long? totalDataTransferred = default(long?), string totalProgressHealth = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ManualActionTaskDetails ManualActionTaskDetails(string name = null, string instructions = null, string observation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MarsAgentDetails MarsAgentDetails(string id = null, string name = null, string biosId = null, Azure.Core.ResourceIdentifier fabricObjectId = null, string fqdn = null, string version = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? health = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MasterTargetServer MasterTargetServer(string id = null, System.Net.IPAddress ipAddress = null, string name = null, string osType = null, string agentVersion = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), string versionStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRetentionVolume> retentionVolumes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataStore> dataStores = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> validationErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null, int? diskCount = default(int?), string osVersion = null, System.DateTimeOffset? agentExpireOn = default(System.DateTimeOffset?), string marsAgentVersion = null, System.DateTimeOffset? marsAgentExpireOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails agentVersionDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails marsAgentVersionDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointData MigrationRecoveryPointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointProperties MigrationRecoveryPointProperties(System.DateTimeOffset? recoveryPointOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType? recoveryPointType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityServiceUpdate MobilityServiceUpdate(string version = null, string rebootStatus = null, string osType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.OSUpgradeSupportedVersions OSUpgradeSupportedVersions(string supportedSourceOSVersion = null, System.Collections.Generic.IEnumerable<string> supportedTargetOSVersions = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingData ProtectionContainerMappingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProperties ProtectionContainerMappingProperties(Azure.Core.ResourceIdentifier targetProtectionContainerId = null, string targetProtectionContainerFriendlyName = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProviderSpecificDetails providerSpecificDetails = null, string health = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrorDetails = null, Azure.Core.ResourceIdentifier policyId = null, string state = null, string sourceProtectionContainerFriendlyName = null, string sourceFabricFriendlyName = null, string targetFabricFriendlyName = null, string policyFriendlyName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PushInstallerDetails PushInstallerDetails(string id = null, string name = null, string biosId = null, Azure.Core.ResourceIdentifier fabricObjectId = null, string fqdn = null, string version = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? health = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmProxyDetails RcmProxyDetails(string id = null, string name = null, string biosId = null, Azure.Core.ResourceIdentifier fabricObjectId = null, string fqdn = null, string clientAuthenticationType = null, string version = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? health = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanA2ADetails RecoveryPlanA2ADetails(string primaryZone = null, string recoveryZone = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation primaryExtendedLocation = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation recoveryExtendedLocation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupTaskDetails RecoveryPlanGroupTaskDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AsrTask> childTasks = null, string name = null, string groupId = null, string rpGroupType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanShutdownGroupTaskDetails RecoveryPlanShutdownGroupTaskDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AsrTask> childTasks = null, string name = null, string groupId = null, string rpGroupType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAgentDetails ReplicationAgentDetails(string id = null, string name = null, string biosId = null, Azure.Core.ResourceIdentifier fabricObjectId = null, string fqdn = null, string version = null, System.DateTimeOffset? lastHeartbeatUtc = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? health = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultData ReplicationEligibilityResultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationEligibilityResultProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationEligibilityResultErrorInfo ReplicationEligibilityResultErrorInfo(string code = null, string message = null, string possibleCauses = null, string recommendedAction = null, string status = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationEligibilityResultProperties ReplicationEligibilityResultProperties(string clientRequestId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationEligibilityResultErrorInfo> errors = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemData ReplicationProtectedItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemProperties ReplicationProtectedItemProperties(string friendlyName = null, string protectedItemType = null, Azure.Core.ResourceIdentifier protectableItemId = null, string recoveryServicesProviderId = null, string primaryFabricFriendlyName = null, string primaryFabricProvider = null, string recoveryFabricFriendlyName = null, Azure.Core.ResourceIdentifier recoveryFabricId = null, string primaryProtectionContainerFriendlyName = null, string recoveryProtectionContainerFriendlyName = null, string protectionState = null, string protectionStateDescription = null, string activeLocation = null, string testFailoverState = null, string testFailoverStateDescription = null, string switchProviderState = null, string switchProviderStateDescription = null, System.Collections.Generic.IEnumerable<string> allowedOperations = null, string replicationHealth = null, string failoverHealth = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null, Azure.Core.ResourceIdentifier policyId = null, string policyFriendlyName = null, System.DateTimeOffset? lastSuccessfulFailoverOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSuccessfulTestFailoverOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentScenarioDetails currentScenario = null, Azure.Core.ResourceIdentifier failoverRecoveryPointId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings providerSpecificDetails = null, Azure.Core.ResourceIdentifier recoveryContainerId = null, System.Guid? eventCorrelationId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentData ReplicationProtectionIntentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentProperties ReplicationProtectionIntentProperties(string friendlyName = null, Azure.Core.ResourceIdentifier jobId = null, string jobState = null, bool? isActive = default(bool?), string createdOn = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentProviderSpecificSettings providerSpecificDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReprotectAgentDetails ReprotectAgentDetails(string id = null, string name = null, string biosId = null, Azure.Core.ResourceIdentifier fabricObjectId = null, string fqdn = null, string version = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? health = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null, int? protectedItemCount = default(int?), System.Collections.Generic.IEnumerable<string> accessibleDatastores = null, string vCenterId = null, System.DateTimeOffset? last = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResourceHealthSummary ResourceHealthSummary(int? resourceCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorSummary> issues = null, System.Collections.Generic.IReadOnlyDictionary<string, int> categorizedResourceCounts = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ScriptActionTaskDetails ScriptActionTaskDetails(string name = null, string path = null, string output = null, bool? isPrimarySideScript = default(bool?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentDetails SiteRecoveryAgentDetails(string agentId = null, string machineId = null, string biosId = null, string fqdn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentDiskDetails> disks = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentDiskDetails SiteRecoveryAgentDiskDetails(string diskId = null, string diskName = null, string isOSDisk = null, long? capacityInBytes = default(long?), int? lunId = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryAlertData SiteRecoveryAlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAlertProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAlertProperties SiteRecoveryAlertProperties(string sendToOwners = null, System.Collections.Generic.IEnumerable<string> customEmailAddresses = null, string locale = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryComputeSizeErrorDetails SiteRecoveryComputeSizeErrorDetails(string message = null, string severity = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataStore SiteRecoveryDataStore(string symbolicName = null, System.Guid? uuid = default(System.Guid?), string capacity = null, string freeSpace = null, string dataStoreType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails SiteRecoveryDiskDetails(long? maxSizeMB = default(long?), string vhdType = null, string vhdId = null, string vhdName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskVolumeDetails SiteRecoveryDiskVolumeDetails(string label = null, string name = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDraDetails SiteRecoveryDraDetails(string id = null, string name = null, string biosId = null, string version = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? health = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null, int? forwardProtectedItemCount = default(int?), int? reverseProtectedItemCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEncryptionDetails SiteRecoveryEncryptionDetails(string kekState = null, string kekCertThumbprint = null, System.DateTimeOffset? kekCertExpireOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryEventData SiteRecoveryEventData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProperties SiteRecoveryEventProperties(string eventCode = null, string description = null, string eventType = null, string affectedObjectFriendlyName = null, string affectedObjectCorrelationId = null, string severity = null, System.DateTimeOffset? occurredOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier fabricId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails providerSpecificDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventSpecificDetails eventSpecificDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryFabricData SiteRecoveryFabricData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryFabricProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryFabricProperties SiteRecoveryFabricProperties(string friendlyName = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEncryptionDetails encryptionDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEncryptionDetails rolloverEncryptionDetails = null, string internalIdentifier = null, string bcdrState = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails customDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrorDetails = null, string health = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryFabricProviderSpecificDetails SiteRecoveryFabricProviderSpecificDetails(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> containerIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AZoneDetails> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AExtendedLocationDetails> extendedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AFabricSpecificLocationDetails> locationDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryGroupTaskDetails SiteRecoveryGroupTaskDetails(string instanceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AsrTask> childTasks = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError SiteRecoveryHealthError(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryInnerHealthError> innerHealthErrors = null, string errorSource = null, string errorType = null, string errorLevel = null, string errorCategory = null, string errorCode = null, string summaryMessage = null, string errorMessage = null, string possibleCauses = null, string recommendedAction = null, System.DateTimeOffset? creationTimeUtc = default(System.DateTimeOffset?), string recoveryProviderErrorMessage = null, string entityId = null, string errorId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability? customerResolvability = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryInnerHealthError SiteRecoveryInnerHealthError(string errorSource = null, string errorType = null, string errorLevel = null, string errorCategory = null, string errorCode = null, string summaryMessage = null, string errorMessage = null, string possibleCauses = null, string recommendedAction = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string recoveryProviderErrorMessage = null, string entityId = null, string errorId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability? customerResolvability = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryJobData SiteRecoveryJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobDetails SiteRecoveryJobDetails(string instanceType = null, System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobEntity SiteRecoveryJobEntity(Azure.Core.ResourceIdentifier jobId = null, string jobFriendlyName = null, string targetObjectId = null, string targetObjectName = null, string targetInstanceType = null, string jobScenarioName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobErrorDetails SiteRecoveryJobErrorDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServiceError serviceErrorDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobProviderError providerErrorDetails = null, string errorLevel = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string taskId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobProperties SiteRecoveryJobProperties(string activityId = null, string scenarioName = null, string friendlyName = null, string state = null, string stateDescription = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AsrTask> tasks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobErrorDetails> errors = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> allowedActions = null, string targetObjectId = null, string targetObjectName = null, string targetInstanceType = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobDetails customDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobProviderError SiteRecoveryJobProviderError(int? errorCode = default(int?), string errorMessage = null, string errorId = null, string possibleCauses = null, string recommendedAction = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobStatusEventDetails SiteRecoveryJobStatusEventDetails(Azure.Core.ResourceIdentifier jobId = null, string jobFriendlyName = null, string jobStatus = null, string affectedObjectType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobTaskDetails SiteRecoveryJobTaskDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobEntity jobTask = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryLogicalNetworkData SiteRecoveryLogicalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLogicalNetworkProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLogicalNetworkProperties SiteRecoveryLogicalNetworkProperties(string friendlyName = null, string networkVirtualizationStatus = null, string logicalNetworkUsage = null, string logicalNetworkDefinitionsStatus = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryMigrationItemData SiteRecoveryMigrationItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationItemProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationItemProperties SiteRecoveryMigrationItemProperties(string machineName = null, Azure.Core.ResourceIdentifier policyId = null, string policyFriendlyName = null, string recoveryServicesProviderId = null, string replicationStatus = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState? migrationState = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState?), string migrationStateDescription = null, System.DateTimeOffset? lastTestMigrationOn = default(System.DateTimeOffset?), string lastTestMigrationStatus = null, System.DateTimeOffset? lastMigrationOn = default(System.DateTimeOffset?), string lastMigrationStatus = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState? testMigrateState = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState?), string testMigrateStateDescription = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? health = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation> allowedOperations = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentJobDetails currentJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CriticalJobHistoryDetails> criticalJobHistory = null, string eventCorrelationId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationProviderSpecificSettings providerSpecificDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkData SiteRecoveryNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryNetworkMappingData SiteRecoveryNetworkMappingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkMappingProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkMappingProperties SiteRecoveryNetworkMappingProperties(string state = null, string primaryNetworkFriendlyName = null, Azure.Core.ResourceIdentifier primaryNetworkId = null, string primaryFabricFriendlyName = null, string recoveryNetworkFriendlyName = null, Azure.Core.ResourceIdentifier recoveryNetworkId = null, Azure.Core.ResourceIdentifier recoveryFabricArmId = null, string recoveryFabricFriendlyName = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingFabricSpecificSettings fabricSpecificSettings = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryNetworkProperties SiteRecoveryNetworkProperties(string fabricType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySubnet> subnets = null, string friendlyName = null, string networkType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDetails SiteRecoveryOSDetails(string osType = null, string productType = null, string osEdition = null, string osVersion = null, string osMajorVersion = null, string osMinorVersion = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDiskDetails SiteRecoveryOSDiskDetails(string osVhdId = null, string osType = null, string vhdName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSVersionWrapper SiteRecoveryOSVersionWrapper(string version = null, string servicePack = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPointData SiteRecoveryPointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointProperties SiteRecoveryPointProperties(System.DateTimeOffset? recoveryPointOn = default(System.DateTimeOffset?), string recoveryPointType = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProviderSpecificRecoveryPointDetails providerSpecificDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryPolicyData SiteRecoveryPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPolicyProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPolicyProperties SiteRecoveryPolicyProperties(string friendlyName = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails providerSpecificDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServer SiteRecoveryProcessServer(string friendlyName = null, string id = null, System.Net.IPAddress ipAddress = null, string osType = null, string agentVersion = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), string versionStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityServiceUpdate> mobilityServiceUpdates = null, string hostId = null, string machineCount = null, string replicationPairCount = null, string systemLoad = null, string systemLoadStatus = null, string cpuLoad = null, string cpuLoadStatus = null, long? totalMemoryInBytes = default(long?), long? availableMemoryInBytes = default(long?), string memoryUsageStatus = null, long? totalSpaceInBytes = default(long?), long? availableSpaceInBytes = default(long?), string spaceUsageStatus = null, string psServiceStatus = null, System.DateTimeOffset? sslCertExpireOn = default(System.DateTimeOffset?), int? sslCertExpiryRemainingDays = default(int?), string osVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null, System.DateTimeOffset? agentExpireOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails agentVersionDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? health = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?), System.DateTimeOffset? psStatsRefreshOn = default(System.DateTimeOffset?), long? throughputUploadPendingDataInBytes = default(long?), long? throughputInMBps = default(long?), long? throughputInBytes = default(long?), string throughputStatus = null, string marsCommunicationStatus = null, string marsRegistrationStatus = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServerDetails SiteRecoveryProcessServerDetails(string id = null, string name = null, string biosId = null, Azure.Core.ResourceIdentifier fabricObjectId = null, string fqdn = null, System.Collections.Generic.IEnumerable<System.Net.IPAddress> ipAddresses = null, string version = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), long? totalMemoryInBytes = default(long?), long? availableMemoryInBytes = default(long?), long? usedMemoryInBytes = default(long?), double? memoryUsagePercentage = default(double?), long? totalSpaceInBytes = default(long?), long? availableSpaceInBytes = default(long?), long? usedSpaceInBytes = default(long?), double? freeSpacePercentage = default(double?), long? throughputUploadPendingDataInBytes = default(long?), long? throughputInBytes = default(long?), double? processorUsagePercentage = default(double?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? throughputStatus = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus?), long? systemLoad = default(long?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? systemLoadStatus = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? diskUsageStatus = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? memoryUsageStatus = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? processorUsageStatus = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? health = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null, int? protectedItemCount = default(int?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? historicHealth = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectableItemData SiteRecoveryProtectableItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectableItemProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectableItemProperties SiteRecoveryProtectableItemProperties(string friendlyName = null, string protectionStatus = null, Azure.Core.ResourceIdentifier replicationProtectedItemId = null, Azure.Core.ResourceIdentifier recoveryServicesProviderId = null, System.Collections.Generic.IEnumerable<string> protectionReadinessErrors = null, System.Collections.Generic.IEnumerable<string> supportedReplicationProviders = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationProviderSettings customDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryProtectionContainerData SiteRecoveryProtectionContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionContainerProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionContainerProperties SiteRecoveryProtectionContainerProperties(string fabricFriendlyName = null, string friendlyName = null, string fabricType = null, int? protectedItemCount = default(int?), string pairingStatus = null, string role = null, string fabricSpecificDetailsInstanceType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryRecoveryPlanData SiteRecoveryRecoveryPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRecoveryPlanProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRecoveryPlanProperties SiteRecoveryRecoveryPlanProperties(string friendlyName = null, Azure.Core.ResourceIdentifier primaryFabricId = null, string primaryFabricFriendlyName = null, Azure.Core.ResourceIdentifier recoveryFabricId = null, string recoveryFabricFriendlyName = null, string failoverDeploymentModel = null, System.Collections.Generic.IEnumerable<string> replicationProviders = null, System.Collections.Generic.IEnumerable<string> allowedOperations = null, System.DateTimeOffset? lastPlannedFailoverOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUnplannedFailoverOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTestFailoverOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentScenarioDetails currentScenario = null, string currentScenarioStatus = null, string currentScenarioStatusDescription = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPlanGroup> groups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificDetails> providerSpecificDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationAppliance SiteRecoveryReplicationAppliance(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplianceSpecificDetails siteRecoveryReplicationApplianceProviderSpecificDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRetentionVolume SiteRecoveryRetentionVolume(string volumeName = null, long? capacityInBytes = default(long?), long? freeSpaceInBytes = default(long?), int? thresholdPercentage = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRunAsAccount SiteRecoveryRunAsAccount(string accountId = null, string accountName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServiceError SiteRecoveryServiceError(string code = null, string message = null, string possibleCauses = null, string recommendedAction = null, string activityId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryServicesProviderData SiteRecoveryServicesProviderData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServicesProviderProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServicesProviderProperties SiteRecoveryServicesProviderProperties(string fabricType = null, string friendlyName = null, string providerVersion = null, string serverVersion = null, string providerVersionState = null, System.DateTimeOffset? providerVersionExpireOn = default(System.DateTimeOffset?), string fabricFriendlyName = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), string connectionStatus = null, int? protectedItemCount = default(int?), System.Collections.Generic.IEnumerable<string> allowedScenarios = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrorDetails = null, string draIdentifier = null, string machineId = null, string machineName = null, string biosId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails authenticationIdentityDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails resourceAccessIdentityDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails dataPlaneAuthenticationIdentityDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails providerVersionDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySubnet SiteRecoverySubnet(string name = null, string friendlyName = null, System.Collections.Generic.IEnumerable<string> addressList = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOperatingSystems SiteRecoverySupportedOperatingSystems(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOSProperty> supportedOSList = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOSDetails SiteRecoverySupportedOSDetails(string osName = null, string osType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSVersionWrapper> osVersions = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOSProperty SiteRecoverySupportedOSProperty(string instanceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOSDetails> supportedOS = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVaultSettingData SiteRecoveryVaultSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVaultSettingProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVaultSettingProperties SiteRecoveryVaultSettingProperties(Azure.Core.ResourceIdentifier migrationSolutionId = null, string vmwareToAzureProviderType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.SiteRecoveryVCenterData SiteRecoveryVCenterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVCenterProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVCenterProperties SiteRecoveryVCenterProperties(string friendlyName = null, string internalId = null, System.DateTimeOffset? lastHeartbeatReceivedOn = default(System.DateTimeOffset?), string discoveryStatus = null, System.Guid? processServerId = default(System.Guid?), System.Net.IPAddress ipAddress = null, string infrastructureId = null, string port = null, string runAsAccountId = null, string fabricArmResourceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> healthErrors = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails SiteRecoveryVersionDetails(string version = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus? status = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmDiskDetails SiteRecoveryVmDiskDetails(string vhdType = null, string vhdId = null, string diskId = null, string vhdName = null, string maxSizeMB = null, string targetDiskLocation = null, string targetDiskName = null, string lunId = null, Azure.Core.ResourceIdentifier diskEncryptionSetId = null, string customTargetDiskName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEndpoint SiteRecoveryVmEndpoint(string endpointName = null, int? privatePort = default(int?), int? publicPort = default(int?), string protocol = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmTaskDetails SiteRecoveryVmTaskDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobEntity jobTask = null, string skippedReason = null, string skippedReasonString = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationData StorageClassificationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string storageClassificationFriendlyName = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingData StorageClassificationMappingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier targetStorageClassificationId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionJobDetails SwitchProtectionJobDetails(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, Azure.Core.ResourceIdentifier newReplicationProtectedItemId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TargetComputeSize TargetComputeSize(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TargetComputeSizeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TargetComputeSizeProperties TargetComputeSizeProperties(string name = null, string friendlyName = null, int? cpuCoresCount = default(int?), int? vCpusAvailable = default(int?), double? memoryInGB = default(double?), int? maxDataDiskCount = default(int?), int? maxNicsCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryComputeSizeErrorDetails> errors = null, string highIopsSupported = null, System.Collections.Generic.IEnumerable<string> hyperVGenerations = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverJobDetails TestFailoverJobDetails(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, string testFailoverStatus = null, string comments = null, string networkName = null, string networkFriendlyName = null, string networkType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverReplicationProtectedItemDetails> protectedItemDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails VaultHealthDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthProperties VaultHealthProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> vaultErrors = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResourceHealthSummary protectedItemsHealth = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResourceHealthSummary fabricsHealth = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResourceHealthSummary containersHealth = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmmVmDetails VmmVmDetails(string sourceItemId = null, string generation = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDetails osDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails> diskDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus? hasPhysicalDisk = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus? hasFibreChannelAdapter = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus? hasSharedVhd = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus?), string hyperVHostId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails VmNicDetails(string nicId = null, string replicaNicId = null, Azure.Core.ResourceIdentifier sourceNicArmId = null, string vmNetworkName = null, Azure.Core.ResourceIdentifier recoveryVmNetworkId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVIPConfigDetails> ipConfigs = null, string selectionType = null, string recoveryNetworkSecurityGroupId = null, bool? isAcceleratedNetworkingOnRecoveryEnabled = default(bool?), Azure.Core.ResourceIdentifier tfoVmNetworkId = null, string tfoNetworkSecurityGroupId = null, bool? isAcceleratedNetworkingOnTfoEnabled = default(bool?), string recoveryNicName = null, string recoveryNicResourceGroupName = null, bool? isReuseExistingNicAllowed = default(bool?), string tfoRecoveryNicName = null, string tfoRecoveryNicResourceGroupName = null, bool? isTfoReuseExistingNicAllowed = default(bool?), string targetNicName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicUpdatesTaskDetails VmNicUpdatesTaskDetails(string vmId = null, string nicId = null, string name = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtEventDetails VMwareCbtEventDetails(string migrationItemName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtMigrationDetails VMwareCbtMigrationDetails(Azure.Core.ResourceIdentifier vmwareMachineId = null, string osType = null, string osName = null, string firmwareType = null, string targetGeneration = null, string licenseType = null, string sqlServerLicenseType = null, Azure.Core.ResourceIdentifier dataMoverRunAsAccountId = null, Azure.Core.ResourceIdentifier snapshotRunAsAccountId = null, Azure.Core.ResourceIdentifier storageAccountId = null, string targetVmName = null, string targetVmSize = null, string targetLocation = null, Azure.Core.ResourceIdentifier targetResourceGroupId = null, Azure.Core.ResourceIdentifier targetAvailabilitySetId = null, string targetAvailabilityZone = null, Azure.Core.ResourceIdentifier targetProximityPlacementGroupId = null, Azure.Core.ResourceIdentifier confidentialVmKeyVaultId = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtSecurityProfileProperties targetVmSecurityProfile = null, Azure.Core.ResourceIdentifier targetBootDiagnosticsStorageAccountId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> targetVmTags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtProtectedDiskDetails> protectedDisks = null, Azure.Core.ResourceIdentifier targetNetworkId = null, Azure.Core.ResourceIdentifier testNetworkId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtNicDetails> vmNics = null, System.Collections.Generic.IReadOnlyDictionary<string, string> targetNicTags = null, Azure.Core.ResourceIdentifier migrationRecoveryPointId = null, System.DateTimeOffset? lastRecoveryPointReceived = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier lastRecoveryPointId = null, int? initialSeedingProgressPercentage = default(int?), int? migrationProgressPercentage = default(int?), int? resyncProgressPercentage = default(int?), int? resumeProgressPercentage = default(int?), int? deltaSyncProgressPercentage = default(int?), string isCheckSumResyncCycle = null, long? initialSeedingRetryCount = default(long?), long? resyncRetryCount = default(long?), long? resumeRetryCount = default(long?), long? deltaSyncRetryCount = default(long?), string resyncRequired = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState? resyncState = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState?), string performAutoResync = null, System.Collections.Generic.IReadOnlyDictionary<string, string> seedDiskTags = null, System.Collections.Generic.IReadOnlyDictionary<string, string> targetDiskTags = null, System.Collections.Generic.IEnumerable<string> supportedOSVersions = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceMonitoringDetails applianceMonitoringDetails = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.GatewayOperationDetails gatewayOperationDetails = null, string operationName = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtMigrationDetails VMwareCbtMigrationDetails(Azure.Core.ResourceIdentifier vmwareMachineId, string osType, string osName, string firmwareType, string targetGeneration, string licenseType, string sqlServerLicenseType, Azure.Core.ResourceIdentifier dataMoverRunAsAccountId, Azure.Core.ResourceIdentifier snapshotRunAsAccountId, Azure.Core.ResourceIdentifier storageAccountId, string targetVmName, string targetVmSize, string targetLocation, Azure.Core.ResourceIdentifier targetResourceGroupId, Azure.Core.ResourceIdentifier targetAvailabilitySetId, string targetAvailabilityZone, Azure.Core.ResourceIdentifier targetProximityPlacementGroupId, Azure.Core.ResourceIdentifier confidentialVmKeyVaultId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtSecurityProfileProperties targetVmSecurityProfile, Azure.Core.ResourceIdentifier targetBootDiagnosticsStorageAccountId, System.Collections.Generic.IReadOnlyDictionary<string, string> targetVmTags, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtProtectedDiskDetails> protectedDisks, Azure.Core.ResourceIdentifier targetNetworkId, Azure.Core.ResourceIdentifier testNetworkId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtNicDetails> vmNics, System.Collections.Generic.IReadOnlyDictionary<string, string> targetNicTags, Azure.Core.ResourceIdentifier migrationRecoveryPointId, System.DateTimeOffset? lastRecoveryPointReceived, Azure.Core.ResourceIdentifier lastRecoveryPointId, int? initialSeedingProgressPercentage, int? migrationProgressPercentage, int? resyncProgressPercentage, int? resumeProgressPercentage, long? initialSeedingRetryCount, long? resyncRetryCount, long? resumeRetryCount, string resyncRequired, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState? resyncState, string performAutoResync, System.Collections.Generic.IReadOnlyDictionary<string, string> seedDiskTags, System.Collections.Generic.IReadOnlyDictionary<string, string> targetDiskTags, System.Collections.Generic.IEnumerable<string> supportedOSVersions) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtNicDetails VMwareCbtNicDetails(string nicId = null, string isPrimaryNic = null, System.Net.IPAddress sourceIPAddress = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? sourceIPAddressType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType?), Azure.Core.ResourceIdentifier sourceNetworkId = null, System.Net.IPAddress targetIPAddress = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? targetIPAddressType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType?), string targetSubnetName = null, Azure.Core.ResourceIdentifier testNetworkId = null, string testSubnetName = null, System.Net.IPAddress testIPAddress = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? testIPAddressType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType?), string targetNicName = null, string isSelectedForMigration = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtPolicyDetails VMwareCbtPolicyDetails(int? recoveryPointHistoryInMinutes = default(int?), int? appConsistentFrequencyInMinutes = default(int?), int? crashConsistentFrequencyInMinutes = default(int?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtProtectedDiskDetails VMwareCbtProtectedDiskDetails(string diskId, string diskName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? diskType, string diskPath, string isOSDisk, long? capacityInBytes, Azure.Core.ResourceIdentifier logStorageAccountId, string logStorageAccountSasSecretName, Azure.Core.ResourceIdentifier diskEncryptionSetId, string seedManagedDiskId, System.Uri seedBlobUri, string targetManagedDiskId, System.Uri targetBlobUri, string targetDiskName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtProtectedDiskDetails VMwareCbtProtectedDiskDetails(string diskId = null, string diskName = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? diskType = default(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType?), string diskPath = null, string isOSDisk = null, long? capacityInBytes = default(long?), Azure.Core.ResourceIdentifier logStorageAccountId = null, string logStorageAccountSasSecretName = null, Azure.Core.ResourceIdentifier diskEncryptionSetId = null, string seedManagedDiskId = null, System.Uri seedBlobUri = null, string targetManagedDiskId = null, System.Uri targetBlobUri = null, string targetDiskName = null, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.GatewayOperationDetails gatewayOperationDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtProtectionContainerMappingDetails VMwareCbtProtectionContainerMappingDetails(Azure.Core.ResourceIdentifier keyVaultId = null, System.Uri keyVaultUri = null, Azure.Core.ResourceIdentifier storageAccountId = null, string storageAccountSasSecretName = null, string serviceBusConnectionStringSecretName = null, string targetLocation = null, System.Collections.Generic.IReadOnlyDictionary<string, int> roleSizeToNicCountMap = null, System.Collections.Generic.IEnumerable<string> excludedSkus = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareDetails VMwareDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServer> processServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MasterTargetServer> masterTargetServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRunAsAccount> runAsAccounts = null, string replicationPairCount = null, string processServerCount = null, string agentCount = null, string protectedServers = null, string systemLoad = null, string systemLoadStatus = null, string cpuLoad = null, string cpuLoadStatus = null, long? totalMemoryInBytes = default(long?), long? availableMemoryInBytes = default(long?), string memoryUsageStatus = null, long? totalSpaceInBytes = default(long?), long? availableSpaceInBytes = default(long?), string spaceUsageStatus = null, string webLoad = null, string webLoadStatus = null, string databaseServerLoad = null, string databaseServerLoadStatus = null, string csServiceStatus = null, System.Net.IPAddress ipAddress = null, string agentVersion = null, string hostName = null, System.DateTimeOffset? lastHeartbeat = default(System.DateTimeOffset?), string versionStatus = null, System.DateTimeOffset? sslCertExpireOn = default(System.DateTimeOffset?), int? sslCertExpiryRemainingDays = default(int?), string psTemplateVersion = null, System.DateTimeOffset? agentExpireOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails agentVersionDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageFabricSwitchProviderBlockingErrorDetails> switchProviderBlockingErrorDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareV2FabricSpecificDetails VMwareV2FabricSpecificDetails(Azure.Core.ResourceIdentifier vmwareSiteId = null, Azure.Core.ResourceIdentifier physicalSiteId = null, Azure.Core.ResourceIdentifier migrationSolutionId = null, string serviceEndpoint = null, Azure.Core.ResourceIdentifier serviceResourceId = null, string serviceContainerId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServerDetails> processServers = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareVmDetails VMwareVmDetails(string agentGeneratedId = null, string agentInstalled = null, string osType = null, string agentVersion = null, System.Net.IPAddress ipAddress = null, string poweredOn = null, string vCenterInfrastructureId = null, string discoveryType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskDetails> diskDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> validationErrors = null) { throw null; }
    }
    public partial class AsrJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobDetails
    {
        internal AsrJobDetails() { }
    }
    public partial class AsrTask
    {
        internal AsrTask() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryTaskTypeDetails CustomDetails { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobErrorDetails> Errors { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryGroupTaskDetails GroupTaskCustomDetails { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
        public string StateDescription { get { throw null; } }
        public string TaskId { get { throw null; } }
        public string TaskType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationAccountAuthenticationType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationAccountAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType RunAsAccount { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType SystemAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationRunbookTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryTaskTypeDetails
    {
        internal AutomationRunbookTaskDetails() { }
        public string AccountName { get { throw null; } }
        public string CloudServiceName { get { throw null; } }
        public bool? IsPrimarySideScript { get { throw null; } }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } }
        public string JobOutput { get { throw null; } }
        public string Name { get { throw null; } }
        public string RunbookId { get { throw null; } }
        public string RunbookName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoProtectionOfDataDisk : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoProtectionOfDataDisk(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChurnOptionSelected : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChurnOptionSelected(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected High { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ChurnOptionSelected right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsistencyCheckTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryTaskTypeDetails
    {
        internal ConsistencyCheckTaskDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InconsistentVmDetails> VmDetails { get { throw null; } }
    }
    public partial class CriticalJobHistoryDetails
    {
        internal CriticalJobHistoryDetails() { }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } }
        public string JobName { get { throw null; } }
        public string JobStatus { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class CurrentJobDetails
    {
        internal CurrentJobDetails() { }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } }
        public string JobName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class CurrentScenarioDetails
    {
        internal CurrentScenarioDetails() { }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class DataStoreUtilizationDetails
    {
        internal DataStoreUtilizationDetails() { }
        public string DataStoreName { get { throw null; } }
        public long? TotalSnapshotsCreated { get { throw null; } }
        public long? TotalSnapshotsSupported { get { throw null; } }
    }
    public partial class DisableProtectionContent
    {
        public DisableProtectionContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionProperties Properties { get { throw null; } }
    }
    public partial class DisableProtectionProperties
    {
        public DisableProtectionProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason? DisableProtectionReason { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionProviderSpecificContent ReplicationProviderContent { get { throw null; } set { } }
    }
    public abstract partial class DisableProtectionProviderSpecificContent
    {
        protected DisableProtectionProviderSpecificContent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisableProtectionReason : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisableProtectionReason(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason MigrationComplete { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoverProtectableItemContent
    {
        public DiscoverProtectableItemContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiscoverProtectableItemProperties Properties { get { throw null; } set { } }
    }
    public partial class DiscoverProtectableItemProperties
    {
        public DiscoverProtectableItemProperties() { }
        public string FriendlyName { get { throw null; } set { } }
        public System.Net.IPAddress IPAddress { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
    }
    public partial class EnableMigrationProperties
    {
        public EnableMigrationProperties(Azure.Core.ResourceIdentifier policyId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationProviderSpecificContent providerSpecificDetails) { }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationProviderSpecificContent ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class EnableMigrationProviderSpecificContent
    {
        protected EnableMigrationProviderSpecificContent() { }
    }
    public partial class EnableProtectionProperties
    {
        public EnableProtectionProperties() { }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProtectableItemId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificContent ProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class EnableProtectionProviderSpecificContent
    {
        protected EnableProtectionProviderSpecificContent() { }
    }
    public partial class ExistingProtectionProfile : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionProfileCustomDetails
    {
        public ExistingProtectionProfile(string protectionProfileId) { }
        public string ProtectionProfileId { get { throw null; } set { } }
    }
    public partial class ExistingRecoveryAvailabilitySet : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryAvailabilitySetCustomDetails
    {
        public ExistingRecoveryAvailabilitySet() { }
        public Azure.Core.ResourceIdentifier RecoveryAvailabilitySetId { get { throw null; } set { } }
    }
    public partial class ExistingRecoveryProximityPlacementGroup : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryProximityPlacementGroupCustomDetails
    {
        public ExistingRecoveryProximityPlacementGroup() { }
        public Azure.Core.ResourceIdentifier RecoveryProximityPlacementGroupId { get { throw null; } set { } }
    }
    public partial class ExistingRecoveryResourceGroup : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryResourceGroupCustomDetails
    {
        public ExistingRecoveryResourceGroup() { }
        public Azure.Core.ResourceIdentifier RecoveryResourceGroupId { get { throw null; } set { } }
    }
    public partial class ExistingRecoveryVirtualNetwork : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryVirtualNetworkCustomDetails
    {
        public ExistingRecoveryVirtualNetwork(Azure.Core.ResourceIdentifier recoveryVirtualNetworkId) { }
        public string RecoverySubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryVirtualNetworkId { get { throw null; } set { } }
    }
    public partial class ExistingStorageAccount : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails
    {
        public ExistingStorageAccount(Azure.Core.ResourceIdentifier azureStorageAccountId) { }
        public Azure.Core.ResourceIdentifier AzureStorageAccountId { get { throw null; } set { } }
    }
    public partial class ExportJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobDetails
    {
        internal ExportJobDetails() { }
        public System.Uri BlobUri { get { throw null; } }
        public string SasToken { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportJobOutputSerializationType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportJobOutputSerializationType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType Excel { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType Json { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FabricReplicationGroupTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobTaskDetails
    {
        internal FabricReplicationGroupTaskDetails() { }
        public string SkippedReason { get { throw null; } }
        public string SkippedReasonString { get { throw null; } }
    }
    public abstract partial class FabricSpecificCreateNetworkMappingContent
    {
        protected FabricSpecificCreateNetworkMappingContent() { }
    }
    public abstract partial class FabricSpecificCreationContent
    {
        protected FabricSpecificCreationContent() { }
    }
    public abstract partial class FabricSpecificDetails
    {
        protected FabricSpecificDetails() { }
    }
    public abstract partial class FabricSpecificUpdateNetworkMappingContent
    {
        protected FabricSpecificUpdateNetworkMappingContent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailoverDeploymentModel : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailoverDeploymentModel(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel Classic { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel ResourceManager { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FailoverJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobDetails
    {
        internal FailoverJobDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverReplicationProtectedItemDetails> ProtectedItemDetails { get { throw null; } }
    }
    public partial class FailoverProcessServerContent
    {
        public FailoverProcessServerContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverProcessServerProperties Properties { get { throw null; } set { } }
    }
    public partial class FailoverProcessServerProperties
    {
        public FailoverProcessServerProperties() { }
        public string ContainerName { get { throw null; } set { } }
        public System.Guid? SourceProcessServerId { get { throw null; } set { } }
        public System.Guid? TargetProcessServerId { get { throw null; } set { } }
        public string UpdateType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VmsToMigrate { get { throw null; } }
    }
    public partial class FailoverReplicationProtectedItemDetails
    {
        internal FailoverReplicationProtectedItemDetails() { }
        public string FriendlyName { get { throw null; } }
        public string Name { get { throw null; } }
        public string NetworkConnectionStatus { get { throw null; } }
        public string NetworkFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } }
        public string Subnet { get { throw null; } }
        public string TestVmFriendlyName { get { throw null; } }
        public string TestVmName { get { throw null; } }
    }
    public partial class GatewayOperationDetails
    {
        internal GatewayOperationDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> DataStores { get { throw null; } }
        public string HostName { get { throw null; } }
        public int? ProgressPercentage { get { throw null; } }
        public string State { get { throw null; } }
        public long? TimeElapsed { get { throw null; } }
        public long? TimeRemaining { get { throw null; } }
        public long? UploadSpeed { get { throw null; } }
        public long? VMwareReadThroughput { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthErrorCategory : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthErrorCategory(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory AgentAutoUpdateArtifactDeleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory AgentAutoUpdateInfra { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory AgentAutoUpdateRunAsAccount { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory AgentAutoUpdateRunAsAccountExpired { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory AgentAutoUpdateRunAsAccountExpiry { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory Configuration { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory FabricInfrastructure { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory Replication { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory TestFailover { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory VersionExpiry { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthErrorCustomerResolvability : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthErrorCustomerResolvability(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability Allowed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability NotAllowed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthErrorSummary
    {
        internal HealthErrorSummary() { }
        public System.Collections.Generic.IReadOnlyList<string> AffectedResourceCorrelationIds { get { throw null; } }
        public string AffectedResourceSubtype { get { throw null; } }
        public string AffectedResourceType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCategory? Category { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity? Severity { get { throw null; } }
        public string SummaryCode { get { throw null; } }
        public string SummaryMessage { get { throw null; } }
    }
    public partial class HyperVFailoverIPConfigDetails
    {
        public HyperVFailoverIPConfigDetails() { }
        public string IPConfigName { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public bool? IsSeletedForFailover { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RecoveryLBBackendAddressPoolIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryPublicIPAddressId { get { throw null; } set { } }
        public System.Net.IPAddress RecoveryStaticIPAddress { get { throw null; } set { } }
        public string RecoverySubnetName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TfoLBBackendAddressPoolIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier TfoPublicIPAddressId { get { throw null; } set { } }
        public System.Net.IPAddress TfoStaticIPAddress { get { throw null; } set { } }
        public string TfoSubnetName { get { throw null; } set { } }
    }
    public partial class HyperVHostDetails
    {
        internal HyperVHostDetails() { }
        public string Id { get { throw null; } }
        public string MarsAgentVersion { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class HyperVIPConfigDetails
    {
        internal HyperVIPConfigDetails() { }
        public string IPAddressType { get { throw null; } }
        public bool? IsPrimary { get { throw null; } }
        public bool? IsSeletedForFailover { get { throw null; } }
        public string Name { get { throw null; } }
        public string RecoveryIPAddressType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecoveryLBBackendAddressPoolIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryPublicIPAddressId { get { throw null; } }
        public System.Net.IPAddress RecoveryStaticIPAddress { get { throw null; } }
        public string RecoverySubnetName { get { throw null; } }
        public System.Net.IPAddress StaticIPAddress { get { throw null; } }
        public string SubnetName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TfoLBBackendAddressPoolIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier TfoPublicIPAddressId { get { throw null; } }
        public System.Net.IPAddress TfoStaticIPAddress { get { throw null; } }
        public string TfoSubnetName { get { throw null; } }
    }
    public partial class HyperVReplica2012EventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails
    {
        internal HyperVReplica2012EventDetails() { }
        public string ContainerName { get { throw null; } }
        public string FabricName { get { throw null; } }
        public string RemoteContainerName { get { throw null; } }
        public string RemoteFabricName { get { throw null; } }
    }
    public partial class HyperVReplica2012R2EventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails
    {
        internal HyperVReplica2012R2EventDetails() { }
        public string ContainerName { get { throw null; } }
        public string FabricName { get { throw null; } }
        public string RemoteContainerName { get { throw null; } }
        public string RemoteFabricName { get { throw null; } }
    }
    public partial class HyperVReplicaAzureApplyRecoveryPointContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointProviderSpecificContent
    {
        public HyperVReplicaAzureApplyRecoveryPointContent() { }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureDiskDetails
    {
        public HyperVReplicaAzureDiskDetails() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? DiskType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureEnableProtectionContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificContent
    {
        public HyperVReplicaAzureEnableProtectionContent() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisksToInclude { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureDiskDetails> DisksToIncludeForManagedDisks { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? DiskType { get { throw null; } set { } }
        public string EnableRdpOnTargetOption { get { throw null; } set { } }
        public string HyperVHostVmId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SeedManagedDiskTags { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureSubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureV1ResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureV2ResourceGroupId { get { throw null; } set { } }
        public string TargetAzureVmName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetStorageAccountId { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public string UseManagedDisks { get { throw null; } set { } }
        public string UseManagedDisksForReplication { get { throw null; } set { } }
        public string VhdId { get { throw null; } set { } }
        public string VmName { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails
    {
        internal HyperVReplicaAzureEventDetails() { }
        public string ContainerName { get { throw null; } }
        public string FabricName { get { throw null; } }
        public string RemoteContainerName { get { throw null; } }
    }
    public partial class HyperVReplicaAzureFailbackProviderContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverProviderSpecificFailoverContent
    {
        public HyperVReplicaAzureFailbackProviderContent() { }
        public string DataSyncOption { get { throw null; } set { } }
        public string ProviderIdForAlternateRecovery { get { throw null; } set { } }
        public string RecoveryVmCreationOption { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureManagedDiskDetails
    {
        internal HyperVReplicaAzureManagedDiskDetails() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string ReplicaDiskType { get { throw null; } }
        public string SeedManagedDiskId { get { throw null; } }
    }
    public partial class HyperVReplicaAzurePlannedFailoverProviderContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverProviderSpecificFailoverContent
    {
        public HyperVReplicaAzurePlannedFailoverProviderContent() { }
        public string OSUpgradeVersion { get { throw null; } set { } }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzurePolicyContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent
    {
        public HyperVReplicaAzurePolicyContent() { }
        public int? ApplicationConsistentSnapshotFrequencyInHours { get { throw null; } set { } }
        public string OnlineReplicationStartTime { get { throw null; } set { } }
        public int? RecoveryPointHistoryDuration { get { throw null; } set { } }
        public int? ReplicationInterval { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StorageAccounts { get { throw null; } }
    }
    public partial class HyperVReplicaAzurePolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal HyperVReplicaAzurePolicyDetails() { }
        public Azure.Core.ResourceIdentifier ActiveStorageAccountId { get { throw null; } }
        public int? ApplicationConsistentSnapshotFrequencyInHours { get { throw null; } }
        public string Encryption { get { throw null; } }
        public string OnlineReplicationStartTime { get { throw null; } }
        public int? RecoveryPointHistoryDurationInHours { get { throw null; } }
        public int? ReplicationInterval { get { throw null; } }
    }
    public partial class HyperVReplicaAzureReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal HyperVReplicaAzureReplicationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.OSUpgradeSupportedVersions> AllAvailableOSUpgradeConfigurations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmDiskDetails> AzureVmDiskDetails { get { throw null; } }
        public string EnableRdpOnTargetOption { get { throw null; } }
        public string Encryption { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails InitialReplicationDetails { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
        public System.DateTimeOffset? LastReplicatedOn { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDetails OSDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureManagedDiskDetails> ProtectedManagedDisks { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAvailabilitySetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAzureLogStorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAzureResourceGroupId { get { throw null; } }
        public string RecoveryAzureStorageAccount { get { throw null; } }
        public string RecoveryAzureVmName { get { throw null; } }
        public string RecoveryAzureVmSize { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SeedManagedDiskTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier SelectedRecoveryAzureNetworkId { get { throw null; } }
        public string SelectedSourceNicId { get { throw null; } }
        public int? SourceVmCpuCount { get { throw null; } }
        public int? SourceVmRamSizeInMB { get { throw null; } }
        public string SqlServerLicenseType { get { throw null; } }
        public string TargetAvailabilityZone { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetNicTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetVmTags { get { throw null; } }
        public string UseManagedDisks { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class HyperVReplicaAzureReprotectContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificContent
    {
        public HyperVReplicaAzureReprotectContent() { }
        public string HyperVHostVmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public string VhdId { get { throw null; } set { } }
        public string VmName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVReplicaAzureRpRecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVReplicaAzureRpRecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType Latest { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType LatestApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType LatestProcessed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HyperVReplicaAzureTestFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificContent
    {
        public HyperVReplicaAzureTestFailoverContent() { }
        public string OSUpgradeVersion { get { throw null; } set { } }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureUnplannedFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificContent
    {
        public HyperVReplicaAzureUnplannedFailoverContent() { }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureUpdateReplicationProtectedItemContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderContent
    {
        public HyperVReplicaAzureUpdateReplicationProtectedItemContent() { }
        public System.Collections.Generic.IDictionary<string, string> DiskIdToDiskEncryptionMap { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAzureV1ResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryAzureV2ResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public string UseManagedDisks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateDiskContent> VmDisks { get { throw null; } }
    }
    public partial class HyperVReplicaBaseEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails
    {
        internal HyperVReplicaBaseEventDetails() { }
        public string ContainerName { get { throw null; } }
        public string FabricName { get { throw null; } }
        public string RemoteContainerName { get { throw null; } }
        public string RemoteFabricName { get { throw null; } }
    }
    public partial class HyperVReplicaBasePolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal HyperVReplicaBasePolicyDetails() { }
        public int? AllowedAuthenticationType { get { throw null; } }
        public int? ApplicationConsistentSnapshotFrequencyInHours { get { throw null; } }
        public string Compression { get { throw null; } }
        public string InitialReplicationMethod { get { throw null; } }
        public string OfflineReplicationExportPath { get { throw null; } }
        public string OfflineReplicationImportPath { get { throw null; } }
        public string OnlineReplicationStartTime { get { throw null; } }
        public int? RecoveryPoints { get { throw null; } }
        public string ReplicaDeletionOption { get { throw null; } }
        public int? ReplicationPort { get { throw null; } }
    }
    public partial class HyperVReplicaBaseReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal HyperVReplicaBaseReplicationDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails InitialReplicationDetails { get { throw null; } }
        public System.DateTimeOffset? LastReplicatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails> VmDiskDetails { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class HyperVReplicaBluePolicyContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaPolicyContent
    {
        public HyperVReplicaBluePolicyContent() { }
        public int? ReplicationFrequencyInSeconds { get { throw null; } set { } }
    }
    public partial class HyperVReplicaBluePolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal HyperVReplicaBluePolicyDetails() { }
        public int? AllowedAuthenticationType { get { throw null; } }
        public int? ApplicationConsistentSnapshotFrequencyInHours { get { throw null; } }
        public string Compression { get { throw null; } }
        public string InitialReplicationMethod { get { throw null; } }
        public string OfflineReplicationExportPath { get { throw null; } }
        public string OfflineReplicationImportPath { get { throw null; } }
        public string OnlineReplicationStartTime { get { throw null; } }
        public int? RecoveryPoints { get { throw null; } }
        public string ReplicaDeletionOption { get { throw null; } }
        public int? ReplicationFrequencyInSeconds { get { throw null; } }
        public int? ReplicationPort { get { throw null; } }
    }
    public partial class HyperVReplicaBlueReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal HyperVReplicaBlueReplicationDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails InitialReplicationDetails { get { throw null; } }
        public System.DateTimeOffset? LastReplicatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails> VmDiskDetails { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class HyperVReplicaPolicyContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent
    {
        public HyperVReplicaPolicyContent() { }
        public int? AllowedAuthenticationType { get { throw null; } set { } }
        public int? ApplicationConsistentSnapshotFrequencyInHours { get { throw null; } set { } }
        public string Compression { get { throw null; } set { } }
        public string InitialReplicationMethod { get { throw null; } set { } }
        public string OfflineReplicationExportPath { get { throw null; } set { } }
        public string OfflineReplicationImportPath { get { throw null; } set { } }
        public string OnlineReplicationStartTime { get { throw null; } set { } }
        public int? RecoveryPoints { get { throw null; } set { } }
        public string ReplicaDeletion { get { throw null; } set { } }
        public int? ReplicationPort { get { throw null; } set { } }
    }
    public partial class HyperVReplicaPolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal HyperVReplicaPolicyDetails() { }
        public int? AllowedAuthenticationType { get { throw null; } }
        public int? ApplicationConsistentSnapshotFrequencyInHours { get { throw null; } }
        public string Compression { get { throw null; } }
        public string InitialReplicationMethod { get { throw null; } }
        public string OfflineReplicationExportPath { get { throw null; } }
        public string OfflineReplicationImportPath { get { throw null; } }
        public string OnlineReplicationStartTime { get { throw null; } }
        public int? RecoveryPoints { get { throw null; } }
        public string ReplicaDeletionOption { get { throw null; } }
        public int? ReplicationPort { get { throw null; } }
    }
    public partial class HyperVReplicaReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal HyperVReplicaReplicationDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails InitialReplicationDetails { get { throw null; } }
        public System.DateTimeOffset? LastReplicatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails> VmDiskDetails { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class HyperVSiteDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal HyperVSiteDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVHostDetails> HyperVHosts { get { throw null; } }
    }
    public partial class HyperVVmDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationProviderSettings
    {
        internal HyperVVmDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskDetails> DiskDetails { get { throw null; } }
        public string Generation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus? HasFibreChannelAdapter { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus? HasPhysicalDisk { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus? HasSharedVhd { get { throw null; } }
        public string HyperVHostId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDetails OSDetails { get { throw null; } }
        public string SourceItemId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVVmDiskPresenceStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVVmDiskPresenceStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus NotPresent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus Present { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDiskPresenceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityProviderContent
    {
        public IdentityProviderContent(System.Guid tenantId, string applicationId, string objectId, string audience, string aadAuthority) { }
        public string AadAuthority { get { throw null; } }
        public string ApplicationId { get { throw null; } }
        public string Audience { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public System.Guid TenantId { get { throw null; } }
    }
    public partial class IdentityProviderDetails
    {
        internal IdentityProviderDetails() { }
        public string AadAuthority { get { throw null; } }
        public string ApplicationId { get { throw null; } }
        public string Audience { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    public partial class InconsistentVmDetails
    {
        internal InconsistentVmDetails() { }
        public string CloudName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Details { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ErrorIds { get { throw null; } }
        public string VmName { get { throw null; } }
    }
    public partial class InitialReplicationDetails
    {
        internal InitialReplicationDetails() { }
        public string InitialReplicationProgressPercentage { get { throw null; } }
        public string InitialReplicationType { get { throw null; } }
    }
    public partial class InlineWorkflowTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryGroupTaskDetails
    {
        internal InlineWorkflowTaskDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> WorkflowIds { get { throw null; } }
    }
    public partial class InMageAgentDetails
    {
        internal InMageAgentDetails() { }
        public System.DateTimeOffset? AgentExpireOn { get { throw null; } }
        public string AgentUpdateStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string PostUpdateRebootStatus { get { throw null; } }
    }
    public partial class InMageAzureV2ApplyRecoveryPointContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointProviderSpecificContent
    {
        public InMageAzureV2ApplyRecoveryPointContent() { }
    }
    public partial class InMageAzureV2DiskDetails
    {
        public InMageAzureV2DiskDetails() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? DiskType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } set { } }
    }
    public partial class InMageAzureV2EnableProtectionContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificContent
    {
        public InMageAzureV2EnableProtectionContent() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2DiskDetails> DisksToInclude { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? DiskType { get { throw null; } set { } }
        public string EnableRdpOnTargetOption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } set { } }
        public string MasterTargetId { get { throw null; } set { } }
        public string MultiVmGroupId { get { throw null; } set { } }
        public string MultiVmGroupName { get { throw null; } set { } }
        public System.Guid? ProcessServerId { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SeedManagedDiskTags { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureSubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureV1ResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureV2ResourceGroupId { get { throw null; } set { } }
        public string TargetAzureVmName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
    }
    public partial class InMageAzureV2EventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails
    {
        internal InMageAzureV2EventDetails() { }
        public string Category { get { throw null; } }
        public string Component { get { throw null; } }
        public string CorrectiveAction { get { throw null; } }
        public string Details { get { throw null; } }
        public string EventType { get { throw null; } }
        public string SiteName { get { throw null; } }
        public string Summary { get { throw null; } }
    }
    public partial class InMageAzureV2ManagedDiskDetails
    {
        internal InMageAzureV2ManagedDiskDetails() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string ReplicaDiskType { get { throw null; } }
        public string SeedManagedDiskId { get { throw null; } }
        public string TargetDiskName { get { throw null; } }
    }
    public partial class InMageAzureV2PolicyContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent
    {
        public InMageAzureV2PolicyContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus multiVmSyncStatus) { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } set { } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } set { } }
    }
    public partial class InMageAzureV2PolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal InMageAzureV2PolicyDetails() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } }
        public string MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } }
    }
    public partial class InMageAzureV2ProtectedDiskDetails
    {
        internal InMageAzureV2ProtectedDiskDetails() { }
        public long? DiskCapacityInBytes { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskResized { get { throw null; } }
        public long? FileSystemCapacityInBytes { get { throw null; } }
        public string HealthErrorCode { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public string ProgressHealth { get { throw null; } }
        public string ProgressStatus { get { throw null; } }
        public string ProtectionStage { get { throw null; } }
        public double? PSDataInMegaBytes { get { throw null; } }
        public long? ResyncDurationInSeconds { get { throw null; } }
        public long? ResyncLast15MinutesTransferredBytes { get { throw null; } }
        public System.DateTimeOffset? ResyncLastDataTransferOn { get { throw null; } }
        public long? ResyncProcessedBytes { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public string ResyncRequired { get { throw null; } }
        public System.DateTimeOffset? ResyncStartOn { get { throw null; } }
        public long? ResyncTotalTransferredBytes { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public long? SecondsToTakeSwitchProvider { get { throw null; } }
        public double? SourceDataInMegaBytes { get { throw null; } }
        public double? TargetDataInMegaBytes { get { throw null; } }
    }
    public partial class InMageAzureV2RecoveryPointDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProviderSpecificRecoveryPointDetails
    {
        internal InMageAzureV2RecoveryPointDetails() { }
        public string IsMultiVmSyncPoint { get { throw null; } }
    }
    public partial class InMageAzureV2ReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal InMageAzureV2ReplicationDetails() { }
        public System.DateTimeOffset? AgentExpireOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.OSUpgradeSupportedVersions> AllAvailableOSUpgradeConfigurations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmDiskDetails> AzureVmDiskDetails { get { throw null; } }
        public string AzureVmGeneration { get { throw null; } }
        public double? CompressedDataRateInMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Datastores { get { throw null; } }
        public string DiscoveryType { get { throw null; } }
        public string DiskResized { get { throw null; } }
        public string EnableRdpOnTargetOption { get { throw null; } }
        public string FirmwareType { get { throw null; } }
        public string InfrastructureVmId { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public bool? IsAdditionalStatsAvailable { get { throw null; } }
        public string IsAgentUpdateRequired { get { throw null; } }
        public string IsRebootAfterUpdateRequired { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeat { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdateReceivedOn { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public string MasterTargetId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public string MultiVmSyncStatus { get { throw null; } }
        public string OSDiskId { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSType { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public System.Guid? ProcessServerId { get { throw null; } }
        public string ProcessServerName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ManagedDiskDetails> ProtectedManagedDisks { get { throw null; } }
        public string ProtectionStage { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAvailabilitySetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAzureLogStorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryAzureResourceGroupId { get { throw null; } }
        public string RecoveryAzureStorageAccount { get { throw null; } }
        public string RecoveryAzureVmName { get { throw null; } }
        public string RecoveryAzureVmSize { get { throw null; } }
        public string ReplicaId { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SeedManagedDiskTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier SelectedRecoveryAzureNetworkId { get { throw null; } }
        public string SelectedSourceNicId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SelectedTfoAzureNetworkId { get { throw null; } }
        public int? SourceVmCpuCount { get { throw null; } }
        public int? SourceVmRamSizeInMB { get { throw null; } }
        public string SqlServerLicenseType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedOSVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderBlockingErrorDetails> SwitchProviderBlockingErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderDetails SwitchProviderDetails { get { throw null; } }
        public string TargetAvailabilityZone { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetNicTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } }
        public string TargetVmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetVmTags { get { throw null; } }
        public long? TotalDataTransferred { get { throw null; } }
        public string TotalProgressHealth { get { throw null; } }
        public double? UncompressedDataRateInMB { get { throw null; } }
        public string UseManagedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> ValidationErrors { get { throw null; } }
        public string VCenterInfrastructureId { get { throw null; } }
        public string VhdName { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class InMageAzureV2ReprotectContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificContent
    {
        public InMageAzureV2ReprotectContent() { }
        public System.Collections.Generic.IList<string> DisksToInclude { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } set { } }
        public string MasterTargetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public System.Guid? ProcessServerId { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
    }
    public partial class InMageAzureV2SwitchProviderBlockingErrorDetails
    {
        internal InMageAzureV2SwitchProviderBlockingErrorDetails() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorMessageParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorTags { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
    }
    public partial class InMageAzureV2SwitchProviderContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProviderSpecificContent
    {
        public InMageAzureV2SwitchProviderContent(Azure.Core.ResourceIdentifier targetVaultId, Azure.Core.ResourceIdentifier targetFabricId, string targetApplianceId) { }
        public string TargetApplianceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetFabricId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetVaultId { get { throw null; } }
    }
    public partial class InMageAzureV2SwitchProviderDetails
    {
        internal InMageAzureV2SwitchProviderDetails() { }
        public string TargetApplianceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetFabricId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetVaultId { get { throw null; } }
    }
    public partial class InMageAzureV2TestFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificContent
    {
        public InMageAzureV2TestFailoverContent() { }
        public string OSUpgradeVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
    }
    public partial class InMageAzureV2UnplannedFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificContent
    {
        public InMageAzureV2UnplannedFailoverContent() { }
        public string OSUpgradeVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
    }
    public partial class InMageAzureV2UpdateReplicationProtectedItemContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderContent
    {
        public InMageAzureV2UpdateReplicationProtectedItemContent() { }
        public Azure.Core.ResourceIdentifier RecoveryAzureV1ResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryAzureV2ResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public string UseManagedDisks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateDiskContent> VmDisks { get { throw null; } }
    }
    public partial class InMageBasePolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal InMageBasePolicyDetails() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } }
        public string MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } }
    }
    public partial class InMageDisableProtectionProviderSpecificContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionProviderSpecificContent
    {
        public InMageDisableProtectionProviderSpecificContent() { }
        public string ReplicaVmDeletionStatus { get { throw null; } set { } }
    }
    public partial class InMageDiskDetails
    {
        internal InMageDiskDetails() { }
        public string DiskConfiguration { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskSizeInMB { get { throw null; } }
        public string DiskType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskVolumeDetails> VolumeList { get { throw null; } }
    }
    public partial class InMageDiskExclusionContent
    {
        public InMageDiskExclusionContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskSignatureExclusionOptions> DiskSignatureOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageVolumeExclusionOptions> VolumeOptions { get { throw null; } }
    }
    public partial class InMageDiskSignatureExclusionOptions
    {
        public InMageDiskSignatureExclusionOptions() { }
        public string DiskSignature { get { throw null; } set { } }
    }
    public partial class InMageEnableProtectionContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificContent
    {
        public InMageEnableProtectionContent(string masterTargetId, System.Guid processServerId, string retentionDrive, string multiVmGroupId, string multiVmGroupName) { }
        public string DatastoreName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskExclusionContent DiskExclusionContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisksToInclude { get { throw null; } }
        public string MasterTargetId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public System.Guid ProcessServerId { get { throw null; } }
        public string RetentionDrive { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
        public string VmFriendlyName { get { throw null; } set { } }
    }
    public partial class InMageFabricSwitchProviderBlockingErrorDetails
    {
        internal InMageFabricSwitchProviderBlockingErrorDetails() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorMessageParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorTags { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
    }
    public partial class InMagePolicyContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent
    {
        public InMagePolicyContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus multiVmSyncStatus) { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } set { } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } set { } }
    }
    public partial class InMagePolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal InMagePolicyDetails() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } }
        public string MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } }
    }
    public partial class InMageProtectedDiskDetails
    {
        internal InMageProtectedDiskDetails() { }
        public long? DiskCapacityInBytes { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskResized { get { throw null; } }
        public long? FileSystemCapacityInBytes { get { throw null; } }
        public string HealthErrorCode { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public string ProgressHealth { get { throw null; } }
        public string ProgressStatus { get { throw null; } }
        public string ProtectionStage { get { throw null; } }
        public double? PSDataInMB { get { throw null; } }
        public long? ResyncDurationInSeconds { get { throw null; } }
        public long? ResyncLast15MinutesTransferredBytes { get { throw null; } }
        public System.DateTimeOffset? ResyncLastDataTransferTimeUTC { get { throw null; } }
        public long? ResyncProcessedBytes { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public string ResyncRequired { get { throw null; } }
        public System.DateTimeOffset? ResyncStartOn { get { throw null; } }
        public long? ResyncTotalTransferredBytes { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public double? SourceDataInMB { get { throw null; } }
        public double? TargetDataInMB { get { throw null; } }
    }
    public partial class InMageRcmAgentUpgradeBlockingErrorDetails
    {
        internal InMageRcmAgentUpgradeBlockingErrorDetails() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorMessageParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorTags { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
    }
    public partial class InMageRcmApplianceDetails
    {
        internal InMageRcmApplianceDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDraDetails Dra { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricArmId { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MarsAgentDetails MarsAgent { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServerDetails ProcessServer { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PushInstallerDetails PushInstaller { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmProxyDetails RcmProxy { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAgentDetails ReplicationAgent { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReprotectAgentDetails ReprotectAgent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFabricSwitchProviderBlockingErrorDetails> SwitchProviderBlockingErrorDetails { get { throw null; } }
    }
    public partial class InMageRcmApplianceSpecificDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplianceSpecificDetails
    {
        internal InMageRcmApplianceSpecificDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmApplianceDetails> Appliances { get { throw null; } }
    }
    public partial class InMageRcmApplyRecoveryPointContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointProviderSpecificContent
    {
        public InMageRcmApplyRecoveryPointContent(Azure.Core.ResourceIdentifier recoveryPointId) { }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } }
    }
    public partial class InMageRcmDiscoveredProtectedVmDetails
    {
        internal InMageRcmDiscoveredProtectedVmDetails() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Datastores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> IPAddresses { get { throw null; } }
        public bool? IsDeleted { get { throw null; } }
        public System.DateTimeOffset? LastDiscoveryTimeInUtc { get { throw null; } }
        public string OSName { get { throw null; } }
        public string PowerStatus { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string VCenterFqdn { get { throw null; } }
        public string VCenterId { get { throw null; } }
        public string VmFqdn { get { throw null; } }
        public string VMwareToolsStatus { get { throw null; } }
    }
    public partial class InMageRcmDiskContent
    {
        public InMageRcmDiskContent(string diskId, Azure.Core.ResourceIdentifier logStorageAccountId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType diskType) { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType DiskType { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } }
    }
    public partial class InMageRcmDisksDefaultContent
    {
        public InMageRcmDisksDefaultContent(Azure.Core.ResourceIdentifier logStorageAccountId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType diskType) { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType DiskType { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } }
    }
    public partial class InMageRcmEnableProtectionContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificContent
    {
        public InMageRcmEnableProtectionContent(string fabricDiscoveryMachineId, Azure.Core.ResourceIdentifier targetResourceGroupId, System.Guid processServerId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmDisksDefaultContent DisksDefault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmDiskContent> DisksToInclude { get { throw null; } }
        public string FabricDiscoveryMachineId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType? LicenseType { get { throw null; } set { } }
        public string MultiVmGroupName { get { throw null; } set { } }
        public System.Guid ProcessServerId { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetBootDiagnosticsStorageAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } }
        public string TargetSubnetName { get { throw null; } set { } }
        public string TargetVmName { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TestNetworkId { get { throw null; } set { } }
        public string TestSubnetName { get { throw null; } set { } }
    }
    public partial class InMageRcmEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails
    {
        internal InMageRcmEventDetails() { }
        public string ApplianceName { get { throw null; } }
        public string ComponentDisplayName { get { throw null; } }
        public string FabricName { get { throw null; } }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } }
        public string LatestAgentVersion { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string ServerType { get { throw null; } }
        public string VmName { get { throw null; } }
    }
    public partial class InMageRcmFabricCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreationContent
    {
        public InMageRcmFabricCreationContent(Azure.Core.ResourceIdentifier vmwareSiteId, Azure.Core.ResourceIdentifier physicalSiteId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderContent sourceAgentIdentity) { }
        public Azure.Core.ResourceIdentifier PhysicalSiteId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderContent SourceAgentIdentity { get { throw null; } }
        public Azure.Core.ResourceIdentifier VMwareSiteId { get { throw null; } }
    }
    public partial class InMageRcmFabricSpecificDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal InMageRcmFabricSpecificDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentDetails> AgentDetails { get { throw null; } }
        public System.Uri ControlPlaneUri { get { throw null; } }
        public System.Uri DataPlaneUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDraDetails> Dras { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MarsAgentDetails> MarsAgents { get { throw null; } }
        public Azure.Core.ResourceIdentifier PhysicalSiteId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServerDetails> ProcessServers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PushInstallerDetails> PushInstallers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmProxyDetails> RcmProxies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAgentDetails> ReplicationAgents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReprotectAgentDetails> ReprotectAgents { get { throw null; } }
        public string ServiceContainerId { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceResourceId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails SourceAgentIdentityDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VMwareSiteId { get { throw null; } }
    }
    public partial class InMageRcmFabricSwitchProviderBlockingErrorDetails
    {
        internal InMageRcmFabricSwitchProviderBlockingErrorDetails() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorMessageParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorTags { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
    }
    public partial class InMageRcmFailbackDiscoveredProtectedVmDetails
    {
        internal InMageRcmFailbackDiscoveredProtectedVmDetails() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Datastores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> IPAddresses { get { throw null; } }
        public bool? IsDeleted { get { throw null; } }
        public System.DateTimeOffset? LastDiscoveredOn { get { throw null; } }
        public string OSName { get { throw null; } }
        public string PowerStatus { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string VCenterFqdn { get { throw null; } }
        public string VCenterId { get { throw null; } }
        public string VmFqdn { get { throw null; } }
        public string VMwareToolsStatus { get { throw null; } }
    }
    public partial class InMageRcmFailbackEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails
    {
        internal InMageRcmFailbackEventDetails() { }
        public string ApplianceName { get { throw null; } }
        public string ComponentDisplayName { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string ServerType { get { throw null; } }
        public string VmName { get { throw null; } }
    }
    public partial class InMageRcmFailbackMobilityAgentDetails
    {
        internal InMageRcmFailbackMobilityAgentDetails() { }
        public System.DateTimeOffset? AgentVersionExpireOn { get { throw null; } }
        public string DriverVersion { get { throw null; } }
        public System.DateTimeOffset? DriverVersionExpireOn { get { throw null; } }
        public string IsUpgradeable { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string LatestUpgradableVersionWithoutReboot { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason> ReasonsBlockingUpgrade { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class InMageRcmFailbackNicDetails
    {
        internal InMageRcmFailbackNicDetails() { }
        public string AdapterType { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string NetworkName { get { throw null; } }
        public System.Net.IPAddress SourceIPAddress { get { throw null; } }
    }
    public partial class InMageRcmFailbackPlannedFailoverProviderContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverProviderSpecificFailoverContent
    {
        public InMageRcmFailbackPlannedFailoverProviderContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType RecoveryPointType { get { throw null; } }
    }
    public partial class InMageRcmFailbackPolicyCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent
    {
        public InMageRcmFailbackPolicyCreationContent() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
    }
    public partial class InMageRcmFailbackPolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal InMageRcmFailbackPolicyDetails() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } }
    }
    public partial class InMageRcmFailbackProtectedDiskDetails
    {
        internal InMageRcmFailbackProtectedDiskDetails() { }
        public long? CapacityInBytes { get { throw null; } }
        public double? DataPendingAtSourceAgentInMB { get { throw null; } }
        public double? DataPendingInLogDataStoreInMB { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskUuid { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackSyncDetails IrDetails { get { throw null; } }
        public string IsInitialReplicationComplete { get { throw null; } }
        public string IsOSDisk { get { throw null; } }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackSyncDetails ResyncDetails { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InMageRcmFailbackRecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InMageRcmFailbackRecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType ApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType CrashConsistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InMageRcmFailbackReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal InMageRcmFailbackReplicationDetails() { }
        public Azure.Core.ResourceIdentifier AzureVirtualMachineId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackDiscoveredProtectedVmDetails DiscoveredVmDetails { get { throw null; } }
        public long? InitialReplicationProcessedBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth? InitialReplicationProgressHealth { get { throw null; } }
        public int? InitialReplicationProgressPercentage { get { throw null; } }
        public long? InitialReplicationTransferredBytes { get { throw null; } }
        public string InternalIdentifier { get { throw null; } }
        public bool? IsAgentRegistrationSuccessfulAfterFailover { get { throw null; } }
        public System.DateTimeOffset? LastPlannedFailoverStartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus? LastPlannedFailoverStatus { get { throw null; } }
        public string LastUsedPolicyFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier LastUsedPolicyId { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackMobilityAgentDetails MobilityAgentDetails { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public string OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public string ReprotectAgentId { get { throw null; } }
        public string ReprotectAgentName { get { throw null; } }
        public long? ResyncProcessedBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth? ResyncProgressHealth { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public string ResyncRequired { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState? ResyncState { get { throw null; } }
        public long? ResyncTransferredBytes { get { throw null; } }
        public string TargetDataStoreName { get { throw null; } }
        public string TargetVCenterId { get { throw null; } }
        public string TargetVmName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackNicDetails> VmNics { get { throw null; } }
    }
    public partial class InMageRcmFailbackReprotectContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificContent
    {
        public InMageRcmFailbackReprotectContent(System.Guid processServerId, Azure.Core.ResourceIdentifier policyId) { }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } }
        public System.Guid ProcessServerId { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
    }
    public partial class InMageRcmFailbackSyncDetails
    {
        internal InMageRcmFailbackSyncDetails() { }
        public long? Last15MinutesTransferredBytes { get { throw null; } }
        public System.DateTimeOffset? LastDataTransferOn { get { throw null; } }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } }
        public long? ProcessedBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth? ProgressHealth { get { throw null; } }
        public int? ProgressPercentage { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public long? TransferredBytes { get { throw null; } }
    }
    public partial class InMageRcmLastAgentUpgradeErrorDetails
    {
        internal InMageRcmLastAgentUpgradeErrorDetails() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorMessageParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ErrorTags { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
    }
    public partial class InMageRcmMobilityAgentDetails
    {
        internal InMageRcmMobilityAgentDetails() { }
        public System.DateTimeOffset? AgentVersionExpireOn { get { throw null; } }
        public string DriverVersion { get { throw null; } }
        public System.DateTimeOffset? DriverVersionExpireOn { get { throw null; } }
        public string IsUpgradeable { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string LatestAgentReleaseDate { get { throw null; } }
        public string LatestUpgradableVersionWithoutReboot { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason> ReasonsBlockingUpgrade { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class InMageRcmNicContent
    {
        public InMageRcmNicContent(string nicId, string isPrimaryNic) { }
        public string IsPrimaryNic { get { throw null; } }
        public string IsSelectedForFailover { get { throw null; } set { } }
        public string NicId { get { throw null; } }
        public System.Net.IPAddress TargetStaticIPAddress { get { throw null; } set { } }
        public string TargetSubnetName { get { throw null; } set { } }
        public System.Net.IPAddress TestStaticIPAddress { get { throw null; } set { } }
        public string TestSubnetName { get { throw null; } set { } }
    }
    public partial class InMageRcmNicDetails
    {
        internal InMageRcmNicDetails() { }
        public string IsPrimaryNic { get { throw null; } }
        public string IsSelectedForFailover { get { throw null; } }
        public string NicId { get { throw null; } }
        public System.Net.IPAddress SourceIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? SourceIPAddressType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceNetworkId { get { throw null; } }
        public string SourceSubnetName { get { throw null; } }
        public System.Net.IPAddress TargetIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? TargetIPAddressType { get { throw null; } }
        public string TargetSubnetName { get { throw null; } }
        public System.Net.IPAddress TestIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? TestIPAddressType { get { throw null; } }
        public string TestSubnetName { get { throw null; } }
    }
    public partial class InMageRcmPolicyCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent
    {
        public InMageRcmPolicyCreationContent() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public string EnableMultiVmSync { get { throw null; } set { } }
        public int? RecoveryPointHistoryInMinutes { get { throw null; } set { } }
    }
    public partial class InMageRcmPolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal InMageRcmPolicyDetails() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } }
        public string EnableMultiVmSync { get { throw null; } }
        public int? RecoveryPointHistoryInMinutes { get { throw null; } }
    }
    public partial class InMageRcmProtectedDiskDetails
    {
        internal InMageRcmProtectedDiskDetails() { }
        public long? CapacityInBytes { get { throw null; } }
        public double? DataPendingAtSourceAgentInMB { get { throw null; } }
        public double? DataPendingInLogDataStoreInMB { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? DiskType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmSyncDetails IrDetails { get { throw null; } }
        public string IsInitialReplicationComplete { get { throw null; } }
        public string IsOSDisk { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmSyncDetails ResyncDetails { get { throw null; } }
        public System.Uri SeedBlobUri { get { throw null; } }
        public string SeedManagedDiskId { get { throw null; } }
        public string TargetManagedDiskId { get { throw null; } }
    }
    public partial class InMageRcmProtectionContainerMappingDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProviderSpecificDetails
    {
        internal InMageRcmProtectionContainerMappingDetails() { }
        public string EnableAgentAutoUpgrade { get { throw null; } }
    }
    public partial class InMageRcmRecoveryPointDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProviderSpecificRecoveryPointDetails
    {
        internal InMageRcmRecoveryPointDetails() { }
        public string IsMultiVmSyncPoint { get { throw null; } }
    }
    public partial class InMageRcmReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal InMageRcmReplicationDetails() { }
        public string AgentUpgradeAttemptToVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmAgentUpgradeBlockingErrorDetails> AgentUpgradeBlockingErrorDetails { get { throw null; } }
        public string AgentUpgradeJobId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState? AgentUpgradeState { get { throw null; } }
        public double? AllocatedMemoryInMB { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmDiscoveredProtectedVmDetails DiscoveredVmDetails { get { throw null; } }
        public string DiscoveryType { get { throw null; } }
        public string FabricDiscoveryMachineId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FailoverRecoveryPointId { get { throw null; } }
        public string FirmwareType { get { throw null; } }
        public long? InitialReplicationProcessedBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth? InitialReplicationProgressHealth { get { throw null; } }
        public int? InitialReplicationProgressPercentage { get { throw null; } }
        public long? InitialReplicationTransferredBytes { get { throw null; } }
        public string InternalIdentifier { get { throw null; } }
        public bool? IsAgentRegistrationSuccessfulAfterFailover { get { throw null; } }
        public string IsLastUpgradeSuccessful { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmLastAgentUpgradeErrorDetails> LastAgentUpgradeErrorDetails { get { throw null; } }
        public string LastAgentUpgradeType { get { throw null; } }
        public Azure.Core.ResourceIdentifier LastRecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public long? LastRpoInSeconds { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmMobilityAgentDetails MobilityAgentDetails { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public string OSType { get { throw null; } }
        public System.Net.IPAddress PrimaryNicIPAddress { get { throw null; } }
        public int? ProcessorCoreCount { get { throw null; } }
        public System.Guid? ProcessServerId { get { throw null; } }
        public string ProcessServerName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public long? ResyncProcessedBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth? ResyncProgressHealth { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public string ResyncRequired { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState? ResyncState { get { throw null; } }
        public long? ResyncTransferredBytes { get { throw null; } }
        public string RunAsAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } }
        public string TargetAvailabilityZone { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetBootDiagnosticsStorageAccountId { get { throw null; } }
        public string TargetGeneration { get { throw null; } }
        public string TargetLocation { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetNetworkId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } }
        public string TargetVmName { get { throw null; } }
        public string TargetVmSize { get { throw null; } }
        public Azure.Core.ResourceIdentifier TestNetworkId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmNicDetails> VmNics { get { throw null; } }
    }
    public partial class InMageRcmReprotectContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificContent
    {
        public InMageRcmReprotectContent(string reprotectAgentId, string datastoreName, Azure.Core.ResourceIdentifier logStorageAccountId) { }
        public string DatastoreName { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public string ReprotectAgentId { get { throw null; } }
    }
    public partial class InMageRcmSyncDetails
    {
        internal InMageRcmSyncDetails() { }
        public long? Last15MinutesTransferredBytes { get { throw null; } }
        public string LastDataTransferTimeUtc { get { throw null; } }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } }
        public long? ProcessedBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth? ProgressHealth { get { throw null; } }
        public int? ProgressPercentage { get { throw null; } }
        public System.DateTimeOffset? StaStartOn { get { throw null; } }
        public long? TransferredBytes { get { throw null; } }
    }
    public partial class InMageRcmTestFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificContent
    {
        public InMageRcmTestFailoverContent() { }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
    }
    public partial class InMageRcmUnplannedFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificContent
    {
        public InMageRcmUnplannedFailoverContent(string performShutdown) { }
        public string PerformShutdown { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
    }
    public partial class InMageRcmUpdateApplianceForReplicationProtectedItemContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemProviderSpecificContent
    {
        public InMageRcmUpdateApplianceForReplicationProtectedItemContent() { }
        public string RunAsAccountId { get { throw null; } set { } }
    }
    public partial class InMageRcmUpdateContainerMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificUpdateContainerMappingContent
    {
        public InMageRcmUpdateContainerMappingContent(string enableAgentAutoUpgrade) { }
        public string EnableAgentAutoUpgrade { get { throw null; } }
    }
    public partial class InMageRcmUpdateReplicationProtectedItemContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderContent
    {
        public InMageRcmUpdateReplicationProtectedItemContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetBootDiagnosticsStorageAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmName { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TestNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmNicContent> VmNics { get { throw null; } }
    }
    public partial class InMageReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal InMageReplicationDetails() { }
        public string ActiveSiteType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAgentDetails AgentDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzureStorageAccountId { get { throw null; } }
        public double? CompressedDataRateInMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.DateTimeOffset> ConsistencyPoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Datastores { get { throw null; } }
        public string DiscoveryType { get { throw null; } }
        public string DiskResized { get { throw null; } }
        public string InfrastructureVmId { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public bool? IsAdditionalStatsAvailable { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdateReceivedOn { get { throw null; } }
        public string MasterTargetId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public string MultiVmSyncStatus { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSDiskDetails OSDetails { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public System.Guid? ProcessServerId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public string ProtectionStage { get { throw null; } }
        public string RebootAfterUpdateStatus { get { throw null; } }
        public string ReplicaId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails ResyncDetails { get { throw null; } }
        public System.DateTimeOffset? RetentionWindowEndOn { get { throw null; } }
        public System.DateTimeOffset? RetentionWindowStartOn { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public int? SourceVmCpuCount { get { throw null; } }
        public int? SourceVmRamSizeInMB { get { throw null; } }
        public long? TotalDataTransferred { get { throw null; } }
        public string TotalProgressHealth { get { throw null; } }
        public double? UncompressedDataRateInMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> ValidationErrors { get { throw null; } }
        public string VCenterInfrastructureId { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class InMageReprotectContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificContent
    {
        public InMageReprotectContent(string masterTargetId, System.Guid processServerId, string retentionDrive, string profileId) { }
        public string DatastoreName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskExclusionContent DiskExclusionContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisksToInclude { get { throw null; } }
        public string MasterTargetId { get { throw null; } }
        public System.Guid ProcessServerId { get { throw null; } }
        public string ProfileId { get { throw null; } }
        public string RetentionDrive { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
    }
    public partial class InMageTestFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificContent
    {
        public InMageTestFailoverContent() { }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType? RecoveryPointType { get { throw null; } set { } }
    }
    public partial class InMageUnplannedFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificContent
    {
        public InMageUnplannedFailoverContent() { }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType? RecoveryPointType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InMageV2RpRecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InMageV2RpRecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType Latest { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType LatestApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType LatestCrashConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType LatestProcessed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InMageVolumeExclusionOptions
    {
        public InMageVolumeExclusionOptions() { }
        public string OnlyExcludeIfSingleVolume { get { throw null; } set { } }
        public string VolumeLabel { get { throw null; } set { } }
    }
    public partial class ManualActionTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryTaskTypeDetails
    {
        internal ManualActionTaskDetails() { }
        public string Instructions { get { throw null; } }
        public string Name { get { throw null; } }
        public string Observation { get { throw null; } }
    }
    public partial class MarsAgentDetails
    {
        internal MarsAgentDetails() { }
        public string BiosId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class MasterTargetServer
    {
        internal MasterTargetServer() { }
        public System.DateTimeOffset? AgentExpireOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails AgentVersionDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataStore> DataStores { get { throw null; } }
        public int? DiskCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public System.DateTimeOffset? MarsAgentExpireOn { get { throw null; } }
        public string MarsAgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails MarsAgentVersionDetails { get { throw null; } }
        public string Name { get { throw null; } }
        public string OSType { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRetentionVolume> RetentionVolumes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> ValidationErrors { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    public abstract partial class MigrateProviderSpecificContent
    {
        protected MigrateProviderSpecificContent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationItemOperation : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationItemOperation(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation DisableMigration { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation Migrate { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation PauseReplication { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation ResumeReplication { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation StartResync { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation TestMigrate { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation TestMigrateCleanup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationItemResyncContent
    {
        public MigrationItemResyncContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemResyncProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncProviderSpecificContent MigrationItemResyncProviderSpecificDetails { get { throw null; } }
    }
    public partial class MigrationItemResyncProperties
    {
        public MigrationItemResyncProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncProviderSpecificContent providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncProviderSpecificContent ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class MigrationProviderSpecificSettings
    {
        protected MigrationProviderSpecificSettings() { }
    }
    public partial class MigrationRecoveryPointProperties
    {
        internal MigrationRecoveryPointProperties() { }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType? RecoveryPointType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationRecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationRecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType ApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType CrashConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationRecoveryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobilityAgentUpgradeState : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobilityAgentUpgradeState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState Commit { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState Completed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState Started { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityAgentUpgradeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobilityServiceUpdate
    {
        internal MobilityServiceUpdate() { }
        public string OSType { get { throw null; } }
        public string RebootStatus { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MultiVmGroupCreateOption : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MultiVmGroupCreateOption(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption AutoCreated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption UserSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmGroupCreateOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MultiVmSyncPointOption : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MultiVmSyncPointOption(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption UseMultiVmSyncRecoveryPoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption UsePerVmRecoveryPoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class NetworkMappingFabricSpecificSettings
    {
        protected NetworkMappingFabricSpecificSettings() { }
    }
    public partial class NewProtectionProfile : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionProfileCustomDetails
    {
        public NewProtectionProfile(string policyName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus multiVmSyncStatus) { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus MultiVmSyncStatus { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public int? RecoveryPointHistory { get { throw null; } set { } }
    }
    public partial class NewRecoveryVirtualNetwork : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryVirtualNetworkCustomDetails
    {
        public NewRecoveryVirtualNetwork() { }
        public string RecoveryVirtualNetworkName { get { throw null; } set { } }
        public string RecoveryVirtualNetworkResourceGroupName { get { throw null; } set { } }
    }
    public partial class OSUpgradeSupportedVersions
    {
        internal OSUpgradeSupportedVersions() { }
        public string SupportedSourceOSVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedTargetOSVersions { get { throw null; } }
    }
    public partial class PauseReplicationContent
    {
        public PauseReplicationContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PauseReplicationProperties properties) { }
        public string PauseReplicationInstanceType { get { throw null; } }
    }
    public partial class PauseReplicationProperties
    {
        public PauseReplicationProperties(string instanceType) { }
        public string InstanceType { get { throw null; } }
    }
    public partial class PlannedFailoverContent
    {
        public PlannedFailoverContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverProperties Properties { get { throw null; } set { } }
    }
    public partial class PlannedFailoverProperties
    {
        public PlannedFailoverProperties() { }
        public string FailoverDirection { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverProviderSpecificFailoverContent ProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class PlannedFailoverProviderSpecificFailoverContent
    {
        protected PlannedFailoverProviderSpecificFailoverContent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlannedFailoverStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlannedFailoverStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class PolicyProviderSpecificContent
    {
        protected PolicyProviderSpecificContent() { }
    }
    public abstract partial class PolicyProviderSpecificDetails
    {
        protected PolicyProviderSpecificDetails() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PossibleOperationsDirection : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PossibleOperationsDirection(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection PrimaryToRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection RecoveryToPrimary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProtectionContainerMappingCreateOrUpdateContent
    {
        public ProtectionContainerMappingCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryCreateProtectionContainerMappingProperties Properties { get { throw null; } set { } }
    }
    public partial class ProtectionContainerMappingPatch
    {
        public ProtectionContainerMappingPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificUpdateContainerMappingContent ProviderSpecificContent { get { throw null; } set { } }
    }
    public partial class ProtectionContainerMappingProperties
    {
        internal ProtectionContainerMappingProperties() { }
        public string Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrorDetails { get { throw null; } }
        public string PolicyFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProviderSpecificDetails ProviderSpecificDetails { get { throw null; } }
        public string SourceFabricFriendlyName { get { throw null; } }
        public string SourceProtectionContainerFriendlyName { get { throw null; } }
        public string State { get { throw null; } }
        public string TargetFabricFriendlyName { get { throw null; } }
        public string TargetProtectionContainerFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProtectionContainerId { get { throw null; } }
    }
    public abstract partial class ProtectionContainerMappingProviderSpecificDetails
    {
        protected ProtectionContainerMappingProviderSpecificDetails() { }
    }
    public abstract partial class ProtectionProfileCustomDetails
    {
        protected ProtectionProfileCustomDetails() { }
    }
    public abstract partial class ProviderSpecificRecoveryPointDetails
    {
        protected ProviderSpecificRecoveryPointDetails() { }
    }
    public partial class PushInstallerDetails
    {
        internal PushInstallerDetails() { }
        public string BiosId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RcmComponentStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RcmComponentStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus Critical { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RcmProxyDetails
    {
        internal RcmProxyDetails() { }
        public string BiosId { get { throw null; } }
        public string ClientAuthenticationType { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public abstract partial class RecoveryAvailabilitySetCustomDetails
    {
        protected RecoveryAvailabilitySetCustomDetails() { }
    }
    public partial class RecoveryPlanA2AContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificContent
    {
        public RecoveryPlanA2AContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation PrimaryExtendedLocation { get { throw null; } set { } }
        public string PrimaryZone { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation RecoveryExtendedLocation { get { throw null; } set { } }
        public string RecoveryZone { get { throw null; } set { } }
    }
    public partial class RecoveryPlanA2ADetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificDetails
    {
        internal RecoveryPlanA2ADetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation PrimaryExtendedLocation { get { throw null; } }
        public string PrimaryZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocation RecoveryExtendedLocation { get { throw null; } }
        public string RecoveryZone { get { throw null; } }
    }
    public partial class RecoveryPlanA2AFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent
    {
        public RecoveryPlanA2AFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType recoveryPointType) { }
        public string CloudServiceCreationOption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption? MultiVmSyncPointOption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType RecoveryPointType { get { throw null; } }
    }
    public partial class RecoveryPlanAction
    {
        public RecoveryPlanAction(string actionName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation> failoverTypes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection> failoverDirections, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionDetails customDetails) { }
        public string ActionName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionDetails CustomDetails { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection> FailoverDirections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation> FailoverTypes { get { throw null; } }
    }
    public abstract partial class RecoveryPlanActionDetails
    {
        protected RecoveryPlanActionDetails() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPlanActionLocation : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPlanActionLocation(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation Primary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation Recovery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryPlanAutomationRunbookActionDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionDetails
    {
        public RecoveryPlanAutomationRunbookActionDetails(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation fabricLocation) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation FabricLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RunbookId { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
    }
    public partial class RecoveryPlanGroupTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryGroupTaskDetails
    {
        internal RecoveryPlanGroupTaskDetails() { }
        public string GroupId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RpGroupType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPlanGroupType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPlanGroupType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType Boot { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType Failover { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType Shutdown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryPlanHyperVReplicaAzureFailbackContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent
    {
        public RecoveryPlanHyperVReplicaAzureFailbackContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus dataSyncOption, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption recoveryVmCreationOption) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus DataSyncOption { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption RecoveryVmCreationOption { get { throw null; } }
    }
    public partial class RecoveryPlanHyperVReplicaAzureFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent
    {
        public RecoveryPlanHyperVReplicaAzureFailoverContent() { }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType? RecoveryPointType { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class RecoveryPlanInMageAzureV2FailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent
    {
        public RecoveryPlanInMageAzureV2FailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType RecoveryPointType { get { throw null; } }
        public string UseMultiVmSyncPoint { get { throw null; } set { } }
    }
    public partial class RecoveryPlanInMageFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent
    {
        public RecoveryPlanInMageFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType RecoveryPointType { get { throw null; } }
    }
    public partial class RecoveryPlanInMageRcmFailbackFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent
    {
        public RecoveryPlanInMageRcmFailbackFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType RecoveryPointType { get { throw null; } }
        public string UseMultiVmSyncPoint { get { throw null; } set { } }
    }
    public partial class RecoveryPlanInMageRcmFailoverContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent
    {
        public RecoveryPlanInMageRcmFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType RecoveryPointType { get { throw null; } }
        public string UseMultiVmSyncPoint { get { throw null; } set { } }
    }
    public partial class RecoveryPlanManualActionDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionDetails
    {
        public RecoveryPlanManualActionDetails() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class RecoveryPlanPlannedFailoverContent
    {
        public RecoveryPlanPlannedFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPlannedFailoverProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPlannedFailoverProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPlanPlannedFailoverProperties
    {
        public RecoveryPlanPlannedFailoverProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection failoverDirection) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection FailoverDirection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent> ProviderSpecificDetails { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPlanPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPlanPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType Latest { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType LatestApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType LatestCrashConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType LatestProcessed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryPlanProtectedItem
    {
        public RecoveryPlanProtectedItem() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string VirtualMachineId { get { throw null; } set { } }
    }
    public abstract partial class RecoveryPlanProviderSpecificContent
    {
        protected RecoveryPlanProviderSpecificContent() { }
    }
    public abstract partial class RecoveryPlanProviderSpecificDetails
    {
        protected RecoveryPlanProviderSpecificDetails() { }
    }
    public abstract partial class RecoveryPlanProviderSpecificFailoverContent
    {
        protected RecoveryPlanProviderSpecificFailoverContent() { }
    }
    public partial class RecoveryPlanScriptActionDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionDetails
    {
        public RecoveryPlanScriptActionDetails(string path, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation fabricLocation) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionLocation FabricLocation { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
    }
    public partial class RecoveryPlanShutdownGroupTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupTaskDetails
    {
        internal RecoveryPlanShutdownGroupTaskDetails() { }
    }
    public partial class RecoveryPlanTestFailoverCleanupContent
    {
        public RecoveryPlanTestFailoverCleanupContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverCleanupProperties properties) { }
        public string RecoveryPlanTestFailoverCleanupComments { get { throw null; } }
    }
    public partial class RecoveryPlanTestFailoverCleanupProperties
    {
        public RecoveryPlanTestFailoverCleanupProperties() { }
        public string Comments { get { throw null; } set { } }
    }
    public partial class RecoveryPlanTestFailoverContent
    {
        public RecoveryPlanTestFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPlanTestFailoverProperties
    {
        public RecoveryPlanTestFailoverProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection failoverDirection, string networkType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection FailoverDirection { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } set { } }
        public string NetworkType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent> ProviderSpecificDetails { get { throw null; } }
    }
    public partial class RecoveryPlanUnplannedFailoverContent
    {
        public RecoveryPlanUnplannedFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanUnplannedFailoverProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanUnplannedFailoverProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPlanUnplannedFailoverProperties
    {
        public RecoveryPlanUnplannedFailoverProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection failoverDirection, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation sourceSiteOperation) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection FailoverDirection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverContent> ProviderSpecificDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation SourceSiteOperation { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPointSyncType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPointSyncType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType MultiVmSyncRecoveryPoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType PerVmRecoveryPoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointSyncType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RecoveryProximityPlacementGroupCustomDetails
    {
        protected RecoveryProximityPlacementGroupCustomDetails() { }
    }
    public abstract partial class RecoveryResourceGroupCustomDetails
    {
        protected RecoveryResourceGroupCustomDetails() { }
    }
    public abstract partial class RecoveryVirtualNetworkCustomDetails
    {
        protected RecoveryVirtualNetworkCustomDetails() { }
    }
    public partial class RemoveDisksContent
    {
        public RemoveDisksContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RemoveDisksProviderSpecificContent RemoveDisksContentProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class RemoveDisksProviderSpecificContent
    {
        protected RemoveDisksProviderSpecificContent() { }
    }
    public partial class RemoveProtectionContainerMappingContent
    {
        public RemoveProtectionContainerMappingContent() { }
        public string ProviderSpecificContentInstanceType { get { throw null; } set { } }
    }
    public partial class RenewCertificateContent
    {
        public RenewCertificateContent() { }
        public string RenewCertificateType { get { throw null; } set { } }
    }
    public partial class ReplicationAgentDetails
    {
        internal ReplicationAgentDetails() { }
        public string BiosId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ReplicationEligibilityResultErrorInfo
    {
        internal ReplicationEligibilityResultErrorInfo() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ReplicationEligibilityResultProperties
    {
        internal ReplicationEligibilityResultProperties() { }
        public string ClientRequestId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationEligibilityResultErrorInfo> Errors { get { throw null; } }
    }
    public partial class ReplicationGroupDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationProviderSettings
    {
        internal ReplicationGroupDetails() { }
    }
    public partial class ReplicationProtectedItemCreateOrUpdateContent
    {
        public ReplicationProtectedItemCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProperties Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationProtectedItemOperation : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationProtectedItemOperation(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation CancelFailover { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation ChangePit { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation Commit { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation CompleteMigration { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation DisableProtection { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation Failback { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation FinalizeFailback { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation PlannedFailover { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation RepairReplication { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation ReverseReplicate { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation SwitchProtection { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation TestFailover { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation TestFailoverCleanup { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation UnplannedFailover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectedItemOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReplicationProtectedItemPatch
    {
        public ReplicationProtectedItemPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProperties Properties { get { throw null; } set { } }
    }
    public partial class ReplicationProtectedItemProperties
    {
        internal ReplicationProtectedItemProperties() { }
        public string ActiveLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AllowedOperations { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentScenarioDetails CurrentScenario { get { throw null; } }
        public System.Guid? EventCorrelationId { get { throw null; } }
        public string FailoverHealth { get { throw null; } }
        public Azure.Core.ResourceIdentifier FailoverRecoveryPointId { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulTestFailoverOn { get { throw null; } }
        public string PolicyFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } }
        public string PrimaryFabricFriendlyName { get { throw null; } }
        public string PrimaryFabricProvider { get { throw null; } }
        public string PrimaryProtectionContainerFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProtectableItemId { get { throw null; } }
        public string ProtectedItemType { get { throw null; } }
        public string ProtectionState { get { throw null; } }
        public string ProtectionStateDescription { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings ProviderSpecificDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryContainerId { get { throw null; } }
        public string RecoveryFabricFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryFabricId { get { throw null; } }
        public string RecoveryProtectionContainerFriendlyName { get { throw null; } }
        public string RecoveryServicesProviderId { get { throw null; } }
        public string ReplicationHealth { get { throw null; } }
        public string SwitchProviderState { get { throw null; } }
        public string SwitchProviderStateDescription { get { throw null; } }
        public string TestFailoverState { get { throw null; } }
        public string TestFailoverStateDescription { get { throw null; } }
    }
    public partial class ReplicationProtectionIntentCreateOrUpdateContent
    {
        public ReplicationProtectionIntentCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryCreateProtectionIntentProviderDetail SiteRecoveryCreateProtectionIntentProviderSpecificDetails { get { throw null; } set { } }
    }
    public partial class ReplicationProtectionIntentProperties
    {
        internal ReplicationProtectionIntentProperties() { }
        public string CreatedOn { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public bool? IsActive { get { throw null; } }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } }
        public string JobState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentProviderSpecificSettings ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class ReplicationProtectionIntentProviderSpecificSettings
    {
        protected ReplicationProtectionIntentProviderSpecificSettings() { }
    }
    public abstract partial class ReplicationProviderSpecificContainerCreationContent
    {
        protected ReplicationProviderSpecificContainerCreationContent() { }
    }
    public abstract partial class ReplicationProviderSpecificContainerMappingContent
    {
        protected ReplicationProviderSpecificContainerMappingContent() { }
    }
    public abstract partial class ReplicationProviderSpecificSettings
    {
        protected ReplicationProviderSpecificSettings() { }
    }
    public abstract partial class ReplicationProviderSpecificUpdateContainerMappingContent
    {
        protected ReplicationProviderSpecificUpdateContainerMappingContent() { }
    }
    public partial class ReplicationResumeJobContent
    {
        public ReplicationResumeJobContent() { }
        public string ReplicationResumeJobComments { get { throw null; } set { } }
    }
    public partial class ReprotectAgentDetails
    {
        internal ReprotectAgentDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> AccessibleDatastores { get { throw null; } }
        public string BiosId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? Last { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public int? ProtectedItemCount { get { throw null; } }
        public string VCenterId { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ResolveHealthContent
    {
        public ResolveHealthContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResolveHealthError> ResolveHealthErrors { get { throw null; } }
    }
    public partial class ResolveHealthError
    {
        public ResolveHealthError() { }
        public string HealthErrorId { get { throw null; } set { } }
    }
    public partial class ResourceHealthSummary
    {
        internal ResourceHealthSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> CategorizedResourceCounts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorSummary> Issues { get { throw null; } }
        public int? ResourceCount { get { throw null; } }
    }
    public partial class ResumeReplicationContent
    {
        public ResumeReplicationContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationProviderSpecificContent ResumeReplicationProviderSpecificDetails { get { throw null; } }
    }
    public partial class ResumeReplicationProperties
    {
        public ResumeReplicationProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationProviderSpecificContent providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationProviderSpecificContent ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class ResumeReplicationProviderSpecificContent
    {
        protected ResumeReplicationProviderSpecificContent() { }
    }
    public abstract partial class ResyncProviderSpecificContent
    {
        protected ResyncProviderSpecificContent() { }
    }
    public partial class ReverseReplicationContent
    {
        public ReverseReplicationContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProperties Properties { get { throw null; } set { } }
    }
    public partial class ReverseReplicationProperties
    {
        public ReverseReplicationProperties() { }
        public string FailoverDirection { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificContent ProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class ReverseReplicationProviderSpecificContent
    {
        protected ReverseReplicationProviderSpecificContent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RpInMageRecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RpInMageRecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType Custom { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType LatestTag { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType LatestTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptActionTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryTaskTypeDetails
    {
        internal ScriptActionTaskDetails() { }
        public bool? IsPrimarySideScript { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        public string Path { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SetMultiVmSyncStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SetMultiVmSyncStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus Disable { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryAddDisksContent
    {
        public SiteRecoveryAddDisksContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAddDisksProviderSpecificContent SiteRecoveryAddDisksProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class SiteRecoveryAddDisksProviderSpecificContent
    {
        protected SiteRecoveryAddDisksProviderSpecificContent() { }
    }
    public partial class SiteRecoveryAddRecoveryServicesProviderProperties
    {
        public SiteRecoveryAddRecoveryServicesProviderProperties(string machineName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderContent authenticationIdentityContent, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderContent resourceAccessIdentityContent) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderContent AuthenticationIdentityContent { get { throw null; } }
        public string BiosId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderContent DataPlaneAuthenticationIdentityContent { get { throw null; } set { } }
        public string MachineId { get { throw null; } set { } }
        public string MachineName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderContent ResourceAccessIdentityContent { get { throw null; } }
    }
    public partial class SiteRecoveryAddVCenterProperties
    {
        public SiteRecoveryAddVCenterProperties() { }
        public string FriendlyName { get { throw null; } set { } }
        public System.Net.IPAddress IPAddress { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        public System.Guid? ProcessServerId { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryAgentAutoUpdateStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryAgentAutoUpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentAutoUpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryAgentDetails
    {
        internal SiteRecoveryAgentDetails() { }
        public string AgentId { get { throw null; } }
        public string BiosId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentDiskDetails> Disks { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public string MachineId { get { throw null; } }
    }
    public partial class SiteRecoveryAgentDiskDetails
    {
        internal SiteRecoveryAgentDiskDetails() { }
        public long? CapacityInBytes { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string IsOSDisk { get { throw null; } }
        public int? LunId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryAgentVersionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryAgentVersionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus Deprecated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus NotSupported { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus SecurityUpdateRequired { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus Supported { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus UpdateRequired { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryAlertCreateOrUpdateContent
    {
        public SiteRecoveryAlertCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryConfigureAlertProperties Properties { get { throw null; } set { } }
    }
    public partial class SiteRecoveryAlertProperties
    {
        internal SiteRecoveryAlertProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> CustomEmailAddresses { get { throw null; } }
        public string Locale { get { throw null; } }
        public string SendToOwners { get { throw null; } }
    }
    public abstract partial class SiteRecoveryApplianceSpecificDetails
    {
        protected SiteRecoveryApplianceSpecificDetails() { }
    }
    public partial class SiteRecoveryApplyRecoveryPointContent
    {
        public SiteRecoveryApplyRecoveryPointContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryApplyRecoveryPointProperties
    {
        public SiteRecoveryApplyRecoveryPointProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointProviderSpecificContent providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplyRecoveryPointProviderSpecificContent ProviderSpecificDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } set { } }
    }
    public abstract partial class SiteRecoveryApplyRecoveryPointProviderSpecificContent
    {
        protected SiteRecoveryApplyRecoveryPointProviderSpecificContent() { }
    }
    public partial class SiteRecoveryComputeSizeErrorDetails
    {
        internal SiteRecoveryComputeSizeErrorDetails() { }
        public string Message { get { throw null; } }
        public string Severity { get { throw null; } }
    }
    public partial class SiteRecoveryConfigureAlertProperties
    {
        public SiteRecoveryConfigureAlertProperties() { }
        public System.Collections.Generic.IList<string> CustomEmailAddresses { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public string SendToOwners { get { throw null; } set { } }
    }
    public partial class SiteRecoveryCreateProtectionContainerMappingProperties
    {
        public SiteRecoveryCreateProtectionContainerMappingProperties() { }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerMappingContent ProviderSpecificContent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetProtectionContainerId { get { throw null; } set { } }
    }
    public abstract partial class SiteRecoveryCreateProtectionIntentProviderDetail
    {
        protected SiteRecoveryCreateProtectionIntentProviderDetail() { }
    }
    public partial class SiteRecoveryCreateRecoveryPlanProperties
    {
        public SiteRecoveryCreateRecoveryPlanProperties(Azure.Core.ResourceIdentifier primaryFabricId, Azure.Core.ResourceIdentifier recoveryFabricId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPlanGroup> groups) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel? FailoverDeploymentModel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPlanGroup> Groups { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryFabricId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificContent> ProviderSpecificContent { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryFabricId { get { throw null; } }
    }
    public partial class SiteRecoveryCreateReplicationNetworkMappingProperties
    {
        public SiteRecoveryCreateReplicationNetworkMappingProperties(Azure.Core.ResourceIdentifier recoveryNetworkId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreateNetworkMappingContent FabricSpecificDetails { get { throw null; } set { } }
        public string RecoveryFabricName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryNetworkId { get { throw null; } }
    }
    public partial class SiteRecoveryDataStore
    {
        internal SiteRecoveryDataStore() { }
        public string Capacity { get { throw null; } }
        public string DataStoreType { get { throw null; } }
        public string FreeSpace { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        public System.Guid? Uuid { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryDataSyncStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryDataSyncStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus ForDownTime { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus ForSynchronization { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDataSyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryDiskAccountType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryDiskAccountType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType StandardSsdLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryDiskDetails
    {
        internal SiteRecoveryDiskDetails() { }
        public long? MaxSizeMB { get { throw null; } }
        public string VhdId { get { throw null; } }
        public string VhdName { get { throw null; } }
        public string VhdType { get { throw null; } }
    }
    public partial class SiteRecoveryDiskEncryptionInfo
    {
        public SiteRecoveryDiskEncryptionInfo() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskEncryptionKeyInfo DiskEncryptionKeyInfo { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryKeyEncryptionKeyInfo KeyEncryptionKeyInfo { get { throw null; } set { } }
    }
    public partial class SiteRecoveryDiskEncryptionKeyInfo
    {
        public SiteRecoveryDiskEncryptionKeyInfo() { }
        public Azure.Core.ResourceIdentifier KeyVaultResourceArmId { get { throw null; } set { } }
        public string SecretIdentifier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryDiskReplicationProgressHealth : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryDiskReplicationProgressHealth(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth InProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth NoProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth Queued { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth SlowProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskReplicationProgressHealth right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryDiskVolumeDetails
    {
        internal SiteRecoveryDiskVolumeDetails() { }
        public string Label { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SiteRecoveryDraDetails
    {
        internal SiteRecoveryDraDetails() { }
        public string BiosId { get { throw null; } }
        public int? ForwardProtectedItemCount { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public int? ReverseProtectedItemCount { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class SiteRecoveryEncryptionDetails
    {
        internal SiteRecoveryEncryptionDetails() { }
        public System.DateTimeOffset? KekCertExpireOn { get { throw null; } }
        public string KekCertThumbprint { get { throw null; } }
        public string KekState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryErrorSeverity : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryErrorSeverity(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity Info { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryErrorSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryEthernetAddressType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryEthernetAddressType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType Dynamic { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryEventProperties
    {
        internal SiteRecoveryEventProperties() { }
        public string AffectedObjectCorrelationId { get { throw null; } }
        public string AffectedObjectFriendlyName { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventCode { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventSpecificDetails EventSpecificDetails { get { throw null; } }
        public string EventType { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public System.DateTimeOffset? OccurredOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails ProviderSpecificDetails { get { throw null; } }
        public string Severity { get { throw null; } }
    }
    public abstract partial class SiteRecoveryEventProviderSpecificDetails
    {
        protected SiteRecoveryEventProviderSpecificDetails() { }
    }
    public abstract partial class SiteRecoveryEventSpecificDetails
    {
        protected SiteRecoveryEventSpecificDetails() { }
    }
    public partial class SiteRecoveryExtendedLocation
    {
        public SiteRecoveryExtendedLocation(string name, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType extendedLocationType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryExtendedLocationType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType EdgeZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryFabricCreateOrUpdateContent
    {
        public SiteRecoveryFabricCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreationContent FabricCreationCustomDetails { get { throw null; } set { } }
    }
    public partial class SiteRecoveryFabricProperties
    {
        internal SiteRecoveryFabricProperties() { }
        public string BcdrState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails CustomDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEncryptionDetails EncryptionDetails { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrorDetails { get { throw null; } }
        public string InternalIdentifier { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEncryptionDetails RolloverEncryptionDetails { get { throw null; } }
    }
    public partial class SiteRecoveryFabricProviderCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreationContent
    {
        public SiteRecoveryFabricProviderCreationContent() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class SiteRecoveryFabricProviderSpecificDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal SiteRecoveryFabricProviderSpecificDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ContainerIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AExtendedLocationDetails> ExtendedLocations { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AFabricSpecificLocationDetails> LocationDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AZoneDetails> Zones { get { throw null; } }
    }
    public abstract partial class SiteRecoveryGroupTaskDetails
    {
        protected SiteRecoveryGroupTaskDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AsrTask> ChildTasks { get { throw null; } }
    }
    public partial class SiteRecoveryHealthError
    {
        internal SiteRecoveryHealthError() { }
        public System.DateTimeOffset? CreationTimeUtc { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability? CustomerResolvability { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string ErrorCategory { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorId { get { throw null; } }
        public string ErrorLevel { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string ErrorSource { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryInnerHealthError> InnerHealthErrors { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public string RecoveryProviderErrorMessage { get { throw null; } }
        public string SummaryMessage { get { throw null; } }
    }
    public partial class SiteRecoveryInnerHealthError
    {
        internal SiteRecoveryInnerHealthError() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthErrorCustomerResolvability? CustomerResolvability { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string ErrorCategory { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorId { get { throw null; } }
        public string ErrorLevel { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string ErrorSource { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public string RecoveryProviderErrorMessage { get { throw null; } }
        public string SummaryMessage { get { throw null; } }
    }
    public abstract partial class SiteRecoveryJobDetails
    {
        protected SiteRecoveryJobDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AffectedObjectDetails { get { throw null; } }
    }
    public partial class SiteRecoveryJobEntity
    {
        internal SiteRecoveryJobEntity() { }
        public string JobFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } }
        public string JobScenarioName { get { throw null; } }
        public string TargetInstanceType { get { throw null; } }
        public string TargetObjectId { get { throw null; } }
        public string TargetObjectName { get { throw null; } }
    }
    public partial class SiteRecoveryJobErrorDetails
    {
        internal SiteRecoveryJobErrorDetails() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string ErrorLevel { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobProviderError ProviderErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryServiceError ServiceErrorDetails { get { throw null; } }
        public string TaskId { get { throw null; } }
    }
    public partial class SiteRecoveryJobProperties
    {
        internal SiteRecoveryJobProperties() { }
        public string ActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobDetails CustomDetails { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobErrorDetails> Errors { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
        public string StateDescription { get { throw null; } }
        public string TargetInstanceType { get { throw null; } }
        public string TargetObjectId { get { throw null; } }
        public string TargetObjectName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AsrTask> Tasks { get { throw null; } }
    }
    public partial class SiteRecoveryJobProviderError
    {
        internal SiteRecoveryJobProviderError() { }
        public int? ErrorCode { get { throw null; } }
        public string ErrorId { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
    }
    public partial class SiteRecoveryJobQueryContent
    {
        public SiteRecoveryJobQueryContent() { }
        public string AffectedObjectTypes { get { throw null; } set { } }
        public string EndOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FabricId { get { throw null; } set { } }
        public string JobName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType? JobOutputType { get { throw null; } set { } }
        public string JobStatus { get { throw null; } set { } }
        public string StartOn { get { throw null; } set { } }
        public double? TimezoneOffset { get { throw null; } set { } }
    }
    public partial class SiteRecoveryJobStatusEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventSpecificDetails
    {
        internal SiteRecoveryJobStatusEventDetails() { }
        public string AffectedObjectType { get { throw null; } }
        public string JobFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } }
        public string JobStatus { get { throw null; } }
    }
    public partial class SiteRecoveryJobTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryTaskTypeDetails
    {
        internal SiteRecoveryJobTaskDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobEntity JobTask { get { throw null; } }
    }
    public partial class SiteRecoveryKeyEncryptionKeyInfo
    {
        public SiteRecoveryKeyEncryptionKeyInfo() { }
        public string KeyIdentifier { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultResourceArmId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryLicenseType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType NoLicenseType { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType WindowsServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryLogicalNetworkProperties
    {
        internal SiteRecoveryLogicalNetworkProperties() { }
        public string FriendlyName { get { throw null; } }
        public string LogicalNetworkDefinitionsStatus { get { throw null; } }
        public string LogicalNetworkUsage { get { throw null; } }
        public string NetworkVirtualizationStatus { get { throw null; } }
    }
    public partial class SiteRecoveryMigrateContent
    {
        public SiteRecoveryMigrateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrateProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateProviderSpecificContent SiteRecoveryMigrateProviderSpecificDetails { get { throw null; } }
    }
    public partial class SiteRecoveryMigrateProperties
    {
        public SiteRecoveryMigrateProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateProviderSpecificContent providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateProviderSpecificContent ProviderSpecificDetails { get { throw null; } }
    }
    public partial class SiteRecoveryMigrationItemCreateOrUpdateContent
    {
        public SiteRecoveryMigrationItemCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryMigrationItemPatch
    {
        public SiteRecoveryMigrationItemPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateMigrationItemProviderSpecificContent UpdateMigrationItemProviderSpecificDetails { get { throw null; } set { } }
    }
    public partial class SiteRecoveryMigrationItemProperties
    {
        internal SiteRecoveryMigrationItemProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation> AllowedOperations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CriticalJobHistoryDetails> CriticalJobHistory { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentJobDetails CurrentJob { get { throw null; } }
        public string EventCorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public System.DateTimeOffset? LastMigrationOn { get { throw null; } }
        public string LastMigrationStatus { get { throw null; } }
        public System.DateTimeOffset? LastTestMigrationOn { get { throw null; } }
        public string LastTestMigrationStatus { get { throw null; } }
        public string MachineName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState? MigrationState { get { throw null; } }
        public string MigrationStateDescription { get { throw null; } }
        public string PolicyFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationProviderSpecificSettings ProviderSpecificDetails { get { throw null; } }
        public string RecoveryServicesProviderId { get { throw null; } }
        public string ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState? TestMigrateState { get { throw null; } }
        public string TestMigrateStateDescription { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryMigrationState : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState DisableMigrationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState DisableMigrationInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState EnableMigrationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState EnableMigrationInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState InitialSeedingFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState InitialSeedingInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState MigrationCompletedWithInformation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState MigrationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState MigrationInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState MigrationPartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState MigrationSucceeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState ProtectionSuspended { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState Replicating { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState ResumeInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState ResumeInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState SuspendingProtection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryNetworkMappingCreateOrUpdateContent
    {
        public SiteRecoveryNetworkMappingCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryCreateReplicationNetworkMappingProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryCreateReplicationNetworkMappingProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryNetworkMappingPatch
    {
        public SiteRecoveryNetworkMappingPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateNetworkMappingProperties Properties { get { throw null; } set { } }
    }
    public partial class SiteRecoveryNetworkMappingProperties
    {
        internal SiteRecoveryNetworkMappingProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingFabricSpecificSettings FabricSpecificSettings { get { throw null; } }
        public string PrimaryFabricFriendlyName { get { throw null; } }
        public string PrimaryNetworkFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryNetworkId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryFabricArmId { get { throw null; } }
        public string RecoveryFabricFriendlyName { get { throw null; } }
        public string RecoveryNetworkFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryNetworkId { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class SiteRecoveryNetworkProperties
    {
        internal SiteRecoveryNetworkProperties() { }
        public string FabricType { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string NetworkType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySubnet> Subnets { get { throw null; } }
    }
    public partial class SiteRecoveryOSDetails
    {
        internal SiteRecoveryOSDetails() { }
        public string OSEdition { get { throw null; } }
        public string OSMajorVersion { get { throw null; } }
        public string OSMinorVersion { get { throw null; } }
        public string OSType { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string ProductType { get { throw null; } }
    }
    public partial class SiteRecoveryOSDiskDetails
    {
        internal SiteRecoveryOSDiskDetails() { }
        public string OSType { get { throw null; } }
        public string OSVhdId { get { throw null; } }
        public string VhdName { get { throw null; } }
    }
    public partial class SiteRecoveryOSVersionWrapper
    {
        internal SiteRecoveryOSVersionWrapper() { }
        public string ServicePack { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class SiteRecoveryPlanGroup
    {
        public SiteRecoveryPlanGroup(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType groupType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanAction> EndGroupActions { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType GroupType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProtectedItem> ReplicationProtectedItems { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanAction> StartGroupActions { get { throw null; } }
    }
    public partial class SiteRecoveryPointProperties
    {
        internal SiteRecoveryPointProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProviderSpecificRecoveryPointDetails ProviderSpecificDetails { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } }
        public string RecoveryPointType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType Custom { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType LatestTag { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType LatestTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryPolicyCreateOrUpdateContent
    {
        public SiteRecoveryPolicyCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent SiteRecoveryCreateProviderSpecificContent { get { throw null; } set { } }
    }
    public partial class SiteRecoveryPolicyPatch
    {
        public SiteRecoveryPolicyPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent UpdatePolicyContentReplicationProviderSettings { get { throw null; } set { } }
    }
    public partial class SiteRecoveryPolicyProperties
    {
        internal SiteRecoveryPolicyProperties() { }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails ProviderSpecificDetails { get { throw null; } }
    }
    public partial class SiteRecoveryProcessServer
    {
        internal SiteRecoveryProcessServer() { }
        public System.DateTimeOffset? AgentExpireOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails AgentVersionDetails { get { throw null; } }
        public long? AvailableMemoryInBytes { get { throw null; } }
        public long? AvailableSpaceInBytes { get { throw null; } }
        public string CpuLoad { get { throw null; } }
        public string CpuLoadStatus { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public string HostId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string MachineCount { get { throw null; } }
        public string MarsCommunicationStatus { get { throw null; } }
        public string MarsRegistrationStatus { get { throw null; } }
        public string MemoryUsageStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MobilityServiceUpdate> MobilityServiceUpdates { get { throw null; } }
        public string OSType { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string PsServiceStatus { get { throw null; } }
        public System.DateTimeOffset? PsStatsRefreshOn { get { throw null; } }
        public string ReplicationPairCount { get { throw null; } }
        public string SpaceUsageStatus { get { throw null; } }
        public System.DateTimeOffset? SslCertExpireOn { get { throw null; } }
        public int? SslCertExpiryRemainingDays { get { throw null; } }
        public string SystemLoad { get { throw null; } }
        public string SystemLoadStatus { get { throw null; } }
        public long? ThroughputInBytes { get { throw null; } }
        public long? ThroughputInMBps { get { throw null; } }
        public string ThroughputStatus { get { throw null; } }
        public long? ThroughputUploadPendingDataInBytes { get { throw null; } }
        public long? TotalMemoryInBytes { get { throw null; } }
        public long? TotalSpaceInBytes { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    public partial class SiteRecoveryProcessServerDetails
    {
        internal SiteRecoveryProcessServerDetails() { }
        public long? AvailableMemoryInBytes { get { throw null; } }
        public long? AvailableSpaceInBytes { get { throw null; } }
        public string BiosId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? DiskUsageStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public double? FreeSpacePercentage { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth? HistoricHealth { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> IPAddresses { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public double? MemoryUsagePercentage { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? MemoryUsageStatus { get { throw null; } }
        public string Name { get { throw null; } }
        public double? ProcessorUsagePercentage { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? ProcessorUsageStatus { get { throw null; } }
        public int? ProtectedItemCount { get { throw null; } }
        public long? SystemLoad { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? SystemLoadStatus { get { throw null; } }
        public long? ThroughputInBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? ThroughputStatus { get { throw null; } }
        public long? ThroughputUploadPendingDataInBytes { get { throw null; } }
        public long? TotalMemoryInBytes { get { throw null; } }
        public long? TotalSpaceInBytes { get { throw null; } }
        public long? UsedMemoryInBytes { get { throw null; } }
        public long? UsedSpaceInBytes { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class SiteRecoveryProtectableItemProperties
    {
        internal SiteRecoveryProtectableItemProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationProviderSettings CustomDetails { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProtectionReadinessErrors { get { throw null; } }
        public string ProtectionStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryServicesProviderId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ReplicationProtectedItemId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedReplicationProviders { get { throw null; } }
    }
    public partial class SiteRecoveryProtectionContainerCreateOrUpdateContent
    {
        public SiteRecoveryProtectionContainerCreateOrUpdateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerCreationContent> SiteRecoveryCreateProtectionContainerProviderSpecificContent { get { throw null; } }
    }
    public partial class SiteRecoveryProtectionContainerProperties
    {
        internal SiteRecoveryProtectionContainerProperties() { }
        public string FabricFriendlyName { get { throw null; } }
        public string FabricSpecificDetailsInstanceType { get { throw null; } }
        public string FabricType { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string PairingStatus { get { throw null; } }
        public int? ProtectedItemCount { get { throw null; } }
        public string Role { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryProtectionHealth : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryProtectionHealth(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth Critical { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth Normal { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProtectionHealth right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryRecoveryPlanCreateOrUpdateContent
    {
        public SiteRecoveryRecoveryPlanCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryCreateRecoveryPlanProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryCreateRecoveryPlanProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryRecoveryPlanPatch
    {
        public SiteRecoveryRecoveryPlanPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPlanGroup> UpdateRecoveryPlanContentGroups { get { throw null; } }
    }
    public partial class SiteRecoveryRecoveryPlanProperties
    {
        internal SiteRecoveryRecoveryPlanProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedOperations { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentScenarioDetails CurrentScenario { get { throw null; } }
        public string CurrentScenarioStatus { get { throw null; } }
        public string CurrentScenarioStatusDescription { get { throw null; } }
        public string FailoverDeploymentModel { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryPlanGroup> Groups { get { throw null; } }
        public System.DateTimeOffset? LastPlannedFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastTestFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastUnplannedFailoverOn { get { throw null; } }
        public string PrimaryFabricFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryFabricId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificDetails> ProviderSpecificDetails { get { throw null; } }
        public string RecoveryFabricFriendlyName { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryFabricId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReplicationProviders { get { throw null; } }
    }
    public partial class SiteRecoveryReplicationAppliance
    {
        internal SiteRecoveryReplicationAppliance() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryApplianceSpecificDetails SiteRecoveryReplicationApplianceProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class SiteRecoveryReplicationProviderSettings
    {
        protected SiteRecoveryReplicationProviderSettings() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryResyncState : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryResyncState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState PreparedForResynchronization { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState StartedResynchronization { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryRetentionVolume
    {
        internal SiteRecoveryRetentionVolume() { }
        public long? CapacityInBytes { get { throw null; } }
        public long? FreeSpaceInBytes { get { throw null; } }
        public int? ThresholdPercentage { get { throw null; } }
        public string VolumeName { get { throw null; } }
    }
    public partial class SiteRecoveryRunAsAccount
    {
        internal SiteRecoveryRunAsAccount() { }
        public string AccountId { get { throw null; } }
        public string AccountName { get { throw null; } }
    }
    public partial class SiteRecoveryServiceError
    {
        internal SiteRecoveryServiceError() { }
        public string ActivityId { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
    }
    public partial class SiteRecoveryServicesProviderCreateOrUpdateContent
    {
        public SiteRecoveryServicesProviderCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAddRecoveryServicesProviderProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAddRecoveryServicesProviderProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryServicesProviderProperties
    {
        internal SiteRecoveryServicesProviderProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedScenarios { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails AuthenticationIdentityDetails { get { throw null; } }
        public string BiosId { get { throw null; } }
        public string ConnectionStatus { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails DataPlaneAuthenticationIdentityDetails { get { throw null; } }
        public string DraIdentifier { get { throw null; } }
        public string FabricFriendlyName { get { throw null; } }
        public string FabricType { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string MachineId { get { throw null; } }
        public string MachineName { get { throw null; } }
        public int? ProtectedItemCount { get { throw null; } }
        public string ProviderVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails ProviderVersionDetails { get { throw null; } }
        public System.DateTimeOffset? ProviderVersionExpireOn { get { throw null; } }
        public string ProviderVersionState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails ResourceAccessIdentityDetails { get { throw null; } }
        public string ServerVersion { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoverySqlServerLicenseType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoverySqlServerLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType Ahub { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType NoLicenseType { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoverySubnet
    {
        internal SiteRecoverySubnet() { }
        public System.Collections.Generic.IReadOnlyList<string> AddressList { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SiteRecoverySupportedOperatingSystems : Azure.ResourceManager.Models.ResourceData
    {
        internal SiteRecoverySupportedOperatingSystems() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOSProperty> SupportedOSList { get { throw null; } }
    }
    public partial class SiteRecoverySupportedOSDetails
    {
        internal SiteRecoverySupportedOSDetails() { }
        public string OSName { get { throw null; } }
        public string OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryOSVersionWrapper> OSVersions { get { throw null; } }
    }
    public partial class SiteRecoverySupportedOSProperty
    {
        internal SiteRecoverySupportedOSProperty() { }
        public string InstanceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySupportedOSDetails> SupportedOS { get { throw null; } }
    }
    public abstract partial class SiteRecoveryTaskTypeDetails
    {
        protected SiteRecoveryTaskTypeDetails() { }
    }
    public partial class SiteRecoveryUpdateVCenterProperties
    {
        public SiteRecoveryUpdateVCenterProperties() { }
        public string FriendlyName { get { throw null; } set { } }
        public System.Net.IPAddress IPAddress { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        public System.Guid? ProcessServerId { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
    }
    public partial class SiteRecoveryVaultSettingCreateOrUpdateContent
    {
        public SiteRecoveryVaultSettingCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultSettingCreationProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultSettingCreationProperties Properties { get { throw null; } }
    }
    public partial class SiteRecoveryVaultSettingProperties
    {
        internal SiteRecoveryVaultSettingProperties() { }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } }
        public string VMwareToAzureProviderType { get { throw null; } }
    }
    public partial class SiteRecoveryVCenterCreateOrUpdateContent
    {
        public SiteRecoveryVCenterCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAddVCenterProperties Properties { get { throw null; } set { } }
    }
    public partial class SiteRecoveryVCenterPatch
    {
        public SiteRecoveryVCenterPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryUpdateVCenterProperties Properties { get { throw null; } set { } }
    }
    public partial class SiteRecoveryVCenterProperties
    {
        internal SiteRecoveryVCenterProperties() { }
        public string DiscoveryStatus { get { throw null; } }
        public string FabricArmResourceName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> HealthErrors { get { throw null; } }
        public string InfrastructureId { get { throw null; } }
        public string InternalId { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatReceivedOn { get { throw null; } }
        public string Port { get { throw null; } }
        public System.Guid? ProcessServerId { get { throw null; } }
        public string RunAsAccountId { get { throw null; } }
    }
    public partial class SiteRecoveryVersionDetails
    {
        internal SiteRecoveryVersionDetails() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryAgentVersionStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class SiteRecoveryVmDiskDetails
    {
        internal SiteRecoveryVmDiskDetails() { }
        public string CustomTargetDiskName { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string LunId { get { throw null; } }
        public string MaxSizeMB { get { throw null; } }
        public string TargetDiskLocation { get { throw null; } }
        public string TargetDiskName { get { throw null; } }
        public string VhdId { get { throw null; } }
        public string VhdName { get { throw null; } }
        public string VhdType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryVmEncryptionType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryVmEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType NotEncrypted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType OnePassEncrypted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType TwoPassEncrypted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryVmEndpoint
    {
        internal SiteRecoveryVmEndpoint() { }
        public string EndpointName { get { throw null; } }
        public int? PrivatePort { get { throw null; } }
        public string Protocol { get { throw null; } }
        public int? PublicPort { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteRecoveryVmSecurityType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteRecoveryVmSecurityType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType ConfidentialVm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteRecoveryVmTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobTaskDetails
    {
        internal SiteRecoveryVmTaskDetails() { }
        public string SkippedReason { get { throw null; } }
        public string SkippedReasonString { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceSiteOperation : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceSiteOperation(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation NotRequired { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class StorageAccountCustomDetails
    {
        protected StorageAccountCustomDetails() { }
    }
    public partial class StorageClassificationMappingCreateOrUpdateContent
    {
        public StorageClassificationMappingCreateOrUpdateContent() { }
        public Azure.Core.ResourceIdentifier TargetStorageClassificationId { get { throw null; } set { } }
    }
    public partial class SwitchProtectionContent
    {
        public SwitchProtectionContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionProperties Properties { get { throw null; } set { } }
    }
    public partial class SwitchProtectionJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobDetails
    {
        internal SwitchProtectionJobDetails() { }
        public Azure.Core.ResourceIdentifier NewReplicationProtectedItemId { get { throw null; } }
    }
    public partial class SwitchProtectionProperties
    {
        public SwitchProtectionProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionProviderSpecificContent ProviderSpecificDetails { get { throw null; } set { } }
        public string ReplicationProtectedItemName { get { throw null; } set { } }
    }
    public abstract partial class SwitchProtectionProviderSpecificContent
    {
        protected SwitchProtectionProviderSpecificContent() { }
    }
    public partial class SwitchProviderContent
    {
        public SwitchProviderContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProviderProperties Properties { get { throw null; } set { } }
    }
    public partial class SwitchProviderProperties
    {
        public SwitchProviderProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProviderSpecificContent ProviderSpecificDetails { get { throw null; } set { } }
        public string TargetInstanceType { get { throw null; } set { } }
    }
    public abstract partial class SwitchProviderSpecificContent
    {
        protected SwitchProviderSpecificContent() { }
    }
    public partial class TargetComputeSize : Azure.ResourceManager.Models.ResourceData
    {
        internal TargetComputeSize() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TargetComputeSizeProperties Properties { get { throw null; } }
    }
    public partial class TargetComputeSizeProperties
    {
        internal TargetComputeSizeProperties() { }
        public int? CpuCoresCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryComputeSizeErrorDetails> Errors { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HighIopsSupported { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> HyperVGenerations { get { throw null; } }
        public int? MaxDataDiskCount { get { throw null; } }
        public int? MaxNicsCount { get { throw null; } }
        public double? MemoryInGB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? VCpusAvailable { get { throw null; } }
    }
    public partial class TestFailoverCleanupContent
    {
        public TestFailoverCleanupContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverCleanupProperties properties) { }
        public string TestFailoverCleanupComments { get { throw null; } }
    }
    public partial class TestFailoverCleanupProperties
    {
        public TestFailoverCleanupProperties() { }
        public string Comments { get { throw null; } set { } }
    }
    public partial class TestFailoverContent
    {
        public TestFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProperties Properties { get { throw null; } }
    }
    public partial class TestFailoverJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryJobDetails
    {
        internal TestFailoverJobDetails() { }
        public string Comments { get { throw null; } }
        public string NetworkFriendlyName { get { throw null; } }
        public string NetworkName { get { throw null; } }
        public string NetworkType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverReplicationProtectedItemDetails> ProtectedItemDetails { get { throw null; } }
        public string TestFailoverStatus { get { throw null; } }
    }
    public partial class TestFailoverProperties
    {
        public TestFailoverProperties() { }
        public string FailoverDirection { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } set { } }
        public string NetworkType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificContent ProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class TestFailoverProviderSpecificContent
    {
        protected TestFailoverProviderSpecificContent() { }
    }
    public partial class TestMigrateCleanupContent
    {
        public TestMigrateCleanupContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateCleanupProperties properties) { }
        public string TestMigrateCleanupComments { get { throw null; } }
    }
    public partial class TestMigrateCleanupProperties
    {
        public TestMigrateCleanupProperties() { }
        public string Comments { get { throw null; } set { } }
    }
    public partial class TestMigrateContent
    {
        public TestMigrateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateProviderSpecificContent TestMigrateProviderSpecificDetails { get { throw null; } }
    }
    public partial class TestMigrateProperties
    {
        public TestMigrateProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateProviderSpecificContent providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateProviderSpecificContent ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class TestMigrateProviderSpecificContent
    {
        protected TestMigrateProviderSpecificContent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TestMigrationState : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TestMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState TestMigrationCleanupInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState TestMigrationCompletedWithInformation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState TestMigrationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState TestMigrationInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState TestMigrationPartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState TestMigrationSucceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UnplannedFailoverContent
    {
        public UnplannedFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProperties Properties { get { throw null; } }
    }
    public partial class UnplannedFailoverProperties
    {
        public UnplannedFailoverProperties() { }
        public string FailoverDirection { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificContent ProviderSpecificDetails { get { throw null; } set { } }
        public string SourceSiteOperations { get { throw null; } set { } }
    }
    public abstract partial class UnplannedFailoverProviderSpecificContent
    {
        protected UnplannedFailoverProviderSpecificContent() { }
    }
    public partial class UpdateApplianceForReplicationProtectedItemContent
    {
        public UpdateApplianceForReplicationProtectedItemContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemProperties Properties { get { throw null; } }
    }
    public partial class UpdateApplianceForReplicationProtectedItemProperties
    {
        public UpdateApplianceForReplicationProtectedItemProperties(string targetApplianceId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemProviderSpecificContent providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemProviderSpecificContent ProviderSpecificDetails { get { throw null; } }
        public string TargetApplianceId { get { throw null; } }
    }
    public abstract partial class UpdateApplianceForReplicationProtectedItemProviderSpecificContent
    {
        protected UpdateApplianceForReplicationProtectedItemProviderSpecificContent() { }
    }
    public partial class UpdateDiskContent
    {
        public UpdateDiskContent(string diskId) { }
        public string DiskId { get { throw null; } }
        public string TargetDiskName { get { throw null; } set { } }
    }
    public abstract partial class UpdateMigrationItemProviderSpecificContent
    {
        protected UpdateMigrationItemProviderSpecificContent() { }
    }
    public partial class UpdateMobilityServiceContent
    {
        public UpdateMobilityServiceContent() { }
        public string UpdateMobilityServiceRequestRunAsAccountId { get { throw null; } set { } }
    }
    public partial class UpdateNetworkMappingProperties
    {
        public UpdateNetworkMappingProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificUpdateNetworkMappingContent FabricSpecificDetails { get { throw null; } set { } }
        public string RecoveryFabricName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryNetworkId { get { throw null; } set { } }
    }
    public partial class UpdateReplicationProtectedItemProperties
    {
        public UpdateReplicationProtectedItemProperties() { }
        public string EnableRdpOnTargetOption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderContent ProviderSpecificDetails { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryAvailabilitySetId { get { throw null; } set { } }
        public string RecoveryAzureVmName { get { throw null; } set { } }
        public string RecoveryAzureVmSize { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SelectedRecoveryAzureNetworkId { get { throw null; } set { } }
        public string SelectedSourceNicId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SelectedTfoAzureNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicContentDetails> VmNics { get { throw null; } }
    }
    public abstract partial class UpdateReplicationProtectedItemProviderContent
    {
        protected UpdateReplicationProtectedItemProviderContent() { }
    }
    public partial class VaultHealthDetails : Azure.ResourceManager.Models.ResourceData
    {
        internal VaultHealthDetails() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthProperties Properties { get { throw null; } }
    }
    public partial class VaultHealthProperties
    {
        internal VaultHealthProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResourceHealthSummary ContainersHealth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResourceHealthSummary FabricsHealth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResourceHealthSummary ProtectedItemsHealth { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> VaultErrors { get { throw null; } }
    }
    public partial class VaultSettingCreationProperties
    {
        public VaultSettingCreationProperties() { }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } set { } }
        public string VMwareToAzureProviderType { get { throw null; } set { } }
    }
    public partial class VmmFabricDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal VmmFabricDetails() { }
    }
    public partial class VmmToAzureCreateNetworkMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreateNetworkMappingContent
    {
        public VmmToAzureCreateNetworkMappingContent() { }
    }
    public partial class VmmToAzureNetworkMappingSettings : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingFabricSpecificSettings
    {
        internal VmmToAzureNetworkMappingSettings() { }
    }
    public partial class VmmToAzureUpdateNetworkMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificUpdateNetworkMappingContent
    {
        public VmmToAzureUpdateNetworkMappingContent() { }
    }
    public partial class VmmToVmmCreateNetworkMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreateNetworkMappingContent
    {
        public VmmToVmmCreateNetworkMappingContent() { }
    }
    public partial class VmmToVmmNetworkMappingSettings : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingFabricSpecificSettings
    {
        internal VmmToVmmNetworkMappingSettings() { }
    }
    public partial class VmmToVmmUpdateNetworkMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificUpdateNetworkMappingContent
    {
        public VmmToVmmUpdateNetworkMappingContent() { }
    }
    public partial class VmmVmDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVmDetails
    {
        internal VmmVmDetails() { }
    }
    public partial class VmNicContentDetails
    {
        public VmNicContentDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVFailoverIPConfigDetails> IPConfigs { get { throw null; } }
        public bool? IsAcceleratedNetworkingOnRecoveryEnabled { get { throw null; } set { } }
        public bool? IsAcceleratedNetworkingOnTfoEnabled { get { throw null; } set { } }
        public bool? IsReuseExistingNicAllowed { get { throw null; } set { } }
        public bool? IsTfoReuseExistingNicAllowed { get { throw null; } set { } }
        public string NicId { get { throw null; } set { } }
        public string RecoveryNetworkSecurityGroupId { get { throw null; } set { } }
        public string RecoveryNicName { get { throw null; } set { } }
        public string RecoveryNicResourceGroupName { get { throw null; } set { } }
        public string SelectionType { get { throw null; } set { } }
        public string TargetNicName { get { throw null; } set { } }
        public string TfoNetworkSecurityGroupId { get { throw null; } set { } }
        public string TfoNicName { get { throw null; } set { } }
        public string TfoNicResourceGroupName { get { throw null; } set { } }
    }
    public partial class VmNicDetails
    {
        internal VmNicDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVIPConfigDetails> IPConfigs { get { throw null; } }
        public bool? IsAcceleratedNetworkingOnRecoveryEnabled { get { throw null; } }
        public bool? IsAcceleratedNetworkingOnTfoEnabled { get { throw null; } }
        public bool? IsReuseExistingNicAllowed { get { throw null; } }
        public bool? IsTfoReuseExistingNicAllowed { get { throw null; } }
        public string NicId { get { throw null; } }
        public string RecoveryNetworkSecurityGroupId { get { throw null; } }
        public string RecoveryNicName { get { throw null; } }
        public string RecoveryNicResourceGroupName { get { throw null; } }
        public Azure.Core.ResourceIdentifier RecoveryVmNetworkId { get { throw null; } }
        public string ReplicaNicId { get { throw null; } }
        public string SelectionType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceNicArmId { get { throw null; } }
        public string TargetNicName { get { throw null; } }
        public string TfoNetworkSecurityGroupId { get { throw null; } }
        public string TfoRecoveryNicName { get { throw null; } }
        public string TfoRecoveryNicResourceGroupName { get { throw null; } }
        public Azure.Core.ResourceIdentifier TfoVmNetworkId { get { throw null; } }
        public string VmNetworkName { get { throw null; } }
    }
    public partial class VmNicUpdatesTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryTaskTypeDetails
    {
        internal VmNicUpdatesTaskDetails() { }
        public string Name { get { throw null; } }
        public string NicId { get { throw null; } }
        public string VmId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmReplicationProgressHealth : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmReplicationProgressHealth(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth InProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth NoProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth SlowProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VMwareCbtContainerCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerCreationContent
    {
        public VMwareCbtContainerCreationContent() { }
    }
    public partial class VMwareCbtContainerMappingContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerMappingContent
    {
        public VMwareCbtContainerMappingContent(Azure.Core.ResourceIdentifier storageAccountId, string targetLocation) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string ServiceBusConnectionStringSecretName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } }
        public string StorageAccountSasSecretName { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } }
    }
    public partial class VMwareCbtDiskContent
    {
        public VMwareCbtDiskContent(string diskId, string isOSDisk, Azure.Core.ResourceIdentifier logStorageAccountId, string logStorageAccountSasSecretName) { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? DiskType { get { throw null; } set { } }
        public string IsOSDisk { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } }
        public string LogStorageAccountSasSecretName { get { throw null; } }
    }
    public partial class VMwareCbtEnableMigrationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationProviderSpecificContent
    {
        public VMwareCbtEnableMigrationContent(Azure.Core.ResourceIdentifier vmwareMachineId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtDiskContent> disksToInclude, Azure.Core.ResourceIdentifier dataMoverRunAsAccountId, Azure.Core.ResourceIdentifier snapshotRunAsAccountId, Azure.Core.ResourceIdentifier targetResourceGroupId, Azure.Core.ResourceIdentifier targetNetworkId) { }
        public Azure.Core.ResourceIdentifier ConfidentialVmKeyVaultId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DataMoverRunAsAccountId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtDiskContent> DisksToInclude { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType? LicenseType { get { throw null; } set { } }
        public string PerformAutoResync { get { throw null; } set { } }
        public string PerformSqlBulkRegistration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SeedDiskTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier SnapshotRunAsAccountId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetBootDiagnosticsStorageAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetDiskTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetNetworkId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } }
        public string TargetSubnetName { get { throw null; } set { } }
        public string TargetVmName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtSecurityProfileProperties TargetVmSecurityProfile { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TestNetworkId { get { throw null; } set { } }
        public string TestSubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VMwareMachineId { get { throw null; } }
    }
    public partial class VMwareCbtEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEventProviderSpecificDetails
    {
        internal VMwareCbtEventDetails() { }
        public string MigrationItemName { get { throw null; } }
    }
    public partial class VMwareCbtMigrateContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateProviderSpecificContent
    {
        public VMwareCbtMigrateContent(string performShutdown) { }
        public string OSUpgradeVersion { get { throw null; } set { } }
        public string PerformShutdown { get { throw null; } }
    }
    public partial class VMwareCbtMigrationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationProviderSpecificSettings
    {
        internal VMwareCbtMigrationDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceMonitoringDetails ApplianceMonitoringDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier ConfidentialVmKeyVaultId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DataMoverRunAsAccountId { get { throw null; } }
        public int? DeltaSyncProgressPercentage { get { throw null; } }
        public long? DeltaSyncRetryCount { get { throw null; } }
        public string FirmwareType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.GatewayOperationDetails GatewayOperationDetails { get { throw null; } }
        public int? InitialSeedingProgressPercentage { get { throw null; } }
        public long? InitialSeedingRetryCount { get { throw null; } }
        public string IsCheckSumResyncCycle { get { throw null; } }
        public Azure.Core.ResourceIdentifier LastRecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public int? MigrationProgressPercentage { get { throw null; } }
        public Azure.Core.ResourceIdentifier MigrationRecoveryPointId { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSType { get { throw null; } }
        public string PerformAutoResync { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public int? ResumeProgressPercentage { get { throw null; } }
        public long? ResumeRetryCount { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public string ResyncRequired { get { throw null; } }
        public long? ResyncRetryCount { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryResyncState? ResyncState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SeedDiskTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier SnapshotRunAsAccountId { get { throw null; } }
        public string SqlServerLicenseType { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedOSVersions { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } }
        public string TargetAvailabilityZone { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetBootDiagnosticsStorageAccountId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetDiskTags { get { throw null; } }
        public string TargetGeneration { get { throw null; } }
        public string TargetLocation { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetNetworkId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetNicTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } }
        public string TargetVmName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtSecurityProfileProperties TargetVmSecurityProfile { get { throw null; } }
        public string TargetVmSize { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetVmTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TestNetworkId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtNicDetails> VmNics { get { throw null; } }
        public Azure.Core.ResourceIdentifier VMwareMachineId { get { throw null; } }
    }
    public partial class VMwareCbtNicContent
    {
        public VMwareCbtNicContent(string nicId, string isPrimaryNic) { }
        public string IsPrimaryNic { get { throw null; } }
        public string IsSelectedForMigration { get { throw null; } set { } }
        public string NicId { get { throw null; } }
        public string TargetNicName { get { throw null; } set { } }
        public System.Net.IPAddress TargetStaticIPAddress { get { throw null; } set { } }
        public string TargetSubnetName { get { throw null; } set { } }
        public System.Net.IPAddress TestStaticIPAddress { get { throw null; } set { } }
        public string TestSubnetName { get { throw null; } set { } }
    }
    public partial class VMwareCbtNicDetails
    {
        internal VMwareCbtNicDetails() { }
        public string IsPrimaryNic { get { throw null; } }
        public string IsSelectedForMigration { get { throw null; } }
        public string NicId { get { throw null; } }
        public System.Net.IPAddress SourceIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? SourceIPAddressType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceNetworkId { get { throw null; } }
        public System.Net.IPAddress TargetIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? TargetIPAddressType { get { throw null; } }
        public string TargetNicName { get { throw null; } }
        public string TargetSubnetName { get { throw null; } }
        public System.Net.IPAddress TestIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryEthernetAddressType? TestIPAddressType { get { throw null; } }
        public Azure.Core.ResourceIdentifier TestNetworkId { get { throw null; } }
        public string TestSubnetName { get { throw null; } }
    }
    public partial class VMwareCbtPolicyCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificContent
    {
        public VMwareCbtPolicyCreationContent() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int? RecoveryPointHistoryInMinutes { get { throw null; } set { } }
    }
    public partial class VMwareCbtPolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal VMwareCbtPolicyDetails() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } }
        public int? RecoveryPointHistoryInMinutes { get { throw null; } }
    }
    public partial class VMwareCbtProtectedDiskDetails
    {
        internal VMwareCbtProtectedDiskDetails() { }
        public long? CapacityInBytes { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskPath { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryDiskAccountType? DiskType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.GatewayOperationDetails GatewayOperationDetails { get { throw null; } }
        public string IsOSDisk { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogStorageAccountId { get { throw null; } }
        public string LogStorageAccountSasSecretName { get { throw null; } }
        public System.Uri SeedBlobUri { get { throw null; } }
        public string SeedManagedDiskId { get { throw null; } }
        public System.Uri TargetBlobUri { get { throw null; } }
        public string TargetDiskName { get { throw null; } }
        public string TargetManagedDiskId { get { throw null; } }
    }
    public partial class VMwareCbtProtectionContainerMappingDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProviderSpecificDetails
    {
        internal VMwareCbtProtectionContainerMappingDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> ExcludedSkus { get { throw null; } }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } }
        public System.Uri KeyVaultUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> RoleSizeToNicCountMap { get { throw null; } }
        public string ServiceBusConnectionStringSecretName { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } }
        public string StorageAccountSasSecretName { get { throw null; } }
        public string TargetLocation { get { throw null; } }
    }
    public partial class VMwareCbtResumeReplicationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationProviderSpecificContent
    {
        public VMwareCbtResumeReplicationContent() { }
        public string DeleteMigrationResources { get { throw null; } set { } }
    }
    public partial class VMwareCbtResyncContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncProviderSpecificContent
    {
        public VMwareCbtResyncContent(string skipCbtReset) { }
        public string SkipCbtReset { get { throw null; } }
    }
    public partial class VMwareCbtSecurityProfileProperties
    {
        public VMwareCbtSecurityProfileProperties() { }
        public string IsTargetVmConfidentialEncryptionEnabled { get { throw null; } set { } }
        public string IsTargetVmIntegrityMonitoringEnabled { get { throw null; } set { } }
        public string IsTargetVmSecureBootEnabled { get { throw null; } set { } }
        public string IsTargetVmTpmEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVmSecurityType? TargetVmSecurityType { get { throw null; } set { } }
    }
    public partial class VMwareCbtTestMigrateContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateProviderSpecificContent
    {
        public VMwareCbtTestMigrateContent(Azure.Core.ResourceIdentifier recoveryPointId, Azure.Core.ResourceIdentifier networkId) { }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } }
        public string OSUpgradeVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPointId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtNicContent> VmNics { get { throw null; } }
    }
    public partial class VMwareCbtUpdateDiskContent
    {
        public VMwareCbtUpdateDiskContent(string diskId) { }
        public string DiskId { get { throw null; } }
        public string IsOSDisk { get { throw null; } set { } }
        public string TargetDiskName { get { throw null; } set { } }
    }
    public partial class VMwareCbtUpdateMigrationItemContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateMigrationItemProviderSpecificContent
    {
        public VMwareCbtUpdateMigrationItemContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryLicenseType? LicenseType { get { throw null; } set { } }
        public string PerformAutoResync { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoverySqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetBootDiagnosticsStorageAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetDiskTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmName { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TestNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtUpdateDiskContent> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtNicContent> VmNics { get { throw null; } }
    }
    public partial class VMwareDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal VMwareDetails() { }
        public string AgentCount { get { throw null; } }
        public System.DateTimeOffset? AgentExpireOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryVersionDetails AgentVersionDetails { get { throw null; } }
        public long? AvailableMemoryInBytes { get { throw null; } }
        public long? AvailableSpaceInBytes { get { throw null; } }
        public string CpuLoad { get { throw null; } }
        public string CpuLoadStatus { get { throw null; } }
        public string CsServiceStatus { get { throw null; } }
        public string DatabaseServerLoad { get { throw null; } }
        public string DatabaseServerLoadStatus { get { throw null; } }
        public string HostName { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeat { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MasterTargetServer> MasterTargetServers { get { throw null; } }
        public string MemoryUsageStatus { get { throw null; } }
        public string ProcessServerCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServer> ProcessServers { get { throw null; } }
        public string ProtectedServers { get { throw null; } }
        public string PSTemplateVersion { get { throw null; } }
        public string ReplicationPairCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryRunAsAccount> RunAsAccounts { get { throw null; } }
        public string SpaceUsageStatus { get { throw null; } }
        public System.DateTimeOffset? SslCertExpireOn { get { throw null; } }
        public int? SslCertExpiryRemainingDays { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageFabricSwitchProviderBlockingErrorDetails> SwitchProviderBlockingErrorDetails { get { throw null; } }
        public string SystemLoad { get { throw null; } }
        public string SystemLoadStatus { get { throw null; } }
        public long? TotalMemoryInBytes { get { throw null; } }
        public long? TotalSpaceInBytes { get { throw null; } }
        public string VersionStatus { get { throw null; } }
        public string WebLoad { get { throw null; } }
        public string WebLoadStatus { get { throw null; } }
    }
    public partial class VMwareV2FabricCreationContent : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreationContent
    {
        public VMwareV2FabricCreationContent(Azure.Core.ResourceIdentifier migrationSolutionId) { }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PhysicalSiteId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VMwareSiteId { get { throw null; } set { } }
    }
    public partial class VMwareV2FabricSpecificDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal VMwareV2FabricSpecificDetails() { }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PhysicalSiteId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryProcessServerDetails> ProcessServers { get { throw null; } }
        public string ServiceContainerId { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier VMwareSiteId { get { throw null; } }
    }
    public partial class VMwareVmDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryReplicationProviderSettings
    {
        internal VMwareVmDetails() { }
        public string AgentGeneratedId { get { throw null; } }
        public string AgentInstalled { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string DiscoveryType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskDetails> DiskDetails { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public string OSType { get { throw null; } }
        public string PoweredOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SiteRecoveryHealthError> ValidationErrors { get { throw null; } }
        public string VCenterInfrastructureId { get { throw null; } }
    }
}
