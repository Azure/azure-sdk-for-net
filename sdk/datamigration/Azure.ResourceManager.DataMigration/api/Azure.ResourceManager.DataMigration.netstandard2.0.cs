namespace Azure.ResourceManager.DataMigration
{
    public partial class DatabaseMigrationSqlDBCollection : Azure.ResourceManager.ArmCollection
    {
        protected DatabaseMigrationSqlDBCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlDBInstanceName, string targetDBName, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlDBInstanceName, string targetDBName, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource> Get(string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource>> GetAsync(string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseMigrationSqlDBData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseMigrationSqlDBData() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties Properties { get { throw null; } set { } }
    }
    public partial class DatabaseMigrationSqlDBResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseMigrationSqlDBResource() { }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlDBInstanceName, string targetDBName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource> Get(System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource>> GetAsync(System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseMigrationSqlMICollection : Azure.ResourceManager.ArmCollection
    {
        protected DatabaseMigrationSqlMICollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedInstanceName, string targetDBName, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedInstanceName, string targetDBName, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource> Get(string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource>> GetAsync(string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseMigrationSqlMIData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseMigrationSqlMIData() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties Properties { get { throw null; } set { } }
    }
    public partial class DatabaseMigrationSqlMIResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseMigrationSqlMIResource() { }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string targetDBName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Cutover(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CutoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource> Get(System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource>> GetAsync(System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseMigrationSqlVmCollection : Azure.ResourceManager.ArmCollection
    {
        protected DatabaseMigrationSqlVmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlVirtualMachineName, string targetDBName, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlVirtualMachineName, string targetDBName, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource> Get(string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource>> GetAsync(string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseMigrationSqlVmData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseMigrationSqlVmData() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties Properties { get { throw null; } set { } }
    }
    public partial class DatabaseMigrationSqlVmResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseMigrationSqlVmResource() { }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVirtualMachineName, string targetDBName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Cutover(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CutoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.MigrationOperationInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource> Get(System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource>> GetAsync(System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataMigrationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse> CheckNameAvailabilityService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest nameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>> CheckNameAvailabilityServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest nameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource> GetDatabaseMigrationSqlDB(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource>> GetDatabaseMigrationSqlDBAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource GetDatabaseMigrationSqlDBResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBCollection GetDatabaseMigrationSqlDBs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource> GetDatabaseMigrationSqlMI(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource>> GetDatabaseMigrationSqlMIAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource GetDatabaseMigrationSqlMIResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMICollection GetDatabaseMigrationSqlMIs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource> GetDatabaseMigrationSqlVm(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource>> GetDatabaseMigrationSqlVmAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource GetDatabaseMigrationSqlVmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmCollection GetDatabaseMigrationSqlVms(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> GetDataMigrationServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationServiceResource GetDataMigrationServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationServiceCollection GetDataMigrationServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataMigration.ProjectFileResource GetProjectFileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.ProjectResource GetProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.ServiceProjectTaskResource GetServiceProjectTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.ServiceServiceTaskResource GetServiceServiceTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataMigration.Models.ResourceSku> GetSkusResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.ResourceSku> GetSkusResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> GetSqlMigrationServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataMigration.SqlMigrationServiceResource GetSqlMigrationServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.SqlMigrationServiceCollection GetSqlMigrationServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataMigration.Models.Quota> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.Quota> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataMigrationServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>, System.Collections.IEnumerable
    {
        protected DataMigrationServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.DataMigration.DataMigrationServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.DataMigration.DataMigrationServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataMigrationServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataMigrationServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AutoStopDelay { get { throw null; } set { } }
        public bool? DeleteResourcesOnStop { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ServiceSku Sku { get { throw null; } set { } }
        public string VirtualNicId { get { throw null; } set { } }
        public string VirtualSubnetId { get { throw null; } set { } }
    }
    public partial class DataMigrationServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMigrationServiceResource() { }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse> CheckChildrenNameAvailability(Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest nameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>> CheckChildrenNameAvailabilityAsync(Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest nameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse> CheckStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>> CheckStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource> GetProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource>> GetProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.ProjectCollection GetProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> GetServiceServiceTask(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> GetServiceServiceTaskAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.ServiceServiceTaskCollection GetServiceServiceTasks() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.AvailableServiceSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.AvailableServiceSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DataMigrationServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DataMigrationServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ProjectResource>, System.Collections.IEnumerable
    {
        protected ProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DataMigration.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DataMigration.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.ProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.ProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.ProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.ProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProjectData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp AzureAuthenticationInfo { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.DatabaseInfo> DatabasesInfo { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform? SourcePlatform { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform? TargetPlatform { get { throw null; } set { } }
    }
    public partial class ProjectFileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ProjectFileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ProjectFileResource>, System.Collections.IEnumerable
    {
        protected ProjectFileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ProjectFileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fileName, Azure.ResourceManager.DataMigration.ProjectFileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ProjectFileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fileName, Azure.ResourceManager.DataMigration.ProjectFileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectFileResource> Get(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.ProjectFileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.ProjectFileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectFileResource>> GetAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.ProjectFileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ProjectFileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.ProjectFileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ProjectFileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectFileData : Azure.ResourceManager.Models.ResourceData
    {
        public ProjectFileData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectFileProperties Properties { get { throw null; } set { } }
    }
    public partial class ProjectFileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectFileResource() { }
        public virtual Azure.ResourceManager.DataMigration.ProjectFileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName, string projectName, string fileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectFileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectFileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.FileStorageInfo> Read(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.FileStorageInfo>> ReadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.FileStorageInfo> ReadWrite(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.FileStorageInfo>> ReadWriteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectFileResource> Update(Azure.ResourceManager.DataMigration.ProjectFileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectFileResource>> UpdateAsync(Azure.ResourceManager.DataMigration.ProjectFileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectResource() { }
        public virtual Azure.ResourceManager.DataMigration.ProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectFileResource> GetProjectFile(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectFileResource>> GetProjectFileAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.ProjectFileCollection GetProjectFiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> GetServiceProjectTask(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>> GetServiceProjectTaskAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.ServiceProjectTaskCollection GetServiceProjectTasks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource> Update(Azure.ResourceManager.DataMigration.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ProjectResource>> UpdateAsync(Azure.ResourceManager.DataMigration.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectTaskData : Azure.ResourceManager.Models.ResourceData
    {
        public ProjectTaskData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties Properties { get { throw null; } set { } }
    }
    public partial class ServiceProjectTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>, System.Collections.IEnumerable
    {
        protected ServiceProjectTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.DataMigration.ProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.DataMigration.ProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> Get(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> GetAll(string taskType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> GetAllAsync(string taskType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>> GetAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceProjectTaskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceProjectTaskResource() { }
        public virtual Azure.ResourceManager.DataMigration.ProjectTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.CommandProperties> Command(Azure.ResourceManager.DataMigration.Models.CommandProperties commandProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.CommandProperties>> CommandAsync(Azure.ResourceManager.DataMigration.Models.CommandProperties commandProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName, string projectName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> Update(Azure.ResourceManager.DataMigration.ProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>> UpdateAsync(Azure.ResourceManager.DataMigration.ProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceServiceTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>, System.Collections.IEnumerable
    {
        protected ServiceServiceTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.DataMigration.ProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.DataMigration.ProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> Get(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> GetAll(string taskType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> GetAllAsync(string taskType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> GetAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceServiceTaskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceServiceTaskResource() { }
        public virtual Azure.ResourceManager.DataMigration.ProjectTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> Update(Azure.ResourceManager.DataMigration.ProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> UpdateAsync(Azure.ResourceManager.DataMigration.ProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlMigrationServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>, System.Collections.IEnumerable
    {
        protected SqlMigrationServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlMigrationServiceName, Azure.ResourceManager.DataMigration.SqlMigrationServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlMigrationServiceName, Azure.ResourceManager.DataMigration.SqlMigrationServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> Get(string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> GetAsync(string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlMigrationServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SqlMigrationServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string IntegrationRuntimeState { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class SqlMigrationServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlMigrationServiceResource() { }
        public virtual Azure.ResourceManager.DataMigration.SqlMigrationServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlMigrationServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.DeleteNode> DeleteNode(Azure.ResourceManager.DataMigration.Models.DeleteNode deleteNode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DeleteNode>> DeleteNodeAsync(Azure.ResourceManager.DataMigration.Models.DeleteNode deleteNode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.AuthenticationKeys> GetAuthKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.AuthenticationKeys>> GetAuthKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.DatabaseMigration> GetMigrations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.DatabaseMigration> GetMigrationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData> GetMonitoringData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData>> GetMonitoringDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.RegenAuthKeys> RegenerateAuthKeys(Azure.ResourceManager.DataMigration.Models.RegenAuthKeys regenAuthKeys, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.RegenAuthKeys>> RegenerateAuthKeysAsync(Azure.ResourceManager.DataMigration.Models.RegenAuthKeys regenAuthKeys, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataMigration.Mock
{
    public partial class DataMigrationServiceResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected DataMigrationServiceResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse> CheckNameAvailabilityService(Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest nameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>> CheckNameAvailabilityServiceAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest nameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBCollection GetDatabaseMigrationSqlDBs() { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMICollection GetDatabaseMigrationSqlMIs() { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmCollection GetDatabaseMigrationSqlVms() { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationServiceCollection GetDataMigrationServices() { throw null; }
        public virtual Azure.ResourceManager.DataMigration.SqlMigrationServiceCollection GetSqlMigrationServices() { throw null; }
    }
    public partial class SqlMigrationServiceResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SqlMigrationServiceResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.ResourceSku> GetSkusResourceSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.ResourceSku> GetSkusResourceSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.Quota> GetUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.Quota> GetUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataMigration.Models
{
    public partial class AuthenticationKeys
    {
        internal AuthenticationKeys() { }
        public string AuthKey1 { get { throw null; } }
        public string AuthKey2 { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.AuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.AuthenticationType ActiveDirectoryIntegrated { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.AuthenticationType ActiveDirectoryPassword { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.AuthenticationType None { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.AuthenticationType SqlAuthentication { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.AuthenticationType WindowsAuthentication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.AuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.AuthenticationType left, Azure.ResourceManager.DataMigration.Models.AuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.AuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.AuthenticationType left, Azure.ResourceManager.DataMigration.Models.AuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailableServiceSku
    {
        internal AvailableServiceSku() { }
        public Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku Sku { get { throw null; } }
    }
    public partial class AvailableServiceSkuCapacity
    {
        internal AvailableServiceSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ServiceScalability? ScaleType { get { throw null; } }
    }
    public partial class AvailableServiceSkuSku
    {
        internal AvailableServiceSkuSku() { }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class AzureActiveDirectoryApp
    {
        public AzureActiveDirectoryApp() { }
        public string AppKey { get { throw null; } set { } }
        public string ApplicationId { get { throw null; } set { } }
        public bool? IgnoreAzurePermissions { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class AzureBlob
    {
        public AzureBlob() { }
        public string AccountKey { get { throw null; } set { } }
        public string BlobContainerName { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
    public partial class BackupConfiguration
    {
        public BackupConfiguration() { }
        public Azure.ResourceManager.DataMigration.Models.SourceLocation SourceLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.TargetLocation TargetLocation { get { throw null; } set { } }
    }
    public partial class BackupFileInfo
    {
        internal BackupFileInfo() { }
        public int? FamilySequenceNumber { get { throw null; } }
        public string FileLocation { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.BackupFileStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupFileStatus : System.IEquatable<Azure.ResourceManager.DataMigration.Models.BackupFileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupFileStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.BackupFileStatus Arrived { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupFileStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupFileStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupFileStatus Restored { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupFileStatus Restoring { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupFileStatus Uploaded { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupFileStatus Uploading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.BackupFileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.BackupFileStatus left, Azure.ResourceManager.DataMigration.Models.BackupFileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.BackupFileStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.BackupFileStatus left, Azure.ResourceManager.DataMigration.Models.BackupFileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupMode : System.IEquatable<Azure.ResourceManager.DataMigration.Models.BackupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupMode(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.BackupMode CreateBackup { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupMode ExistingBackup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.BackupMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.BackupMode left, Azure.ResourceManager.DataMigration.Models.BackupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.BackupMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.BackupMode left, Azure.ResourceManager.DataMigration.Models.BackupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupSetInfo
    {
        internal BackupSetInfo() { }
        public System.DateTimeOffset? BackupFinishedOn { get { throw null; } }
        public string BackupSetId { get { throw null; } }
        public System.DateTimeOffset? BackupStartOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.BackupType? BackupType { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public string FirstLsn { get { throw null; } }
        public bool? IsBackupRestored { get { throw null; } }
        public string LastLsn { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.BackupFileInfo> ListOfBackupFiles { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.BackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.BackupType Database { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupType DifferentialDatabase { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupType DifferentialFile { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupType DifferentialPartial { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupType File { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupType Partial { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.BackupType TransactionLog { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.BackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.BackupType left, Azure.ResourceManager.DataMigration.Models.BackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.BackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.BackupType left, Azure.ResourceManager.DataMigration.Models.BackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobShare
    {
        public BlobShare() { }
        public System.Uri SasUri { get { throw null; } set { } }
    }
    public partial class CheckOciDriverTaskOutput
    {
        internal CheckOciDriverTaskOutput() { }
        public Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo InstalledDriver { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class CheckOciDriverTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public CheckOciDriverTaskProperties() { }
        public string InputServerVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput> Output { get { throw null; } }
    }
    public abstract partial class CommandProperties
    {
        protected CommandProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ODataError> Errors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.CommandState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommandState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.CommandState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommandState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.CommandState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.CommandState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.CommandState Running { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.CommandState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.CommandState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.CommandState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.CommandState left, Azure.ResourceManager.DataMigration.Models.CommandState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.CommandState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.CommandState left, Azure.ResourceManager.DataMigration.Models.CommandState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ConnectionInfo
    {
        protected ConnectionInfo() { }
        public string Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class ConnectToMongoDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToMongoDBTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo> Output { get { throw null; } }
    }
    public partial class ConnectToSourceMySqlTaskInput
    {
        public ConnectToSourceMySqlTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo sourceConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.ServerLevelPermissionsGroup? CheckPermissionsGroup { get { throw null; } set { } }
        public bool? IsOfflineMigration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType? TargetPlatform { get { throw null; } set { } }
    }
    public partial class ConnectToSourceMySqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToSourceMySqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToSourceNonSqlTaskOutput
    {
        internal ConnectToSourceNonSqlTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ServerProperties ServerProperties { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToSourceOracleSyncTaskOutput
    {
        internal ConnectToSourceOracleSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToSourceOracleSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToSourceOracleSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo InputSourceConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToSourcePostgreSqlSyncTaskOutput
    {
        internal ConnectToSourcePostgreSqlSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToSourcePostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToSourcePostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo InputSourceConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToSourceSqlServerSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToSourceSqlServerSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToSourceSqlServerTaskInput
    {
        public ConnectToSourceSqlServerTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.ServerLevelPermissionsGroup? CheckPermissionsGroup { get { throw null; } set { } }
        public bool? CollectAgentJobs { get { throw null; } set { } }
        public bool? CollectDatabases { get { throw null; } set { } }
        public bool? CollectLogins { get { throw null; } set { } }
        public bool? CollectTdeCertificateInfo { get { throw null; } set { } }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public bool? ValidateSsisCatalogOnly { get { throw null; } set { } }
    }
    public abstract partial class ConnectToSourceSqlServerTaskOutput
    {
        protected ConnectToSourceSqlServerTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class ConnectToSourceSqlServerTaskOutputAgentJobLevel : Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput
    {
        internal ConnectToSourceSqlServerTaskOutputAgentJobLevel() { }
        public bool? IsEnabled { get { throw null; } }
        public string JobCategory { get { throw null; } }
        public string JobOwner { get { throw null; } }
        public System.DateTimeOffset? LastExecutedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo MigrationEligibility { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToSourceSqlServerTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput
    {
        internal ConnectToSourceSqlServerTaskOutputDatabaseLevel() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel? CompatibilityLevel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo> DatabaseFiles { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseState? DatabaseState { get { throw null; } }
        public string Name { get { throw null; } }
        public double? SizeMB { get { throw null; } }
    }
    public partial class ConnectToSourceSqlServerTaskOutputLoginLevel : Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput
    {
        internal ConnectToSourceSqlServerTaskOutputLoginLevel() { }
        public string DefaultDatabase { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.LoginType? LoginType { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo MigrationEligibility { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ConnectToSourceSqlServerTaskOutputTaskLevel : Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput
    {
        internal ConnectToSourceSqlServerTaskOutputTaskLevel() { }
        public string AgentJobs { get { throw null; } }
        public string Databases { get { throw null; } }
        public string DatabaseTdeCertificateMapping { get { throw null; } }
        public string Logins { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToSourceSqlServerTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToSourceSqlServerTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class ConnectToTargetAzureDBForMySqlTaskInput
    {
        public ConnectToTargetAzureDBForMySqlTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo targetConnectionInfo) { }
        public bool? IsOfflineMigration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public partial class ConnectToTargetAzureDBForMySqlTaskOutput
    {
        internal ConnectToTargetAzureDBForMySqlTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public string ServerVersion { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToTargetAzureDBForMySqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToTargetAzureDBForMySqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToTargetAzureDBForPostgreSqlSyncTaskInput
    {
        public ConnectToTargetAzureDBForPostgreSqlSyncTaskInput(Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo targetConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public partial class ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput
    {
        internal ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput
    {
        internal ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem> DatabaseSchemaMap { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem
    {
        internal ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem() { }
        public string Database { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Schemas { get { throw null; } }
    }
    public partial class ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo InputTargetConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToTargetSqlDBSyncTaskInput
    {
        public ConnectToTargetSqlDBSyncTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public partial class ConnectToTargetSqlDBSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToTargetSqlDBSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToTargetSqlDBTaskInput
    {
        public ConnectToTargetSqlDBTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo) { }
        public bool? QueryObjectCounts { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public partial class ConnectToTargetSqlDBTaskOutput
    {
        internal ConnectToTargetSqlDBTaskOutput() { }
        public string Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class ConnectToTargetSqlDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToTargetSqlDBTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToTargetSqlMISyncTaskInput
    {
        public ConnectToTargetSqlMISyncTaskInput(Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp azureApp) { }
        public Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp AzureApp { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public partial class ConnectToTargetSqlMISyncTaskOutput
    {
        internal ConnectToTargetSqlMISyncTaskOutput() { }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToTargetSqlMISyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToTargetSqlMISyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput> Output { get { throw null; } }
    }
    public partial class ConnectToTargetSqlMITaskInput
    {
        public ConnectToTargetSqlMITaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo) { }
        public bool? CollectAgentJobs { get { throw null; } set { } }
        public bool? CollectLogins { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        public bool? ValidateSsisCatalogOnly { get { throw null; } set { } }
    }
    public partial class ConnectToTargetSqlMITaskOutput
    {
        internal ConnectToTargetSqlMITaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> AgentJobs { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Logins { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ConnectToTargetSqlMITaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ConnectToTargetSqlMITaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput> Output { get { throw null; } }
    }
    public partial class CopyProgressDetails
    {
        internal CopyProgressDetails() { }
        public int? CopyDuration { get { throw null; } }
        public System.DateTimeOffset? CopyStart { get { throw null; } }
        public double? CopyThroughput { get { throw null; } }
        public long? DataRead { get { throw null; } }
        public long? DataWritten { get { throw null; } }
        public string ParallelCopyType { get { throw null; } }
        public long? RowsCopied { get { throw null; } }
        public long? RowsRead { get { throw null; } }
        public string Status { get { throw null; } }
        public string TableName { get { throw null; } }
        public int? UsedParallelCopies { get { throw null; } }
    }
    public partial class DatabaseBackupInfo
    {
        internal DatabaseBackupInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> BackupFiles { get { throw null; } }
        public System.DateTimeOffset? BackupFinishOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.BackupType? BackupType { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public int? FamilyCount { get { throw null; } }
        public bool? IsCompressed { get { throw null; } }
        public bool? IsDamaged { get { throw null; } }
        public int? Position { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseCompatLevel : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseCompatLevel(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel CompatLevel100 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel CompatLevel110 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel CompatLevel120 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel CompatLevel130 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel CompatLevel140 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel CompatLevel80 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel CompatLevel90 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel left, Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel left, Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseFileInfo
    {
        internal DatabaseFileInfo() { }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseFileType? FileType { get { throw null; } }
        public string Id { get { throw null; } }
        public string LogicalName { get { throw null; } }
        public string PhysicalFullName { get { throw null; } }
        public string RestoreFullName { get { throw null; } }
        public double? SizeMB { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseFileType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DatabaseFileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseFileType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseFileType Filestream { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseFileType Fulltext { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseFileType Log { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseFileType NotSupported { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseFileType Rows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DatabaseFileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DatabaseFileType left, Azure.ResourceManager.DataMigration.Models.DatabaseFileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DatabaseFileType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DatabaseFileType left, Azure.ResourceManager.DataMigration.Models.DatabaseFileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseInfo
    {
        public DatabaseInfo(string sourceDatabaseName) { }
        public string SourceDatabaseName { get { throw null; } set { } }
    }
    public partial class DatabaseMigration : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseMigration() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties Properties { get { throw null; } set { } }
    }
    public abstract partial class DatabaseMigrationProperties
    {
        protected DatabaseMigrationProperties() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ErrorInfo MigrationFailureError { get { throw null; } }
        public string MigrationOperationId { get { throw null; } set { } }
        public string MigrationService { get { throw null; } set { } }
        public string MigrationStatus { get { throw null; } }
        public string ProvisioningError { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public string SourceDatabaseName { get { throw null; } set { } }
        public string SourceServerName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation SourceSqlConnection { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string TargetDatabaseCollation { get { throw null; } set { } }
    }
    public partial class DatabaseMigrationSqlDBProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties
    {
        public DatabaseMigrationSqlDBProperties() { }
        public Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails MigrationStatusDetails { get { throw null; } }
        public bool? Offline { get { throw null; } }
        public System.Collections.Generic.IList<string> TableList { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation TargetSqlConnection { get { throw null; } set { } }
    }
    public partial class DatabaseMigrationSqlMIProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties
    {
        public DatabaseMigrationSqlMIProperties() { }
        public Azure.ResourceManager.DataMigration.Models.BackupConfiguration BackupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails MigrationStatusDetails { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.OfflineConfiguration OfflineConfiguration { get { throw null; } set { } }
    }
    public partial class DatabaseMigrationSqlVmProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties
    {
        public DatabaseMigrationSqlVmProperties() { }
        public Azure.ResourceManager.DataMigration.Models.BackupConfiguration BackupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails MigrationStatusDetails { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.OfflineConfiguration OfflineConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseMigrationStage : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseMigrationStage(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage Backup { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage FileCopy { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage Initialize { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage None { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage left, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage left, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseMigrationState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState CutoverStart { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState FullBackupUploadStart { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState Initial { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState LOGShippingStart { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState PostCutoverComplete { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState Undefined { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState UploadLOGFilesStart { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState left, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState left, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DatabaseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseState Copying { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseState Emergency { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseState Offline { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseState OfflineSecondary { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseState Online { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseState Recovering { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseState RecoveryPending { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseState Restoring { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseState Suspect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DatabaseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DatabaseState left, Azure.ResourceManager.DataMigration.Models.DatabaseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DatabaseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DatabaseState left, Azure.ResourceManager.DataMigration.Models.DatabaseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseTable
    {
        internal DatabaseTable() { }
        public bool? HasRows { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class DataIntegrityValidationResult
    {
        internal DataIntegrityValidationResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FailedObjects { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationError ValidationErrors { get { throw null; } }
    }
    public partial class DataMigrationServiceStatusResponse
    {
        internal DataMigrationServiceStatusResponse() { }
        public System.BinaryData AgentConfiguration { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedTaskTypes { get { throw null; } }
        public string VmSize { get { throw null; } }
    }
    public partial class DeleteNode
    {
        public DeleteNode() { }
        public string IntegrationRuntimeName { get { throw null; } set { } }
        public string NodeName { get { throw null; } set { } }
    }
    public partial class ErrorInfo
    {
        internal ErrorInfo() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ExecutionStatistics
    {
        internal ExecutionStatistics() { }
        public float? CpuTimeMs { get { throw null; } }
        public float? ElapsedTimeMs { get { throw null; } }
        public long? ExecutionCount { get { throw null; } }
        public bool? HasErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.WaitStatistics> WaitStats { get { throw null; } }
    }
    public partial class FileShare
    {
        public FileShare(string path) { }
        public string Password { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class FileStorageInfo
    {
        internal FileStorageInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class GetTdeCertificatesSqlTaskInput
    {
        public GetTdeCertificatesSqlTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo connectionInfo, Azure.ResourceManager.DataMigration.Models.FileShare backupFileShare, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput> selectedCertificates) { }
        public Azure.ResourceManager.DataMigration.Models.FileShare BackupFileShare { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput> SelectedCertificates { get { throw null; } }
    }
    public partial class GetTdeCertificatesSqlTaskOutput
    {
        internal GetTdeCertificatesSqlTaskOutput() { }
        public string Base64EncodedCertificates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class GetTdeCertificatesSqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public GetTdeCertificatesSqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput> Output { get { throw null; } }
    }
    public partial class GetUserTablesMySqlTaskInput
    {
        public GetUserTablesMySqlTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedDatabases) { }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedDatabases { get { throw null; } }
    }
    public partial class GetUserTablesMySqlTaskOutput
    {
        internal GetUserTablesMySqlTaskOutput() { }
        public string DatabasesToTables { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class GetUserTablesMySqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public GetUserTablesMySqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput> Output { get { throw null; } }
    }
    public partial class GetUserTablesOracleTaskInput
    {
        public GetUserTablesOracleTaskInput(Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedSchemas) { }
        public Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedSchemas { get { throw null; } }
    }
    public partial class GetUserTablesOracleTaskOutput
    {
        internal GetUserTablesOracleTaskOutput() { }
        public string SchemaName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DatabaseTable> Tables { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class GetUserTablesOracleTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public GetUserTablesOracleTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput> Output { get { throw null; } }
    }
    public partial class GetUserTablesPostgreSqlTaskInput
    {
        public GetUserTablesPostgreSqlTaskInput(Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedDatabases) { }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedDatabases { get { throw null; } }
    }
    public partial class GetUserTablesPostgreSqlTaskOutput
    {
        internal GetUserTablesPostgreSqlTaskOutput() { }
        public string DatabaseName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DatabaseTable> Tables { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class GetUserTablesPostgreSqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public GetUserTablesPostgreSqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput> Output { get { throw null; } }
    }
    public partial class GetUserTablesSqlSyncTaskInput
    {
        public GetUserTablesSqlSyncTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<string> selectedSourceDatabases, System.Collections.Generic.IEnumerable<string> selectedTargetDatabases) { }
        public System.Collections.Generic.IList<string> SelectedSourceDatabases { get { throw null; } }
        public System.Collections.Generic.IList<string> SelectedTargetDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public partial class GetUserTablesSqlSyncTaskOutput
    {
        internal GetUserTablesSqlSyncTaskOutput() { }
        public string DatabasesToSourceTables { get { throw null; } }
        public string DatabasesToTargetTables { get { throw null; } }
        public string TableValidationErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class GetUserTablesSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public GetUserTablesSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput> Output { get { throw null; } }
    }
    public partial class GetUserTablesSqlTaskInput
    {
        public GetUserTablesSqlTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedDatabases) { }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedDatabases { get { throw null; } }
    }
    public partial class GetUserTablesSqlTaskOutput
    {
        internal GetUserTablesSqlTaskOutput() { }
        public string DatabasesToTables { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class GetUserTablesSqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public GetUserTablesSqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class InstallOciDriverTaskOutput
    {
        internal InstallOciDriverTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class InstallOciDriverTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public InstallOciDriverTaskProperties() { }
        public string InputDriverPackageName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput> Output { get { throw null; } }
    }
    public partial class IntegrationRuntimeMonitoringData
    {
        internal IntegrationRuntimeMonitoringData() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData> Nodes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoginMigrationStage : System.IEquatable<Azure.ResourceManager.DataMigration.Models.LoginMigrationStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoginMigrationStage(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.LoginMigrationStage AssignRoleMembership { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginMigrationStage AssignRoleOwnership { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginMigrationStage Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginMigrationStage EstablishObjectPermissions { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginMigrationStage EstablishServerPermissions { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginMigrationStage EstablishUserMapping { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginMigrationStage Initialize { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginMigrationStage LoginMigration { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginMigrationStage None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.LoginMigrationStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.LoginMigrationStage left, Azure.ResourceManager.DataMigration.Models.LoginMigrationStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.LoginMigrationStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.LoginMigrationStage left, Azure.ResourceManager.DataMigration.Models.LoginMigrationStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoginType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.LoginType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoginType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.LoginType AsymmetricKey { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginType Certificate { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginType ExternalGroup { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginType ExternalUser { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginType SqlLogin { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginType WindowsGroup { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.LoginType WindowsUser { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.LoginType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.LoginType left, Azure.ResourceManager.DataMigration.Models.LoginType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.LoginType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.LoginType left, Azure.ResourceManager.DataMigration.Models.LoginType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateMISyncCompleteCommandProperties : Azure.ResourceManager.DataMigration.Models.CommandProperties
    {
        public MigrateMISyncCompleteCommandProperties() { }
        public string InputSourceDatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> OutputErrors { get { throw null; } }
    }
    public partial class MigrateMongoDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateMongoDBTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBProgress> Output { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineDatabaseInput
    {
        public MigrateMySqlAzureDBForMySqlOfflineDatabaseInput() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TableMap { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskInput
    {
        public MigrateMySqlAzureDBForMySqlOfflineTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput> selectedDatabases) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public bool? MakeSourceServerReadOnly { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> OptionalAgentSettings { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public abstract partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutput
    {
        protected MigrateMySqlAzureDBForMySqlOfflineTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput
    {
        internal MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel() { }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public long? ErrorCount { get { throw null; } }
        public string ErrorPrefix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public System.DateTimeOffset? LastStorageUpdate { get { throw null; } }
        public string Message { get { throw null; } }
        public long? NumberOfObjects { get { throw null; } }
        public long? NumberOfObjectsCompleted { get { throw null; } }
        public string ObjectSummary { get { throw null; } }
        public string ResultPrefix { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput
    {
        internal MigrateMySqlAzureDBForMySqlOfflineTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput
    {
        internal MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel() { }
        public string Databases { get { throw null; } }
        public string DatabaseSummary { get { throw null; } }
        public long? DurationInSeconds { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public System.DateTimeOffset? LastStorageUpdate { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationReportResult MigrationReportResult { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput
    {
        internal MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string ErrorPrefix { get { throw null; } }
        public long? ItemsCompletedCount { get { throw null; } }
        public long? ItemsCount { get { throw null; } }
        public System.DateTimeOffset? LastStorageUpdate { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ResultPrefix { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateMySqlAzureDBForMySqlOfflineTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncDatabaseInput
    {
        public MigrateMySqlAzureDBForMySqlSyncDatabaseInput() { }
        public System.Collections.Generic.IDictionary<string, string> MigrationSetting { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SourceSetting { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TableMap { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetSetting { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskInput
    {
        public MigrateMySqlAzureDBForMySqlSyncTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput> selectedDatabases) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public abstract partial class MigrateMySqlAzureDBForMySqlSyncTaskOutput
    {
        protected MigrateMySqlAzureDBForMySqlSyncTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput
    {
        internal MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput
    {
        internal MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel() { }
        public long? AppliedChanges { get { throw null; } }
        public long? CdcDeleteCounter { get { throw null; } }
        public long? CdcInsertCounter { get { throw null; } }
        public long? CdcUpdateCounter { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public long? FullLoadCompletedTables { get { throw null; } }
        public long? FullLoadErroredTables { get { throw null; } }
        public long? FullLoadLoadingTables { get { throw null; } }
        public long? FullLoadQueuedTables { get { throw null; } }
        public long? IncomingChanges { get { throw null; } }
        public bool? InitializationCompleted { get { throw null; } }
        public long? Latency { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput
    {
        internal MigrateMySqlAzureDBForMySqlSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput
    {
        internal MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServer { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string TargetServer { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput
    {
        internal MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel() { }
        public string CdcDeleteCounter { get { throw null; } }
        public string CdcInsertCounter { get { throw null; } }
        public string CdcUpdateCounter { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public long? DataErrorsCounter { get { throw null; } }
        public System.DateTimeOffset? FullLoadEndedOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadEstFinishOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadStartedOn { get { throw null; } }
        public long? FullLoadTotalRows { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? State { get { throw null; } }
        public string TableName { get { throw null; } }
        public long? TotalChangesApplied { get { throw null; } }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateMySqlAzureDBForMySqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput> Output { get { throw null; } }
    }
    public partial class MigrateOracleAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateOracleAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput> Output { get { throw null; } }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncDatabaseInput
    {
        public MigrateOracleAzureDBPostgreSqlSyncDatabaseInput() { }
        public string CaseManipulation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> MigrationSetting { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SourceSetting { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TableMap { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetSetting { get { throw null; } }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskInput
    {
        public MigrateOracleAzureDBPostgreSqlSyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo sourceConnectionInfo) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public abstract partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutput
    {
        protected MigrateOracleAzureDBPostgreSqlSyncTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput
    {
        internal MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput
    {
        internal MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel() { }
        public long? AppliedChanges { get { throw null; } }
        public long? CdcDeleteCounter { get { throw null; } }
        public long? CdcInsertCounter { get { throw null; } }
        public long? CdcUpdateCounter { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public long? FullLoadCompletedTables { get { throw null; } }
        public long? FullLoadErroredTables { get { throw null; } }
        public long? FullLoadLoadingTables { get { throw null; } }
        public long? FullLoadQueuedTables { get { throw null; } }
        public long? IncomingChanges { get { throw null; } }
        public bool? InitializationCompleted { get { throw null; } }
        public long? Latency { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput
    {
        internal MigrateOracleAzureDBPostgreSqlSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput
    {
        internal MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServer { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string TargetServer { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput
    {
        internal MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel() { }
        public long? CdcDeleteCounter { get { throw null; } }
        public long? CdcInsertCounter { get { throw null; } }
        public long? CdcUpdateCounter { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public long? DataErrorsCounter { get { throw null; } }
        public System.DateTimeOffset? FullLoadEndedOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadEstFinishOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadStartedOn { get { throw null; } }
        public long? FullLoadTotalRows { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? State { get { throw null; } }
        public string TableName { get { throw null; } }
        public long? TotalChangesApplied { get { throw null; } }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> MigrationSetting { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput> SelectedTables { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> SourceSetting { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetSetting { get { throw null; } }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo sourceConnectionInfo) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public abstract partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput
    {
        protected MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput
    {
        internal MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput
    {
        internal MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel() { }
        public long? AppliedChanges { get { throw null; } }
        public long? CdcDeleteCounter { get { throw null; } }
        public long? CdcInsertCounter { get { throw null; } }
        public long? CdcUpdateCounter { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public long? FullLoadCompletedTables { get { throw null; } }
        public long? FullLoadErroredTables { get { throw null; } }
        public long? FullLoadLoadingTables { get { throw null; } }
        public long? FullLoadQueuedTables { get { throw null; } }
        public long? IncomingChanges { get { throw null; } }
        public bool? InitializationCompleted { get { throw null; } }
        public long? Latency { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput
    {
        internal MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput
    {
        internal MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel() { }
        public float? DatabaseCount { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServer { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ScenarioSource? SourceServerType { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState? State { get { throw null; } }
        public string TargetServer { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ScenarioTarget? TargetServerType { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput
    {
        internal MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel() { }
        public long? CdcDeleteCounter { get { throw null; } }
        public long? CdcInsertCounter { get { throw null; } }
        public long? CdcUpdateCounter { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public long? DataErrorsCounter { get { throw null; } }
        public System.DateTimeOffset? FullLoadEndedOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadEstFinishOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadStartedOn { get { throw null; } }
        public long? FullLoadTotalRows { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? State { get { throw null; } }
        public string TableName { get { throw null; } }
        public long? TotalChangesApplied { get { throw null; } }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class MigrateSchemaSqlServerSqlDBDatabaseInput
    {
        public MigrateSchemaSqlServerSqlDBDatabaseInput() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting SchemaSetting { get { throw null; } set { } }
        public string TargetDatabaseName { get { throw null; } set { } }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput
    {
        public MigrateSchemaSqlServerSqlDBTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput> selectedDatabases) : base (default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo)) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput> SelectedDatabases { get { throw null; } }
        public string StartedOn { get { throw null; } set { } }
    }
    public abstract partial class MigrateSchemaSqlServerSqlDBTaskOutput
    {
        protected MigrateSchemaSqlServerSqlDBTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput
    {
        internal MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel() { }
        public string DatabaseErrorResultPrefix { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string FileId { get { throw null; } }
        public long? NumberOfFailedOperations { get { throw null; } }
        public long? NumberOfSuccessfulOperations { get { throw null; } }
        public string SchemaErrorResultPrefix { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput
    {
        internal MigrateSchemaSqlServerSqlDBTaskOutputError() { }
        public string CommandText { get { throw null; } }
        public string ErrorText { get { throw null; } }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput
    {
        internal MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateSchemaSqlServerSqlDBTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class MigrateSchemaSqlTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput
    {
        internal MigrateSchemaSqlTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBDatabaseInput
    {
        public MigrateSqlServerSqlDBDatabaseInput() { }
        public string Id { get { throw null; } set { } }
        public bool? MakeSourceDBReadOnly { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData SchemaSetting { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TableMap { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
    }
    public partial class MigrateSqlServerSqlDBSyncDatabaseInput
    {
        public MigrateSqlServerSqlDBSyncDatabaseInput() { }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> MigrationSetting { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SourceSetting { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TableMap { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetSetting { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput
    {
        public MigrateSqlServerSqlDBSyncTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> selectedDatabases) : base (default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions ValidationOptions { get { throw null; } set { } }
    }
    public abstract partial class MigrateSqlServerSqlDBSyncTaskOutput
    {
        protected MigrateSqlServerSqlDBSyncTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputDatabaseError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput
    {
        internal MigrateSqlServerSqlDBSyncTaskOutputDatabaseError() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput
    {
        internal MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel() { }
        public long? AppliedChanges { get { throw null; } }
        public long? CdcDeleteCounter { get { throw null; } }
        public long? CdcInsertCounter { get { throw null; } }
        public long? CdcUpdateCounter { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public long? FullLoadCompletedTables { get { throw null; } }
        public long? FullLoadErroredTables { get { throw null; } }
        public long? FullLoadLoadingTables { get { throw null; } }
        public long? FullLoadQueuedTables { get { throw null; } }
        public long? IncomingChanges { get { throw null; } }
        public bool? InitializationCompleted { get { throw null; } }
        public long? Latency { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput
    {
        internal MigrateSqlServerSqlDBSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput
    {
        internal MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel() { }
        public int? DatabaseCount { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServer { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string TargetServer { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput
    {
        internal MigrateSqlServerSqlDBSyncTaskOutputTableLevel() { }
        public long? CdcDeleteCounter { get { throw null; } }
        public long? CdcInsertCounter { get { throw null; } }
        public long? CdcUpdateCounter { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public long? DataErrorsCounter { get { throw null; } }
        public System.DateTimeOffset? FullLoadEndedOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadEstFinishOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadStartedOn { get { throw null; } }
        public long? FullLoadTotalRows { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? State { get { throw null; } }
        public string TableName { get { throw null; } }
        public long? TotalChangesApplied { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateSqlServerSqlDBSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput> Output { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput
    {
        public MigrateSqlServerSqlDBTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput> selectedDatabases) : base (default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo)) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput> SelectedDatabases { get { throw null; } }
        public string StartedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions ValidationOptions { get { throw null; } set { } }
    }
    public abstract partial class MigrateSqlServerSqlDBTaskOutput
    {
        protected MigrateSqlServerSqlDBTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput
    {
        internal MigrateSqlServerSqlDBTaskOutputDatabaseLevel() { }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public long? ErrorCount { get { throw null; } }
        public string ErrorPrefix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Message { get { throw null; } }
        public long? NumberOfObjects { get { throw null; } }
        public long? NumberOfObjectsCompleted { get { throw null; } }
        public string ObjectSummary { get { throw null; } }
        public string ResultPrefix { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput
    {
        internal MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult() { }
        public Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult DataIntegrityValidationResult { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string MigrationId { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult QueryAnalysisValidationResult { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult SchemaValidationResult { get { throw null; } }
        public string SourceDatabaseName { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationStatus? Status { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput
    {
        internal MigrateSqlServerSqlDBTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput
    {
        internal MigrateSqlServerSqlDBTaskOutputMigrationLevel() { }
        public string Databases { get { throw null; } }
        public string DatabaseSummary { get { throw null; } }
        public long? DurationInSeconds { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationReportResult MigrationReportResult { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationResult MigrationValidationResult { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput
    {
        internal MigrateSqlServerSqlDBTaskOutputTableLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string ErrorPrefix { get { throw null; } }
        public long? ItemsCompletedCount { get { throw null; } }
        public long? ItemsCount { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ResultPrefix { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputValidationResult : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput
    {
        internal MigrateSqlServerSqlDBTaskOutputValidationResult() { }
        public string MigrationId { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> SummaryResults { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateSqlServerSqlDBTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class MigrateSqlServerSqlMIDatabaseInput
    {
        public MigrateSqlServerSqlMIDatabaseInput(string name, string restoreDatabaseName) { }
        public System.Collections.Generic.IList<string> BackupFilePaths { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.FileShare BackupFileShare { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string RestoreDatabaseName { get { throw null; } set { } }
    }
    public partial class MigrateSqlServerSqlMISyncTaskInput : Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput
    {
        public MigrateSqlServerSqlMISyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, string storageResourceId, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp azureApp) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>), default(string), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp)) { }
        public float? NumberOfParallelDatabaseMigrations { get { throw null; } set { } }
    }
    public abstract partial class MigrateSqlServerSqlMISyncTaskOutput
    {
        protected MigrateSqlServerSqlMISyncTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput
    {
        internal MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.BackupSetInfo> ActiveBackupSets { get { throw null; } }
        public string ContainerName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string ErrorPrefix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.BackupSetInfo FullBackupSetInfo { get { throw null; } }
        public bool? IsFullBackupRestored { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.BackupSetInfo LastRestoredBackupSetInfo { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState? MigrationState { get { throw null; } }
        public string SourceDatabaseName { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMISyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput
    {
        internal MigrateSqlServerSqlMISyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMISyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput
    {
        internal MigrateSqlServerSqlMISyncTaskOutputMigrationLevel() { }
        public int? DatabaseCount { get { throw null; } }
        public int? DatabaseErrorCount { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerName { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerName { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMISyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateSqlServerSqlMISyncTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput> Output { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMITaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput
    {
        public MigrateSqlServerSqlMITaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.BlobShare backupBlobShare) : base (default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo)) { }
        public string AadDomainName { get { throw null; } set { } }
        public System.Uri BackupBlobShareSasUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.FileShare BackupFileShare { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.BackupMode? BackupMode { get { throw null; } set { } }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedAgentJobs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> SelectedDatabases { get { throw null; } }
        public System.Collections.Generic.IList<string> SelectedLogins { get { throw null; } }
        public string StartedOn { get { throw null; } set { } }
    }
    public abstract partial class MigrateSqlServerSqlMITaskOutput
    {
        protected MigrateSqlServerSqlMITaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMITaskOutputAgentJobLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput
    {
        internal MigrateSqlServerSqlMITaskOutputAgentJobLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMITaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput
    {
        internal MigrateSqlServerSqlMITaskOutputDatabaseLevel() { }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Message { get { throw null; } }
        public double? SizeMB { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMITaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput
    {
        internal MigrateSqlServerSqlMITaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMITaskOutputLoginLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput
    {
        internal MigrateSqlServerSqlMITaskOutputLoginLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string LoginName { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.LoginMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMITaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput
    {
        internal MigrateSqlServerSqlMITaskOutputMigrationLevel() { }
        public string AgentJobs { get { throw null; } }
        public string Databases { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Logins { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo> OrphanedUsersInfo { get { throw null; } }
        public string ServerRoleResults { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationStatus? Status { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigrateSqlServerSqlMITaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateSqlServerSqlMITaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput> Output { get { throw null; } }
        public string ParentTaskId { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class MigrateSsisTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput
    {
        public MigrateSsisTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo ssisMigrationInfo) : base (default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo)) { }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo SsisMigrationInfo { get { throw null; } set { } }
    }
    public abstract partial class MigrateSsisTaskOutput
    {
        protected MigrateSsisTaskOutput() { }
        public string Id { get { throw null; } }
    }
    public partial class MigrateSsisTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput
    {
        internal MigrateSsisTaskOutputMigrationLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Message { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationStatus? Status { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
    }
    public partial class MigrateSsisTaskOutputProjectLevel : Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput
    {
        internal MigrateSsisTaskOutputProjectLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string FolderName { get { throw null; } }
        public string Message { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
    }
    public partial class MigrateSsisTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public MigrateSsisTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput> Output { get { throw null; } }
    }
    public partial class MigrateSyncCompleteCommandInput
    {
        public MigrateSyncCompleteCommandInput(string databaseName) { }
        public System.DateTimeOffset? CommitTimeStamp { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
    }
    public partial class MigrateSyncCompleteCommandOutput
    {
        internal MigrateSyncCompleteCommandOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> Errors { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class MigrateSyncCompleteCommandProperties : Azure.ResourceManager.DataMigration.Models.CommandProperties
    {
        public MigrateSyncCompleteCommandProperties() { }
        public string CommandId { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput Input { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput Output { get { throw null; } }
    }
    public partial class MigrationEligibilityInfo
    {
        internal MigrationEligibilityInfo() { }
        public bool? IsEligibleForMigration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ValidationMessages { get { throw null; } }
    }
    public partial class MigrationOperationInput
    {
        public MigrationOperationInput() { }
        public System.Guid? MigrationOperationId { get { throw null; } set { } }
    }
    public partial class MigrationReportResult
    {
        internal MigrationReportResult() { }
        public string Id { get { throw null; } }
        public System.Uri ReportUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationState Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationState None { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationState Skipped { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationState Stopped { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MigrationState left, Azure.ResourceManager.DataMigration.Models.MigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MigrationState left, Azure.ResourceManager.DataMigration.Models.MigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationStatus : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MigrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus Configured { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus Connecting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus Default { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus Error { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus SelectLogins { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus SourceAndTargetSelected { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MigrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MigrationStatus left, Azure.ResourceManager.DataMigration.Models.MigrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MigrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MigrationStatus left, Azure.ResourceManager.DataMigration.Models.MigrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationStatusDetails
    {
        internal MigrationStatusDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo> ActiveBackupSets { get { throw null; } }
        public string BlobContainerName { get { throw null; } }
        public string CompleteRestoreErrorMessage { get { throw null; } }
        public string CurrentRestoringFilename { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileUploadBlockingErrors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo FullBackupSetInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InvalidFiles { get { throw null; } }
        public bool? IsFullBackupRestored { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo LastRestoredBackupSetInfo { get { throw null; } }
        public string LastRestoredFilename { get { throw null; } }
        public string MigrationState { get { throw null; } }
        public int? PendingLogBackupsCount { get { throw null; } }
        public string RestoreBlockingReason { get { throw null; } }
    }
    public partial class MigrationValidationDatabaseSummaryResult
    {
        internal MigrationValidationDatabaseSummaryResult() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string MigrationId { get { throw null; } }
        public string SourceDatabaseName { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationStatus? Status { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } }
    }
    public partial class MigrationValidationOptions
    {
        public MigrationValidationOptions() { }
        public bool? EnableDataIntegrityValidation { get { throw null; } set { } }
        public bool? EnableQueryAnalysisValidation { get { throw null; } set { } }
        public bool? EnableSchemaValidation { get { throw null; } set { } }
    }
    public partial class MigrationValidationResult
    {
        internal MigrationValidationResult() { }
        public string Id { get { throw null; } }
        public string MigrationId { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> SummaryResults { get { throw null; } }
    }
    public partial class MISqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo
    {
        public MISqlConnectionInfo(string managedInstanceResourceId) { }
        public string ManagedInstanceResourceId { get { throw null; } set { } }
    }
    public partial class MongoDBCancelCommand : Azure.ResourceManager.DataMigration.Models.CommandProperties
    {
        public MongoDBCancelCommand() { }
        public string InputObjectName { get { throw null; } set { } }
    }
    public partial class MongoDBClusterInfo
    {
        internal MongoDBClusterInfo() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBClusterType ClusterType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo> Databases { get { throw null; } }
        public bool SupportsSharding { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDBClusterType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MongoDBClusterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDBClusterType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBClusterType BlobContainer { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBClusterType CosmosDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBClusterType MongoDB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MongoDBClusterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MongoDBClusterType left, Azure.ResourceManager.DataMigration.Models.MongoDBClusterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MongoDBClusterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MongoDBClusterType left, Azure.ResourceManager.DataMigration.Models.MongoDBClusterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBCollectionInfo : Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo
    {
        internal MongoDBCollectionInfo() { }
        public string DatabaseName { get { throw null; } }
        public bool IsCapped { get { throw null; } }
        public bool IsSystemCollection { get { throw null; } }
        public bool IsView { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo ShardKey { get { throw null; } }
        public bool SupportsSharding { get { throw null; } }
        public string ViewOf { get { throw null; } }
    }
    public partial class MongoDBCollectionProgress : Azure.ResourceManager.DataMigration.Models.MongoDBProgress
    {
        internal MongoDBCollectionProgress() : base (default(long), default(long), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError>), default(long), default(long), default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), default(long), default(long)) { }
    }
    public partial class MongoDBCollectionSettings
    {
        public MongoDBCollectionSettings() { }
        public bool? CanDelete { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting ShardKey { get { throw null; } set { } }
        public int? TargetRUs { get { throw null; } set { } }
    }
    public partial class MongoDBCommandInput
    {
        public MongoDBCommandInput() { }
        public string ObjectName { get { throw null; } set { } }
    }
    public partial class MongoDBConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo
    {
        public MongoDBConnectionInfo(string connectionString) { }
        public string AdditionalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.AuthenticationType? Authentication { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public bool? EncryptConnection { get { throw null; } set { } }
        public bool? EnforceSSL { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ServerBrandVersion { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public bool? TrustServerCertificate { get { throw null; } set { } }
    }
    public partial class MongoDBDatabaseInfo : Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo
    {
        internal MongoDBDatabaseInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo> Collections { get { throw null; } }
        public bool SupportsSharding { get { throw null; } }
    }
    public partial class MongoDBDatabaseProgress : Azure.ResourceManager.DataMigration.Models.MongoDBProgress
    {
        internal MongoDBDatabaseProgress() : base (default(long), default(long), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError>), default(long), default(long), default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), default(long), default(long)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress> Collections { get { throw null; } }
    }
    public partial class MongoDBDatabaseSettings
    {
        public MongoDBDatabaseSettings(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings> collections) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings> Collections { get { throw null; } }
        public int? TargetRUs { get { throw null; } set { } }
    }
    public partial class MongoDBError
    {
        internal MongoDBError() { }
        public string Code { get { throw null; } }
        public int? Count { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBErrorType? ErrorType { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDBErrorType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MongoDBErrorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDBErrorType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBErrorType Error { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBErrorType ValidationError { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBErrorType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MongoDBErrorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MongoDBErrorType left, Azure.ResourceManager.DataMigration.Models.MongoDBErrorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MongoDBErrorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MongoDBErrorType left, Azure.ResourceManager.DataMigration.Models.MongoDBErrorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBFinishCommand : Azure.ResourceManager.DataMigration.Models.CommandProperties
    {
        public MongoDBFinishCommand() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput Input { get { throw null; } set { } }
    }
    public partial class MongoDBFinishCommandInput : Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput
    {
        public MongoDBFinishCommandInput(bool immediate) { }
        public bool Immediate { get { throw null; } set { } }
    }
    public partial class MongoDBMigrationProgress : Azure.ResourceManager.DataMigration.Models.MongoDBProgress
    {
        internal MongoDBMigrationProgress() : base (default(long), default(long), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError>), default(long), default(long), default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), default(long), default(long)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress> Databases { get { throw null; } }
    }
    public partial class MongoDBMigrationSettings
    {
        public MongoDBMigrationSettings(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings> databases, Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo source, Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo target) { }
        public int? BoostRUs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings> Databases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBReplication? Replication { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo Source { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo Target { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings Throttling { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDBMigrationState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDBMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState Complete { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState Copying { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState Finalizing { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState Initializing { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState InitialReplay { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState Replaying { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState Restarting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState ValidatingInput { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState left, Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState left, Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBObjectInfo
    {
        internal MongoDBObjectInfo() { }
        public long AverageDocumentSize { get { throw null; } }
        public long DataSize { get { throw null; } }
        public long DocumentCount { get { throw null; } }
        public string Name { get { throw null; } }
        public string QualifiedName { get { throw null; } }
    }
    public abstract partial class MongoDBProgress
    {
        protected MongoDBProgress(long bytesCopied, long documentsCopied, string elapsedTime, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError> errors, long eventsPending, long eventsReplayed, Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState state, long totalBytes, long totalDocuments) { }
        public long BytesCopied { get { throw null; } }
        public long DocumentsCopied { get { throw null; } }
        public string ElapsedTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError> Errors { get { throw null; } }
        public long EventsPending { get { throw null; } }
        public long EventsReplayed { get { throw null; } }
        public System.DateTimeOffset? LastEventOn { get { throw null; } }
        public System.DateTimeOffset? LastReplayOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string QualifiedName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState State { get { throw null; } }
        public long TotalBytes { get { throw null; } }
        public long TotalDocuments { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDBReplication : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MongoDBReplication>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDBReplication(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBReplication Continuous { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBReplication Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBReplication OneTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MongoDBReplication other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MongoDBReplication left, Azure.ResourceManager.DataMigration.Models.MongoDBReplication right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MongoDBReplication (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MongoDBReplication left, Azure.ResourceManager.DataMigration.Models.MongoDBReplication right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBRestartCommand : Azure.ResourceManager.DataMigration.Models.CommandProperties
    {
        public MongoDBRestartCommand() { }
        public string InputObjectName { get { throw null; } set { } }
    }
    public partial class MongoDBShardKeyField
    {
        public MongoDBShardKeyField(string name, Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder order) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder Order { get { throw null; } set { } }
    }
    public partial class MongoDBShardKeyInfo
    {
        internal MongoDBShardKeyInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField> Fields { get { throw null; } }
        public bool IsUnique { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDBShardKeyOrder : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDBShardKeyOrder(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder Forward { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder Hashed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder Reverse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder left, Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder left, Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBShardKeySetting
    {
        public MongoDBShardKeySetting(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField> fields) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField> Fields { get { throw null; } }
        public bool? IsUnique { get { throw null; } set { } }
    }
    public partial class MongoDBThrottlingSettings
    {
        public MongoDBThrottlingSettings() { }
        public int? MaxParallelism { get { throw null; } set { } }
        public int? MinFreeCpu { get { throw null; } set { } }
        public int? MinFreeMemoryMb { get { throw null; } set { } }
    }
    public partial class MySqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo
    {
        public MySqlConnectionInfo(string serverName, int port) { }
        public string AdditionalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.AuthenticationType? Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public bool? EncryptConnection { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlTargetPlatformType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlTargetPlatformType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType AzureDBForMySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType SqlServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType left, Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType left, Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NameAvailabilityRequest
    {
        public NameAvailabilityRequest() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class NameAvailabilityResponse
    {
        internal NameAvailabilityResponse() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NameCheckFailureReason : System.IEquatable<Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NameCheckFailureReason(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason left, Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason left, Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeMonitoringData
    {
        internal NodeMonitoringData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? AvailableMemoryInMB { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public int? ConcurrentJobsRunning { get { throw null; } }
        public int? CpuUtilization { get { throw null; } }
        public int? MaxConcurrentJobs { get { throw null; } }
        public string NodeName { get { throw null; } }
        public double? ReceivedBytes { get { throw null; } }
        public double? SentBytes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObjectType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObjectType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ObjectType Function { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ObjectType StoredProcedures { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ObjectType Table { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ObjectType User { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ObjectType View { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ObjectType left, Azure.ResourceManager.DataMigration.Models.ObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ObjectType left, Azure.ResourceManager.DataMigration.Models.ObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ODataError
    {
        internal ODataError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ODataError> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class OfflineConfiguration
    {
        public OfflineConfiguration() { }
        public string LastBackupName { get { throw null; } set { } }
        public bool? Offline { get { throw null; } set { } }
    }
    public partial class OracleConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo
    {
        public OracleConnectionInfo(string dataSource) { }
        public Azure.ResourceManager.DataMigration.Models.AuthenticationType? Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
    }
    public partial class OracleOciDriverInfo
    {
        internal OracleOciDriverInfo() { }
        public string ArchiveChecksum { get { throw null; } }
        public string AssemblyVersion { get { throw null; } }
        public string DriverName { get { throw null; } }
        public string DriverSize { get { throw null; } }
        public string OracleChecksum { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedOracleVersions { get { throw null; } }
    }
    public partial class OrphanedUserInfo
    {
        internal OrphanedUserInfo() { }
        public string DatabaseName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class PostgreSqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo
    {
        public PostgreSqlConnectionInfo(string serverName, int port) { }
        public string AdditionalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.AuthenticationType? Authentication { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public bool? EncryptConnection { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string ServerBrandVersion { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public bool? TrustServerCertificate { get { throw null; } set { } }
    }
    public partial class ProjectFileProperties
    {
        public ProjectFileProperties() { }
        public string Extension { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string MediaType { get { throw null; } set { } }
        public long? Size { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectProvisioningState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState left, Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState left, Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectSourcePlatform : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectSourcePlatform(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform MongoDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform MySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform Sql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform left, Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform left, Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectTargetPlatform : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectTargetPlatform(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform AzureDBForMySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform AzureDBForPostgreSql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform MongoDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform SqlDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform SqlMI { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform left, Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform left, Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ProjectTaskProperties
    {
        protected ProjectTaskProperties() { }
        public System.Collections.Generic.IDictionary<string, string> ClientData { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.CommandProperties> Commands { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ODataError> Errors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.TaskState? State { get { throw null; } }
    }
    public partial class QueryAnalysisValidationResult
    {
        internal QueryAnalysisValidationResult() { }
        public Azure.ResourceManager.DataMigration.Models.QueryExecutionResult QueryResults { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationError ValidationErrors { get { throw null; } }
    }
    public partial class QueryExecutionResult
    {
        internal QueryExecutionResult() { }
        public string QueryText { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ExecutionStatistics SourceResult { get { throw null; } }
        public long? StatementsInBatch { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ExecutionStatistics TargetResult { get { throw null; } }
    }
    public partial class Quota
    {
        internal Quota() { }
        public double? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public double? Limit { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.QuotaName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class QuotaName
    {
        internal QuotaName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class RegenAuthKeys
    {
        public RegenAuthKeys() { }
        public string AuthKey1 { get { throw null; } set { } }
        public string AuthKey2 { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicateMigrationState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicateMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState Complete { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState Pending { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState Undefined { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState Validating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState left, Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState left, Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReportableException
    {
        internal ReportableException() { }
        public string ActionableMessage { get { throw null; } }
        public string FilePath { get { throw null; } }
        public int? HResult { get { throw null; } }
        public string LineNumber { get { throw null; } }
        public string Message { get { throw null; } }
        public string StackTrace { get { throw null; } }
    }
    public partial class ResourceSku
    {
        internal ResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ResourceSkuCapabilities
    {
        internal ResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ResourceSkuCapacity
    {
        internal ResourceSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuCapacityScaleType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuCapacityScaleType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType left, Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType left, Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSkuCosts
    {
        internal ResourceSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
    }
    public partial class ResourceSkuRestrictions
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuRestrictionsReasonCode : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuRestrictionsReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuRestrictionsType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuRestrictionsType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType Location { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType left, Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType left, Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScenarioSource : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ScenarioSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScenarioSource(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource Access { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource DB2 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource MongoDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource MySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource MySqlrds { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource Oracle { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource PostgreSqlrds { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource Sql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource Sqlrds { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioSource Sybase { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ScenarioSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ScenarioSource left, Azure.ResourceManager.DataMigration.Models.ScenarioSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ScenarioSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ScenarioSource left, Azure.ResourceManager.DataMigration.Models.ScenarioSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScenarioTarget : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ScenarioTarget>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScenarioTarget(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioTarget AzureDBForMySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioTarget AzureDBForPostgresSql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioTarget MongoDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioTarget SqlDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioTarget SqlDW { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioTarget SqlMI { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ScenarioTarget SqlServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ScenarioTarget other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ScenarioTarget left, Azure.ResourceManager.DataMigration.Models.ScenarioTarget right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ScenarioTarget (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ScenarioTarget left, Azure.ResourceManager.DataMigration.Models.ScenarioTarget right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SchemaComparisonValidationResult
    {
        internal SchemaComparisonValidationResult() { }
        public Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType SchemaDifferences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, long> SourceDatabaseObjectCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, long> TargetDatabaseObjectCount { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationError ValidationErrors { get { throw null; } }
    }
    public partial class SchemaComparisonValidationResultType
    {
        internal SchemaComparisonValidationResultType() { }
        public string ObjectName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ObjectType? ObjectType { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.UpdateActionType? UpdateAction { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchemaMigrationOption : System.IEquatable<Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchemaMigrationOption(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption ExtractFromSource { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption None { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption UseStorageFile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption left, Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption left, Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SchemaMigrationSetting
    {
        public SchemaMigrationSetting() { }
        public string FileId { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption? SchemaOption { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchemaMigrationStage : System.IEquatable<Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchemaMigrationStage(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage CollectingObjects { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage DeployingSchema { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage DownloadingScript { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage GeneratingScript { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage UploadingScript { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage ValidatingInputs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage left, Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage left, Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelectedCertificateInput
    {
        public SelectedCertificateInput(string certificateName, string password) { }
        public string CertificateName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
    }
    public enum ServerLevelPermissionsGroup
    {
        Default = 0,
        MigrationFromSqlServerToAzureDB = 1,
        MigrationFromSqlServerToAzureMI = 2,
        MigrationFromMySqlToAzureDBForMySql = 3,
        MigrationFromSqlServerToAzureVm = 4,
    }
    public partial class ServerProperties
    {
        internal ServerProperties() { }
        public int? ServerDatabaseCount { get { throw null; } }
        public string ServerEdition { get { throw null; } }
        public string ServerName { get { throw null; } }
        public string ServerOperatingSystemVersion { get { throw null; } }
        public string ServerPlatform { get { throw null; } }
        public string ServerVersion { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceProvisioningState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState Deploying { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState FailedToStart { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState FailedToStop { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState Starting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState Stopped { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState Stopping { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState left, Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState left, Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceScalability : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ServiceScalability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceScalability(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ServiceScalability Automatic { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceScalability Manual { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ServiceScalability None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ServiceScalability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ServiceScalability left, Azure.ResourceManager.DataMigration.Models.ServiceScalability right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ServiceScalability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ServiceScalability left, Azure.ResourceManager.DataMigration.Models.ServiceScalability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceSku
    {
        public ServiceSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Severity : System.IEquatable<Azure.ResourceManager.DataMigration.Models.Severity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Severity(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.Severity Error { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.Severity Message { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.Severity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.Severity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.Severity left, Azure.ResourceManager.DataMigration.Models.Severity right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.Severity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.Severity left, Azure.ResourceManager.DataMigration.Models.Severity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceLocation
    {
        public SourceLocation() { }
        public Azure.ResourceManager.DataMigration.Models.AzureBlob AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlFileShare FileShare { get { throw null; } set { } }
        public string FileStorageType { get { throw null; } }
    }
    public partial class SqlBackupFileInfo
    {
        internal SqlBackupFileInfo() { }
        public int? CopyDuration { get { throw null; } }
        public double? CopyThroughput { get { throw null; } }
        public long? DataRead { get { throw null; } }
        public long? DataWritten { get { throw null; } }
        public int? FamilySequenceNumber { get { throw null; } }
        public string FileName { get { throw null; } }
        public string Status { get { throw null; } }
        public long? TotalSize { get { throw null; } }
    }
    public partial class SqlBackupSetInfo
    {
        internal SqlBackupSetInfo() { }
        public System.DateTimeOffset? BackupFinishOn { get { throw null; } }
        public System.Guid? BackupSetId { get { throw null; } }
        public System.DateTimeOffset? BackupStartOn { get { throw null; } }
        public string BackupType { get { throw null; } }
        public int? FamilyCount { get { throw null; } }
        public string FirstLSN { get { throw null; } }
        public bool? HasBackupChecksums { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IgnoreReasons { get { throw null; } }
        public bool? IsBackupRestored { get { throw null; } }
        public string LastLSN { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo> ListOfBackupFiles { get { throw null; } }
    }
    public partial class SqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo
    {
        public SqlConnectionInfo(string dataSource) { }
        public string AdditionalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.AuthenticationType? Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public bool? EncryptConnection { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlSourcePlatform? Platform { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ServerBrandVersion { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public bool? TrustServerCertificate { get { throw null; } set { } }
    }
    public partial class SqlConnectionInformation
    {
        public SqlConnectionInformation() { }
        public string Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public bool? EncryptConnection { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public bool? TrustServerCertificate { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class SqlDBMigrationStatusDetails
    {
        internal SqlDBMigrationStatusDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails> ListOfCopyProgressDetails { get { throw null; } }
        public string MigrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlDataCopyErrors { get { throw null; } }
    }
    public partial class SqlFileShare
    {
        public SqlFileShare() { }
        public string Password { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class SqlMigrationServicePatch
    {
        public SqlMigrationServicePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SqlMigrationTaskInput
    {
        public SqlMigrationTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public partial class SqlServerSqlMISyncTaskInput
    {
        public SqlServerSqlMISyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, string storageResourceId, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp azureApp) { }
        public Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp AzureApp { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.FileShare BackupFileShare { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public string StorageResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlSourcePlatform : System.IEquatable<Azure.ResourceManager.DataMigration.Models.SqlSourcePlatform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlSourcePlatform(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SqlSourcePlatform SqlOnPrem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.SqlSourcePlatform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.SqlSourcePlatform left, Azure.ResourceManager.DataMigration.Models.SqlSourcePlatform right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.SqlSourcePlatform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.SqlSourcePlatform left, Azure.ResourceManager.DataMigration.Models.SqlSourcePlatform right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SsisMigrationInfo
    {
        public SsisMigrationInfo() { }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption? EnvironmentOverwriteOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption? ProjectOverwriteOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SsisStoreType? SsisStoreType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsisMigrationOverwriteOption : System.IEquatable<Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsisMigrationOverwriteOption(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption Ignore { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption Overwrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption left, Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption left, Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsisMigrationStage : System.IEquatable<Azure.ResourceManager.DataMigration.Models.SsisMigrationStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsisMigrationStage(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SsisMigrationStage Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SsisMigrationStage Initialize { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SsisMigrationStage InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SsisMigrationStage None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.SsisMigrationStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.SsisMigrationStage left, Azure.ResourceManager.DataMigration.Models.SsisMigrationStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.SsisMigrationStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.SsisMigrationStage left, Azure.ResourceManager.DataMigration.Models.SsisMigrationStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsisStoreType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.SsisStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsisStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SsisStoreType SsisCatalog { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.SsisStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.SsisStoreType left, Azure.ResourceManager.DataMigration.Models.SsisStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.SsisStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.SsisStoreType left, Azure.ResourceManager.DataMigration.Models.SsisStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncDatabaseMigrationReportingState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncDatabaseMigrationReportingState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState BackupCompleted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState BackupINProgress { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Cancelling { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Complete { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Completing { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Configuring { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Initialiazing { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState ReadyTOComplete { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState RestoreCompleted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState RestoreINProgress { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Running { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Starting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Undefined { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState Validating { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState ValidationComplete { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState ValidationFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState left, Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState left, Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyncMigrationDatabaseErrorEvent
    {
        internal SyncMigrationDatabaseErrorEvent() { }
        public string EventText { get { throw null; } }
        public string EventTypeString { get { throw null; } }
        public string TimestampString { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncTableMigrationState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncTableMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState BeforeLoad { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState Error { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState FullLoad { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState left, Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState left, Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetLocation
    {
        public TargetLocation() { }
        public string AccountKey { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.TaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.TaskState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.TaskState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.TaskState FailedInputValidation { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.TaskState Faulted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.TaskState Queued { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.TaskState Running { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.TaskState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.TaskState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.TaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.TaskState left, Azure.ResourceManager.DataMigration.Models.TaskState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.TaskState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.TaskState left, Azure.ResourceManager.DataMigration.Models.TaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateActionType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.UpdateActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateActionType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.UpdateActionType AddedOnTarget { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.UpdateActionType ChangedOnTarget { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.UpdateActionType DeletedOnTarget { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.UpdateActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.UpdateActionType left, Azure.ResourceManager.DataMigration.Models.UpdateActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.UpdateActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.UpdateActionType left, Azure.ResourceManager.DataMigration.Models.UpdateActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UploadOciDriverTaskOutput
    {
        internal UploadOciDriverTaskOutput() { }
        public string DriverPackageName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class UploadOciDriverTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public UploadOciDriverTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.FileShare InputDriverShare { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput> Output { get { throw null; } }
    }
    public partial class ValidateMigrationInputSqlServerSqlDBSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ValidateMigrationInputSqlServerSqlDBSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput> Output { get { throw null; } }
    }
    public partial class ValidateMigrationInputSqlServerSqlMISyncTaskInput : Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput
    {
        public ValidateMigrationInputSqlServerSqlMISyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, string storageResourceId, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp azureApp) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>), default(string), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp)) { }
    }
    public partial class ValidateMigrationInputSqlServerSqlMISyncTaskOutput
    {
        internal ValidateMigrationInputSqlServerSqlMISyncTaskOutput() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ValidateMigrationInputSqlServerSqlMISyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ValidateMigrationInputSqlServerSqlMISyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput> Output { get { throw null; } }
    }
    public partial class ValidateMigrationInputSqlServerSqlMITaskInput
    {
        public ValidateMigrationInputSqlServerSqlMITaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.BlobShare backupBlobShare) { }
        public System.Uri BackupBlobShareSasUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.FileShare BackupFileShare { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.BackupMode? BackupMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> SelectedDatabases { get { throw null; } }
        public System.Collections.Generic.IList<string> SelectedLogins { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public partial class ValidateMigrationInputSqlServerSqlMITaskOutput
    {
        internal ValidateMigrationInputSqlServerSqlMITaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> BackupFolderErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> BackupShareCredentialsErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> BackupStorageAccountErrors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo DatabaseBackupInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExistingBackupErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> RestoreDatabaseNameErrors { get { throw null; } }
    }
    public partial class ValidateMigrationInputSqlServerSqlMITaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ValidateMigrationInputSqlServerSqlMITaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput> Output { get { throw null; } }
    }
    public partial class ValidateMongoDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ValidateMongoDBTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress> Output { get { throw null; } }
    }
    public partial class ValidateOracleAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties
    {
        public ValidateOracleAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput> Output { get { throw null; } }
    }
    public partial class ValidateOracleAzureDBPostgreSqlSyncTaskOutput
    {
        internal ValidateOracleAzureDBPostgreSqlSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ValidateSyncMigrationInputSqlServerTaskInput
    {
        public ValidateSyncMigrationInputSqlServerTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> selectedDatabases) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
    }
    public partial class ValidateSyncMigrationInputSqlServerTaskOutput
    {
        internal ValidateSyncMigrationInputSqlServerTaskOutput() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
    }
    public partial class ValidationError
    {
        internal ValidationError() { }
        public Azure.ResourceManager.DataMigration.Models.Severity? Severity { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationStatus : System.IEquatable<Azure.ResourceManager.DataMigration.Models.ValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ValidationStatus CompletedWithIssues { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ValidationStatus Default { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ValidationStatus Initialized { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ValidationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ValidationStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.ValidationStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.ValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.ValidationStatus left, Azure.ResourceManager.DataMigration.Models.ValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.ValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.ValidationStatus left, Azure.ResourceManager.DataMigration.Models.ValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WaitStatistics
    {
        internal WaitStatistics() { }
        public long? WaitCount { get { throw null; } }
        public float? WaitTimeMs { get { throw null; } }
        public string WaitType { get { throw null; } }
    }
}
