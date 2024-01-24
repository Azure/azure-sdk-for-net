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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource> GetIfExists(string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource>> GetIfExistsAsync(string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseMigrationSqlDBData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>
    {
        public DatabaseMigrationSqlDBData() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource> GetIfExists(string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource>> GetIfExistsAsync(string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseMigrationSqlMIData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>
    {
        public DatabaseMigrationSqlMIData() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource> GetIfExists(string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource>> GetIfExistsAsync(string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseMigrationSqlVmData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>
    {
        public DatabaseMigrationSqlVmData() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataMigrationServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>
    {
        public DataMigrationServiceData(Azure.Core.AzureLocation location) { }
        public string AutoStopDelay { get { throw null; } set { } }
        public bool? DeleteResourcesOnStop { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ServiceSku Sku { get { throw null; } set { } }
        public string VirtualNicId { get { throw null; } set { } }
        public string VirtualSubnetId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.DataMigrationServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.ProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.ProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.ProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.ProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.ProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectData>
    {
        public ProjectData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp AzureAuthenticationInfo { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.DatabaseInfo> DatabasesInfo { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform? SourcePlatform { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform? TargetPlatform { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.ProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.ProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.ProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.ProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.ProjectFileResource> GetIfExists(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.ProjectFileResource>> GetIfExistsAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.ProjectFileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ProjectFileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.ProjectFileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ProjectFileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectFileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.ProjectFileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectFileData>
    {
        public ProjectFileData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectFileProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.ProjectFileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.ProjectFileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.ProjectFileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.ProjectFileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectFileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectFileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectFileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProjectTaskData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.ProjectTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectTaskData>
    {
        public ProjectTaskData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.ProjectTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.ProjectTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.ProjectTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.ProjectTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.ProjectTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource> GetIfExists(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.ServiceProjectTaskResource>> GetIfExistsAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> GetIfExists(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> GetIfExistsAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetIfExists(string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> GetIfExistsAsync(string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlMigrationServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>
    {
        public SqlMigrationServiceData(Azure.Core.AzureLocation location) { }
        public string IntegrationRuntimeState { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        Azure.ResourceManager.DataMigration.SqlMigrationServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.SqlMigrationServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
namespace Azure.ResourceManager.DataMigration.Mocking
{
    public partial class MockableDataMigrationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDataMigrationArmClient() { }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource GetDatabaseMigrationSqlDBResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource GetDatabaseMigrationSqlMIResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource GetDatabaseMigrationSqlVmResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationServiceResource GetDataMigrationServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.ProjectFileResource GetProjectFileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.ProjectResource GetProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.ServiceProjectTaskResource GetServiceProjectTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.ServiceServiceTaskResource GetServiceServiceTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.SqlMigrationServiceResource GetSqlMigrationServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDataMigrationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataMigrationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource> GetDatabaseMigrationSqlDB(string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBResource>> GetDatabaseMigrationSqlDBAsync(string sqlDBInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBCollection GetDatabaseMigrationSqlDBs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource> GetDatabaseMigrationSqlMI(string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIResource>> GetDatabaseMigrationSqlMIAsync(string managedInstanceName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMICollection GetDatabaseMigrationSqlMIs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource> GetDatabaseMigrationSqlVm(string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource>> GetDatabaseMigrationSqlVmAsync(string sqlVirtualMachineName, string targetDBName, System.Guid? migrationOperationId = default(System.Guid?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmCollection GetDatabaseMigrationSqlVms() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> GetDataMigrationServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationServiceCollection GetDataMigrationServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationService(string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> GetSqlMigrationServiceAsync(string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.SqlMigrationServiceCollection GetSqlMigrationServices() { throw null; }
    }
    public partial class MockableDataMigrationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataMigrationSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse> CheckNameAvailabilityService(Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest nameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>> CheckNameAvailabilityServiceAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest nameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.ResourceSku> GetSkusResourceSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.ResourceSku> GetSkusResourceSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.Quota> GetUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.Quota> GetUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataMigration.Models
{
    public static partial class ArmDataMigrationModelFactory
    {
        public static Azure.ResourceManager.DataMigration.Models.AuthenticationKeys AuthenticationKeys(string authKey1 = null, string authKey2 = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.AvailableServiceSku AvailableServiceSku(string resourceType = null, Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku sku = null, Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity AvailableServiceSkuCapacity(int? minimum = default(int?), int? maximum = default(int?), int? @default = default(int?), Azure.ResourceManager.DataMigration.Models.ServiceScalability? scaleType = default(Azure.ResourceManager.DataMigration.Models.ServiceScalability?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku AvailableServiceSkuSku(string name = null, string family = null, string size = null, string tier = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.BackupFileInfo BackupFileInfo(string fileLocation = null, int? familySequenceNumber = default(int?), Azure.ResourceManager.DataMigration.Models.BackupFileStatus? status = default(Azure.ResourceManager.DataMigration.Models.BackupFileStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.BackupSetInfo BackupSetInfo(string backupSetId = null, string firstLsn = null, string lastLsn = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.BackupType? backupType = default(Azure.ResourceManager.DataMigration.Models.BackupType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.BackupFileInfo> listOfBackupFiles = null, string databaseName = null, System.DateTimeOffset? backupStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? backupFinishedOn = default(System.DateTimeOffset?), bool? isBackupRestored = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput CheckOciDriverTaskOutput(Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo installedDriver = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties CheckOciDriverTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, string inputServerVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.CommandProperties CommandProperties(string commandType = "Unknown", System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.CommandState? state = default(Azure.ResourceManager.DataMigration.Models.CommandState?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties ConnectToMongoDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties ConnectToSourceMySqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput ConnectToSourceNonSqlTaskOutput(string id = null, string sourceServerBrandVersion = null, Azure.ResourceManager.DataMigration.Models.ServerProperties serverProperties = null, System.Collections.Generic.IEnumerable<string> databases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput ConnectToSourceOracleSyncTaskOutput(string sourceServerVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string sourceServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties ConnectToSourceOracleSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo inputSourceConnectionInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput ConnectToSourcePostgreSqlSyncTaskOutput(string id = null, string sourceServerVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string sourceServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties ConnectToSourcePostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo inputSourceConnectionInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties ConnectToSourceSqlServerSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput ConnectToSourceSqlServerTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel ConnectToSourceSqlServerTaskOutputAgentJobLevel(string id = null, string name = null, string jobCategory = null, bool? isEnabled = default(bool?), string jobOwner = null, System.DateTimeOffset? lastExecutedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null, Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo migrationEligibility = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel ConnectToSourceSqlServerTaskOutputDatabaseLevel(string id = null, string name = null, double? sizeMB = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo> databaseFiles = null, Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel? compatibilityLevel = default(Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel?), Azure.ResourceManager.DataMigration.Models.DatabaseState? databaseState = default(Azure.ResourceManager.DataMigration.Models.DatabaseState?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel ConnectToSourceSqlServerTaskOutputLoginLevel(string id = null, string name = null, Azure.ResourceManager.DataMigration.Models.LoginType? loginType = default(Azure.ResourceManager.DataMigration.Models.LoginType?), string defaultDatabase = null, bool? isEnabled = default(bool?), Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo migrationEligibility = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel ConnectToSourceSqlServerTaskOutputTaskLevel(string id = null, string databases = null, string logins = null, string agentJobs = null, string databaseTdeCertificateMapping = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties ConnectToSourceSqlServerTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> output = null, string taskId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput ConnectToTargetAzureDBForMySqlTaskOutput(string id = null, string serverVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties ConnectToTargetAzureDBForMySqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput(string id = null, string targetServerVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput(string targetServerVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem> databaseSchemaMap = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem(string database = null, System.Collections.Generic.IEnumerable<string> schemas = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo inputTargetConnectionInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties ConnectToTargetSqlDBSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput ConnectToTargetSqlDBTaskOutput(string id = null, string databases = null, string targetServerVersion = null, string targetServerBrandVersion = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties ConnectToTargetSqlDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> output = null, string createdOn = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput ConnectToTargetSqlMISyncTaskOutput(string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties ConnectToTargetSqlMISyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput ConnectToTargetSqlMITaskOutput(string id = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<string> logins = null, System.Collections.Generic.IEnumerable<string> agentJobs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties ConnectToTargetSqlMITaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.CopyProgressDetails CopyProgressDetails(string tableName = null, string status = null, string parallelCopyType = null, int? usedParallelCopies = default(int?), long? dataRead = default(long?), long? dataWritten = default(long?), long? rowsRead = default(long?), long? rowsCopied = default(long?), System.DateTimeOffset? copyStart = default(System.DateTimeOffset?), double? copyThroughput = default(double?), int? copyDuration = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo DatabaseBackupInfo(string databaseName = null, Azure.ResourceManager.DataMigration.Models.BackupType? backupType = default(Azure.ResourceManager.DataMigration.Models.BackupType?), System.Collections.Generic.IEnumerable<string> backupFiles = null, int? position = default(int?), bool? isDamaged = default(bool?), bool? isCompressed = default(bool?), int? familyCount = default(int?), System.DateTimeOffset? backupFinishOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo DatabaseFileInfo(string databaseName = null, string id = null, string logicalName = null, string physicalFullName = null, string restoreFullName = null, Azure.ResourceManager.DataMigration.Models.DatabaseFileType? fileType = default(Azure.ResourceManager.DataMigration.Models.DatabaseFileType?), double? sizeMB = default(double?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigration DatabaseMigration(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties DatabaseMigrationProperties(string kind = "Unknown", string scope = null, string provisioningState = null, string migrationStatus = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation sourceSqlConnection = null, string sourceDatabaseName = null, string sourceServerName = null, string migrationService = null, string migrationOperationId = null, Azure.ResourceManager.DataMigration.Models.ErrorInfo migrationFailureError = null, string targetDatabaseCollation = null, string provisioningError = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData DatabaseMigrationSqlDBData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties DatabaseMigrationSqlDBProperties(string scope = null, string provisioningState = null, string migrationStatus = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation sourceSqlConnection = null, string sourceDatabaseName = null, string sourceServerName = null, string migrationService = null, string migrationOperationId = null, Azure.ResourceManager.DataMigration.Models.ErrorInfo migrationFailureError = null, string targetDatabaseCollation = null, string provisioningError = null, Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails migrationStatusDetails = null, Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation targetSqlConnection = null, bool? offline = default(bool?), System.Collections.Generic.IEnumerable<string> tableList = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData DatabaseMigrationSqlMIData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties DatabaseMigrationSqlMIProperties(string scope = null, string provisioningState = null, string migrationStatus = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation sourceSqlConnection = null, string sourceDatabaseName = null, string sourceServerName = null, string migrationService = null, string migrationOperationId = null, Azure.ResourceManager.DataMigration.Models.ErrorInfo migrationFailureError = null, string targetDatabaseCollation = null, string provisioningError = null, Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails migrationStatusDetails = null, Azure.ResourceManager.DataMigration.Models.BackupConfiguration backupConfiguration = null, Azure.ResourceManager.DataMigration.Models.OfflineConfiguration offlineConfiguration = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData DatabaseMigrationSqlVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties DatabaseMigrationSqlVmProperties(string scope = null, string provisioningState = null, string migrationStatus = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation sourceSqlConnection = null, string sourceDatabaseName = null, string sourceServerName = null, string migrationService = null, string migrationOperationId = null, Azure.ResourceManager.DataMigration.Models.ErrorInfo migrationFailureError = null, string targetDatabaseCollation = null, string provisioningError = null, Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails migrationStatusDetails = null, Azure.ResourceManager.DataMigration.Models.BackupConfiguration backupConfiguration = null, Azure.ResourceManager.DataMigration.Models.OfflineConfiguration offlineConfiguration = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseTable DatabaseTable(bool? hasRows = default(bool?), string name = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult DataIntegrityValidationResult(System.Collections.Generic.IReadOnlyDictionary<string, string> failedObjects = null, Azure.ResourceManager.DataMigration.Models.ValidationError validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationServiceData DataMigrationServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), string kind = null, Azure.ResourceManager.DataMigration.Models.ServiceSku sku = null, Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState? provisioningState = default(Azure.ResourceManager.DataMigration.Models.ServiceProvisioningState?), string publicKey = null, string virtualSubnetId = null, string virtualNicId = null, string autoStopDelay = null, bool? deleteResourcesOnStop = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse DataMigrationServiceStatusResponse(string agentVersion = null, System.BinaryData agentConfiguration = null, string status = null, string vmSize = null, System.Collections.Generic.IEnumerable<string> supportedTaskTypes = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ErrorInfo ErrorInfo(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ExecutionStatistics ExecutionStatistics(long? executionCount = default(long?), float? cpuTimeMs = default(float?), float? elapsedTimeMs = default(float?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.WaitStatistics> waitStats = null, bool? hasErrors = default(bool?), System.Collections.Generic.IEnumerable<string> sqlErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.FileStorageInfo FileStorageInfo(System.Uri uri = null, System.Collections.Generic.IReadOnlyDictionary<string, string> headers = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput GetTdeCertificatesSqlTaskOutput(string base64EncodedCertificates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties GetTdeCertificatesSqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput GetUserTablesMySqlTaskOutput(string id = null, string databasesToTables = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties GetUserTablesMySqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput GetUserTablesOracleTaskOutput(string schemaName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DatabaseTable> tables = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties GetUserTablesOracleTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput GetUserTablesPostgreSqlTaskOutput(string databaseName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DatabaseTable> tables = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties GetUserTablesPostgreSqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput GetUserTablesSqlSyncTaskOutput(string databasesToSourceTables = null, string databasesToTargetTables = null, string tableValidationErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties GetUserTablesSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput GetUserTablesSqlTaskOutput(string id = null, string databasesToTables = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties GetUserTablesSqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput> output = null, string taskId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput InstallOciDriverTaskOutput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties InstallOciDriverTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, string inputDriverPackageName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData IntegrationRuntimeMonitoringData(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData> nodes = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties MigrateMISyncCompleteCommandProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.CommandState? state = default(Azure.ResourceManager.DataMigration.Models.CommandState?), string inputSourceDatabaseName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> outputErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties MigrateMongoDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MongoDBProgress> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput MigrateMySqlAzureDBForMySqlOfflineTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage?), string statusMessage = null, string message = null, long? numberOfObjects = default(long?), long? numberOfObjectsCompleted = default(long?), long? errorCount = default(long?), string errorPrefix = null, string resultPrefix = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null, System.DateTimeOffset? lastStorageUpdate = default(System.DateTimeOffset?), string objectSummary = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError MigrateMySqlAzureDBForMySqlOfflineTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.ReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), long? durationInSeconds = default(long?), Azure.ResourceManager.DataMigration.Models.MigrationStatus? status = default(Azure.ResourceManager.DataMigration.Models.MigrationStatus?), string statusMessage = null, string message = null, string databases = null, string databaseSummary = null, Azure.ResourceManager.DataMigration.Models.MigrationReportResult migrationReportResult = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null, System.DateTimeOffset? lastStorageUpdate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel(string id = null, string objectName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), string statusMessage = null, long? itemsCount = default(long?), long? itemsCompletedCount = default(long?), string errorPrefix = null, string resultPrefix = null, System.DateTimeOffset? lastStorageUpdate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties MigrateMySqlAzureDBForMySqlOfflineTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput> output = null, bool? isCloneable = default(bool?), string taskId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput MigrateMySqlAzureDBForMySqlSyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError(string id = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? migrationState = default(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState?), long? incomingChanges = default(long?), long? appliedChanges = default(long?), long? cdcInsertCounter = default(long?), long? cdcDeleteCounter = default(long?), long? cdcUpdateCounter = default(long?), long? fullLoadCompletedTables = default(long?), long? fullLoadLoadingTables = default(long?), long? fullLoadQueuedTables = default(long?), long? fullLoadErroredTables = default(long?), bool? initializationCompleted = default(bool?), long? latency = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError MigrateMySqlAzureDBForMySqlSyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.ReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServer = null, string targetServerVersion = null, string targetServer = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel(string id = null, string tableName = null, string databaseName = null, string cdcInsertCounter = null, string cdcUpdateCounter = null, string cdcDeleteCounter = null, System.DateTimeOffset? fullLoadEstFinishOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadEndedOn = default(System.DateTimeOffset?), long? fullLoadTotalRows = default(long?), Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState?), long? totalChangesApplied = default(long?), long? dataErrorsCounter = default(long?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties MigrateMySqlAzureDBForMySqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties MigrateOracleAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput MigrateOracleAzureDBPostgreSqlSyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError(string id = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? migrationState = default(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState?), long? incomingChanges = default(long?), long? appliedChanges = default(long?), long? cdcInsertCounter = default(long?), long? cdcDeleteCounter = default(long?), long? cdcUpdateCounter = default(long?), long? fullLoadCompletedTables = default(long?), long? fullLoadLoadingTables = default(long?), long? fullLoadQueuedTables = default(long?), long? fullLoadErroredTables = default(long?), bool? initializationCompleted = default(bool?), long? latency = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError MigrateOracleAzureDBPostgreSqlSyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.ReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServer = null, string targetServerVersion = null, string targetServer = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel(string id = null, string tableName = null, string databaseName = null, long? cdcInsertCounter = default(long?), long? cdcUpdateCounter = default(long?), long? cdcDeleteCounter = default(long?), System.DateTimeOffset? fullLoadEstFinishOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadEndedOn = default(System.DateTimeOffset?), long? fullLoadTotalRows = default(long?), Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState?), long? totalChangesApplied = default(long?), long? dataErrorsCounter = default(long?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput(string name = null, string id = null, string targetDatabaseName = null, System.Collections.Generic.IDictionary<string, System.BinaryData> migrationSetting = null, System.Collections.Generic.IDictionary<string, string> sourceSetting = null, System.Collections.Generic.IDictionary<string, string> targetSetting = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput> selectedTables = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput> selectedDatabases = null, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo targetConnectionInfo = null, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo sourceConnectionInfo = null, string encryptedKeyForSecureFields = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError(string id = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? migrationState = default(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState?), long? incomingChanges = default(long?), long? appliedChanges = default(long?), long? cdcInsertCounter = default(long?), long? cdcDeleteCounter = default(long?), long? cdcUpdateCounter = default(long?), long? fullLoadCompletedTables = default(long?), long? fullLoadLoadingTables = default(long?), long? fullLoadQueuedTables = default(long?), long? fullLoadErroredTables = default(long?), bool? initializationCompleted = default(bool?), long? latency = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.ReportableException error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServer = null, string targetServerVersion = null, string targetServer = null, Azure.ResourceManager.DataMigration.Models.ScenarioSource? sourceServerType = default(Azure.ResourceManager.DataMigration.Models.ScenarioSource?), Azure.ResourceManager.DataMigration.Models.ScenarioTarget? targetServerType = default(Azure.ResourceManager.DataMigration.Models.ScenarioTarget?), Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState?), float? databaseCount = default(float?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel(string id = null, string tableName = null, string databaseName = null, long? cdcInsertCounter = default(long?), long? cdcUpdateCounter = default(long?), long? cdcDeleteCounter = default(long?), System.DateTimeOffset? fullLoadEstFinishOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadEndedOn = default(System.DateTimeOffset?), long? fullLoadTotalRows = default(long?), Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState?), long? totalChangesApplied = default(long?), long? dataErrorsCounter = default(long?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput> output = null, string taskId = null, string createdOn = null, bool? isCloneable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput MigrateSchemaSqlServerSqlDBTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel(string id = null, string databaseName = null, Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string databaseErrorResultPrefix = null, string schemaErrorResultPrefix = null, long? numberOfSuccessfulOperations = default(long?), long? numberOfFailedOperations = default(long?), string fileId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError MigrateSchemaSqlServerSqlDBTaskOutputError(string id = null, string commandText = null, string errorText = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel(string id = null, Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties MigrateSchemaSqlServerSqlDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput> output = null, string createdOn = null, string taskId = null, bool? isCloneable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError MigrateSchemaSqlTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.ReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput MigrateSqlServerSqlDBSyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError MigrateSqlServerSqlDBSyncTaskOutputDatabaseError(string id = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? migrationState = default(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState?), long? incomingChanges = default(long?), long? appliedChanges = default(long?), long? cdcInsertCounter = default(long?), long? cdcDeleteCounter = default(long?), long? cdcUpdateCounter = default(long?), long? fullLoadCompletedTables = default(long?), long? fullLoadLoadingTables = default(long?), long? fullLoadQueuedTables = default(long?), long? fullLoadErroredTables = default(long?), bool? initializationCompleted = default(bool?), long? latency = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError MigrateSqlServerSqlDBSyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.ReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServer = null, string targetServerVersion = null, string targetServer = null, int? databaseCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel MigrateSqlServerSqlDBSyncTaskOutputTableLevel(string id = null, string tableName = null, string databaseName = null, long? cdcInsertCounter = default(long?), long? cdcUpdateCounter = default(long?), long? cdcDeleteCounter = default(long?), System.DateTimeOffset? fullLoadEstFinishOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadEndedOn = default(System.DateTimeOffset?), long? fullLoadTotalRows = default(long?), Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState?), long? totalChangesApplied = default(long?), long? dataErrorsCounter = default(long?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties MigrateSqlServerSqlDBSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput MigrateSqlServerSqlDBTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel MigrateSqlServerSqlDBTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage?), string statusMessage = null, string message = null, long? numberOfObjects = default(long?), long? numberOfObjectsCompleted = default(long?), long? errorCount = default(long?), string errorPrefix = null, string resultPrefix = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null, string objectSummary = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult(string id = null, string migrationId = null, string sourceDatabaseName = null, string targetDatabaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult dataIntegrityValidationResult = null, Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult schemaValidationResult = null, Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult queryAnalysisValidationResult = null, Azure.ResourceManager.DataMigration.Models.ValidationStatus? status = default(Azure.ResourceManager.DataMigration.Models.ValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError MigrateSqlServerSqlDBTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.ReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel MigrateSqlServerSqlDBTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), long? durationInSeconds = default(long?), Azure.ResourceManager.DataMigration.Models.MigrationStatus? status = default(Azure.ResourceManager.DataMigration.Models.MigrationStatus?), string statusMessage = null, string message = null, string databases = null, string databaseSummary = null, Azure.ResourceManager.DataMigration.Models.MigrationValidationResult migrationValidationResult = null, Azure.ResourceManager.DataMigration.Models.MigrationReportResult migrationReportResult = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel MigrateSqlServerSqlDBTaskOutputTableLevel(string id = null, string objectName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), string statusMessage = null, long? itemsCount = default(long?), long? itemsCompletedCount = default(long?), string errorPrefix = null, string resultPrefix = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult MigrateSqlServerSqlDBTaskOutputValidationResult(string id = null, string migrationId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> summaryResults = null, Azure.ResourceManager.DataMigration.Models.ValidationStatus? status = default(Azure.ResourceManager.DataMigration.Models.ValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties MigrateSqlServerSqlDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput> output = null, string taskId = null, bool? isCloneable = default(bool?), string createdOn = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput MigrateSqlServerSqlMISyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel(string id = null, string sourceDatabaseName = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState? migrationState = default(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.BackupSetInfo fullBackupSetInfo = null, Azure.ResourceManager.DataMigration.Models.BackupSetInfo lastRestoredBackupSetInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.BackupSetInfo> activeBackupSets = null, string containerName = null, string errorPrefix = null, bool? isFullBackupRestored = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError MigrateSqlServerSqlMISyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.ReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel MigrateSqlServerSqlMISyncTaskOutputMigrationLevel(string id = null, int? databaseCount = default(int?), Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerName = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerName = null, string targetServerVersion = null, string targetServerBrandVersion = null, int? databaseErrorCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties MigrateSqlServerSqlMISyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput> output = null, string createdOn = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput MigrateSqlServerSqlMITaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel MigrateSqlServerSqlMITaskOutputAgentJobLevel(string id = null, string name = null, bool? isEnabled = default(bool?), Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel MigrateSqlServerSqlMITaskOutputDatabaseLevel(string id = null, string databaseName = null, double? sizeMB = default(double?), Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError MigrateSqlServerSqlMITaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.ReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel MigrateSqlServerSqlMITaskOutputLoginLevel(string id = null, string loginName = null, Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), Azure.ResourceManager.DataMigration.Models.LoginMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.LoginMigrationStage?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel MigrateSqlServerSqlMITaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.MigrationStatus? status = default(Azure.ResourceManager.DataMigration.Models.MigrationStatus?), Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), string agentJobs = null, string logins = null, string message = null, string serverRoleResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo> orphanedUsersInfo = null, string databases = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties MigrateSqlServerSqlMITaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput> output = null, string taskId = null, string createdOn = null, string parentTaskId = null, bool? isCloneable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput MigrateSsisTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel MigrateSsisTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.MigrationStatus? status = default(Azure.ResourceManager.DataMigration.Models.MigrationStatus?), string message = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null, Azure.ResourceManager.DataMigration.Models.SsisMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.SsisMigrationStage?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel MigrateSsisTaskOutputProjectLevel(string id = null, string folderName = null, string projectName = null, Azure.ResourceManager.DataMigration.Models.MigrationState? state = default(Azure.ResourceManager.DataMigration.Models.MigrationState?), Azure.ResourceManager.DataMigration.Models.SsisMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.SsisMigrationStage?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties MigrateSsisTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput MigrateSyncCompleteCommandOutput(string id = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> errors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties MigrateSyncCompleteCommandProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.CommandState? state = default(Azure.ResourceManager.DataMigration.Models.CommandState?), Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput input = null, Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput output = null, string commandId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo MigrationEligibilityInfo(bool? isEligibleForMigration = default(bool?), System.Collections.Generic.IEnumerable<string> validationMessages = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationReportResult MigrationReportResult(string id = null, System.Uri reportUri = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails MigrationStatusDetails(string migrationState = null, Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo fullBackupSetInfo = null, Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo lastRestoredBackupSetInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo> activeBackupSets = null, System.Collections.Generic.IEnumerable<string> invalidFiles = null, string blobContainerName = null, bool? isFullBackupRestored = default(bool?), string restoreBlockingReason = null, string completeRestoreErrorMessage = null, System.Collections.Generic.IEnumerable<string> fileUploadBlockingErrors = null, string currentRestoringFilename = null, string lastRestoredFilename = null, int? pendingLogBackupsCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult MigrationValidationDatabaseSummaryResult(string id = null, string migrationId = null, string sourceDatabaseName = null, string targetDatabaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.ValidationStatus? status = default(Azure.ResourceManager.DataMigration.Models.ValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationResult MigrationValidationResult(string id = null, string migrationId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> summaryResults = null, Azure.ResourceManager.DataMigration.Models.ValidationStatus? status = default(Azure.ResourceManager.DataMigration.Models.ValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand MongoDBCancelCommand(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.CommandState? state = default(Azure.ResourceManager.DataMigration.Models.CommandState?), string inputObjectName = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo MongoDBClusterInfo(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo> databases = null, bool supportsSharding = false, Azure.ResourceManager.DataMigration.Models.MongoDBClusterType clusterType = default(Azure.ResourceManager.DataMigration.Models.MongoDBClusterType), string version = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo MongoDBCollectionInfo(long averageDocumentSize = (long)0, long dataSize = (long)0, long documentCount = (long)0, string name = null, string qualifiedName = null, string databaseName = null, bool isCapped = false, bool isSystemCollection = false, bool isView = false, Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo shardKey = null, bool supportsSharding = false, string viewOf = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress MongoDBCollectionProgress(long bytesCopied = (long)0, long documentsCopied = (long)0, string elapsedTime = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError> errors = null, long eventsPending = (long)0, long eventsReplayed = (long)0, System.DateTimeOffset? lastEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastReplayOn = default(System.DateTimeOffset?), string name = null, string qualifiedName = null, Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState state = default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), long totalBytes = (long)0, long totalDocuments = (long)0) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo MongoDBDatabaseInfo(long averageDocumentSize = (long)0, long dataSize = (long)0, long documentCount = (long)0, string name = null, string qualifiedName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo> collections = null, bool supportsSharding = false) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress MongoDBDatabaseProgress(long bytesCopied = (long)0, long documentsCopied = (long)0, string elapsedTime = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError> errors = null, long eventsPending = (long)0, long eventsReplayed = (long)0, System.DateTimeOffset? lastEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastReplayOn = default(System.DateTimeOffset?), string name = null, string qualifiedName = null, Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState state = default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), long totalBytes = (long)0, long totalDocuments = (long)0, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress> collections = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBError MongoDBError(string code = null, int? count = default(int?), string message = null, Azure.ResourceManager.DataMigration.Models.MongoDBErrorType? errorType = default(Azure.ResourceManager.DataMigration.Models.MongoDBErrorType?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand MongoDBFinishCommand(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.CommandState? state = default(Azure.ResourceManager.DataMigration.Models.CommandState?), Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput input = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress MongoDBMigrationProgress(long bytesCopied = (long)0, long documentsCopied = (long)0, string elapsedTime = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError> errors = null, long eventsPending = (long)0, long eventsReplayed = (long)0, System.DateTimeOffset? lastEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastReplayOn = default(System.DateTimeOffset?), string name = null, string qualifiedName = null, Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState state = default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), long totalBytes = (long)0, long totalDocuments = (long)0, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress> databases = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo MongoDBObjectInfo(long averageDocumentSize = (long)0, long dataSize = (long)0, long documentCount = (long)0, string name = null, string qualifiedName = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBProgress MongoDBProgress(long bytesCopied = (long)0, long documentsCopied = (long)0, string elapsedTime = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError> errors = null, long eventsPending = (long)0, long eventsReplayed = (long)0, System.DateTimeOffset? lastEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastReplayOn = default(System.DateTimeOffset?), string name = null, string qualifiedName = null, string resultType = "Unknown", Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState state = default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), long totalBytes = (long)0, long totalDocuments = (long)0) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand MongoDBRestartCommand(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.CommandState? state = default(Azure.ResourceManager.DataMigration.Models.CommandState?), string inputObjectName = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo MongoDBShardKeyInfo(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField> fields = null, bool isUnique = false) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse NameAvailabilityResponse(bool? nameAvailable = default(bool?), Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason? reason = default(Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.NodeMonitoringData NodeMonitoringData(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null, string nodeName = null, int? availableMemoryInMB = default(int?), int? cpuUtilization = default(int?), int? concurrentJobsLimit = default(int?), int? concurrentJobsRunning = default(int?), int? maxConcurrentJobs = default(int?), double? sentBytes = default(double?), double? receivedBytes = default(double?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ODataError ODataError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> details = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo OracleOciDriverInfo(string driverName = null, string driverSize = null, string archiveChecksum = null, string oracleChecksum = null, string assemblyVersion = null, System.Collections.Generic.IEnumerable<string> supportedOracleVersions = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo OrphanedUserInfo(string name = null, string databaseName = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.ProjectData ProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform? sourcePlatform = default(Azure.ResourceManager.DataMigration.Models.ProjectSourcePlatform?), Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp azureAuthenticationInfo = null, Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform? targetPlatform = default(Azure.ResourceManager.DataMigration.Models.ProjectTargetPlatform?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.ConnectionInfo sourceConnectionInfo = null, Azure.ResourceManager.DataMigration.Models.ConnectionInfo targetConnectionInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DatabaseInfo> databasesInfo = null, Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState? provisioningState = default(Azure.ResourceManager.DataMigration.Models.ProjectProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.ProjectFileData ProjectFileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.DataMigration.Models.ProjectFileProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ProjectFileProperties ProjectFileProperties(string extension = null, string filePath = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), string mediaType = null, long? size = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.ProjectTaskData ProjectTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties ProjectTaskProperties(string taskType = "Unknown", System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult QueryAnalysisValidationResult(Azure.ResourceManager.DataMigration.Models.QueryExecutionResult queryResults = null, Azure.ResourceManager.DataMigration.Models.ValidationError validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.QueryExecutionResult QueryExecutionResult(string queryText = null, long? statementsInBatch = default(long?), Azure.ResourceManager.DataMigration.Models.ExecutionStatistics sourceResult = null, Azure.ResourceManager.DataMigration.Models.ExecutionStatistics targetResult = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.Quota Quota(double? currentValue = default(double?), string id = null, double? limit = default(double?), Azure.ResourceManager.DataMigration.Models.QuotaName name = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.QuotaName QuotaName(string localizedValue = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ReportableException ReportableException(string message = null, string actionableMessage = null, string filePath = null, string lineNumber = null, int? hResult = default(int?), string stackTrace = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSku ResourceSku(string resourceType = null, string name = null, string tier = null, string size = null, string family = null, string kind = null, Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity capacity = null, System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts> costs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities ResourceSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity ResourceSkuCapacity(long? minimum = default(long?), long? maximum = default(long?), long? @default = default(long?), Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType? scaleType = default(Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts ResourceSkuCosts(string meterId = null, long? quantity = default(long?), string extendedUnit = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions ResourceSkuRestrictions(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType? restrictionsType = default(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult SchemaComparisonValidationResult(Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType schemaDifferences = null, Azure.ResourceManager.DataMigration.Models.ValidationError validationErrors = null, System.Collections.Generic.IReadOnlyDictionary<string, long> sourceDatabaseObjectCount = null, System.Collections.Generic.IReadOnlyDictionary<string, long> targetDatabaseObjectCount = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType SchemaComparisonValidationResultType(string objectName = null, Azure.ResourceManager.DataMigration.Models.ObjectType? objectType = default(Azure.ResourceManager.DataMigration.Models.ObjectType?), Azure.ResourceManager.DataMigration.Models.UpdateActionType? updateAction = default(Azure.ResourceManager.DataMigration.Models.UpdateActionType?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ServerProperties ServerProperties(string serverPlatform = null, string serverName = null, string serverVersion = null, string serverEdition = null, string serverOperatingSystemVersion = null, int? serverDatabaseCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SourceLocation SourceLocation(Azure.ResourceManager.DataMigration.Models.SqlFileShare fileShare = null, Azure.ResourceManager.DataMigration.Models.AzureBlob azureBlob = null, string fileStorageType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo SqlBackupFileInfo(string fileName = null, string status = null, long? totalSize = default(long?), long? dataRead = default(long?), long? dataWritten = default(long?), double? copyThroughput = default(double?), int? copyDuration = default(int?), int? familySequenceNumber = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo SqlBackupSetInfo(System.Guid? backupSetId = default(System.Guid?), string firstLSN = null, string lastLSN = null, string backupType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo> listOfBackupFiles = null, System.DateTimeOffset? backupStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? backupFinishOn = default(System.DateTimeOffset?), bool? isBackupRestored = default(bool?), bool? hasBackupChecksums = default(bool?), int? familyCount = default(int?), System.Collections.Generic.IEnumerable<string> ignoreReasons = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails SqlDBMigrationStatusDetails(string migrationState = null, System.Collections.Generic.IEnumerable<string> sqlDataCopyErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails> listOfCopyProgressDetails = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.SqlMigrationServiceData SqlMigrationServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, string integrationRuntimeState = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent SyncMigrationDatabaseErrorEvent(string timestampString = null, string eventTypeString = null, string eventText = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput UploadOciDriverTaskOutput(string driverPackageName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties UploadOciDriverTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.FileShare inputDriverShare = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties ValidateMigrationInputSqlServerSqlDBSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput ValidateMigrationInputSqlServerSqlMISyncTaskOutput(string id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties ValidateMigrationInputSqlServerSqlMISyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput ValidateMigrationInputSqlServerSqlMITaskOutput(string id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> restoreDatabaseNameErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> backupFolderErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> backupShareCredentialsErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> backupStorageAccountErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> existingBackupErrors = null, Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo databaseBackupInfo = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties ValidateMigrationInputSqlServerSqlMITaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties ValidateMongoDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties ValidateOracleAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ODataError> errors = null, Azure.ResourceManager.DataMigration.Models.TaskState? state = default(Azure.ResourceManager.DataMigration.Models.TaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput ValidateOracleAzureDBPostgreSqlSyncTaskOutput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput ValidateSyncMigrationInputSqlServerTaskOutput(string id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidationError ValidationError(string text = null, Azure.ResourceManager.DataMigration.Models.Severity? severity = default(Azure.ResourceManager.DataMigration.Models.Severity?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.WaitStatistics WaitStatistics(string waitType = null, float? waitTimeMs = default(float?), long? waitCount = default(long?)) { throw null; }
    }
    public partial class AuthenticationKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AuthenticationKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AuthenticationKeys>
    {
        internal AuthenticationKeys() { }
        public string AuthKey1 { get { throw null; } }
        public string AuthKey2 { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.AuthenticationKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AuthenticationKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AuthenticationKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.AuthenticationKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AuthenticationKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AuthenticationKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AuthenticationKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AvailableServiceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSku>
    {
        internal AvailableServiceSku() { }
        public Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku Sku { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.AvailableServiceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.AvailableServiceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableServiceSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity>
    {
        internal AvailableServiceSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ServiceScalability? ScaleType { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableServiceSkuSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku>
    {
        internal AvailableServiceSkuSku() { }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AvailableServiceSkuSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureActiveDirectoryApp : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp>
    {
        public AzureActiveDirectoryApp() { }
        public string AppKey { get { throw null; } set { } }
        public string ApplicationId { get { throw null; } set { } }
        public bool? IgnoreAzurePermissions { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlob : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AzureBlob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AzureBlob>
    {
        public AzureBlob() { }
        public string AccountKey { get { throw null; } set { } }
        public string BlobContainerName { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.AzureBlob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AzureBlob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.AzureBlob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.AzureBlob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AzureBlob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AzureBlob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.AzureBlob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BackupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupConfiguration>
    {
        public BackupConfiguration() { }
        public Azure.ResourceManager.DataMigration.Models.SourceLocation SourceLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.TargetLocation TargetLocation { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.BackupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BackupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BackupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.BackupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BackupFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupFileInfo>
    {
        internal BackupFileInfo() { }
        public int? FamilySequenceNumber { get { throw null; } }
        public string FileLocation { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.BackupFileStatus? Status { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.BackupFileInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BackupFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BackupFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.BackupFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BackupSetInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BackupSetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupSetInfo>
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
        Azure.ResourceManager.DataMigration.Models.BackupSetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BackupSetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BackupSetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.BackupSetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupSetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupSetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BackupSetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BlobShare : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BlobShare>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BlobShare>
    {
        public BlobShare() { }
        public System.Uri SasUri { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.BlobShare System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BlobShare>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.BlobShare>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.BlobShare System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BlobShare>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BlobShare>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.BlobShare>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckOciDriverTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>
    {
        internal CheckOciDriverTaskOutput() { }
        public Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo InstalledDriver { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckOciDriverTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>
    {
        public CheckOciDriverTaskProperties() { }
        public string InputServerVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CommandProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CommandProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CommandProperties>
    {
        protected CommandProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ODataError> Errors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.CommandState? State { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.CommandProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CommandProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CommandProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CommandProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CommandProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CommandProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CommandProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class ConnectionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectionInfo>
    {
        protected ConnectionInfo() { }
        public string Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToMongoDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>
    {
        public ConnectToMongoDBTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceMySqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>
    {
        public ConnectToSourceMySqlTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo sourceConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.ServerLevelPermissionsGroup? CheckPermissionsGroup { get { throw null; } set { } }
        public bool? IsOfflineMigration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlTargetPlatformType? TargetPlatform { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceMySqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties>
    {
        public ConnectToSourceMySqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceNonSqlTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput>
    {
        internal ConnectToSourceNonSqlTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ServerProperties ServerProperties { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceOracleSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>
    {
        internal ConnectToSourceOracleSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceOracleSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties>
    {
        public ConnectToSourceOracleSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo InputSourceConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourcePostgreSqlSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>
    {
        internal ConnectToSourcePostgreSqlSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourcePostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>
    {
        public ConnectToSourcePostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo InputSourceConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>
    {
        public ConnectToSourceSqlServerSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput>
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
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ConnectToSourceSqlServerTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput>
    {
        protected ConnectToSourceSqlServerTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerTaskOutputAgentJobLevel : Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>
    {
        internal ConnectToSourceSqlServerTaskOutputAgentJobLevel() { }
        public bool? IsEnabled { get { throw null; } }
        public string JobCategory { get { throw null; } }
        public string JobOwner { get { throw null; } }
        public System.DateTimeOffset? LastExecutedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo MigrationEligibility { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel>
    {
        internal ConnectToSourceSqlServerTaskOutputDatabaseLevel() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseCompatLevel? CompatibilityLevel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo> DatabaseFiles { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseState? DatabaseState { get { throw null; } }
        public string Name { get { throw null; } }
        public double? SizeMB { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerTaskOutputLoginLevel : Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel>
    {
        internal ConnectToSourceSqlServerTaskOutputLoginLevel() { }
        public string DefaultDatabase { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.LoginType? LoginType { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo MigrationEligibility { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerTaskOutputTaskLevel : Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>
    {
        internal ConnectToSourceSqlServerTaskOutputTaskLevel() { }
        public string AgentJobs { get { throw null; } }
        public string Databases { get { throw null; } }
        public string DatabaseTdeCertificateMapping { get { throw null; } }
        public string Logins { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>
    {
        public ConnectToSourceSqlServerTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForMySqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput>
    {
        public ConnectToTargetAzureDBForMySqlTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo targetConnectionInfo) { }
        public bool? IsOfflineMigration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForMySqlTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>
    {
        internal ConnectToTargetAzureDBForMySqlTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public string ServerVersion { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForMySqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>
    {
        public ConnectToTargetAzureDBForMySqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForPostgreSqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput>
    {
        public ConnectToTargetAzureDBForPostgreSqlSyncTaskInput(Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo targetConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>
    {
        internal ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties>
    {
        public ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput>
    {
        internal ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> Databases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem> DatabaseSchemaMap { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>
    {
        internal ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem() { }
        public string Database { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Schemas { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>
    {
        public ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo InputTargetConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlDBSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>
    {
        public ConnectToTargetSqlDBSyncTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlDBSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>
    {
        public ConnectToTargetSqlDBSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlDBTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput>
    {
        public ConnectToTargetSqlDBTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo) { }
        public bool? QueryObjectCounts { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlDBTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>
    {
        internal ConnectToTargetSqlDBTaskOutput() { }
        public string Databases { get { throw null; } }
        public string Id { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>
    {
        public ConnectToTargetSqlDBTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMISyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput>
    {
        public ConnectToTargetSqlMISyncTaskInput(Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp azureApp) { }
        public Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp AzureApp { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMISyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>
    {
        internal ConnectToTargetSqlMISyncTaskOutput() { }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMISyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>
    {
        public ConnectToTargetSqlMISyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMITaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput>
    {
        public ConnectToTargetSqlMITaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo) { }
        public bool? CollectAgentJobs { get { throw null; } set { } }
        public bool? CollectLogins { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        public bool? ValidateSsisCatalogOnly { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMITaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>
    {
        internal ConnectToTargetSqlMITaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<string> AgentJobs { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Logins { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMITaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties>
    {
        public ConnectToTargetSqlMITaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CopyProgressDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>
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
        Azure.ResourceManager.DataMigration.Models.CopyProgressDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CopyProgressDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseBackupInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo>
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
        Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseBackupInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DatabaseFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo>
    {
        internal DatabaseFileInfo() { }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseFileType? FileType { get { throw null; } }
        public string Id { get { throw null; } }
        public string LogicalName { get { throw null; } }
        public string PhysicalFullName { get { throw null; } }
        public string RestoreFullName { get { throw null; } }
        public double? SizeMB { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DatabaseInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseInfo>
    {
        public DatabaseInfo(string sourceDatabaseName) { }
        public string SourceDatabaseName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.DatabaseInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigration : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>
    {
        public DatabaseMigration() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DatabaseMigrationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>
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
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationSqlDBProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>
    {
        public DatabaseMigrationSqlDBProperties() { }
        public Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails MigrationStatusDetails { get { throw null; } }
        public bool? Offline { get { throw null; } }
        public System.Collections.Generic.IList<string> TableList { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation TargetSqlConnection { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationSqlMIProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>
    {
        public DatabaseMigrationSqlMIProperties() { }
        public Azure.ResourceManager.DataMigration.Models.BackupConfiguration BackupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails MigrationStatusDetails { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.OfflineConfiguration OfflineConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationSqlVmProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties>
    {
        public DatabaseMigrationSqlVmProperties() { }
        public Azure.ResourceManager.DataMigration.Models.BackupConfiguration BackupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails MigrationStatusDetails { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.OfflineConfiguration OfflineConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DatabaseTable : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseTable>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseTable>
    {
        internal DatabaseTable() { }
        public bool? HasRows { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.DatabaseTable System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseTable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseTable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseTable System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseTable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseTable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseTable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataIntegrityValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>
    {
        internal DataIntegrityValidationResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FailedObjects { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationError ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationServiceStatusResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>
    {
        internal DataMigrationServiceStatusResponse() { }
        public System.BinaryData AgentConfiguration { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedTaskTypes { get { throw null; } }
        public string VmSize { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteNode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DeleteNode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DeleteNode>
    {
        public DeleteNode() { }
        public string IntegrationRuntimeName { get { throw null; } set { } }
        public string NodeName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.DeleteNode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DeleteNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DeleteNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DeleteNode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DeleteNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DeleteNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DeleteNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ErrorInfo>
    {
        internal ErrorInfo() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionStatistics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>
    {
        internal ExecutionStatistics() { }
        public float? CpuTimeMs { get { throw null; } }
        public float? ElapsedTimeMs { get { throw null; } }
        public long? ExecutionCount { get { throw null; } }
        public bool? HasErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.WaitStatistics> WaitStats { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ExecutionStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ExecutionStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShare : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.FileShare>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.FileShare>
    {
        public FileShare(string path) { }
        public string Password { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.FileShare System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.FileShare>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.FileShare>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.FileShare System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.FileShare>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.FileShare>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.FileShare>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileStorageInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.FileStorageInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.FileStorageInfo>
    {
        internal FileStorageInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.FileStorageInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.FileStorageInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.FileStorageInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.FileStorageInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.FileStorageInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.FileStorageInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.FileStorageInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTdeCertificatesSqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput>
    {
        public GetTdeCertificatesSqlTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo connectionInfo, Azure.ResourceManager.DataMigration.Models.FileShare backupFileShare, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput> selectedCertificates) { }
        public Azure.ResourceManager.DataMigration.Models.FileShare BackupFileShare { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput> SelectedCertificates { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTdeCertificatesSqlTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>
    {
        internal GetTdeCertificatesSqlTaskOutput() { }
        public string Base64EncodedCertificates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTdeCertificatesSqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>
    {
        public GetTdeCertificatesSqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesMySqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput>
    {
        public GetUserTablesMySqlTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedDatabases) { }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedDatabases { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesMySqlTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>
    {
        internal GetUserTablesMySqlTaskOutput() { }
        public string DatabasesToTables { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesMySqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>
    {
        public GetUserTablesMySqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesOracleTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput>
    {
        public GetUserTablesOracleTaskInput(Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedSchemas) { }
        public Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedSchemas { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesOracleTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>
    {
        internal GetUserTablesOracleTaskOutput() { }
        public string SchemaName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DatabaseTable> Tables { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesOracleTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>
    {
        public GetUserTablesOracleTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesPostgreSqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput>
    {
        public GetUserTablesPostgreSqlTaskInput(Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedDatabases) { }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedDatabases { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesPostgreSqlTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>
    {
        internal GetUserTablesPostgreSqlTaskOutput() { }
        public string DatabaseName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DatabaseTable> Tables { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesPostgreSqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>
    {
        public GetUserTablesPostgreSqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput>
    {
        public GetUserTablesSqlSyncTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<string> selectedSourceDatabases, System.Collections.Generic.IEnumerable<string> selectedTargetDatabases) { }
        public System.Collections.Generic.IList<string> SelectedSourceDatabases { get { throw null; } }
        public System.Collections.Generic.IList<string> SelectedTargetDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>
    {
        internal GetUserTablesSqlSyncTaskOutput() { }
        public string DatabasesToSourceTables { get { throw null; } }
        public string DatabasesToTargetTables { get { throw null; } }
        public string TableValidationErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>
    {
        public GetUserTablesSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput>
    {
        public GetUserTablesSqlTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedDatabases) { }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedDatabases { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>
    {
        internal GetUserTablesSqlTaskOutput() { }
        public string DatabasesToTables { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>
    {
        public GetUserTablesSqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstallOciDriverTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>
    {
        internal InstallOciDriverTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstallOciDriverTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>
    {
        public InstallOciDriverTaskProperties() { }
        public string InputDriverPackageName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationRuntimeMonitoringData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData>
    {
        internal IntegrationRuntimeMonitoringData() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData> Nodes { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MigrateMISyncCompleteCommandProperties : Azure.ResourceManager.DataMigration.Models.CommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>
    {
        public MigrateMISyncCompleteCommandProperties() { }
        public string InputSourceDatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> OutputErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMongoDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties>
    {
        public MigrateMongoDBTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBProgress> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineDatabaseInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>
    {
        public MigrateMySqlAzureDBForMySqlOfflineDatabaseInput() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TableMap { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput>
    {
        public MigrateMySqlAzureDBForMySqlOfflineTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput> selectedDatabases) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public bool? MakeSourceServerReadOnly { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> OptionalAgentSettings { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput>
    {
        protected MigrateMySqlAzureDBForMySqlOfflineTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError>
    {
        internal MigrateMySqlAzureDBForMySqlOfflineTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties>
    {
        public MigrateMySqlAzureDBForMySqlOfflineTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncDatabaseInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>
    {
        public MigrateMySqlAzureDBForMySqlSyncDatabaseInput() { }
        public System.Collections.Generic.IDictionary<string, string> MigrationSetting { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SourceSetting { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TableMap { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetSetting { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput>
    {
        public MigrateMySqlAzureDBForMySqlSyncTaskInput(Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput> selectedDatabases) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrateMySqlAzureDBForMySqlSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput>
    {
        protected MigrateMySqlAzureDBForMySqlSyncTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError>
    {
        internal MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError>
    {
        internal MigrateMySqlAzureDBForMySqlSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel>
    {
        internal MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServer { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string TargetServer { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>
    {
        public MigrateMySqlAzureDBForMySqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties>
    {
        public MigrateOracleAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncDatabaseInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>
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
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput>
    {
        public MigrateOracleAzureDBPostgreSqlSyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo sourceConnectionInfo) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput>
    {
        protected MigrateOracleAzureDBPostgreSqlSyncTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError>
    {
        internal MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError>
    {
        internal MigrateOracleAzureDBPostgreSqlSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel>
    {
        internal MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServer { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string TargetServer { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput>
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> MigrationSetting { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput> SelectedTables { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> SourceSetting { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TargetSetting { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput() { }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput>
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo sourceConnectionInfo) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput>
    {
        protected MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError>
    {
        internal MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError>
    {
        internal MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties>
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlServerSqlDBDatabaseInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>
    {
        public MigrateSchemaSqlServerSqlDBDatabaseInput() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting SchemaSetting { get { throw null; } set { } }
        public string TargetDatabaseName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput>
    {
        public MigrateSchemaSqlServerSqlDBTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput> selectedDatabases) : base (default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo)) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput> SelectedDatabases { get { throw null; } }
        public string StartedOn { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrateSchemaSqlServerSqlDBTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput>
    {
        protected MigrateSchemaSqlServerSqlDBTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError>
    {
        internal MigrateSchemaSqlServerSqlDBTaskOutputError() { }
        public string CommandText { get { throw null; } }
        public string ErrorText { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>
    {
        internal MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>
    {
        public MigrateSchemaSqlServerSqlDBTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError>
    {
        internal MigrateSchemaSqlTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBDatabaseInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput>
    {
        public MigrateSqlServerSqlDBDatabaseInput() { }
        public string Id { get { throw null; } set { } }
        public bool? MakeSourceDBReadOnly { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData SchemaSetting { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TableMap { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncDatabaseInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput>
    {
        public MigrateSqlServerSqlDBSyncTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> selectedDatabases) : base (default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions ValidationOptions { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrateSqlServerSqlDBSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput>
    {
        protected MigrateSqlServerSqlDBSyncTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputDatabaseError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError>
    {
        internal MigrateSqlServerSqlDBSyncTaskOutputDatabaseError() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError>
    {
        internal MigrateSqlServerSqlDBSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel>
    {
        internal MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel() { }
        public int? DatabaseCount { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string SourceServer { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string TargetServer { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>
    {
        public MigrateSqlServerSqlDBSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput>
    {
        public MigrateSqlServerSqlDBTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput> selectedDatabases) : base (default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo)) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput> SelectedDatabases { get { throw null; } }
        public string StartedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions ValidationOptions { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrateSqlServerSqlDBTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput>
    {
        protected MigrateSqlServerSqlDBTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError>
    {
        internal MigrateSqlServerSqlDBTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputTableLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputValidationResult : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>
    {
        internal MigrateSqlServerSqlDBTaskOutputValidationResult() { }
        public string MigrationId { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> SummaryResults { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties>
    {
        public MigrateSqlServerSqlDBTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMIDatabaseInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>
    {
        public MigrateSqlServerSqlMIDatabaseInput(string name, string restoreDatabaseName) { }
        public System.Collections.Generic.IList<string> BackupFilePaths { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.FileShare BackupFileShare { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string RestoreDatabaseName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMISyncTaskInput : Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput>
    {
        public MigrateSqlServerSqlMISyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, string storageResourceId, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp azureApp) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>), default(string), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp)) { }
        public float? NumberOfParallelDatabaseMigrations { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrateSqlServerSqlMISyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>
    {
        protected MigrateSqlServerSqlMISyncTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMISyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError>
    {
        internal MigrateSqlServerSqlMISyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMISyncTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMISyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>
    {
        public MigrateSqlServerSqlMISyncTaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrateSqlServerSqlMITaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput>
    {
        protected MigrateSqlServerSqlMITaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskOutputAgentJobLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel>
    {
        internal MigrateSqlServerSqlMITaskOutputAgentJobLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError>
    {
        internal MigrateSqlServerSqlMITaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.ReportableException Error { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskOutputLoginLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel>
    {
        internal MigrateSqlServerSqlMITaskOutputLoginLevel() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string LoginName { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.LoginMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationState? State { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>
    {
        public MigrateSqlServerSqlMITaskProperties() { }
        public string CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput> Output { get { throw null; } }
        public string ParentTaskId { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSsisTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput>
    {
        public MigrateSsisTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo ssisMigrationInfo) : base (default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo)) { }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo SsisMigrationInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrateSsisTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput>
    {
        protected MigrateSsisTaskOutput() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSsisTaskOutputMigrationLevel : Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSsisTaskOutputProjectLevel : Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>
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
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSsisTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>
    {
        public MigrateSsisTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSyncCompleteCommandInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>
    {
        public MigrateSyncCompleteCommandInput(string databaseName) { }
        public System.DateTimeOffset? CommitTimeStamp { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSyncCompleteCommandOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>
    {
        internal MigrateSyncCompleteCommandOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> Errors { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSyncCompleteCommandProperties : Azure.ResourceManager.DataMigration.Models.CommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties>
    {
        public MigrateSyncCompleteCommandProperties() { }
        public string CommandId { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput Input { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationEligibilityInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo>
    {
        internal MigrationEligibilityInfo() { }
        public bool? IsEligibleForMigration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ValidationMessages { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationOperationInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationOperationInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationOperationInput>
    {
        public MigrationOperationInput() { }
        public System.Guid? MigrationOperationId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrationOperationInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationOperationInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationOperationInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationOperationInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationOperationInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationOperationInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationOperationInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationReportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>
    {
        internal MigrationReportResult() { }
        public string Id { get { throw null; } }
        public System.Uri ReportUri { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrationReportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationReportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MigrationStatusDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails>
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
        Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationStatusDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationValidationDatabaseSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>
    {
        internal MigrationValidationDatabaseSummaryResult() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string MigrationId { get { throw null; } }
        public string SourceDatabaseName { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationStatus? Status { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationValidationOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions>
    {
        public MigrationValidationOptions() { }
        public bool? EnableDataIntegrityValidation { get { throw null; } set { } }
        public bool? EnableQueryAnalysisValidation { get { throw null; } set { } }
        public bool? EnableSchemaValidation { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>
    {
        internal MigrationValidationResult() { }
        public string Id { get { throw null; } }
        public string MigrationId { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> SummaryResults { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MISqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo>
    {
        public MISqlConnectionInfo(string managedInstanceResourceId) { }
        public string ManagedInstanceResourceId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBCancelCommand : Azure.ResourceManager.DataMigration.Models.CommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand>
    {
        public MongoDBCancelCommand() { }
        public string InputObjectName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCancelCommand>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBClusterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo>
    {
        internal MongoDBClusterInfo() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBClusterType ClusterType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo> Databases { get { throw null; } }
        public bool SupportsSharding { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBClusterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MongoDBCollectionInfo : Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo>
    {
        internal MongoDBCollectionInfo() { }
        public string DatabaseName { get { throw null; } }
        public bool IsCapped { get { throw null; } }
        public bool IsSystemCollection { get { throw null; } }
        public bool IsView { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo ShardKey { get { throw null; } }
        public bool SupportsSharding { get { throw null; } }
        public string ViewOf { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBCollectionProgress : Azure.ResourceManager.DataMigration.Models.MongoDBProgress, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress>
    {
        internal MongoDBCollectionProgress() : base (default(long), default(long), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError>), default(long), default(long), default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), default(long), default(long)) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBCollectionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings>
    {
        public MongoDBCollectionSettings() { }
        public bool? CanDelete { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting ShardKey { get { throw null; } set { } }
        public int? TargetRUs { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBCommandInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput>
    {
        public MongoDBCommandInput() { }
        public string ObjectName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo>
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
        Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBDatabaseInfo : Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo>
    {
        internal MongoDBDatabaseInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBCollectionInfo> Collections { get { throw null; } }
        public bool SupportsSharding { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBDatabaseProgress : Azure.ResourceManager.DataMigration.Models.MongoDBProgress, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress>
    {
        internal MongoDBDatabaseProgress() : base (default(long), default(long), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError>), default(long), default(long), default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), default(long), default(long)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBCollectionProgress> Collections { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBDatabaseSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings>
    {
        public MongoDBDatabaseSettings(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings> collections) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBCollectionSettings> Collections { get { throw null; } }
        public int? TargetRUs { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBError>
    {
        internal MongoDBError() { }
        public string Code { get { throw null; } }
        public int? Count { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBErrorType? ErrorType { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MongoDBError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MongoDBFinishCommand : Azure.ResourceManager.DataMigration.Models.CommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand>
    {
        public MongoDBFinishCommand() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput Input { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommand>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBFinishCommandInput : Azure.ResourceManager.DataMigration.Models.MongoDBCommandInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput>
    {
        public MongoDBFinishCommandInput(bool immediate) { }
        public bool Immediate { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBFinishCommandInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBMigrationProgress : Azure.ResourceManager.DataMigration.Models.MongoDBProgress, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress>
    {
        internal MongoDBMigrationProgress() : base (default(long), default(long), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBError>), default(long), default(long), default(Azure.ResourceManager.DataMigration.Models.MongoDBMigrationState), default(long), default(long)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseProgress> Databases { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBMigrationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings>
    {
        public MongoDBMigrationSettings(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings> databases, Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo source, Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo target) { }
        public int? BoostRUs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.MongoDBDatabaseSettings> Databases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBReplication? Replication { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo Source { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBConnectionInfo Target { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings Throttling { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MongoDBObjectInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo>
    {
        internal MongoDBObjectInfo() { }
        public long AverageDocumentSize { get { throw null; } }
        public long DataSize { get { throw null; } }
        public long DocumentCount { get { throw null; } }
        public string Name { get { throw null; } }
        public string QualifiedName { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBObjectInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MongoDBProgress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBProgress>
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
        Azure.ResourceManager.DataMigration.Models.MongoDBProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MongoDBRestartCommand : Azure.ResourceManager.DataMigration.Models.CommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand>
    {
        public MongoDBRestartCommand() { }
        public string InputObjectName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBRestartCommand>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBShardKeyField : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField>
    {
        public MongoDBShardKeyField(string name, Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder order) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyOrder Order { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBShardKeyInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo>
    {
        internal MongoDBShardKeyInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField> Fields { get { throw null; } }
        public bool IsUnique { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MongoDBShardKeySetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting>
    {
        public MongoDBShardKeySetting(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField> fields) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeyField> Fields { get { throw null; } }
        public bool? IsUnique { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBShardKeySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBThrottlingSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings>
    {
        public MongoDBThrottlingSettings() { }
        public int? MaxParallelism { get { throw null; } set { } }
        public int? MinFreeCpu { get { throw null; } set { } }
        public int? MinFreeMemoryMb { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MongoDBThrottlingSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo>
    {
        public MySqlConnectionInfo(string serverName, int port) { }
        public string AdditionalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.AuthenticationType? Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public bool? EncryptConnection { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MySqlConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NameAvailabilityRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest>
    {
        public NameAvailabilityRequest() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NameAvailabilityResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>
    {
        internal NameAvailabilityResponse() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.NameCheckFailureReason? Reason { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NameAvailabilityResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NodeMonitoringData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData>
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
        Azure.ResourceManager.DataMigration.Models.NodeMonitoringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.NodeMonitoringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.NodeMonitoringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ODataError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ODataError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ODataError>
    {
        internal ODataError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ODataError> Details { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ODataError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ODataError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ODataError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ODataError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ODataError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ODataError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ODataError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfflineConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OfflineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OfflineConfiguration>
    {
        public OfflineConfiguration() { }
        public string LastBackupName { get { throw null; } set { } }
        public bool? Offline { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.OfflineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OfflineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OfflineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.OfflineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OfflineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OfflineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OfflineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo>
    {
        public OracleConnectionInfo(string dataSource) { }
        public Azure.ResourceManager.DataMigration.Models.AuthenticationType? Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OracleConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleOciDriverInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo>
    {
        internal OracleOciDriverInfo() { }
        public string ArchiveChecksum { get { throw null; } }
        public string AssemblyVersion { get { throw null; } }
        public string DriverName { get { throw null; } }
        public string DriverSize { get { throw null; } }
        public string OracleChecksum { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedOracleVersions { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OracleOciDriverInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrphanedUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo>
    {
        internal OrphanedUserInfo() { }
        public string DatabaseName { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.OrphanedUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo>
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
        Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.PostgreSqlConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectFileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ProjectFileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ProjectFileProperties>
    {
        public ProjectFileProperties() { }
        public string Extension { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string MediaType { get { throw null; } set { } }
        public long? Size { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ProjectFileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ProjectFileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ProjectFileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ProjectFileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ProjectFileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ProjectFileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ProjectFileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class ProjectTaskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties>
    {
        protected ProjectTaskProperties() { }
        public System.Collections.Generic.IDictionary<string, string> ClientData { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.CommandProperties> Commands { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ODataError> Errors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.TaskState? State { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryAnalysisValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult>
    {
        internal QueryAnalysisValidationResult() { }
        public Azure.ResourceManager.DataMigration.Models.QueryExecutionResult QueryResults { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationError ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryExecutionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>
    {
        internal QueryExecutionResult() { }
        public string QueryText { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ExecutionStatistics SourceResult { get { throw null; } }
        public long? StatementsInBatch { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ExecutionStatistics TargetResult { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.QueryExecutionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.QueryExecutionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Quota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.Quota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.Quota>
    {
        internal Quota() { }
        public double? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public double? Limit { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.QuotaName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.Quota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.Quota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.Quota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.Quota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.Quota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.Quota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.Quota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QuotaName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QuotaName>
    {
        internal QuotaName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.QuotaName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QuotaName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QuotaName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.QuotaName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QuotaName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QuotaName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QuotaName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegenAuthKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.RegenAuthKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.RegenAuthKeys>
    {
        public RegenAuthKeys() { }
        public string AuthKey1 { get { throw null; } set { } }
        public string AuthKey2 { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.RegenAuthKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.RegenAuthKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.RegenAuthKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.RegenAuthKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.RegenAuthKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.RegenAuthKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.RegenAuthKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ReportableException : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ReportableException>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ReportableException>
    {
        internal ReportableException() { }
        public string ActionableMessage { get { throw null; } }
        public string FilePath { get { throw null; } }
        public int? HResult { get { throw null; } }
        public string LineNumber { get { throw null; } }
        public string Message { get { throw null; } }
        public string StackTrace { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ReportableException System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ReportableException>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ReportableException>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ReportableException System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ReportableException>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ReportableException>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ReportableException>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSku>
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
        Azure.ResourceManager.DataMigration.Models.ResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities>
    {
        internal ResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity>
    {
        internal ResourceSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResourceSkuCosts : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts>
    {
        internal ResourceSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuCosts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions>
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SchemaComparisonValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult>
    {
        internal SchemaComparisonValidationResult() { }
        public Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType SchemaDifferences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, long> SourceDatabaseObjectCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, long> TargetDatabaseObjectCount { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ValidationError ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaComparisonValidationResultType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType>
    {
        internal SchemaComparisonValidationResultType() { }
        public string ObjectName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ObjectType? ObjectType { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.UpdateActionType? UpdateAction { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SchemaMigrationSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting>
    {
        public SchemaMigrationSetting() { }
        public string FileId { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SchemaMigrationOption? SchemaOption { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaMigrationSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SelectedCertificateInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>
    {
        public SelectedCertificateInput(string certificateName, string password) { }
        public string CertificateName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ServerLevelPermissionsGroup
    {
        Default = 0,
        MigrationFromSqlServerToAzureDB = 1,
        MigrationFromSqlServerToAzureMI = 2,
        MigrationFromMySqlToAzureDBForMySql = 3,
        MigrationFromSqlServerToAzureVm = 4,
    }
    public partial class ServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServerProperties>
    {
        internal ServerProperties() { }
        public int? ServerDatabaseCount { get { throw null; } }
        public string ServerEdition { get { throw null; } }
        public string ServerName { get { throw null; } }
        public string ServerOperatingSystemVersion { get { throw null; } }
        public string ServerPlatform { get { throw null; } }
        public string ServerVersion { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ServiceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ServiceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServiceSku>
    {
        public ServiceSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ServiceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ServiceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ServiceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ServiceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServiceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServiceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServiceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SourceLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SourceLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SourceLocation>
    {
        public SourceLocation() { }
        public Azure.ResourceManager.DataMigration.Models.AzureBlob AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlFileShare FileShare { get { throw null; } set { } }
        public string FileStorageType { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.SourceLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SourceLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SourceLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SourceLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SourceLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SourceLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SourceLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlBackupFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo>
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
        Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlBackupFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlBackupSetInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo>
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
        Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlBackupSetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo>
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
        Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlConnectionInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation>
    {
        public SqlConnectionInformation() { }
        public string Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public bool? EncryptConnection { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public bool? TrustServerCertificate { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlConnectionInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDBMigrationStatusDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails>
    {
        internal SqlDBMigrationStatusDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails> ListOfCopyProgressDetails { get { throw null; } }
        public string MigrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlDataCopyErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlDBMigrationStatusDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlFileShare : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlFileShare>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlFileShare>
    {
        public SqlFileShare() { }
        public string Password { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.SqlFileShare System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlFileShare>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlFileShare>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlFileShare System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlFileShare>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlFileShare>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlFileShare>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMigrationServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>
    {
        public SqlMigrationServicePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMigrationTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>
    {
        public SqlMigrationTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerSqlMISyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>
    {
        public SqlServerSqlMISyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, string storageResourceId, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp azureApp) { }
        public Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp AzureApp { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.FileShare BackupFileShare { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public string StorageResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SsisMigrationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo>
    {
        public SsisMigrationInfo() { }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption? EnvironmentOverwriteOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption? ProjectOverwriteOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SsisStoreType? SsisStoreType { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SyncMigrationDatabaseErrorEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent>
    {
        internal SyncMigrationDatabaseErrorEvent() { }
        public string EventText { get { throw null; } }
        public string EventTypeString { get { throw null; } }
        public string TimestampString { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TargetLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.TargetLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.TargetLocation>
    {
        public TargetLocation() { }
        public string AccountKey { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.TargetLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.TargetLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.TargetLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.TargetLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.TargetLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.TargetLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.TargetLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class UploadOciDriverTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>
    {
        internal UploadOciDriverTaskOutput() { }
        public string DriverPackageName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UploadOciDriverTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>
    {
        public UploadOciDriverTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.FileShare InputDriverShare { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlDBSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>
    {
        public ValidateMigrationInputSqlServerSqlDBSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMISyncTaskInput : Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput>
    {
        public ValidateMigrationInputSqlServerSqlMISyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, string storageResourceId, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp azureApp) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>), default(string), default(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.MISqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.AzureActiveDirectoryApp)) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMISyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>
    {
        internal ValidateMigrationInputSqlServerSqlMISyncTaskOutput() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMISyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>
    {
        public ValidateMigrationInputSqlServerSqlMISyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMITaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>
    {
        public ValidateMigrationInputSqlServerSqlMITaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.BlobShare backupBlobShare) { }
        public System.Uri BackupBlobShareSasUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.FileShare BackupFileShare { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.BackupMode? BackupMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> SelectedDatabases { get { throw null; } }
        public System.Collections.Generic.IList<string> SelectedLogins { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMITaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>
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
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMITaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>
    {
        public ValidateMigrationInputSqlServerSqlMITaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMongoDBTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>
    {
        public ValidateMongoDBTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MongoDBMigrationSettings Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MongoDBMigrationProgress> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateOracleAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.ProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>
    {
        public ValidateOracleAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateOracleAzureDBPostgreSqlSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>
    {
        internal ValidateOracleAzureDBPostgreSqlSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateSyncMigrationInputSqlServerTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput>
    {
        public ValidateSyncMigrationInputSqlServerTaskInput(Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> selectedDatabases) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateSyncMigrationInputSqlServerTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>
    {
        internal ValidateSyncMigrationInputSqlServerTaskOutput() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ReportableException> ValidationErrors { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidationError>
    {
        internal ValidationError() { }
        public Azure.ResourceManager.DataMigration.Models.Severity? Severity { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.ValidationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class WaitStatistics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.WaitStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.WaitStatistics>
    {
        internal WaitStatistics() { }
        public long? WaitCount { get { throw null; } }
        public float? WaitTimeMs { get { throw null; } }
        public string WaitType { get { throw null; } }
        Azure.ResourceManager.DataMigration.Models.WaitStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.WaitStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.WaitStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.WaitStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.WaitStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.WaitStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.WaitStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
