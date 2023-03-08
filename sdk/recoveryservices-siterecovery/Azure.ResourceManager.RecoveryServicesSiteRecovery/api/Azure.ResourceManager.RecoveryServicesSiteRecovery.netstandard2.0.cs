namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public partial class AlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource>, System.Collections.IEnumerable
    {
        protected AlertCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertSettingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlertCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertSettingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlertCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource> Get(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource>> GetAsync(string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertData : Azure.ResourceManager.Models.ResourceData
    {
        internal AlertData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlertProperties Properties { get { throw null; } }
    }
    public partial class AlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string alertSettingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlertCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlertCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource>, System.Collections.IEnumerable
    {
        protected EventCollection() { }
        public virtual Azure.Response<bool> Exists(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource> Get(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource>> GetAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventData : Azure.ResourceManager.Models.ResourceData
    {
        internal EventData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProperties Properties { get { throw null; } }
    }
    public partial class EventResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.EventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string eventName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FabricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>, System.Collections.IEnumerable
    {
        protected FabricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fabricName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fabricName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> Get(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>> GetAsync(string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FabricData : Azure.ResourceManager.Models.ResourceData
    {
        internal FabricData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricProperties Properties { get { throw null; } }
    }
    public partial class FabricResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FabricResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> CheckConsistency(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>> CheckConsistencyAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> Get(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>> GetAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource> GetLogicalNetwork(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource>> GetLogicalNetworkAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkCollection GetLogicalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> GetNetwork(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource>> GetNetworkAsync(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkCollection GetNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> GetProtectionContainer(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>> GetProtectionContainerAsync(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerCollection GetProtectionContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> GetRecoveryServicesProvider(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>> GetRecoveryServicesProviderAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderCollection GetRecoveryServicesProviders() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassification(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>> GetStorageClassificationAsync(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationCollection GetStorageClassifications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> GetVCenter(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource>> GetVCenterAsync(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterCollection GetVCenters() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MigrateToAad(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MigrateToAadAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> ReassociateGateway(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverProcessServerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>> ReassociateGatewayAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverProcessServerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> RenewCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RenewCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>> RenewCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RenewCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>, System.Collections.IEnumerable
    {
        protected JobCollection() { }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobData : Azure.ResourceManager.Models.ResourceData
    {
        internal JobData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobProperties Properties { get { throw null; } }
    }
    public partial class JobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.JobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> Export(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobQueryParameter jobQueryParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>> ExportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobQueryParameter jobQueryParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> Resume(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeJobParams resumeJobParams, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>> ResumeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeJobParams resumeJobParams, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicalNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource>, System.Collections.IEnumerable
    {
        protected LogicalNetworkCollection() { }
        public virtual Azure.Response<bool> Exists(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource> Get(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource>> GetAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicalNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        internal LogicalNetworkData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LogicalNetworkProperties Properties { get { throw null; } }
    }
    public partial class LogicalNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicalNetworkResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string logicalNetworkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>, System.Collections.IEnumerable
    {
        protected MigrationItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string migrationItemName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string migrationItemName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> Get(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> GetAll(string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> GetAllAsync(string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> GetAsync(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationItemData : Azure.ResourceManager.Models.ResourceData
    {
        internal MigrationItemData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemProperties Properties { get { throw null; } }
    }
    public partial class MigrationItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationItemResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string migrationItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string deleteOption = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string deleteOption = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> GetMigrationRecoveryPoint(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>> GetMigrationRecoveryPointAsync(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointCollection GetMigrationRecoveryPoints() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> Migrate(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> MigrateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> PauseReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PauseReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> PauseReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PauseReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> ResumeReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> ResumeReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> Resync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> ResyncAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> TestMigrate(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> TestMigrateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> TestMigrateCleanup(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> TestMigrateCleanupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationRecoveryPointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>, System.Collections.IEnumerable
    {
        protected MigrationRecoveryPointCollection() { }
        public virtual Azure.Response<bool> Exists(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> Get(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource>> GetAsync(string migrationRecoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class NetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkCollection() { }
        public virtual Azure.Response<bool> Exists(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> Get(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource>> GetAsync(string networkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkData : Azure.ResourceManager.Models.ResourceData
    {
        internal NetworkData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkProperties Properties { get { throw null; } }
    }
    public partial class NetworkMappingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource>, System.Collections.IEnumerable
    {
        protected NetworkMappingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkMappingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkMappingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> Get(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource>> GetAsync(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkMappingData : Azure.ResourceManager.Models.ResourceData
    {
        internal NetworkMappingData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingProperties Properties { get { throw null; } }
    }
    public partial class NetworkMappingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkMappingResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string networkName, string networkMappingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string networkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> GetNetworkMapping(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource>> GetNetworkMappingAsync(string networkMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingCollection GetNetworkMappings() { throw null; }
    }
    public partial class PolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource>, System.Collections.IEnumerable
    {
        protected PolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyData : Azure.ResourceManager.Models.ResourceData
    {
        internal PolicyData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProperties Properties { get { throw null; } }
    }
    public partial class PolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectableItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource>, System.Collections.IEnumerable
    {
        protected ProtectableItemCollection() { }
        public virtual Azure.Response<bool> Exists(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource> Get(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource> GetAll(string filter = null, string take = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource> GetAllAsync(string filter = null, string take = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource>> GetAsync(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProtectableItemData : Azure.ResourceManager.Models.ResourceData
    {
        internal ProtectableItemData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectableItemProperties Properties { get { throw null; } }
    }
    public partial class ProtectableItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectableItemResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string protectableItemName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectionContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>, System.Collections.IEnumerable
    {
        protected ProtectionContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectionContainerName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectionContainerName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> Get(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>> GetAsync(string protectionContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProtectionContainerData : Azure.ResourceManager.Models.ResourceData
    {
        internal ProtectionContainerData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerProperties Properties { get { throw null; } }
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
    public partial class ProtectionContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectionContainerResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> DiscoverProtectableItem(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiscoverProtectableItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>> DiscoverProtectableItemAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiscoverProtectableItemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> GetMigrationItem(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource>> GetMigrationItemAsync(string migrationItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemCollection GetMigrationItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource> GetProtectableItem(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource>> GetProtectableItemAsync(string protectableItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemCollection GetProtectableItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMapping(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource>> GetProtectionContainerMappingAsync(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingCollection GetProtectionContainerMappings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetReplicationProtectedItem(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> GetReplicationProtectedItemAsync(string replicatedProtectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemCollection GetReplicationProtectedItems() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> SwitchProtection(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>> SwitchProtectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>, System.Collections.IEnumerable
    {
        protected RecoveryPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string recoveryPlanName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string recoveryPlanName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> Get(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> GetAsync(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryPlanData : Azure.ResourceManager.Models.ResourceData
    {
        internal RecoveryPlanData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPlanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryPlanResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string recoveryPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> FailoverCancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> FailoverCancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> FailoverCommit(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> FailoverCommitAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> PlannedFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPlannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> PlannedFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPlannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> Reprotect(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> ReprotectAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> TestFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> TestFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> TestFailoverCleanup(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> TestFailoverCleanupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> UnplannedFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanUnplannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> UnplannedFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanUnplannedFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryPointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource>, System.Collections.IEnumerable
    {
        protected RecoveryPointCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource> Get(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource>> GetAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryPointData : Azure.ResourceManager.Models.ResourceData
    {
        internal RecoveryPointData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryPointResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string protectionContainerName, string replicatedProtectedItemName, string recoveryPointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryServicesProviderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>, System.Collections.IEnumerable
    {
        protected RecoveryServicesProviderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryServicesProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryServicesProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> Get(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>> GetAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryServicesProviderData : Azure.ResourceManager.Models.ResourceData
    {
        internal RecoveryServicesProviderData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryServicesProviderProperties Properties { get { throw null; } }
    }
    public partial class RecoveryServicesProviderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryServicesProviderResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string providerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> RefreshProvider(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>> RefreshProviderAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryServicesProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryServicesProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RecoveryServicesSiteRecoveryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource> GetAlert(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource>> GetAlertAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string alertSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertResource GetAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertCollection GetAlerts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource> GetEvent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource>> GetEventAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.EventResource GetEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.EventCollection GetEvents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource> GetFabric(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource>> GetFabricAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricResource GetFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricCollection GetFabrics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource> GetJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource>> GetJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.JobResource GetJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.JobCollection GetJobs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.LogicalNetworkResource GetLogicalNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource GetMigrationItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> GetMigrationItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> GetMigrationItemsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationRecoveryPointResource GetMigrationRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource GetNetworkMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> GetNetworkMappings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> GetNetworkMappingsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource GetNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> GetNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> GetNetworksAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyCollection GetPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource> GetPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource>> GetPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyResource GetPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectableItemResource GetProtectableItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource GetProtectionContainerMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMappings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMappingsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource GetProtectionContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> GetProtectionContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> GetProtectionContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource> GetRecoveryPlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource>> GetRecoveryPlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanResource GetRecoveryPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanCollection GetRecoveryPlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource GetRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource GetRecoveryServicesProviderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> GetRecoveryServicesProviders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> GetRecoveryServicesProvidersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAppliance> GetReplicationAppliances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAppliance> GetReplicationAppliancesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource GetStorageClassificationMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetStorageClassificationMappings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetStorageClassificationMappingsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource GetStorageClassificationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassifications(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassificationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SupportedOperatingSystems> GetSupportedOperatingSystem(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string instanceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SupportedOperatingSystems>> GetSupportedOperatingSystemAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string instanceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource> GetVaultSetting(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource>> GetVaultSettingAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource GetVaultSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingCollection GetVaultSettings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource GetVCenterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> GetVCenters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> GetVCentersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicationEligibilityResultData : Azure.ResourceManager.Models.ResourceData
    {
        internal ReplicationEligibilityResultData() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationEligibilityResultsProperties Properties { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> AddDisks(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AddDisksContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> AddDisksAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AddDisksContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> ApplyRecoveryPoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource>> ApplyRecoveryPointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource> GetRecoveryPoint(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointResource>> GetRecoveryPointAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPointCollection GetRecoveryPoints() { throw null; }
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
    public partial class StorageClassificationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>, System.Collections.IEnumerable
    {
        protected StorageClassificationCollection() { }
        public virtual Azure.Response<bool> Exists(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> Get(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource>> GetAsync(string storageClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageClassificationMappingData : Azure.ResourceManager.Models.ResourceData
    {
        internal StorageClassificationMappingData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string TargetStorageClassificationId { get { throw null; } }
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
    public partial class VaultSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource>, System.Collections.IEnumerable
    {
        protected VaultSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultSettingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultSettingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultSettingName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultSettingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource> Get(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource>> GetAsync(string vaultSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VaultSettingData : Azure.ResourceManager.Models.ResourceData
    {
        internal VaultSettingData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultSettingProperties Properties { get { throw null; } }
    }
    public partial class VaultSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VaultSettingResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string vaultSettingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultSettingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultSettingCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VCenterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource>, System.Collections.IEnumerable
    {
        protected VCenterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vCenterName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VCenterCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vCenterName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VCenterCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> Get(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource>> GetAsync(string vCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VCenterData : Azure.ResourceManager.Models.ResourceData
    {
        internal VCenterData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VCenterProperties Properties { get { throw null; } }
    }
    public partial class VCenterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VCenterResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string fabricName, string vCenterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Mock
{
    public partial class MigrationItemResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected MigrationItemResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> GetMigrationItems(string resourceName, string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.MigrationItemResource> GetMigrationItemsAsync(string resourceName, string skipToken = null, string takeToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkMappingResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected NetworkMappingResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> GetNetworkMappings(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkMappingResource> GetNetworkMappingsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected NetworkResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> GetNetworks(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.NetworkResource> GetNetworksAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectionContainerMappingResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ProtectionContainerMappingResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMappings(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerMappingResource> GetProtectionContainerMappingsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectionContainerResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ProtectionContainerResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> GetProtectionContainers(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ProtectionContainerResource> GetProtectionContainersAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryServicesProviderResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected RecoveryServicesProviderResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> GetRecoveryServicesProviders(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryServicesProviderResource> GetRecoveryServicesProvidersAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationProtectedItemResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ReplicationProtectedItemResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetReplicationProtectedItems(string resourceName, string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectedItemResource> GetReplicationProtectedItemsAsync(string resourceName, string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.AlertCollection GetAlerts(string resourceName) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.EventCollection GetEvents(string resourceName) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.FabricCollection GetFabrics(string resourceName) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.JobCollection GetJobs(string resourceName) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.PolicyCollection GetPolicies(string resourceName) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.RecoveryPlanCollection GetRecoveryPlans(string resourceName) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAppliance> GetReplicationAppliances(string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAppliance> GetReplicationAppliancesAsync(string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationEligibilityResultCollection GetReplicationEligibilityResults(string virtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.ReplicationProtectionIntentCollection GetReplicationProtectionIntents(string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails> GetReplicationVaultHealth(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails>> GetReplicationVaultHealthAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SupportedOperatingSystems> GetSupportedOperatingSystem(string resourceName, string instanceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SupportedOperatingSystems>> GetSupportedOperatingSystemAsync(string resourceName, string instanceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesSiteRecovery.VaultSettingCollection GetVaultSettings(string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails> RefreshReplicationVaultHealth(Azure.WaitUntil waitUntil, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultHealthDetails>> RefreshReplicationVaultHealthAsync(Azure.WaitUntil waitUntil, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageClassificationMappingResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected StorageClassificationMappingResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetStorageClassificationMappings(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationMappingResource> GetStorageClassificationMappingsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageClassificationResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected StorageClassificationResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassifications(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.StorageClassificationResource> GetStorageClassificationsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VCenterResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected VCenterResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> GetVCenters(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesSiteRecovery.VCenterResource> GetVCentersAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class A2AAddDisksInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AddDisksProviderSpecificInput
    {
        public A2AAddDisksInput() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmDiskInputDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmManagedDiskInputDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2AApplyRecoveryPointInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointProviderSpecificInput
    {
        public A2AApplyRecoveryPointInput() { }
    }
    public partial class A2AContainerCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerCreationInput
    {
        public A2AContainerCreationInput() { }
    }
    public partial class A2AContainerMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerMappingInput
    {
        public A2AContainerMappingInput() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } set { } }
        public string AutomationAccountArmId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } set { } }
    }
    public partial class A2ACreateProtectionIntentInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CreateProtectionIntentProviderSpecificDetails
    {
        public A2ACreateProtectionIntentInput(string fabricObjectId, string primaryLocation, string recoveryLocation, string recoverySubscriptionId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType recoveryAvailabilityType, string recoveryResourceGroupId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } set { } }
        public string AutomationAccountArmId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? AutoProtectionOfDataDisk { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public string FabricObjectId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } set { } }
        public string MultiVmGroupName { get { throw null; } set { } }
        public string PrimaryLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails PrimaryStagingStorageAccountCustomInput { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionProfileCustomDetails ProtectionProfileCustomInput { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryAvailabilitySetCustomDetails RecoveryAvailabilitySetCustomInput { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARecoveryAvailabilityType RecoveryAvailabilityType { get { throw null; } }
        public string RecoveryAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails RecoveryBootDiagStorageAccount { get { throw null; } set { } }
        public string RecoveryLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryProximityPlacementGroupCustomDetails RecoveryProximityPlacementGroupCustomInput { get { throw null; } set { } }
        public string RecoveryResourceGroupId { get { throw null; } }
        public string RecoverySubscriptionId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryVirtualNetworkCustomDetails RecoveryVirtualNetworkCustomInput { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentDiskInputDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentManagedDiskInputDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2ACrossClusterMigrationApplyRecoveryPointInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointProviderSpecificInput
    {
        public A2ACrossClusterMigrationApplyRecoveryPointInput() { }
    }
    public partial class A2ACrossClusterMigrationContainerCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerCreationInput
    {
        public A2ACrossClusterMigrationContainerCreationInput() { }
    }
    public partial class A2ACrossClusterMigrationEnableProtectionInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificInput
    {
        public A2ACrossClusterMigrationEnableProtectionInput() { }
        public string FabricObjectId { get { throw null; } set { } }
        public string RecoveryContainerId { get { throw null; } set { } }
    }
    public partial class A2ACrossClusterMigrationPolicyCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput
    {
        public A2ACrossClusterMigrationPolicyCreationInput() { }
    }
    public partial class A2ACrossClusterMigrationReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal A2ACrossClusterMigrationReplicationDetails() { }
        public string FabricObjectId { get { throw null; } }
        public string LifecycleId { get { throw null; } }
        public string OSType { get { throw null; } }
        public string PrimaryFabricLocation { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class A2AEnableProtectionInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificInput
    {
        public A2AEnableProtectionInput(string fabricObjectId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public string FabricObjectId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } set { } }
        public string MultiVmGroupName { get { throw null; } set { } }
        public string RecoveryAvailabilitySetId { get { throw null; } set { } }
        public string RecoveryAvailabilityZone { get { throw null; } set { } }
        public string RecoveryAzureNetworkId { get { throw null; } set { } }
        public string RecoveryBootDiagStorageAccountId { get { throw null; } set { } }
        public string RecoveryCapacityReservationGroupId { get { throw null; } set { } }
        public string RecoveryCloudServiceId { get { throw null; } set { } }
        public string RecoveryContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation RecoveryExtendedLocation { get { throw null; } set { } }
        public string RecoveryProximityPlacementGroupId { get { throw null; } set { } }
        public string RecoveryResourceGroupId { get { throw null; } set { } }
        public string RecoverySubnetName { get { throw null; } set { } }
        public string RecoveryVirtualMachineScaleSetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmDiskInputDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmManagedDiskInputDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2AEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails
    {
        internal A2AEventDetails() { }
        public string FabricLocation { get { throw null; } }
        public string FabricName { get { throw null; } }
        public string FabricObjectId { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string RemoteFabricLocation { get { throw null; } }
        public string RemoteFabricName { get { throw null; } }
    }
    public partial class A2AExtendedLocationDetails
    {
        internal A2AExtendedLocationDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation PrimaryExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation RecoveryExtendedLocation { get { throw null; } }
    }
    public partial class A2APolicyCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput
    {
        public A2APolicyCreationInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus multiVmSyncStatus) { }
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
        public string DekKeyVaultArmId { get { throw null; } }
        public long? DiskCapacityInBytes { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskState { get { throw null; } }
        public string DiskType { get { throw null; } }
        public System.Uri DiskUri { get { throw null; } }
        public string FailoverDiskName { get { throw null; } }
        public bool? IsDiskEncrypted { get { throw null; } }
        public bool? IsDiskKeyEncrypted { get { throw null; } }
        public string KekKeyVaultArmId { get { throw null; } }
        public string KeyIdentifier { get { throw null; } }
        public string MonitoringJobType { get { throw null; } }
        public int? MonitoringPercentageCompletion { get { throw null; } }
        public string PrimaryDiskAzureStorageAccountId { get { throw null; } }
        public string PrimaryStagingAzureStorageAccountId { get { throw null; } }
        public string RecoveryAzureStorageAccountId { get { throw null; } }
        public System.Uri RecoveryDiskUri { get { throw null; } }
        public bool? ResyncRequired { get { throw null; } }
        public string SecretIdentifier { get { throw null; } }
        public string TfoDiskName { get { throw null; } }
    }
    public partial class A2AProtectedManagedDiskDetails
    {
        internal A2AProtectedManagedDiskDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedDiskLevelOperation { get { throw null; } }
        public double? DataPendingAtSourceAgentInMB { get { throw null; } }
        public double? DataPendingInStagingStorageAccountInMB { get { throw null; } }
        public string DekKeyVaultArmId { get { throw null; } }
        public long? DiskCapacityInBytes { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskState { get { throw null; } }
        public string DiskType { get { throw null; } }
        public string FailoverDiskName { get { throw null; } }
        public bool? IsDiskEncrypted { get { throw null; } }
        public bool? IsDiskKeyEncrypted { get { throw null; } }
        public string KekKeyVaultArmId { get { throw null; } }
        public string KeyIdentifier { get { throw null; } }
        public string MonitoringJobType { get { throw null; } }
        public int? MonitoringPercentageCompletion { get { throw null; } }
        public string PrimaryDiskEncryptionSetId { get { throw null; } }
        public string PrimaryStagingAzureStorageAccountId { get { throw null; } }
        public string RecoveryDiskEncryptionSetId { get { throw null; } }
        public string RecoveryOrignalTargetDiskId { get { throw null; } }
        public string RecoveryReplicaDiskAccountType { get { throw null; } }
        public string RecoveryReplicaDiskId { get { throw null; } }
        public string RecoveryResourceGroupId { get { throw null; } }
        public string RecoveryTargetDiskAccountType { get { throw null; } }
        public string RecoveryTargetDiskId { get { throw null; } }
        public bool? ResyncRequired { get { throw null; } }
        public string SecretIdentifier { get { throw null; } }
        public string TfoDiskName { get { throw null; } }
    }
    public partial class A2AProtectionContainerMappingDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProviderSpecificDetails
    {
        internal A2AProtectionContainerMappingDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } }
        public string AutomationAccountArmId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } }
        public string JobScheduleName { get { throw null; } }
        public string ScheduleName { get { throw null; } }
    }
    public partial class A2AProtectionIntentDiskInputDetails
    {
        public A2AProtectionIntentDiskInputDetails(System.Uri diskUri) { }
        public System.Uri DiskUri { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails PrimaryStagingStorageAccountCustomInput { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails RecoveryAzureStorageAccountCustomInput { get { throw null; } set { } }
    }
    public partial class A2AProtectionIntentManagedDiskInputDetails
    {
        public A2AProtectionIntentManagedDiskInputDetails(string diskId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails PrimaryStagingStorageAccountCustomInput { get { throw null; } set { } }
        public string RecoveryDiskEncryptionSetId { get { throw null; } set { } }
        public string RecoveryReplicaDiskAccountType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryResourceGroupCustomDetails RecoveryResourceGroupCustomInput { get { throw null; } set { } }
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
    public partial class A2ARemoveDisksInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RemoveDisksProviderSpecificInput
    {
        public A2ARemoveDisksInput() { }
        public System.Collections.Generic.IList<System.Uri> VmDisksUris { get { throw null; } }
        public System.Collections.Generic.IList<string> VmManagedDisksIds { get { throw null; } }
    }
    public partial class A2AReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal A2AReplicationDetails() { }
        public System.DateTimeOffset? AgentCertificateExpiryOn { get { throw null; } }
        public System.DateTimeOffset? AgentExpiryOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? AutoProtectionOfDataDisk { get { throw null; } }
        public string FabricObjectId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation InitialPrimaryExtendedLocation { get { throw null; } }
        public string InitialPrimaryFabricLocation { get { throw null; } }
        public string InitialPrimaryZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation InitialRecoveryExtendedLocation { get { throw null; } }
        public string InitialRecoveryFabricLocation { get { throw null; } }
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
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation PrimaryExtendedLocation { get { throw null; } }
        public string PrimaryFabricLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectedManagedDiskDetails> ProtectedManagedDisks { get { throw null; } }
        public string RecoveryAvailabilitySet { get { throw null; } }
        public string RecoveryAvailabilityZone { get { throw null; } }
        public string RecoveryAzureGeneration { get { throw null; } }
        public string RecoveryAzureResourceGroupId { get { throw null; } }
        public string RecoveryAzureVmName { get { throw null; } }
        public string RecoveryAzureVmSize { get { throw null; } }
        public string RecoveryBootDiagStorageAccountId { get { throw null; } }
        public string RecoveryCapacityReservationGroupId { get { throw null; } }
        public string RecoveryCloudService { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation RecoveryExtendedLocation { get { throw null; } }
        public string RecoveryFabricLocation { get { throw null; } }
        public string RecoveryFabricObjectId { get { throw null; } }
        public string RecoveryProximityPlacementGroupId { get { throw null; } }
        public string RecoveryVirtualMachineScaleSetId { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public string SelectedRecoveryAzureNetworkId { get { throw null; } }
        public string SelectedTfoAzureNetworkId { get { throw null; } }
        public string TestFailoverRecoveryFabricObjectId { get { throw null; } }
        public string TfoAzureVmName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AUnprotectedDiskDetails> UnprotectedDisks { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType? VmEncryptionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AzureToAzureVmSyncedConfigDetails VmSyncedConfigDetails { get { throw null; } }
    }
    public partial class A2AReplicationIntentDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentProviderSpecificSettings
    {
        internal A2AReplicationIntentDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } }
        public string AutomationAccountArmId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? AutoProtectionOfDataDisk { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskEncryptionInfo DiskEncryptionInfo { get { throw null; } }
        public string FabricObjectId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public string PrimaryLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails PrimaryStagingStorageAccount { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionProfileCustomDetails ProtectionProfile { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryAvailabilitySetCustomDetails RecoveryAvailabilitySet { get { throw null; } }
        public string RecoveryAvailabilityType { get { throw null; } }
        public string RecoveryAvailabilityZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails RecoveryBootDiagStorageAccount { get { throw null; } }
        public string RecoveryLocation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryProximityPlacementGroupCustomDetails RecoveryProximityPlacementGroup { get { throw null; } }
        public string RecoveryResourceGroupId { get { throw null; } }
        public string RecoverySubscriptionId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryVirtualNetworkCustomDetails RecoveryVirtualNetwork { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentDiskInputDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AProtectionIntentManagedDiskInputDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2AReprotectInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificInput
    {
        public A2AReprotectInput() { }
        public string PolicyId { get { throw null; } set { } }
        public string RecoveryAvailabilitySetId { get { throw null; } set { } }
        public string RecoveryCloudServiceId { get { throw null; } set { } }
        public string RecoveryContainerId { get { throw null; } set { } }
        public string RecoveryResourceGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmDiskInputDetails> VmDisks { get { throw null; } }
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
    public partial class A2ASwitchProtectionInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionProviderSpecificInput
    {
        public A2ASwitchProtectionInput() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public string PolicyId { get { throw null; } set { } }
        public string RecoveryAvailabilitySetId { get { throw null; } set { } }
        public string RecoveryAvailabilityZone { get { throw null; } set { } }
        public string RecoveryBootDiagStorageAccountId { get { throw null; } set { } }
        public string RecoveryCapacityReservationGroupId { get { throw null; } set { } }
        public string RecoveryCloudServiceId { get { throw null; } set { } }
        public string RecoveryContainerId { get { throw null; } set { } }
        public string RecoveryProximityPlacementGroupId { get { throw null; } set { } }
        public string RecoveryResourceGroupId { get { throw null; } set { } }
        public string RecoveryVirtualMachineScaleSetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmDiskInputDetails> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmManagedDiskInputDetails> VmManagedDisks { get { throw null; } }
    }
    public partial class A2ATestFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificInput
    {
        public A2ATestFailoverInput() { }
        public string CloudServiceCreationOption { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
    }
    public partial class A2AUnplannedFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificInput
    {
        public A2AUnplannedFailoverInput() { }
        public string CloudServiceCreationOption { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
    }
    public partial class A2AUnprotectedDiskDetails
    {
        internal A2AUnprotectedDiskDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutoProtectionOfDataDisk? DiskAutoProtectionStatus { get { throw null; } }
        public int? DiskLunId { get { throw null; } }
    }
    public partial class A2AUpdateContainerMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificUpdateContainerMappingInput
    {
        public A2AUpdateContainerMappingInput() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus? AgentAutoUpdateStatus { get { throw null; } set { } }
        public string AutomationAccountArmId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AutomationAccountAuthenticationType? AutomationAccountAuthenticationType { get { throw null; } set { } }
    }
    public partial class A2AUpdateReplicationProtectedItemInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderInput
    {
        public A2AUpdateReplicationProtectedItemInput() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AVmManagedDiskUpdateDetails> ManagedDiskUpdateDetails { get { throw null; } }
        public string RecoveryBootDiagStorageAccountId { get { throw null; } set { } }
        public string RecoveryCapacityReservationGroupId { get { throw null; } set { } }
        public string RecoveryCloudServiceId { get { throw null; } set { } }
        public string RecoveryProximityPlacementGroupId { get { throw null; } set { } }
        public string RecoveryResourceGroupId { get { throw null; } set { } }
        public string RecoveryVirtualMachineScaleSetId { get { throw null; } set { } }
        public string TfoAzureVmName { get { throw null; } set { } }
    }
    public partial class A2AVmDiskInputDetails
    {
        public A2AVmDiskInputDetails(System.Uri diskUri, string recoveryAzureStorageAccountId, string primaryStagingAzureStorageAccountId) { }
        public System.Uri DiskUri { get { throw null; } }
        public string PrimaryStagingAzureStorageAccountId { get { throw null; } }
        public string RecoveryAzureStorageAccountId { get { throw null; } }
    }
    public partial class A2AVmManagedDiskInputDetails
    {
        public A2AVmManagedDiskInputDetails(string diskId, string primaryStagingAzureStorageAccountId, string recoveryResourceGroupId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        public string PrimaryStagingAzureStorageAccountId { get { throw null; } }
        public string RecoveryDiskEncryptionSetId { get { throw null; } set { } }
        public string RecoveryReplicaDiskAccountType { get { throw null; } set { } }
        public string RecoveryResourceGroupId { get { throw null; } }
        public string RecoveryTargetDiskAccountType { get { throw null; } set { } }
    }
    public partial class A2AVmManagedDiskUpdateDetails
    {
        public A2AVmManagedDiskUpdateDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskEncryptionInfo DiskEncryptionInfo { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public string FailoverDiskName { get { throw null; } set { } }
        public string RecoveryReplicaDiskAccountType { get { throw null; } set { } }
        public string RecoveryTargetDiskAccountType { get { throw null; } set { } }
        public string TfoDiskName { get { throw null; } set { } }
    }
    public partial class A2AZoneDetails
    {
        internal A2AZoneDetails() { }
        public string Source { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class AddDisksContent
    {
        public AddDisksContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AddDisksProviderSpecificInput AddDisksInputProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class AddDisksProviderSpecificInput
    {
        protected AddDisksProviderSpecificInput() { }
    }
    public partial class AddRecoveryServicesProviderInputProperties
    {
        public AddRecoveryServicesProviderInputProperties(string machineName, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderInput authenticationIdentityInput, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderInput resourceAccessIdentityInput) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderInput AuthenticationIdentityInput { get { throw null; } }
        public string BiosId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderInput DataPlaneAuthenticationIdentityInput { get { throw null; } set { } }
        public string MachineId { get { throw null; } set { } }
        public string MachineName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderInput ResourceAccessIdentityInput { get { throw null; } }
    }
    public partial class AddVCenterRequestProperties
    {
        public AddVCenterRequestProperties() { }
        public string FriendlyName { get { throw null; } set { } }
        public string IPAddress { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        public string ProcessServerId { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentAutoUpdateStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentAutoUpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentAutoUpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentDetails
    {
        internal AgentDetails() { }
        public string AgentId { get { throw null; } }
        public string BiosId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentDiskDetails> Disks { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public string MachineId { get { throw null; } }
    }
    public partial class AgentDiskDetails
    {
        internal AgentDiskDetails() { }
        public long? CapacityInBytes { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string IsOSDisk { get { throw null; } }
        public int? LunId { get { throw null; } }
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
    public readonly partial struct AgentVersionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentVersionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus Deprecated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus NotSupported { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus SecurityUpdateRequired { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus Supported { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus UpdateRequired { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertCreateOrUpdateContent
    {
        public AlertCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ConfigureAlertRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class AlertProperties
    {
        internal AlertProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> CustomEmailAddresses { get { throw null; } }
        public string Locale { get { throw null; } }
        public string SendToOwners { get { throw null; } }
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
    public abstract partial class ApplianceSpecificDetails
    {
        protected ApplianceSpecificDetails() { }
    }
    public partial class ApplyRecoveryPointContent
    {
        public ApplyRecoveryPointContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointInputProperties Properties { get { throw null; } }
    }
    public partial class ApplyRecoveryPointInputProperties
    {
        public ApplyRecoveryPointInputProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointProviderSpecificInput providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointProviderSpecificInput ProviderSpecificDetails { get { throw null; } }
        public string RecoveryPointId { get { throw null; } set { } }
    }
    public abstract partial class ApplyRecoveryPointProviderSpecificInput
    {
        protected ApplyRecoveryPointProviderSpecificInput() { }
    }
    public partial class AsrJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobDetails
    {
        internal AsrJobDetails() { }
    }
    public partial class ASRTask
    {
        internal ASRTask() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TaskTypeDetails CustomDetails { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobErrorDetails> Errors { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.GroupTaskDetails GroupTaskCustomDetails { get { throw null; } }
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
    public partial class AutomationRunbookTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TaskTypeDetails
    {
        internal AutomationRunbookTaskDetails() { }
        public string AccountName { get { throw null; } }
        public string CloudServiceName { get { throw null; } }
        public bool? IsPrimarySideScript { get { throw null; } }
        public string JobId { get { throw null; } }
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
    public partial class AzureFabricCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreationInput
    {
        public AzureFabricCreationInput() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class AzureFabricSpecificDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal AzureFabricSpecificDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> ContainerIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AExtendedLocationDetails> ExtendedLocations { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2AZoneDetails> Zones { get { throw null; } }
    }
    public partial class AzureToAzureCreateNetworkMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreateNetworkMappingInput
    {
        public AzureToAzureCreateNetworkMappingInput(string primaryNetworkId) { }
        public string PrimaryNetworkId { get { throw null; } }
    }
    public partial class AzureToAzureNetworkMappingSettings : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingFabricSpecificSettings
    {
        internal AzureToAzureNetworkMappingSettings() { }
        public string PrimaryFabricLocation { get { throw null; } }
        public string RecoveryFabricLocation { get { throw null; } }
    }
    public partial class AzureToAzureUpdateNetworkMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificUpdateNetworkMappingInput
    {
        public AzureToAzureUpdateNetworkMappingInput() { }
        public string PrimaryNetworkId { get { throw null; } set { } }
    }
    public partial class AzureToAzureVmSyncedConfigDetails
    {
        internal AzureToAzureVmSyncedConfigDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InputEndpoint> InputEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AzureVmDiskDetails
    {
        internal AzureVmDiskDetails() { }
        public string CustomTargetDiskName { get { throw null; } }
        public string DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string LunId { get { throw null; } }
        public string MaxSizeMB { get { throw null; } }
        public string TargetDiskLocation { get { throw null; } }
        public string TargetDiskName { get { throw null; } }
        public string VhdId { get { throw null; } }
        public string VhdName { get { throw null; } }
        public string VhdType { get { throw null; } }
    }
    public partial class ComputeSizeErrorDetails
    {
        internal ComputeSizeErrorDetails() { }
        public string Message { get { throw null; } }
        public string Severity { get { throw null; } }
    }
    public abstract partial class ConfigurationSettings
    {
        protected ConfigurationSettings() { }
    }
    public partial class ConfigureAlertRequestProperties
    {
        public ConfigureAlertRequestProperties() { }
        public System.Collections.Generic.IList<string> CustomEmailAddresses { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public string SendToOwners { get { throw null; } set { } }
    }
    public partial class ConsistencyCheckTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TaskTypeDetails
    {
        internal ConsistencyCheckTaskDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InconsistentVmDetails> VmDetails { get { throw null; } }
    }
    public partial class CreateNetworkMappingInputProperties
    {
        public CreateNetworkMappingInputProperties(string recoveryNetworkId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreateNetworkMappingInput FabricSpecificDetails { get { throw null; } set { } }
        public string RecoveryFabricName { get { throw null; } set { } }
        public string RecoveryNetworkId { get { throw null; } }
    }
    public partial class CreateProtectionContainerMappingInputProperties
    {
        public CreateProtectionContainerMappingInputProperties() { }
        public string PolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerMappingInput ProviderSpecificInput { get { throw null; } set { } }
        public string TargetProtectionContainerId { get { throw null; } set { } }
    }
    public abstract partial class CreateProtectionIntentProviderSpecificDetails
    {
        protected CreateProtectionIntentProviderSpecificDetails() { }
    }
    public partial class CreateRecoveryPlanInputProperties
    {
        public CreateRecoveryPlanInputProperties(string primaryFabricId, string recoveryFabricId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroup> groups) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverDeploymentModel? FailoverDeploymentModel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroup> Groups { get { throw null; } }
        public string PrimaryFabricId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificInput> ProviderSpecificInput { get { throw null; } }
        public string RecoveryFabricId { get { throw null; } }
    }
    public partial class CriticalJobHistoryDetails
    {
        internal CriticalJobHistoryDetails() { }
        public string JobId { get { throw null; } }
        public string JobName { get { throw null; } }
        public string JobStatus { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class CurrentJobDetails
    {
        internal CurrentJobDetails() { }
        public string JobId { get { throw null; } }
        public string JobName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class CurrentScenarioDetails
    {
        internal CurrentScenarioDetails() { }
        public string JobId { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class DataStore
    {
        internal DataStore() { }
        public string Capacity { get { throw null; } }
        public string DataStoreType { get { throw null; } }
        public string FreeSpace { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        public string Uuid { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSyncStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSyncStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus ForDownTime { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus ForSynchronization { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DisableProtectionContent
    {
        public DisableProtectionContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionInputProperties Properties { get { throw null; } }
    }
    public partial class DisableProtectionInputProperties
    {
        public DisableProtectionInputProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionReason? DisableProtectionReason { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionProviderSpecificInput ReplicationProviderInput { get { throw null; } set { } }
    }
    public abstract partial class DisableProtectionProviderSpecificInput
    {
        protected DisableProtectionProviderSpecificInput() { }
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
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiscoverProtectableItemRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class DiscoverProtectableItemRequestProperties
    {
        public DiscoverProtectableItemRequestProperties() { }
        public string FriendlyName { get { throw null; } set { } }
        public string IPAddress { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskAccountType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskAccountType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType StandardSsdLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskDetails
    {
        internal DiskDetails() { }
        public long? MaxSizeMB { get { throw null; } }
        public string VhdId { get { throw null; } }
        public string VhdName { get { throw null; } }
        public string VhdType { get { throw null; } }
    }
    public partial class DiskEncryptionInfo
    {
        public DiskEncryptionInfo() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskEncryptionKeyInfo DiskEncryptionKeyInfo { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.KeyEncryptionKeyInfo KeyEncryptionKeyInfo { get { throw null; } set { } }
    }
    public partial class DiskEncryptionKeyInfo
    {
        public DiskEncryptionKeyInfo() { }
        public string KeyVaultResourceArmId { get { throw null; } set { } }
        public string SecretIdentifier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskReplicationProgressHealth : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskReplicationProgressHealth(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth InProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth NoProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth Queued { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth SlowProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskVolumeDetails
    {
        internal DiskVolumeDetails() { }
        public string Label { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class DraDetails
    {
        internal DraDetails() { }
        public string BiosId { get { throw null; } }
        public int? ForwardProtectedItemCount { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
        public string Name { get { throw null; } }
        public int? ReverseProtectedItemCount { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class EnableMigrationInputProperties
    {
        public EnableMigrationInputProperties(string policyId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationProviderSpecificInput providerSpecificDetails) { }
        public string PolicyId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationProviderSpecificInput ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class EnableMigrationProviderSpecificInput
    {
        protected EnableMigrationProviderSpecificInput() { }
    }
    public partial class EnableProtectionInputProperties
    {
        public EnableProtectionInputProperties() { }
        public string PolicyId { get { throw null; } set { } }
        public string ProtectableItemId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificInput ProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class EnableProtectionProviderSpecificInput
    {
        protected EnableProtectionProviderSpecificInput() { }
    }
    public partial class EncryptionDetails
    {
        internal EncryptionDetails() { }
        public System.DateTimeOffset? KekCertExpiryOn { get { throw null; } }
        public string KekCertThumbprint { get { throw null; } }
        public string KekState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EthernetAddressType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EthernetAddressType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType Dynamic { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventProperties
    {
        internal EventProperties() { }
        public string AffectedObjectCorrelationId { get { throw null; } }
        public string AffectedObjectFriendlyName { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventCode { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventSpecificDetails EventSpecificDetails { get { throw null; } }
        public string EventType { get { throw null; } }
        public string FabricId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails ProviderSpecificDetails { get { throw null; } }
        public string Severity { get { throw null; } }
        public System.DateTimeOffset? TimeOfOccurrence { get { throw null; } }
    }
    public abstract partial class EventProviderSpecificDetails
    {
        protected EventProviderSpecificDetails() { }
    }
    public abstract partial class EventSpecificDetails
    {
        protected EventSpecificDetails() { }
    }
    public partial class ExistingProtectionProfile : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionProfileCustomDetails
    {
        public ExistingProtectionProfile(string protectionProfileId) { }
        public string ProtectionProfileId { get { throw null; } set { } }
    }
    public partial class ExistingRecoveryAvailabilitySet : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryAvailabilitySetCustomDetails
    {
        public ExistingRecoveryAvailabilitySet() { }
        public string RecoveryAvailabilitySetId { get { throw null; } set { } }
    }
    public partial class ExistingRecoveryProximityPlacementGroup : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryProximityPlacementGroupCustomDetails
    {
        public ExistingRecoveryProximityPlacementGroup() { }
        public string RecoveryProximityPlacementGroupId { get { throw null; } set { } }
    }
    public partial class ExistingRecoveryResourceGroup : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryResourceGroupCustomDetails
    {
        public ExistingRecoveryResourceGroup() { }
        public string RecoveryResourceGroupId { get { throw null; } set { } }
    }
    public partial class ExistingRecoveryVirtualNetwork : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryVirtualNetworkCustomDetails
    {
        public ExistingRecoveryVirtualNetwork(string recoveryVirtualNetworkId) { }
        public string RecoverySubnetName { get { throw null; } set { } }
        public string RecoveryVirtualNetworkId { get { throw null; } set { } }
    }
    public partial class ExistingStorageAccount : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.StorageAccountCustomDetails
    {
        public ExistingStorageAccount(string azureStorageAccountId) { }
        public string AzureStorageAccountId { get { throw null; } set { } }
    }
    public partial class ExportJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobDetails
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
    public partial class ExtendedLocation
    {
        public ExtendedLocation(string name, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType extendedLocationType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType EdgeZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FabricCreateOrUpdateContent
    {
        public FabricCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreationInput FabricCreationInputCustomDetails { get { throw null; } set { } }
    }
    public partial class FabricProperties
    {
        internal FabricProperties() { }
        public string BcdrState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails CustomDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EncryptionDetails EncryptionDetails { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrorDetails { get { throw null; } }
        public string InternalIdentifier { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EncryptionDetails RolloverEncryptionDetails { get { throw null; } }
    }
    public partial class FabricReplicationGroupTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobTaskDetails
    {
        internal FabricReplicationGroupTaskDetails() { }
        public string SkippedReason { get { throw null; } }
        public string SkippedReasonString { get { throw null; } }
    }
    public abstract partial class FabricSpecificCreateNetworkMappingInput
    {
        protected FabricSpecificCreateNetworkMappingInput() { }
    }
    public abstract partial class FabricSpecificCreationInput
    {
        protected FabricSpecificCreationInput() { }
    }
    public abstract partial class FabricSpecificDetails
    {
        protected FabricSpecificDetails() { }
    }
    public abstract partial class FabricSpecificUpdateNetworkMappingInput
    {
        protected FabricSpecificUpdateNetworkMappingInput() { }
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
    public partial class FailoverJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobDetails
    {
        internal FailoverJobDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverReplicationProtectedItemDetails> ProtectedItemDetails { get { throw null; } }
    }
    public partial class FailoverProcessServerContent
    {
        public FailoverProcessServerContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverProcessServerRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class FailoverProcessServerRequestProperties
    {
        public FailoverProcessServerRequestProperties() { }
        public string ContainerName { get { throw null; } set { } }
        public string SourceProcessServerId { get { throw null; } set { } }
        public string TargetProcessServerId { get { throw null; } set { } }
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
        public string RecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } }
        public string Subnet { get { throw null; } }
        public string TestVmFriendlyName { get { throw null; } }
        public string TestVmName { get { throw null; } }
    }
    public abstract partial class GroupTaskDetails
    {
        protected GroupTaskDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ASRTask> ChildTasks { get { throw null; } }
    }
    public partial class HealthError
    {
        internal HealthError() { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InnerHealthError> InnerHealthErrors { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public string RecoveryProviderErrorMessage { get { throw null; } }
        public string SummaryMessage { get { throw null; } }
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
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity? Severity { get { throw null; } }
        public string SummaryCode { get { throw null; } }
        public string SummaryMessage { get { throw null; } }
    }
    public partial class HyperVHostDetails
    {
        internal HyperVHostDetails() { }
        public string Id { get { throw null; } }
        public string MarsAgentVersion { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class HyperVReplica2012EventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails
    {
        internal HyperVReplica2012EventDetails() { }
        public string ContainerName { get { throw null; } }
        public string FabricName { get { throw null; } }
        public string RemoteContainerName { get { throw null; } }
        public string RemoteFabricName { get { throw null; } }
    }
    public partial class HyperVReplica2012R2EventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails
    {
        internal HyperVReplica2012R2EventDetails() { }
        public string ContainerName { get { throw null; } }
        public string FabricName { get { throw null; } }
        public string RemoteContainerName { get { throw null; } }
        public string RemoteFabricName { get { throw null; } }
    }
    public partial class HyperVReplicaAzureApplyRecoveryPointInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointProviderSpecificInput
    {
        public HyperVReplicaAzureApplyRecoveryPointInput() { }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureDiskInputDetails
    {
        public HyperVReplicaAzureDiskInputDetails() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType? DiskType { get { throw null; } set { } }
        public string LogStorageAccountId { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureEnableProtectionInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificInput
    {
        public HyperVReplicaAzureEnableProtectionInput() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisksToInclude { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureDiskInputDetails> DisksToIncludeForManagedDisks { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType? DiskType { get { throw null; } set { } }
        public string EnableRdpOnTargetOption { get { throw null; } set { } }
        public string HvHostVmId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public string LogStorageAccountId { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SeedManagedDiskTags { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public string TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetAzureNetworkId { get { throw null; } set { } }
        public string TargetAzureSubnetId { get { throw null; } set { } }
        public string TargetAzureV1ResourceGroupId { get { throw null; } set { } }
        public string TargetAzureV2ResourceGroupId { get { throw null; } set { } }
        public string TargetAzureVmName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } set { } }
        public string TargetStorageAccountId { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public string UseManagedDisks { get { throw null; } set { } }
        public string UseManagedDisksForReplication { get { throw null; } set { } }
        public string VhdId { get { throw null; } set { } }
        public string VmName { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails
    {
        internal HyperVReplicaAzureEventDetails() { }
        public string ContainerName { get { throw null; } }
        public string FabricName { get { throw null; } }
        public string RemoteContainerName { get { throw null; } }
    }
    public partial class HyperVReplicaAzureFailbackProviderInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverProviderSpecificFailoverInput
    {
        public HyperVReplicaAzureFailbackProviderInput() { }
        public string DataSyncOption { get { throw null; } set { } }
        public string ProviderIdForAlternateRecovery { get { throw null; } set { } }
        public string RecoveryVmCreationOption { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureManagedDiskDetails
    {
        internal HyperVReplicaAzureManagedDiskDetails() { }
        public string DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string ReplicaDiskType { get { throw null; } }
        public string SeedManagedDiskId { get { throw null; } }
    }
    public partial class HyperVReplicaAzurePlannedFailoverProviderInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverProviderSpecificFailoverInput
    {
        public HyperVReplicaAzurePlannedFailoverProviderInput() { }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzurePolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal HyperVReplicaAzurePolicyDetails() { }
        public string ActiveStorageAccountId { get { throw null; } }
        public int? ApplicationConsistentSnapshotFrequencyInHours { get { throw null; } }
        public string Encryption { get { throw null; } }
        public string OnlineReplicationStartTime { get { throw null; } }
        public int? RecoveryPointHistoryDurationInHours { get { throw null; } }
        public int? ReplicationInterval { get { throw null; } }
    }
    public partial class HyperVReplicaAzurePolicyInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput
    {
        public HyperVReplicaAzurePolicyInput() { }
        public int? ApplicationConsistentSnapshotFrequencyInHours { get { throw null; } set { } }
        public string OnlineReplicationStartTime { get { throw null; } set { } }
        public int? RecoveryPointHistoryDuration { get { throw null; } set { } }
        public int? ReplicationInterval { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StorageAccounts { get { throw null; } }
    }
    public partial class HyperVReplicaAzureReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal HyperVReplicaAzureReplicationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AzureVmDiskDetails> AzureVmDiskDetails { get { throw null; } }
        public string EnableRdpOnTargetOption { get { throw null; } }
        public string Encryption { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails InitialReplicationDetails { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
        public System.DateTimeOffset? LastReplicatedOn { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.OSDetails OSDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureManagedDiskDetails> ProtectedManagedDisks { get { throw null; } }
        public string RecoveryAvailabilitySetId { get { throw null; } }
        public string RecoveryAzureLogStorageAccountId { get { throw null; } }
        public string RecoveryAzureResourceGroupId { get { throw null; } }
        public string RecoveryAzureStorageAccount { get { throw null; } }
        public string RecoveryAzureVmName { get { throw null; } }
        public string RecoveryAzureVmSize { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SeedManagedDiskTags { get { throw null; } }
        public string SelectedRecoveryAzureNetworkId { get { throw null; } }
        public string SelectedSourceNicId { get { throw null; } }
        public int? SourceVmCpuCount { get { throw null; } }
        public int? SourceVmRamSizeInMB { get { throw null; } }
        public string SqlServerLicenseType { get { throw null; } }
        public string TargetAvailabilityZone { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetNicTags { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetVmTags { get { throw null; } }
        public string UseManagedDisks { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class HyperVReplicaAzureReprotectInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificInput
    {
        public HyperVReplicaAzureReprotectInput() { }
        public string HvHostVmId { get { throw null; } set { } }
        public string LogStorageAccountId { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public string VHDId { get { throw null; } set { } }
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
    public partial class HyperVReplicaAzureTestFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificInput
    {
        public HyperVReplicaAzureTestFailoverInput() { }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureUnplannedFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificInput
    {
        public HyperVReplicaAzureUnplannedFailoverInput() { }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class HyperVReplicaAzureUpdateReplicationProtectedItemInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderInput
    {
        public HyperVReplicaAzureUpdateReplicationProtectedItemInput() { }
        public System.Collections.Generic.IDictionary<string, string> DiskIdToDiskEncryptionMap { get { throw null; } }
        public string RecoveryAzureV1ResourceGroupId { get { throw null; } set { } }
        public string RecoveryAzureV2ResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public string UseManagedDisks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateDiskInput> VmDisks { get { throw null; } }
    }
    public partial class HyperVReplicaBaseEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskDetails> VmDiskDetails { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
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
    public partial class HyperVReplicaBluePolicyInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaPolicyInput
    {
        public HyperVReplicaBluePolicyInput() { }
        public int? ReplicationFrequencyInSeconds { get { throw null; } set { } }
    }
    public partial class HyperVReplicaBlueReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal HyperVReplicaBlueReplicationDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails InitialReplicationDetails { get { throw null; } }
        public System.DateTimeOffset? LastReplicatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskDetails> VmDiskDetails { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
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
    public partial class HyperVReplicaPolicyInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput
    {
        public HyperVReplicaPolicyInput() { }
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
    public partial class HyperVReplicaReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal HyperVReplicaReplicationDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails InitialReplicationDetails { get { throw null; } }
        public System.DateTimeOffset? LastReplicatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskDetails> VmDiskDetails { get { throw null; } }
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
    public partial class HyperVVirtualMachineDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ConfigurationSettings
    {
        internal HyperVVirtualMachineDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskDetails> DiskDetails { get { throw null; } }
        public string Generation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus? HasFibreChannelAdapter { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus? HasPhysicalDisk { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus? HasSharedVhd { get { throw null; } }
        public string HyperVHostId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.OSDetails OSDetails { get { throw null; } }
        public string SourceItemId { get { throw null; } }
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
    public partial class IdentityProviderInput
    {
        public IdentityProviderInput(System.Guid tenantId, string applicationId, string objectId, string audience, string aadAuthority) { }
        public string AadAuthority { get { throw null; } }
        public string ApplicationId { get { throw null; } }
        public string Audience { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public System.Guid TenantId { get { throw null; } }
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
    public partial class InlineWorkflowTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.GroupTaskDetails
    {
        internal InlineWorkflowTaskDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> WorkflowIds { get { throw null; } }
    }
    public partial class InMageAgentDetails
    {
        internal InMageAgentDetails() { }
        public System.DateTimeOffset? AgentExpiryOn { get { throw null; } }
        public string AgentUpdateStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string PostUpdateRebootStatus { get { throw null; } }
    }
    public partial class InMageAzureV2ApplyRecoveryPointInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointProviderSpecificInput
    {
        public InMageAzureV2ApplyRecoveryPointInput() { }
    }
    public partial class InMageAzureV2DiskInputDetails
    {
        public InMageAzureV2DiskInputDetails() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType? DiskType { get { throw null; } set { } }
        public string LogStorageAccountId { get { throw null; } set { } }
    }
    public partial class InMageAzureV2EnableProtectionInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificInput
    {
        public InMageAzureV2EnableProtectionInput() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2DiskInputDetails> DisksToInclude { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType? DiskType { get { throw null; } set { } }
        public string EnableRdpOnTargetOption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public string LogStorageAccountId { get { throw null; } set { } }
        public string MasterTargetId { get { throw null; } set { } }
        public string MultiVmGroupId { get { throw null; } set { } }
        public string MultiVmGroupName { get { throw null; } set { } }
        public string ProcessServerId { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SeedManagedDiskTags { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public string TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetAzureNetworkId { get { throw null; } set { } }
        public string TargetAzureSubnetId { get { throw null; } set { } }
        public string TargetAzureV1ResourceGroupId { get { throw null; } set { } }
        public string TargetAzureV2ResourceGroupId { get { throw null; } set { } }
        public string TargetAzureVmName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
    }
    public partial class InMageAzureV2EventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails
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
        public string DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string ReplicaDiskType { get { throw null; } }
        public string SeedManagedDiskId { get { throw null; } }
        public string TargetDiskName { get { throw null; } }
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
    public partial class InMageAzureV2PolicyInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput
    {
        public InMageAzureV2PolicyInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus multiVmSyncStatus) { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int? CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } set { } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } set { } }
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
        public double? PsDataInMegaBytes { get { throw null; } }
        public long? ResyncDurationInSeconds { get { throw null; } }
        public long? ResyncLast15MinutesTransferredBytes { get { throw null; } }
        public System.DateTimeOffset? ResyncLastDataTransferTimeUTC { get { throw null; } }
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
        public System.DateTimeOffset? AgentExpiryOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AzureVmDiskDetails> AzureVmDiskDetails { get { throw null; } }
        public string AzureVmGeneration { get { throw null; } }
        public double? CompressedDataRateInMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Datastores { get { throw null; } }
        public string DiscoveryType { get { throw null; } }
        public string DiskResized { get { throw null; } }
        public string EnableRdpOnTargetOption { get { throw null; } }
        public string FirmwareType { get { throw null; } }
        public string InfrastructureVmId { get { throw null; } }
        public string IPAddress { get { throw null; } }
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
        public string OSType { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string ProcessServerId { get { throw null; } }
        public string ProcessServerName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2ManagedDiskDetails> ProtectedManagedDisks { get { throw null; } }
        public string ProtectionStage { get { throw null; } }
        public string RecoveryAvailabilitySetId { get { throw null; } }
        public string RecoveryAzureLogStorageAccountId { get { throw null; } }
        public string RecoveryAzureResourceGroupId { get { throw null; } }
        public string RecoveryAzureStorageAccount { get { throw null; } }
        public string RecoveryAzureVmName { get { throw null; } }
        public string RecoveryAzureVmSize { get { throw null; } }
        public string ReplicaId { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SeedManagedDiskTags { get { throw null; } }
        public string SelectedRecoveryAzureNetworkId { get { throw null; } }
        public string SelectedSourceNicId { get { throw null; } }
        public string SelectedTfoAzureNetworkId { get { throw null; } }
        public int? SourceVmCpuCount { get { throw null; } }
        public int? SourceVmRamSizeInMB { get { throw null; } }
        public string SqlServerLicenseType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderBlockingErrorDetails> SwitchProviderBlockingErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAzureV2SwitchProviderDetails SwitchProviderDetails { get { throw null; } }
        public string TargetAvailabilityZone { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetNicTags { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } }
        public string TargetVmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetVmTags { get { throw null; } }
        public long? TotalDataTransferred { get { throw null; } }
        public string TotalProgressHealth { get { throw null; } }
        public double? UncompressedDataRateInMB { get { throw null; } }
        public string UseManagedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> ValidationErrors { get { throw null; } }
        public string VCenterInfrastructureId { get { throw null; } }
        public string VhdName { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class InMageAzureV2ReprotectInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificInput
    {
        public InMageAzureV2ReprotectInput() { }
        public System.Collections.Generic.IList<string> DisksToInclude { get { throw null; } }
        public string LogStorageAccountId { get { throw null; } set { } }
        public string MasterTargetId { get { throw null; } set { } }
        public string PolicyId { get { throw null; } set { } }
        public string ProcessServerId { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
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
    public partial class InMageAzureV2SwitchProviderDetails
    {
        internal InMageAzureV2SwitchProviderDetails() { }
        public string TargetApplianceId { get { throw null; } }
        public string TargetFabricId { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
        public string TargetVaultId { get { throw null; } }
    }
    public partial class InMageAzureV2SwitchProviderInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProviderSpecificInput
    {
        public InMageAzureV2SwitchProviderInput(string targetVaultId, string targetFabricId, string targetApplianceId) { }
        public string TargetApplianceId { get { throw null; } }
        public string TargetFabricId { get { throw null; } }
        public string TargetVaultId { get { throw null; } }
    }
    public partial class InMageAzureV2TestFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificInput
    {
        public InMageAzureV2TestFailoverInput() { }
        public string RecoveryPointId { get { throw null; } set { } }
    }
    public partial class InMageAzureV2UnplannedFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificInput
    {
        public InMageAzureV2UnplannedFailoverInput() { }
        public string RecoveryPointId { get { throw null; } set { } }
    }
    public partial class InMageAzureV2UpdateReplicationProtectedItemInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderInput
    {
        public InMageAzureV2UpdateReplicationProtectedItemInput() { }
        public string RecoveryAzureV1ResourceGroupId { get { throw null; } set { } }
        public string RecoveryAzureV2ResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public string UseManagedDisks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateDiskInput> VmDisks { get { throw null; } }
    }
    public partial class InMageBasePolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal InMageBasePolicyDetails() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } }
        public string MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } }
    }
    public partial class InMageDisableProtectionProviderSpecificInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DisableProtectionProviderSpecificInput
    {
        public InMageDisableProtectionProviderSpecificInput() { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskVolumeDetails> VolumeList { get { throw null; } }
    }
    public partial class InMageDiskExclusionInput
    {
        public InMageDiskExclusionInput() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskSignatureExclusionOptions> DiskSignatureOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageVolumeExclusionOptions> VolumeOptions { get { throw null; } }
    }
    public partial class InMageDiskSignatureExclusionOptions
    {
        public InMageDiskSignatureExclusionOptions() { }
        public string DiskSignature { get { throw null; } set { } }
    }
    public partial class InMageEnableProtectionInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificInput
    {
        public InMageEnableProtectionInput(string masterTargetId, string processServerId, string retentionDrive, string multiVmGroupId, string multiVmGroupName) { }
        public string DatastoreName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskExclusionInput DiskExclusionInput { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisksToInclude { get { throw null; } }
        public string MasterTargetId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public string ProcessServerId { get { throw null; } }
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
    public partial class InMagePolicyDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails
    {
        internal InMagePolicyDetails() { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } }
        public string MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } }
    }
    public partial class InMagePolicyInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput
    {
        public InMagePolicyInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus multiVmSyncStatus) { }
        public int? AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SetMultiVmSyncStatus MultiVmSyncStatus { get { throw null; } }
        public int? RecoveryPointHistory { get { throw null; } set { } }
        public int? RecoveryPointThresholdInMinutes { get { throw null; } set { } }
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
        public double? PsDataInMB { get { throw null; } }
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
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DraDetails Dra { get { throw null; } }
        public string FabricArmId { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MarsAgentDetails MarsAgent { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProcessServerDetails ProcessServer { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PushInstallerDetails PushInstaller { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmProxyDetails RcmProxy { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAgentDetails ReplicationAgent { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReprotectAgentDetails ReprotectAgent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFabricSwitchProviderBlockingErrorDetails> SwitchProviderBlockingErrorDetails { get { throw null; } }
    }
    public partial class InMageRcmApplianceSpecificDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceSpecificDetails
    {
        internal InMageRcmApplianceSpecificDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmApplianceDetails> Appliances { get { throw null; } }
    }
    public partial class InMageRcmApplyRecoveryPointInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplyRecoveryPointProviderSpecificInput
    {
        public InMageRcmApplyRecoveryPointInput(string recoveryPointId) { }
        public string RecoveryPointId { get { throw null; } }
    }
    public partial class InMageRcmDiscoveredProtectedVmDetails
    {
        internal InMageRcmDiscoveredProtectedVmDetails() { }
        public System.DateTimeOffset? CreatedTimestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Datastores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public bool? IsDeleted { get { throw null; } }
        public System.DateTimeOffset? LastDiscoveryTimeInUtc { get { throw null; } }
        public string OSName { get { throw null; } }
        public string PowerStatus { get { throw null; } }
        public System.DateTimeOffset? UpdatedTimestamp { get { throw null; } }
        public string VCenterFqdn { get { throw null; } }
        public string VCenterId { get { throw null; } }
        public string VmFqdn { get { throw null; } }
        public string VMwareToolsStatus { get { throw null; } }
    }
    public partial class InMageRcmDiskInput
    {
        public InMageRcmDiskInput(string diskId, string logStorageAccountId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType diskType) { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType DiskType { get { throw null; } }
        public string LogStorageAccountId { get { throw null; } }
    }
    public partial class InMageRcmDisksDefaultInput
    {
        public InMageRcmDisksDefaultInput(string logStorageAccountId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType diskType) { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType DiskType { get { throw null; } }
        public string LogStorageAccountId { get { throw null; } }
    }
    public partial class InMageRcmEnableProtectionInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionProviderSpecificInput
    {
        public InMageRcmEnableProtectionInput(string fabricDiscoveryMachineId, string targetResourceGroupId, string processServerId) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmDisksDefaultInput DisksDefault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmDiskInput> DisksToInclude { get { throw null; } }
        public string FabricDiscoveryMachineId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public string MultiVmGroupName { get { throw null; } set { } }
        public string ProcessServerId { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
        public string TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetBootDiagnosticsStorageAccountId { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TargetProximityPlacementGroupId { get { throw null; } set { } }
        public string TargetResourceGroupId { get { throw null; } }
        public string TargetSubnetName { get { throw null; } set { } }
        public string TargetVmName { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        public string TestSubnetName { get { throw null; } set { } }
    }
    public partial class InMageRcmEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails
    {
        internal InMageRcmEventDetails() { }
        public string ApplianceName { get { throw null; } }
        public string ComponentDisplayName { get { throw null; } }
        public string FabricName { get { throw null; } }
        public string JobId { get { throw null; } }
        public string LatestAgentVersion { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string ServerType { get { throw null; } }
        public string VmName { get { throw null; } }
    }
    public partial class InMageRcmFabricCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreationInput
    {
        public InMageRcmFabricCreationInput(string vmwareSiteId, string physicalSiteId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderInput sourceAgentIdentity) { }
        public string PhysicalSiteId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderInput SourceAgentIdentity { get { throw null; } }
        public string VMwareSiteId { get { throw null; } }
    }
    public partial class InMageRcmFabricSpecificDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal InMageRcmFabricSpecificDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentDetails> AgentDetails { get { throw null; } }
        public System.Uri ControlPlaneUri { get { throw null; } }
        public System.Uri DataPlaneUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DraDetails> Dras { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MarsAgentDetails> MarsAgents { get { throw null; } }
        public string PhysicalSiteId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProcessServerDetails> ProcessServers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PushInstallerDetails> PushInstallers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmProxyDetails> RcmProxies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationAgentDetails> ReplicationAgents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReprotectAgentDetails> ReprotectAgents { get { throw null; } }
        public string ServiceContainerId { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public string ServiceResourceId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails SourceAgentIdentityDetails { get { throw null; } }
        public string VMwareSiteId { get { throw null; } }
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
        public System.DateTimeOffset? CreatedTimestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Datastores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public bool? IsDeleted { get { throw null; } }
        public System.DateTimeOffset? LastDiscoveryTimeInUtc { get { throw null; } }
        public string OSName { get { throw null; } }
        public string PowerStatus { get { throw null; } }
        public System.DateTimeOffset? UpdatedTimestamp { get { throw null; } }
        public string VCenterFqdn { get { throw null; } }
        public string VCenterId { get { throw null; } }
        public string VmFqdn { get { throw null; } }
        public string VMwareToolsStatus { get { throw null; } }
    }
    public partial class InMageRcmFailbackEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails
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
        public System.DateTimeOffset? AgentVersionExpiryOn { get { throw null; } }
        public string DriverVersion { get { throw null; } }
        public System.DateTimeOffset? DriverVersionExpiryOn { get { throw null; } }
        public string IsUpgradeable { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
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
        public string SourceIPAddress { get { throw null; } }
    }
    public partial class InMageRcmFailbackPlannedFailoverProviderInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverProviderSpecificFailoverInput
    {
        public InMageRcmFailbackPlannedFailoverProviderInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType RecoveryPointType { get { throw null; } }
    }
    public partial class InMageRcmFailbackPolicyCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput
    {
        public InMageRcmFailbackPolicyCreationInput() { }
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
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
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
        public string AzureVirtualMachineId { get { throw null; } }
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
        public string LastUsedPolicyId { get { throw null; } }
        public string LogStorageAccountId { get { throw null; } }
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
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState? ResyncState { get { throw null; } }
        public long? ResyncTransferredBytes { get { throw null; } }
        public string TargetDataStoreName { get { throw null; } }
        public string TargetVCenterId { get { throw null; } }
        public string TargetVmName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackNicDetails> VmNics { get { throw null; } }
    }
    public partial class InMageRcmFailbackReprotectInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificInput
    {
        public InMageRcmFailbackReprotectInput(string processServerId, string policyId) { }
        public string PolicyId { get { throw null; } }
        public string ProcessServerId { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
    }
    public partial class InMageRcmFailbackSyncDetails
    {
        internal InMageRcmFailbackSyncDetails() { }
        public long? Last15MinutesTransferredBytes { get { throw null; } }
        public string LastDataTransferTimeUtc { get { throw null; } }
        public string LastRefreshTime { get { throw null; } }
        public long? ProcessedBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth? ProgressHealth { get { throw null; } }
        public int? ProgressPercentage { get { throw null; } }
        public string StartTime { get { throw null; } }
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
        public System.DateTimeOffset? AgentVersionExpiryOn { get { throw null; } }
        public string DriverVersion { get { throw null; } }
        public System.DateTimeOffset? DriverVersionExpiryOn { get { throw null; } }
        public string IsUpgradeable { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
        public string LatestAgentReleaseDate { get { throw null; } }
        public string LatestUpgradableVersionWithoutReboot { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentUpgradeBlockedReason> ReasonsBlockingUpgrade { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class InMageRcmNicDetails
    {
        internal InMageRcmNicDetails() { }
        public string IsPrimaryNic { get { throw null; } }
        public string IsSelectedForFailover { get { throw null; } }
        public string NicId { get { throw null; } }
        public string SourceIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType? SourceIPAddressType { get { throw null; } }
        public string SourceNetworkId { get { throw null; } }
        public string SourceSubnetName { get { throw null; } }
        public string TargetIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType? TargetIPAddressType { get { throw null; } }
        public string TargetSubnetName { get { throw null; } }
        public string TestIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType? TestIPAddressType { get { throw null; } }
        public string TestSubnetName { get { throw null; } }
    }
    public partial class InMageRcmNicInput
    {
        public InMageRcmNicInput(string nicId, string isPrimaryNic) { }
        public string IsPrimaryNic { get { throw null; } }
        public string IsSelectedForFailover { get { throw null; } set { } }
        public string NicId { get { throw null; } }
        public string TargetStaticIPAddress { get { throw null; } set { } }
        public string TargetSubnetName { get { throw null; } set { } }
        public string TestStaticIPAddress { get { throw null; } set { } }
        public string TestSubnetName { get { throw null; } set { } }
    }
    public partial class InMageRcmPolicyCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput
    {
        public InMageRcmPolicyCreationInput() { }
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
        public string DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType? DiskType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmSyncDetails IrDetails { get { throw null; } }
        public string IsInitialReplicationComplete { get { throw null; } }
        public string IsOSDisk { get { throw null; } }
        public string LogStorageAccountId { get { throw null; } }
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
        public string FailoverRecoveryPointId { get { throw null; } }
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
        public string LastRecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public long? LastRpoInSeconds { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmMobilityAgentDetails MobilityAgentDetails { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public string OSType { get { throw null; } }
        public string PrimaryNicIPAddress { get { throw null; } }
        public int? ProcessorCoreCount { get { throw null; } }
        public string ProcessServerId { get { throw null; } }
        public string ProcessServerName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public long? ResyncProcessedBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmReplicationProgressHealth? ResyncProgressHealth { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public string ResyncRequired { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState? ResyncState { get { throw null; } }
        public long? ResyncTransferredBytes { get { throw null; } }
        public string RunAsAccountId { get { throw null; } }
        public string StorageAccountId { get { throw null; } }
        public string TargetAvailabilitySetId { get { throw null; } }
        public string TargetAvailabilityZone { get { throw null; } }
        public string TargetBootDiagnosticsStorageAccountId { get { throw null; } }
        public string TargetGeneration { get { throw null; } }
        public string TargetLocation { get { throw null; } }
        public string TargetNetworkId { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } }
        public string TargetResourceGroupId { get { throw null; } }
        public string TargetVmName { get { throw null; } }
        public string TargetVmSize { get { throw null; } }
        public string TestNetworkId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmNicDetails> VmNics { get { throw null; } }
    }
    public partial class InMageRcmReprotectInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificInput
    {
        public InMageRcmReprotectInput(string reprotectAgentId, string datastoreName, string logStorageAccountId) { }
        public string DatastoreName { get { throw null; } }
        public string LogStorageAccountId { get { throw null; } }
        public string PolicyId { get { throw null; } set { } }
        public string ReprotectAgentId { get { throw null; } }
    }
    public partial class InMageRcmSyncDetails
    {
        internal InMageRcmSyncDetails() { }
        public long? Last15MinutesTransferredBytes { get { throw null; } }
        public string LastDataTransferTimeUtc { get { throw null; } }
        public string LastRefreshTime { get { throw null; } }
        public long? ProcessedBytes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskReplicationProgressHealth? ProgressHealth { get { throw null; } }
        public int? ProgressPercentage { get { throw null; } }
        public string StartTime { get { throw null; } }
        public long? TransferredBytes { get { throw null; } }
    }
    public partial class InMageRcmTestFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificInput
    {
        public InMageRcmTestFailoverInput() { }
        public string NetworkId { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
    }
    public partial class InMageRcmUnplannedFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificInput
    {
        public InMageRcmUnplannedFailoverInput(string performShutdown) { }
        public string PerformShutdown { get { throw null; } }
        public string RecoveryPointId { get { throw null; } set { } }
    }
    public partial class InMageRcmUpdateApplianceForReplicationProtectedItemInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemProviderSpecificInput
    {
        public InMageRcmUpdateApplianceForReplicationProtectedItemInput() { }
        public string RunAsAccountId { get { throw null; } set { } }
    }
    public partial class InMageRcmUpdateContainerMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificUpdateContainerMappingInput
    {
        public InMageRcmUpdateContainerMappingInput(string enableAgentAutoUpgrade) { }
        public string EnableAgentAutoUpgrade { get { throw null; } }
    }
    public partial class InMageRcmUpdateReplicationProtectedItemInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderInput
    {
        public InMageRcmUpdateReplicationProtectedItemInput() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public string TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetBootDiagnosticsStorageAccountId { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TargetProximityPlacementGroupId { get { throw null; } set { } }
        public string TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmName { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmNicInput> VmNics { get { throw null; } }
    }
    public partial class InMageReplicationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings
    {
        internal InMageReplicationDetails() { }
        public string ActiveSiteType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageAgentDetails AgentDetails { get { throw null; } }
        public string AzureStorageAccountId { get { throw null; } }
        public double? CompressedDataRateInMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.DateTimeOffset> ConsistencyPoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Datastores { get { throw null; } }
        public string DiscoveryType { get { throw null; } }
        public string DiskResized { get { throw null; } }
        public string InfrastructureVmId { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public bool? IsAdditionalStatsAvailable { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeat { get { throw null; } }
        public System.DateTimeOffset? LastRpoCalculatedOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdateReceivedOn { get { throw null; } }
        public string MasterTargetId { get { throw null; } }
        public string MultiVmGroupId { get { throw null; } }
        public string MultiVmGroupName { get { throw null; } }
        public string MultiVmSyncStatus { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.OSDiskDetails OSDetails { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string ProcessServerId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public string ProtectionStage { get { throw null; } }
        public string RebootAfterUpdateStatus { get { throw null; } }
        public string ReplicaId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InitialReplicationDetails ResyncDetails { get { throw null; } }
        public System.DateTimeOffset? RetentionWindowEnd { get { throw null; } }
        public System.DateTimeOffset? RetentionWindowStart { get { throw null; } }
        public long? RpoInSeconds { get { throw null; } }
        public int? SourceVmCpuCount { get { throw null; } }
        public int? SourceVmRamSizeInMB { get { throw null; } }
        public long? TotalDataTransferred { get { throw null; } }
        public string TotalProgressHealth { get { throw null; } }
        public double? UncompressedDataRateInMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> ValidationErrors { get { throw null; } }
        public string VCenterInfrastructureId { get { throw null; } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicDetails> VmNics { get { throw null; } }
        public string VmProtectionState { get { throw null; } }
        public string VmProtectionStateDescription { get { throw null; } }
    }
    public partial class InMageReprotectInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificInput
    {
        public InMageReprotectInput(string masterTargetId, string processServerId, string retentionDrive, string profileId) { }
        public string DatastoreName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskExclusionInput DiskExclusionInput { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisksToInclude { get { throw null; } }
        public string MasterTargetId { get { throw null; } }
        public string ProcessServerId { get { throw null; } }
        public string ProfileId { get { throw null; } }
        public string RetentionDrive { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
    }
    public partial class InMageTestFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificInput
    {
        public InMageTestFailoverInput() { }
        public string RecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType? RecoveryPointType { get { throw null; } set { } }
    }
    public partial class InMageUnplannedFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificInput
    {
        public InMageUnplannedFailoverInput() { }
        public string RecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType? RecoveryPointType { get { throw null; } set { } }
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
    public partial class InnerHealthError
    {
        internal InnerHealthError() { }
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
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public string RecoveryProviderErrorMessage { get { throw null; } }
        public string SummaryMessage { get { throw null; } }
    }
    public partial class InputEndpoint
    {
        internal InputEndpoint() { }
        public string EndpointName { get { throw null; } }
        public int? PrivatePort { get { throw null; } }
        public string Protocol { get { throw null; } }
        public int? PublicPort { get { throw null; } }
    }
    public partial class IPConfigDetails
    {
        internal IPConfigDetails() { }
        public string IPAddressType { get { throw null; } }
        public bool? IsPrimary { get { throw null; } }
        public bool? IsSeletedForFailover { get { throw null; } }
        public string Name { get { throw null; } }
        public string RecoveryIPAddressType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecoveryLBBackendAddressPoolIds { get { throw null; } }
        public string RecoveryPublicIPAddressId { get { throw null; } }
        public string RecoveryStaticIPAddress { get { throw null; } }
        public string RecoverySubnetName { get { throw null; } }
        public string StaticIPAddress { get { throw null; } }
        public string SubnetName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TfoLBBackendAddressPoolIds { get { throw null; } }
        public string TfoPublicIPAddressId { get { throw null; } }
        public string TfoStaticIPAddress { get { throw null; } }
        public string TfoSubnetName { get { throw null; } }
    }
    public partial class IPConfigInputDetails
    {
        public IPConfigInputDetails() { }
        public string IPConfigName { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public bool? IsSeletedForFailover { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RecoveryLBBackendAddressPoolIds { get { throw null; } }
        public string RecoveryPublicIPAddressId { get { throw null; } set { } }
        public string RecoveryStaticIPAddress { get { throw null; } set { } }
        public string RecoverySubnetName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TfoLBBackendAddressPoolIds { get { throw null; } }
        public string TfoPublicIPAddressId { get { throw null; } set { } }
        public string TfoStaticIPAddress { get { throw null; } set { } }
        public string TfoSubnetName { get { throw null; } set { } }
    }
    public abstract partial class JobDetails
    {
        protected JobDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AffectedObjectDetails { get { throw null; } }
    }
    public partial class JobEntity
    {
        internal JobEntity() { }
        public string JobFriendlyName { get { throw null; } }
        public string JobId { get { throw null; } }
        public string JobScenarioName { get { throw null; } }
        public string TargetInstanceType { get { throw null; } }
        public string TargetObjectId { get { throw null; } }
        public string TargetObjectName { get { throw null; } }
    }
    public partial class JobErrorDetails
    {
        internal JobErrorDetails() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string ErrorLevel { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProviderError ProviderErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ServiceError ServiceErrorDetails { get { throw null; } }
        public string TaskId { get { throw null; } }
    }
    public partial class JobProperties
    {
        internal JobProperties() { }
        public string ActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobDetails CustomDetails { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobErrorDetails> Errors { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
        public string StateDescription { get { throw null; } }
        public string TargetInstanceType { get { throw null; } }
        public string TargetObjectId { get { throw null; } }
        public string TargetObjectName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ASRTask> Tasks { get { throw null; } }
    }
    public partial class JobQueryParameter
    {
        public JobQueryParameter() { }
        public string AffectedObjectTypes { get { throw null; } set { } }
        public string EndTime { get { throw null; } set { } }
        public string FabricId { get { throw null; } set { } }
        public string JobName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExportJobOutputSerializationType? JobOutputType { get { throw null; } set { } }
        public string JobStatus { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public double? TimezoneOffset { get { throw null; } set { } }
    }
    public partial class JobStatusEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventSpecificDetails
    {
        internal JobStatusEventDetails() { }
        public string AffectedObjectType { get { throw null; } }
        public string JobFriendlyName { get { throw null; } }
        public string JobId { get { throw null; } }
        public string JobStatus { get { throw null; } }
    }
    public partial class JobTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TaskTypeDetails
    {
        internal JobTaskDetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobEntity JobTask { get { throw null; } }
    }
    public partial class KeyEncryptionKeyInfo
    {
        public KeyEncryptionKeyInfo() { }
        public string KeyIdentifier { get { throw null; } set { } }
        public string KeyVaultResourceArmId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType NoLicenseType { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType WindowsServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicalNetworkProperties
    {
        internal LogicalNetworkProperties() { }
        public string FriendlyName { get { throw null; } }
        public string LogicalNetworkDefinitionsStatus { get { throw null; } }
        public string LogicalNetworkUsage { get { throw null; } }
        public string NetworkVirtualizationStatus { get { throw null; } }
    }
    public partial class ManualActionTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TaskTypeDetails
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
        public string FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class MasterTargetServer
    {
        internal MasterTargetServer() { }
        public System.DateTimeOffset? AgentExpiryOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VersionDetails AgentVersionDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataStore> DataStores { get { throw null; } }
        public int? DiskCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeat { get { throw null; } }
        public System.DateTimeOffset? MarsAgentExpiryOn { get { throw null; } }
        public string MarsAgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VersionDetails MarsAgentVersionDetails { get { throw null; } }
        public string Name { get { throw null; } }
        public string OSType { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RetentionVolume> RetentionVolumes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> ValidationErrors { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    public partial class MigrateContent
    {
        public MigrateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateProviderSpecificInput MigrateInputProviderSpecificDetails { get { throw null; } }
    }
    public partial class MigrateInputProperties
    {
        public MigrateInputProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateProviderSpecificInput providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateProviderSpecificInput ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class MigrateProviderSpecificInput
    {
        protected MigrateProviderSpecificInput() { }
    }
    public partial class MigrationItemCreateOrUpdateContent
    {
        public MigrationItemCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationInputProperties Properties { get { throw null; } }
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
    public partial class MigrationItemPatch
    {
        public MigrationItemPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateMigrationItemProviderSpecificInput UpdateMigrationItemInputProviderSpecificDetails { get { throw null; } set { } }
    }
    public partial class MigrationItemProperties
    {
        internal MigrationItemProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationItemOperation> AllowedOperations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CriticalJobHistoryDetails> CriticalJobHistory { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentJobDetails CurrentJob { get { throw null; } }
        public string EventCorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public System.DateTimeOffset? LastMigrationOn { get { throw null; } }
        public string LastMigrationStatus { get { throw null; } }
        public System.DateTimeOffset? LastTestMigrationOn { get { throw null; } }
        public string LastTestMigrationStatus { get { throw null; } }
        public string MachineName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState? MigrationState { get { throw null; } }
        public string MigrationStateDescription { get { throw null; } }
        public string PolicyFriendlyName { get { throw null; } }
        public string PolicyId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationProviderSpecificSettings ProviderSpecificDetails { get { throw null; } }
        public string RecoveryServicesProviderId { get { throw null; } }
        public string ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrationState? TestMigrateState { get { throw null; } }
        public string TestMigrateStateDescription { get { throw null; } }
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
    public readonly partial struct MigrationState : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState DisableMigrationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState DisableMigrationInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState EnableMigrationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState EnableMigrationInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState InitialSeedingFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState InitialSeedingInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState MigrationCompletedWithInformation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState MigrationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState MigrationInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState MigrationPartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState MigrationSucceeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState ProtectionSuspended { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState Replicating { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState ResumeInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState ResumeInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState SuspendingProtection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationState right) { throw null; }
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
    public partial class NetworkMappingCreateOrUpdateContent
    {
        public NetworkMappingCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CreateNetworkMappingInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CreateNetworkMappingInputProperties Properties { get { throw null; } }
    }
    public abstract partial class NetworkMappingFabricSpecificSettings
    {
        protected NetworkMappingFabricSpecificSettings() { }
    }
    public partial class NetworkMappingPatch
    {
        public NetworkMappingPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateNetworkMappingInputProperties Properties { get { throw null; } set { } }
    }
    public partial class NetworkMappingProperties
    {
        internal NetworkMappingProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingFabricSpecificSettings FabricSpecificSettings { get { throw null; } }
        public string PrimaryFabricFriendlyName { get { throw null; } }
        public string PrimaryNetworkFriendlyName { get { throw null; } }
        public string PrimaryNetworkId { get { throw null; } }
        public string RecoveryFabricArmId { get { throw null; } }
        public string RecoveryFabricFriendlyName { get { throw null; } }
        public string RecoveryNetworkFriendlyName { get { throw null; } }
        public string RecoveryNetworkId { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class NetworkProperties
    {
        internal NetworkProperties() { }
        public string FabricType { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string NetworkType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Subnet> Subnets { get { throw null; } }
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
    public partial class OSDetails
    {
        internal OSDetails() { }
        public string OSEdition { get { throw null; } }
        public string OSMajorVersion { get { throw null; } }
        public string OSMinorVersion { get { throw null; } }
        public string OSType { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string ProductType { get { throw null; } }
    }
    public partial class OSDiskDetails
    {
        internal OSDiskDetails() { }
        public string OSType { get { throw null; } }
        public string OSVhdId { get { throw null; } }
        public string VhdName { get { throw null; } }
    }
    public partial class OSVersionWrapper
    {
        internal OSVersionWrapper() { }
        public string ServicePack { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class PauseReplicationContent
    {
        public PauseReplicationContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PauseReplicationInputProperties properties) { }
        public string PauseReplicationInputInstanceType { get { throw null; } }
    }
    public partial class PauseReplicationInputProperties
    {
        public PauseReplicationInputProperties(string instanceType) { }
        public string InstanceType { get { throw null; } }
    }
    public partial class PlannedFailoverContent
    {
        public PlannedFailoverContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverInputProperties Properties { get { throw null; } set { } }
    }
    public partial class PlannedFailoverInputProperties
    {
        public PlannedFailoverInputProperties() { }
        public string FailoverDirection { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PlannedFailoverProviderSpecificFailoverInput ProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class PlannedFailoverProviderSpecificFailoverInput
    {
        protected PlannedFailoverProviderSpecificFailoverInput() { }
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
    public partial class PolicyCreateOrUpdateContent
    {
        public PolicyCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput ProviderSpecificInput { get { throw null; } set { } }
    }
    public partial class PolicyPatch
    {
        public PolicyPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput UpdatePolicyInputReplicationProviderSettings { get { throw null; } set { } }
    }
    public partial class PolicyProperties
    {
        internal PolicyProperties() { }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificDetails ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class PolicyProviderSpecificDetails
    {
        protected PolicyProviderSpecificDetails() { }
    }
    public abstract partial class PolicyProviderSpecificInput
    {
        protected PolicyProviderSpecificInput() { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PresenceStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PresenceStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus NotPresent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus Present { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PresenceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProcessServer
    {
        internal ProcessServer() { }
        public System.DateTimeOffset? AgentExpiryOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VersionDetails AgentVersionDetails { get { throw null; } }
        public long? AvailableMemoryInBytes { get { throw null; } }
        public long? AvailableSpaceInBytes { get { throw null; } }
        public string CpuLoad { get { throw null; } }
        public string CpuLoadStatus { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public string HostId { get { throw null; } }
        public string Id { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeat { get { throw null; } }
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
        public System.DateTimeOffset? SslCertExpiryOn { get { throw null; } }
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
    public partial class ProcessServerDetails
    {
        internal ProcessServerDetails() { }
        public long? AvailableMemoryInBytes { get { throw null; } }
        public long? AvailableSpaceInBytes { get { throw null; } }
        public string BiosId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RcmComponentStatus? DiskUsageStatus { get { throw null; } }
        public string FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public double? FreeSpacePercentage { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? HistoricHealth { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
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
    public partial class ProtectableItemProperties
    {
        internal ProtectableItemProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ConfigurationSettings CustomDetails { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProtectionReadinessErrors { get { throw null; } }
        public string ProtectionStatus { get { throw null; } }
        public string RecoveryServicesProviderId { get { throw null; } }
        public string ReplicationProtectedItemId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedReplicationProviders { get { throw null; } }
    }
    public partial class ProtectionContainerCreateOrUpdateContent
    {
        public ProtectionContainerCreateOrUpdateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerCreationInput> ProviderSpecificInput { get { throw null; } }
    }
    public partial class ProtectionContainerMappingCreateOrUpdateContent
    {
        public ProtectionContainerMappingCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CreateProtectionContainerMappingInputProperties Properties { get { throw null; } set { } }
    }
    public partial class ProtectionContainerMappingPatch
    {
        public ProtectionContainerMappingPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificUpdateContainerMappingInput ProviderSpecificInput { get { throw null; } set { } }
    }
    public partial class ProtectionContainerMappingProperties
    {
        internal ProtectionContainerMappingProperties() { }
        public string Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrorDetails { get { throw null; } }
        public string PolicyFriendlyName { get { throw null; } }
        public string PolicyId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionContainerMappingProviderSpecificDetails ProviderSpecificDetails { get { throw null; } }
        public string SourceFabricFriendlyName { get { throw null; } }
        public string SourceProtectionContainerFriendlyName { get { throw null; } }
        public string State { get { throw null; } }
        public string TargetFabricFriendlyName { get { throw null; } }
        public string TargetProtectionContainerFriendlyName { get { throw null; } }
        public string TargetProtectionContainerId { get { throw null; } }
    }
    public abstract partial class ProtectionContainerMappingProviderSpecificDetails
    {
        protected ProtectionContainerMappingProviderSpecificDetails() { }
    }
    public partial class ProtectionContainerProperties
    {
        internal ProtectionContainerProperties() { }
        public string FabricFriendlyName { get { throw null; } }
        public string FabricSpecificDetailsInstanceType { get { throw null; } }
        public string FabricType { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string PairingStatus { get { throw null; } }
        public int? ProtectedItemCount { get { throw null; } }
        public string Role { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectionHealth : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectionHealth(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth Critical { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth Normal { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ProtectionProfileCustomDetails
    {
        protected ProtectionProfileCustomDetails() { }
    }
    public partial class ProviderError
    {
        internal ProviderError() { }
        public int? ErrorCode { get { throw null; } }
        public string ErrorId { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
    }
    public abstract partial class ProviderSpecificRecoveryPointDetails
    {
        protected ProviderSpecificRecoveryPointDetails() { }
    }
    public partial class PushInstallerDetails
    {
        internal PushInstallerDetails() { }
        public string BiosId { get { throw null; } }
        public string FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
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
        public string FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public abstract partial class RecoveryAvailabilitySetCustomDetails
    {
        protected RecoveryAvailabilitySetCustomDetails() { }
    }
    public partial class RecoveryPlanA2ADetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificDetails
    {
        internal RecoveryPlanA2ADetails() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation PrimaryExtendedLocation { get { throw null; } }
        public string PrimaryZone { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation RecoveryExtendedLocation { get { throw null; } }
        public string RecoveryZone { get { throw null; } }
    }
    public partial class RecoveryPlanA2AFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput
    {
        public RecoveryPlanA2AFailoverInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType recoveryPointType) { }
        public string CloudServiceCreationOption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MultiVmSyncPointOption? MultiVmSyncPointOption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.A2ARpRecoveryPointType RecoveryPointType { get { throw null; } }
    }
    public partial class RecoveryPlanA2AInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificInput
    {
        public RecoveryPlanA2AInput() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation PrimaryExtendedLocation { get { throw null; } set { } }
        public string PrimaryZone { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ExtendedLocation RecoveryExtendedLocation { get { throw null; } set { } }
        public string RecoveryZone { get { throw null; } set { } }
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
        public string RunbookId { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
    }
    public partial class RecoveryPlanCreateOrUpdateContent
    {
        public RecoveryPlanCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CreateRecoveryPlanInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CreateRecoveryPlanInputProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPlanGroup
    {
        public RecoveryPlanGroup(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType groupType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanAction> EndGroupActions { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroupType GroupType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProtectedItem> ReplicationProtectedItems { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanAction> StartGroupActions { get { throw null; } }
    }
    public partial class RecoveryPlanGroupTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.GroupTaskDetails
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
    public partial class RecoveryPlanHyperVReplicaAzureFailbackInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput
    {
        public RecoveryPlanHyperVReplicaAzureFailbackInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus dataSyncOption, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption recoveryVmCreationOption) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DataSyncStatus DataSyncOption { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AlternateLocationRecoveryOption RecoveryVmCreationOption { get { throw null; } }
    }
    public partial class RecoveryPlanHyperVReplicaAzureFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput
    {
        public RecoveryPlanHyperVReplicaAzureFailoverInput() { }
        public string PrimaryKekCertificatePfx { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVReplicaAzureRpRecoveryPointType? RecoveryPointType { get { throw null; } set { } }
        public string SecondaryKekCertificatePfx { get { throw null; } set { } }
    }
    public partial class RecoveryPlanInMageAzureV2FailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput
    {
        public RecoveryPlanInMageAzureV2FailoverInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageV2RpRecoveryPointType RecoveryPointType { get { throw null; } }
        public string UseMultiVmSyncPoint { get { throw null; } set { } }
    }
    public partial class RecoveryPlanInMageFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput
    {
        public RecoveryPlanInMageFailoverInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RpInMageRecoveryPointType RecoveryPointType { get { throw null; } }
    }
    public partial class RecoveryPlanInMageRcmFailbackFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput
    {
        public RecoveryPlanInMageRcmFailbackFailoverInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageRcmFailbackRecoveryPointType RecoveryPointType { get { throw null; } }
        public string UseMultiVmSyncPoint { get { throw null; } set { } }
    }
    public partial class RecoveryPlanInMageRcmFailoverInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput
    {
        public RecoveryPlanInMageRcmFailoverInput(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType recoveryPointType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPointType RecoveryPointType { get { throw null; } }
        public string UseMultiVmSyncPoint { get { throw null; } set { } }
    }
    public partial class RecoveryPlanManualActionDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanActionDetails
    {
        public RecoveryPlanManualActionDetails() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class RecoveryPlanPatch
    {
        public RecoveryPlanPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroup> UpdateRecoveryPlanInputGroups { get { throw null; } }
    }
    public partial class RecoveryPlanPlannedFailoverContent
    {
        public RecoveryPlanPlannedFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPlannedFailoverInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanPlannedFailoverInputProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPlanPlannedFailoverInputProperties
    {
        public RecoveryPlanPlannedFailoverInputProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection failoverDirection) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection FailoverDirection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput> ProviderSpecificDetails { get { throw null; } }
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
    public partial class RecoveryPlanProperties
    {
        internal RecoveryPlanProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedOperations { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentScenarioDetails CurrentScenario { get { throw null; } }
        public string CurrentScenarioStatus { get { throw null; } }
        public string CurrentScenarioStatusDescription { get { throw null; } }
        public string FailoverDeploymentModel { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanGroup> Groups { get { throw null; } }
        public System.DateTimeOffset? LastPlannedFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastTestFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastUnplannedFailoverOn { get { throw null; } }
        public string PrimaryFabricFriendlyName { get { throw null; } }
        public string PrimaryFabricId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificDetails> ProviderSpecificDetails { get { throw null; } }
        public string RecoveryFabricFriendlyName { get { throw null; } }
        public string RecoveryFabricId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReplicationProviders { get { throw null; } }
    }
    public partial class RecoveryPlanProtectedItem
    {
        public RecoveryPlanProtectedItem() { }
        public string Id { get { throw null; } set { } }
        public string VirtualMachineId { get { throw null; } set { } }
    }
    public abstract partial class RecoveryPlanProviderSpecificDetails
    {
        protected RecoveryPlanProviderSpecificDetails() { }
    }
    public abstract partial class RecoveryPlanProviderSpecificFailoverInput
    {
        protected RecoveryPlanProviderSpecificFailoverInput() { }
    }
    public abstract partial class RecoveryPlanProviderSpecificInput
    {
        protected RecoveryPlanProviderSpecificInput() { }
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
        public RecoveryPlanTestFailoverCleanupContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverCleanupInputProperties properties) { }
        public string RecoveryPlanTestFailoverCleanupInputComments { get { throw null; } }
    }
    public partial class RecoveryPlanTestFailoverCleanupInputProperties
    {
        public RecoveryPlanTestFailoverCleanupInputProperties() { }
        public string Comments { get { throw null; } set { } }
    }
    public partial class RecoveryPlanTestFailoverContent
    {
        public RecoveryPlanTestFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanTestFailoverInputProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPlanTestFailoverInputProperties
    {
        public RecoveryPlanTestFailoverInputProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection failoverDirection, string networkType) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection FailoverDirection { get { throw null; } }
        public string NetworkId { get { throw null; } set { } }
        public string NetworkType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput> ProviderSpecificDetails { get { throw null; } }
    }
    public partial class RecoveryPlanUnplannedFailoverContent
    {
        public RecoveryPlanUnplannedFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanUnplannedFailoverInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanUnplannedFailoverInputProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPlanUnplannedFailoverInputProperties
    {
        public RecoveryPlanUnplannedFailoverInputProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection failoverDirection, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation sourceSiteOperations) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PossibleOperationsDirection FailoverDirection { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPlanProviderSpecificFailoverInput> ProviderSpecificDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SourceSiteOperation SourceSiteOperations { get { throw null; } }
    }
    public partial class RecoveryPointProperties
    {
        internal RecoveryPointProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProviderSpecificRecoveryPointDetails ProviderSpecificDetails { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } }
        public string RecoveryPointType { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType Custom { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType LatestTag { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType LatestTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RecoveryPointType right) { throw null; }
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
    public partial class RecoveryServicesProviderCreateOrUpdateContent
    {
        public RecoveryServicesProviderCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AddRecoveryServicesProviderInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AddRecoveryServicesProviderInputProperties Properties { get { throw null; } }
    }
    public partial class RecoveryServicesProviderProperties
    {
        internal RecoveryServicesProviderProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedScenarios { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails AuthenticationIdentityDetails { get { throw null; } }
        public string BiosId { get { throw null; } }
        public string ConnectionStatus { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails DataPlaneAuthenticationIdentityDetails { get { throw null; } }
        public string DraIdentifier { get { throw null; } }
        public string FabricFriendlyName { get { throw null; } }
        public string FabricType { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastHeartBeat { get { throw null; } }
        public string MachineId { get { throw null; } }
        public string MachineName { get { throw null; } }
        public int? ProtectedItemCount { get { throw null; } }
        public string ProviderVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VersionDetails ProviderVersionDetails { get { throw null; } }
        public System.DateTimeOffset? ProviderVersionExpiryOn { get { throw null; } }
        public string ProviderVersionState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IdentityProviderDetails ResourceAccessIdentityDetails { get { throw null; } }
        public string ServerVersion { get { throw null; } }
    }
    public abstract partial class RecoveryVirtualNetworkCustomDetails
    {
        protected RecoveryVirtualNetworkCustomDetails() { }
    }
    public partial class RemoveDisksContent
    {
        public RemoveDisksContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RemoveDisksProviderSpecificInput RemoveDisksInputProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class RemoveDisksProviderSpecificInput
    {
        protected RemoveDisksProviderSpecificInput() { }
    }
    public partial class RemoveProtectionContainerMappingContent
    {
        public RemoveProtectionContainerMappingContent() { }
        public string ProviderSpecificInputInstanceType { get { throw null; } set { } }
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
        public string FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ReplicationAppliance
    {
        internal ReplicationAppliance() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ApplianceSpecificDetails ReplicationApplianceProviderSpecificDetails { get { throw null; } }
    }
    public partial class ReplicationEligibilityResultsErrorInfo
    {
        internal ReplicationEligibilityResultsErrorInfo() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ReplicationEligibilityResultsProperties
    {
        internal ReplicationEligibilityResultsProperties() { }
        public string ClientRequestId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationEligibilityResultsErrorInfo> Errors { get { throw null; } }
    }
    public partial class ReplicationGroupDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ConfigurationSettings
    {
        internal ReplicationGroupDetails() { }
    }
    public partial class ReplicationProtectedItemCreateOrUpdateContent
    {
        public ReplicationProtectedItemCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableProtectionInputProperties Properties { get { throw null; } set { } }
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
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemInputProperties Properties { get { throw null; } set { } }
    }
    public partial class ReplicationProtectedItemProperties
    {
        internal ReplicationProtectedItemProperties() { }
        public string ActiveLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AllowedOperations { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CurrentScenarioDetails CurrentScenario { get { throw null; } }
        public string EventCorrelationId { get { throw null; } }
        public string FailoverHealth { get { throw null; } }
        public string FailoverRecoveryPointId { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulTestFailoverOn { get { throw null; } }
        public string PolicyFriendlyName { get { throw null; } }
        public string PolicyId { get { throw null; } }
        public string PrimaryFabricFriendlyName { get { throw null; } }
        public string PrimaryFabricProvider { get { throw null; } }
        public string PrimaryProtectionContainerFriendlyName { get { throw null; } }
        public string ProtectableItemId { get { throw null; } }
        public string ProtectedItemType { get { throw null; } }
        public string ProtectionState { get { throw null; } }
        public string ProtectionStateDescription { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificSettings ProviderSpecificDetails { get { throw null; } }
        public string RecoveryContainerId { get { throw null; } }
        public string RecoveryFabricFriendlyName { get { throw null; } }
        public string RecoveryFabricId { get { throw null; } }
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
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.CreateProtectionIntentProviderSpecificDetails CreateProtectionIntentProviderSpecificDetails { get { throw null; } set { } }
    }
    public partial class ReplicationProtectionIntentProperties
    {
        internal ReplicationProtectionIntentProperties() { }
        public string CreationTimeUTC { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public bool? IsActive { get { throw null; } }
        public string JobId { get { throw null; } }
        public string JobState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProtectionIntentProviderSpecificSettings ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class ReplicationProtectionIntentProviderSpecificSettings
    {
        protected ReplicationProtectionIntentProviderSpecificSettings() { }
    }
    public abstract partial class ReplicationProviderSpecificContainerCreationInput
    {
        protected ReplicationProviderSpecificContainerCreationInput() { }
    }
    public abstract partial class ReplicationProviderSpecificContainerMappingInput
    {
        protected ReplicationProviderSpecificContainerMappingInput() { }
    }
    public abstract partial class ReplicationProviderSpecificSettings
    {
        protected ReplicationProviderSpecificSettings() { }
    }
    public abstract partial class ReplicationProviderSpecificUpdateContainerMappingInput
    {
        protected ReplicationProviderSpecificUpdateContainerMappingInput() { }
    }
    public partial class ReprotectAgentDetails
    {
        internal ReprotectAgentDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> AccessibleDatastores { get { throw null; } }
        public string BiosId { get { throw null; } }
        public string FabricObjectId { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProtectionHealth? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastDiscoveryInUtc { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
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
    public partial class ResumeJobParams
    {
        public ResumeJobParams() { }
        public string ResumeJobParamsComments { get { throw null; } set { } }
    }
    public partial class ResumeReplicationContent
    {
        public ResumeReplicationContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationProviderSpecificInput ResumeReplicationInputProviderSpecificDetails { get { throw null; } }
    }
    public partial class ResumeReplicationInputProperties
    {
        public ResumeReplicationInputProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationProviderSpecificInput providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationProviderSpecificInput ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class ResumeReplicationProviderSpecificInput
    {
        protected ResumeReplicationProviderSpecificInput() { }
    }
    public partial class ResyncContent
    {
        public ResyncContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncProviderSpecificInput ResyncInputProviderSpecificDetails { get { throw null; } }
    }
    public partial class ResyncInputProperties
    {
        public ResyncInputProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncProviderSpecificInput providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncProviderSpecificInput ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class ResyncProviderSpecificInput
    {
        protected ResyncProviderSpecificInput() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResyncState : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResyncState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState PreparedForResynchronization { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState StartedResynchronization { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RetentionVolume
    {
        internal RetentionVolume() { }
        public long? CapacityInBytes { get { throw null; } }
        public long? FreeSpaceInBytes { get { throw null; } }
        public int? ThresholdPercentage { get { throw null; } }
        public string VolumeName { get { throw null; } }
    }
    public partial class ReverseReplicationContent
    {
        public ReverseReplicationContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationInputProperties Properties { get { throw null; } set { } }
    }
    public partial class ReverseReplicationInputProperties
    {
        public ReverseReplicationInputProperties() { }
        public string FailoverDirection { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReverseReplicationProviderSpecificInput ProviderSpecificDetails { get { throw null; } set { } }
    }
    public abstract partial class ReverseReplicationProviderSpecificInput
    {
        protected ReverseReplicationProviderSpecificInput() { }
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
    public partial class RunAsAccount
    {
        internal RunAsAccount() { }
        public string AccountId { get { throw null; } }
        public string AccountName { get { throw null; } }
    }
    public partial class ScriptActionTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TaskTypeDetails
    {
        internal ScriptActionTaskDetails() { }
        public bool? IsPrimarySideScript { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        public string Path { get { throw null; } }
    }
    public partial class ServiceError
    {
        internal ServiceError() { }
        public string ActivityId { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Severity : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Severity(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity Error { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity Info { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.Severity right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerLicenseType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType Ahub { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType NoLicenseType { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class StorageAccountCustomDetails
    {
        protected StorageAccountCustomDetails() { }
    }
    public partial class StorageClassificationMappingCreateOrUpdateContent
    {
        public StorageClassificationMappingCreateOrUpdateContent() { }
        public string TargetStorageClassificationId { get { throw null; } set { } }
    }
    public partial class Subnet
    {
        internal Subnet() { }
        public System.Collections.Generic.IReadOnlyList<string> AddressList { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SupportedOperatingSystems : Azure.ResourceManager.Models.ResourceData
    {
        internal SupportedOperatingSystems() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SupportedOSProperty> SupportedOSList { get { throw null; } }
    }
    public partial class SupportedOSDetails
    {
        internal SupportedOSDetails() { }
        public string OSName { get { throw null; } }
        public string OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.OSVersionWrapper> OSVersions { get { throw null; } }
    }
    public partial class SupportedOSProperty
    {
        internal SupportedOSProperty() { }
        public string InstanceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SupportedOSDetails> SupportedOS { get { throw null; } }
    }
    public partial class SwitchProtectionContent
    {
        public SwitchProtectionContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionInputProperties Properties { get { throw null; } set { } }
    }
    public partial class SwitchProtectionInputProperties
    {
        public SwitchProtectionInputProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProtectionProviderSpecificInput ProviderSpecificDetails { get { throw null; } set { } }
        public string ReplicationProtectedItemName { get { throw null; } set { } }
    }
    public partial class SwitchProtectionJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobDetails
    {
        internal SwitchProtectionJobDetails() { }
        public string NewReplicationProtectedItemId { get { throw null; } }
    }
    public abstract partial class SwitchProtectionProviderSpecificInput
    {
        protected SwitchProtectionProviderSpecificInput() { }
    }
    public partial class SwitchProviderContent
    {
        public SwitchProviderContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProviderInputProperties Properties { get { throw null; } set { } }
    }
    public partial class SwitchProviderInputProperties
    {
        public SwitchProviderInputProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SwitchProviderSpecificInput ProviderSpecificDetails { get { throw null; } set { } }
        public string TargetInstanceType { get { throw null; } set { } }
    }
    public abstract partial class SwitchProviderSpecificInput
    {
        protected SwitchProviderSpecificInput() { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ComputeSizeErrorDetails> Errors { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HighIopsSupported { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> HyperVGenerations { get { throw null; } }
        public int? MaxDataDiskCount { get { throw null; } }
        public int? MaxNicsCount { get { throw null; } }
        public double? MemoryInGB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? VCpusAvailable { get { throw null; } }
    }
    public abstract partial class TaskTypeDetails
    {
        protected TaskTypeDetails() { }
    }
    public partial class TestFailoverCleanupContent
    {
        public TestFailoverCleanupContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverCleanupInputProperties properties) { }
        public string TestFailoverCleanupInputComments { get { throw null; } }
    }
    public partial class TestFailoverCleanupInputProperties
    {
        public TestFailoverCleanupInputProperties() { }
        public string Comments { get { throw null; } set { } }
    }
    public partial class TestFailoverContent
    {
        public TestFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverInputProperties Properties { get { throw null; } }
    }
    public partial class TestFailoverInputProperties
    {
        public TestFailoverInputProperties() { }
        public string FailoverDirection { get { throw null; } set { } }
        public string NetworkId { get { throw null; } set { } }
        public string NetworkType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestFailoverProviderSpecificInput ProviderSpecificDetails { get { throw null; } set { } }
    }
    public partial class TestFailoverJobDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobDetails
    {
        internal TestFailoverJobDetails() { }
        public string Comments { get { throw null; } }
        public string NetworkFriendlyName { get { throw null; } }
        public string NetworkName { get { throw null; } }
        public string NetworkType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FailoverReplicationProtectedItemDetails> ProtectedItemDetails { get { throw null; } }
        public string TestFailoverStatus { get { throw null; } }
    }
    public abstract partial class TestFailoverProviderSpecificInput
    {
        protected TestFailoverProviderSpecificInput() { }
    }
    public partial class TestMigrateCleanupContent
    {
        public TestMigrateCleanupContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateCleanupInputProperties properties) { }
        public string TestMigrateCleanupInputComments { get { throw null; } }
    }
    public partial class TestMigrateCleanupInputProperties
    {
        public TestMigrateCleanupInputProperties() { }
        public string Comments { get { throw null; } set { } }
    }
    public partial class TestMigrateContent
    {
        public TestMigrateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateProviderSpecificInput TestMigrateInputProviderSpecificDetails { get { throw null; } }
    }
    public partial class TestMigrateInputProperties
    {
        public TestMigrateInputProperties(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateProviderSpecificInput providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateProviderSpecificInput ProviderSpecificDetails { get { throw null; } }
    }
    public abstract partial class TestMigrateProviderSpecificInput
    {
        protected TestMigrateProviderSpecificInput() { }
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
        public UnplannedFailoverContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverInputProperties Properties { get { throw null; } }
    }
    public partial class UnplannedFailoverInputProperties
    {
        public UnplannedFailoverInputProperties() { }
        public string FailoverDirection { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UnplannedFailoverProviderSpecificInput ProviderSpecificDetails { get { throw null; } set { } }
        public string SourceSiteOperations { get { throw null; } set { } }
    }
    public abstract partial class UnplannedFailoverProviderSpecificInput
    {
        protected UnplannedFailoverProviderSpecificInput() { }
    }
    public partial class UpdateApplianceForReplicationProtectedItemContent
    {
        public UpdateApplianceForReplicationProtectedItemContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemInputProperties Properties { get { throw null; } }
    }
    public partial class UpdateApplianceForReplicationProtectedItemInputProperties
    {
        public UpdateApplianceForReplicationProtectedItemInputProperties(string targetApplianceId, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemProviderSpecificInput providerSpecificDetails) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateApplianceForReplicationProtectedItemProviderSpecificInput ProviderSpecificDetails { get { throw null; } }
        public string TargetApplianceId { get { throw null; } }
    }
    public abstract partial class UpdateApplianceForReplicationProtectedItemProviderSpecificInput
    {
        protected UpdateApplianceForReplicationProtectedItemProviderSpecificInput() { }
    }
    public partial class UpdateDiskInput
    {
        public UpdateDiskInput(string diskId) { }
        public string DiskId { get { throw null; } }
        public string TargetDiskName { get { throw null; } set { } }
    }
    public abstract partial class UpdateMigrationItemProviderSpecificInput
    {
        protected UpdateMigrationItemProviderSpecificInput() { }
    }
    public partial class UpdateMobilityServiceContent
    {
        public UpdateMobilityServiceContent() { }
        public string UpdateMobilityServiceRequestRunAsAccountId { get { throw null; } set { } }
    }
    public partial class UpdateNetworkMappingInputProperties
    {
        public UpdateNetworkMappingInputProperties() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificUpdateNetworkMappingInput FabricSpecificDetails { get { throw null; } set { } }
        public string RecoveryFabricName { get { throw null; } set { } }
        public string RecoveryNetworkId { get { throw null; } set { } }
    }
    public partial class UpdateReplicationProtectedItemInputProperties
    {
        public UpdateReplicationProtectedItemInputProperties() { }
        public string EnableRdpOnTargetOption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateReplicationProtectedItemProviderInput ProviderSpecificDetails { get { throw null; } set { } }
        public string RecoveryAvailabilitySetId { get { throw null; } set { } }
        public string RecoveryAzureVmName { get { throw null; } set { } }
        public string RecoveryAzureVmSize { get { throw null; } set { } }
        public string SelectedRecoveryAzureNetworkId { get { throw null; } set { } }
        public string SelectedSourceNicId { get { throw null; } set { } }
        public string SelectedTfoAzureNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmNicInputDetails> VmNics { get { throw null; } }
    }
    public abstract partial class UpdateReplicationProtectedItemProviderInput
    {
        protected UpdateReplicationProtectedItemProviderInput() { }
    }
    public partial class UpdateVCenterRequestProperties
    {
        public UpdateVCenterRequestProperties() { }
        public string FriendlyName { get { throw null; } set { } }
        public string IPAddress { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        public string ProcessServerId { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> VaultErrors { get { throw null; } }
    }
    public partial class VaultSettingCreateOrUpdateContent
    {
        public VaultSettingCreateOrUpdateContent(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultSettingCreationInputProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VaultSettingCreationInputProperties Properties { get { throw null; } }
    }
    public partial class VaultSettingCreationInputProperties
    {
        public VaultSettingCreationInputProperties() { }
        public string MigrationSolutionId { get { throw null; } set { } }
        public string VMwareToAzureProviderType { get { throw null; } set { } }
    }
    public partial class VaultSettingProperties
    {
        internal VaultSettingProperties() { }
        public string MigrationSolutionId { get { throw null; } }
        public string VMwareToAzureProviderType { get { throw null; } }
    }
    public partial class VCenterCreateOrUpdateContent
    {
        public VCenterCreateOrUpdateContent() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AddVCenterRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class VCenterPatch
    {
        public VCenterPatch() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateVCenterRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class VCenterProperties
    {
        internal VCenterProperties() { }
        public string DiscoveryStatus { get { throw null; } }
        public string FabricArmResourceName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> HealthErrors { get { throw null; } }
        public string InfrastructureId { get { throw null; } }
        public string InternalId { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeat { get { throw null; } }
        public string Port { get { throw null; } }
        public string ProcessServerId { get { throw null; } }
        public string RunAsAccountId { get { throw null; } }
    }
    public partial class VersionDetails
    {
        internal VersionDetails() { }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.AgentVersionStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class VirtualMachineTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.JobTaskDetails
    {
        internal VirtualMachineTaskDetails() { }
        public string SkippedReason { get { throw null; } }
        public string SkippedReasonString { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmEncryptionType : System.IEquatable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType NotEncrypted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType OnePassEncrypted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType TwoPassEncrypted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType left, Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VmEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmmDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal VmmDetails() { }
    }
    public partial class VmmToAzureCreateNetworkMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreateNetworkMappingInput
    {
        public VmmToAzureCreateNetworkMappingInput() { }
    }
    public partial class VmmToAzureNetworkMappingSettings : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingFabricSpecificSettings
    {
        internal VmmToAzureNetworkMappingSettings() { }
    }
    public partial class VmmToAzureUpdateNetworkMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificUpdateNetworkMappingInput
    {
        public VmmToAzureUpdateNetworkMappingInput() { }
    }
    public partial class VmmToVmmCreateNetworkMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreateNetworkMappingInput
    {
        public VmmToVmmCreateNetworkMappingInput() { }
    }
    public partial class VmmToVmmNetworkMappingSettings : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.NetworkMappingFabricSpecificSettings
    {
        internal VmmToVmmNetworkMappingSettings() { }
    }
    public partial class VmmToVmmUpdateNetworkMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificUpdateNetworkMappingInput
    {
        public VmmToVmmUpdateNetworkMappingInput() { }
    }
    public partial class VmmVirtualMachineDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HyperVVirtualMachineDetails
    {
        internal VmmVirtualMachineDetails() { }
    }
    public partial class VmNicDetails
    {
        internal VmNicDetails() { }
        public bool? EnableAcceleratedNetworkingOnRecovery { get { throw null; } }
        public bool? EnableAcceleratedNetworkingOnTfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IPConfigDetails> IPConfigs { get { throw null; } }
        public string NicId { get { throw null; } }
        public string RecoveryNetworkSecurityGroupId { get { throw null; } }
        public string RecoveryNicName { get { throw null; } }
        public string RecoveryNicResourceGroupName { get { throw null; } }
        public string RecoveryVmNetworkId { get { throw null; } }
        public string ReplicaNicId { get { throw null; } }
        public bool? ReuseExistingNic { get { throw null; } }
        public string SelectionType { get { throw null; } }
        public string SourceNicArmId { get { throw null; } }
        public string TargetNicName { get { throw null; } }
        public string TfoNetworkSecurityGroupId { get { throw null; } }
        public string TfoRecoveryNicName { get { throw null; } }
        public string TfoRecoveryNicResourceGroupName { get { throw null; } }
        public bool? TfoReuseExistingNic { get { throw null; } }
        public string TfoVmNetworkId { get { throw null; } }
        public string VmNetworkName { get { throw null; } }
    }
    public partial class VmNicInputDetails
    {
        public VmNicInputDetails() { }
        public bool? EnableAcceleratedNetworkingOnRecovery { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworkingOnTfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.IPConfigInputDetails> IPConfigs { get { throw null; } }
        public string NicId { get { throw null; } set { } }
        public string RecoveryNetworkSecurityGroupId { get { throw null; } set { } }
        public string RecoveryNicName { get { throw null; } set { } }
        public string RecoveryNicResourceGroupName { get { throw null; } set { } }
        public bool? ReuseExistingNic { get { throw null; } set { } }
        public string SelectionType { get { throw null; } set { } }
        public string TargetNicName { get { throw null; } set { } }
        public string TfoNetworkSecurityGroupId { get { throw null; } set { } }
        public string TfoNicName { get { throw null; } set { } }
        public string TfoNicResourceGroupName { get { throw null; } set { } }
        public bool? TfoReuseExistingNic { get { throw null; } set { } }
    }
    public partial class VmNicUpdatesTaskDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TaskTypeDetails
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
    public partial class VMwareCbtContainerCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerCreationInput
    {
        public VMwareCbtContainerCreationInput() { }
    }
    public partial class VMwareCbtContainerMappingInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ReplicationProviderSpecificContainerMappingInput
    {
        public VMwareCbtContainerMappingInput(string storageAccountId, string targetLocation) { }
        public string KeyVaultId { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string ServiceBusConnectionStringSecretName { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } }
        public string StorageAccountSasSecretName { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } }
    }
    public partial class VMwareCbtDiskInput
    {
        public VMwareCbtDiskInput(string diskId, string isOSDisk, string logStorageAccountId, string logStorageAccountSasSecretName) { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType? DiskType { get { throw null; } set { } }
        public string IsOSDisk { get { throw null; } }
        public string LogStorageAccountId { get { throw null; } }
        public string LogStorageAccountSasSecretName { get { throw null; } }
    }
    public partial class VMwareCbtEnableMigrationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EnableMigrationProviderSpecificInput
    {
        public VMwareCbtEnableMigrationInput(string vmwareMachineId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtDiskInput> disksToInclude, string dataMoverRunAsAccountId, string snapshotRunAsAccountId, string targetResourceGroupId, string targetNetworkId) { }
        public string DataMoverRunAsAccountId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtDiskInput> DisksToInclude { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public string PerformAutoResync { get { throw null; } set { } }
        public string PerformSqlBulkRegistration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SeedDiskTags { get { throw null; } }
        public string SnapshotRunAsAccountId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public string TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetBootDiagnosticsStorageAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetDiskTags { get { throw null; } }
        public string TargetNetworkId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } set { } }
        public string TargetResourceGroupId { get { throw null; } }
        public string TargetSubnetName { get { throw null; } set { } }
        public string TargetVmName { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public string TestNetworkId { get { throw null; } set { } }
        public string TestSubnetName { get { throw null; } set { } }
        public string VMwareMachineId { get { throw null; } }
    }
    public partial class VMwareCbtEventDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EventProviderSpecificDetails
    {
        internal VMwareCbtEventDetails() { }
        public string MigrationItemName { get { throw null; } }
    }
    public partial class VMwareCbtMigrateInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrateProviderSpecificInput
    {
        public VMwareCbtMigrateInput(string performShutdown) { }
        public string PerformShutdown { get { throw null; } }
    }
    public partial class VMwareCbtMigrationDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MigrationProviderSpecificSettings
    {
        internal VMwareCbtMigrationDetails() { }
        public string DataMoverRunAsAccountId { get { throw null; } }
        public string FirmwareType { get { throw null; } }
        public int? InitialSeedingProgressPercentage { get { throw null; } }
        public long? InitialSeedingRetryCount { get { throw null; } }
        public string LastRecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public int? MigrationProgressPercentage { get { throw null; } }
        public string MigrationRecoveryPointId { get { throw null; } }
        public string OSType { get { throw null; } }
        public string PerformAutoResync { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtProtectedDiskDetails> ProtectedDisks { get { throw null; } }
        public int? ResumeProgressPercentage { get { throw null; } }
        public long? ResumeRetryCount { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public string ResyncRequired { get { throw null; } }
        public long? ResyncRetryCount { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncState? ResyncState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SeedDiskTags { get { throw null; } }
        public string SnapshotRunAsAccountId { get { throw null; } }
        public string SqlServerLicenseType { get { throw null; } }
        public string StorageAccountId { get { throw null; } }
        public string TargetAvailabilitySetId { get { throw null; } }
        public string TargetAvailabilityZone { get { throw null; } }
        public string TargetBootDiagnosticsStorageAccountId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetDiskTags { get { throw null; } }
        public string TargetGeneration { get { throw null; } }
        public string TargetLocation { get { throw null; } }
        public string TargetNetworkId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetNicTags { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } }
        public string TargetResourceGroupId { get { throw null; } }
        public string TargetVmName { get { throw null; } }
        public string TargetVmSize { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> TargetVmTags { get { throw null; } }
        public string TestNetworkId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtNicDetails> VmNics { get { throw null; } }
        public string VMwareMachineId { get { throw null; } }
    }
    public partial class VMwareCbtNicDetails
    {
        internal VMwareCbtNicDetails() { }
        public string IsPrimaryNic { get { throw null; } }
        public string IsSelectedForMigration { get { throw null; } }
        public string NicId { get { throw null; } }
        public string SourceIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType? SourceIPAddressType { get { throw null; } }
        public string SourceNetworkId { get { throw null; } }
        public string TargetIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType? TargetIPAddressType { get { throw null; } }
        public string TargetNicName { get { throw null; } }
        public string TargetSubnetName { get { throw null; } }
        public string TestIPAddress { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.EthernetAddressType? TestIPAddressType { get { throw null; } }
        public string TestNetworkId { get { throw null; } }
        public string TestSubnetName { get { throw null; } }
    }
    public partial class VMwareCbtNicInput
    {
        public VMwareCbtNicInput(string nicId, string isPrimaryNic) { }
        public string IsPrimaryNic { get { throw null; } }
        public string IsSelectedForMigration { get { throw null; } set { } }
        public string NicId { get { throw null; } }
        public string TargetNicName { get { throw null; } set { } }
        public string TargetStaticIPAddress { get { throw null; } set { } }
        public string TargetSubnetName { get { throw null; } set { } }
        public string TestStaticIPAddress { get { throw null; } set { } }
        public string TestSubnetName { get { throw null; } set { } }
    }
    public partial class VMwareCbtPolicyCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.PolicyProviderSpecificInput
    {
        public VMwareCbtPolicyCreationInput() { }
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
        public string DiskEncryptionSetId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string DiskPath { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.DiskAccountType? DiskType { get { throw null; } }
        public string IsOSDisk { get { throw null; } }
        public string LogStorageAccountId { get { throw null; } }
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
        public string KeyVaultId { get { throw null; } }
        public System.Uri KeyVaultUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> RoleSizeToNicCountMap { get { throw null; } }
        public string ServiceBusConnectionStringSecretName { get { throw null; } }
        public string StorageAccountId { get { throw null; } }
        public string StorageAccountSasSecretName { get { throw null; } }
        public string TargetLocation { get { throw null; } }
    }
    public partial class VMwareCbtResumeReplicationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResumeReplicationProviderSpecificInput
    {
        public VMwareCbtResumeReplicationInput() { }
        public string DeleteMigrationResources { get { throw null; } set { } }
    }
    public partial class VMwareCbtResyncInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ResyncProviderSpecificInput
    {
        public VMwareCbtResyncInput(string skipCbtReset) { }
        public string SkipCbtReset { get { throw null; } }
    }
    public partial class VMwareCbtTestMigrateInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.TestMigrateProviderSpecificInput
    {
        public VMwareCbtTestMigrateInput(string recoveryPointId, string networkId) { }
        public string NetworkId { get { throw null; } }
        public string RecoveryPointId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtNicInput> VmNics { get { throw null; } }
    }
    public partial class VMwareCbtUpdateDiskInput
    {
        public VMwareCbtUpdateDiskInput(string diskId) { }
        public string DiskId { get { throw null; } }
        public string IsOSDisk { get { throw null; } set { } }
        public string TargetDiskName { get { throw null; } set { } }
    }
    public partial class VMwareCbtUpdateMigrationItemInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.UpdateMigrationItemProviderSpecificInput
    {
        public VMwareCbtUpdateMigrationItemInput() { }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public string PerformAutoResync { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.SqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public string TargetAvailabilitySetId { get { throw null; } set { } }
        public string TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetBootDiagnosticsStorageAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetDiskTags { get { throw null; } }
        public string TargetNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags { get { throw null; } }
        public string TargetProximityPlacementGroupId { get { throw null; } set { } }
        public string TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmName { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetVmTags { get { throw null; } }
        public string TestNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtUpdateDiskInput> VmDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VMwareCbtNicInput> VmNics { get { throw null; } }
    }
    public partial class VMwareDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal VMwareDetails() { }
        public string AgentCount { get { throw null; } }
        public System.DateTimeOffset? AgentExpiryOn { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.VersionDetails AgentVersionDetails { get { throw null; } }
        public long? AvailableMemoryInBytes { get { throw null; } }
        public long? AvailableSpaceInBytes { get { throw null; } }
        public string CpuLoad { get { throw null; } }
        public string CpuLoadStatus { get { throw null; } }
        public string CsServiceStatus { get { throw null; } }
        public string DatabaseServerLoad { get { throw null; } }
        public string DatabaseServerLoadStatus { get { throw null; } }
        public string HostName { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeat { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.MasterTargetServer> MasterTargetServers { get { throw null; } }
        public string MemoryUsageStatus { get { throw null; } }
        public string ProcessServerCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProcessServer> ProcessServers { get { throw null; } }
        public string ProtectedServers { get { throw null; } }
        public string PsTemplateVersion { get { throw null; } }
        public string ReplicationPairCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.RunAsAccount> RunAsAccounts { get { throw null; } }
        public string SpaceUsageStatus { get { throw null; } }
        public System.DateTimeOffset? SslCertExpiryOn { get { throw null; } }
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
    public partial class VMwareV2FabricCreationInput : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificCreationInput
    {
        public VMwareV2FabricCreationInput(string migrationSolutionId) { }
        public string MigrationSolutionId { get { throw null; } }
        public string PhysicalSiteId { get { throw null; } set { } }
        public string VMwareSiteId { get { throw null; } set { } }
    }
    public partial class VMwareV2FabricSpecificDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.FabricSpecificDetails
    {
        internal VMwareV2FabricSpecificDetails() { }
        public string MigrationSolutionId { get { throw null; } }
        public string PhysicalSiteId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ProcessServerDetails> ProcessServers { get { throw null; } }
        public string ServiceContainerId { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public string ServiceResourceId { get { throw null; } }
        public string VMwareSiteId { get { throw null; } }
    }
    public partial class VMwareVirtualMachineDetails : Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.ConfigurationSettings
    {
        internal VMwareVirtualMachineDetails() { }
        public string AgentGeneratedId { get { throw null; } }
        public string AgentInstalled { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string DiscoveryType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.InMageDiskDetails> DiskDetails { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string OSType { get { throw null; } }
        public string PoweredOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesSiteRecovery.Models.HealthError> ValidationErrors { get { throw null; } }
        public string VCenterInfrastructureId { get { throw null; } }
    }
}
