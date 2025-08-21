namespace Azure.ResourceManager.DataMigration
{
    public partial class AzureResourceManagerDataMigrationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDataMigrationContext() { }
        public static Azure.ResourceManager.DataMigration.AzureResourceManagerDataMigrationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationSqlDBResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>
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
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationSqlMIResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>
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
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationSqlVmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>
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
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataMigrationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult> CheckDataMigrationNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>> CheckDataMigrationNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource GetDataMigrationProjectFileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationProjectResource GetDataMigrationProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> GetDataMigrationServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationServiceResource GetDataMigrationServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationServiceCollection GetDataMigrationServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource GetDataMigrationServiceTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.ServiceServiceTaskResource GetServiceServiceTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataMigration.Models.DataMigrationSku> GetSkusResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.DataMigrationSku> GetSkusResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> GetSqlMigrationServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlMigrationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataMigration.SqlMigrationServiceResource GetSqlMigrationServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataMigration.SqlMigrationServiceCollection GetSqlMigrationServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataMigrationProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>, System.Collections.IEnumerable
    {
        protected DataMigrationProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DataMigration.DataMigrationProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DataMigration.DataMigrationProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataMigrationProjectData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>
    {
        public DataMigrationProjectData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp AzureAuthenticationInfo { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo> DatabasesInfo { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform? SourcePlatform { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform? TargetPlatform { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationProjectFileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>, System.Collections.IEnumerable
    {
        protected DataMigrationProjectFileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fileName, Azure.ResourceManager.DataMigration.DataMigrationProjectFileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fileName, Azure.ResourceManager.DataMigration.DataMigrationProjectFileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> Get(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>> GetAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> GetIfExists(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>> GetIfExistsAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataMigrationProjectFileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>
    {
        public DataMigrationProjectFileData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectFileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectFileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationProjectFileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMigrationProjectFileResource() { }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationProjectFileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName, string projectName, string fileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo> Read(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo>> ReadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo> ReadWrite(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo>> ReadWriteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataMigration.DataMigrationProjectFileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectFileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectFileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> Update(Azure.ResourceManager.DataMigration.DataMigrationProjectFileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>> UpdateAsync(Azure.ResourceManager.DataMigration.DataMigrationProjectFileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataMigrationProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMigrationProjectResource() { }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource> GetDataMigrationProjectFile(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource>> GetDataMigrationProjectFileAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationProjectFileCollection GetDataMigrationProjectFiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> GetDataMigrationServiceTask(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>> GetDataMigrationServiceTaskAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationServiceTaskCollection GetDataMigrationServiceTasks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataMigration.DataMigrationProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> Update(Azure.ResourceManager.DataMigration.DataMigrationProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>> UpdateAsync(Azure.ResourceManager.DataMigration.DataMigrationProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataMigrationProjectTaskData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>
    {
        public DataMigrationProjectTaskData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public bool? ShouldDeleteResourcesOnStop { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku Sku { get { throw null; } set { } }
        public string VirtualNicId { get { throw null; } set { } }
        public string VirtualSubnetId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMigrationServiceResource() { }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult> CheckDataMigrationServiceNameAvailability(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>> CheckDataMigrationServiceNameAvailabilityAsync(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse> CheckStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>> CheckStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource> GetDataMigrationProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationProjectResource>> GetDataMigrationProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationProjectCollection GetDataMigrationProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> GetServiceServiceTask(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> GetServiceServiceTaskAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.ServiceServiceTaskCollection GetServiceServiceTasks() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataMigration.DataMigrationServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DataMigrationServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataMigration.DataMigrationServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataMigrationServiceTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>, System.Collections.IEnumerable
    {
        protected DataMigrationServiceTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> Get(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> GetAll(string taskType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> GetAllAsync(string taskType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>> GetAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> GetIfExists(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>> GetIfExistsAsync(string taskName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataMigrationServiceTaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMigrationServiceTaskResource() { }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> Command(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties dataMigrationCommandProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties>> CommandAsync(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties dataMigrationCommandProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName, string projectName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource> Update(Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource>> UpdateAsync(Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceServiceTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>, System.Collections.IEnumerable
    {
        protected ServiceServiceTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ServiceServiceTaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceServiceTaskResource() { }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groupName, string serviceName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? deleteRunningTasks = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource> Update(Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.ServiceServiceTaskResource>> UpdateAsync(Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.SqlMigrationServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.SqlMigrationServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMigrationServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>
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
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult> DeleteNode(Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult deletedIntegrationRuntimeNodeResult, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult>> DeleteNodeAsync(Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult deletedIntegrationRuntimeNodeResult, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys> GetAuthKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys>> GetAuthKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.DatabaseMigration> GetMigrations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.DatabaseMigration> GetMigrationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult> GetMonitoringData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult>> GetMonitoringDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys> RegenerateAuthKeys(Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys sqlMigrationRegenAuthKeys, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys>> RegenerateAuthKeysAsync(Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys sqlMigrationRegenAuthKeys, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataMigration.SqlMigrationServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.SqlMigrationServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.SqlMigrationServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.DataMigration.DataMigrationProjectFileResource GetDataMigrationProjectFileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationProjectResource GetDataMigrationProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationServiceResource GetDataMigrationServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataMigration.DataMigrationServiceTaskResource GetDataMigrationServiceTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult> CheckDataMigrationNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>> CheckDataMigrationNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.DataMigrationServiceResource> GetDataMigrationServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.DataMigrationSku> GetSkusResourceSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.DataMigrationSku> GetSkusResourceSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.SqlMigrationServiceResource> GetSqlMigrationServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota> GetUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota> GetUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataMigration.Models
{
    public static partial class ArmDataMigrationModelFactory
    {
        public static Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput CheckOciDriverTaskOutput(Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo installedDriver = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties CheckOciDriverTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, string inputServerVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties ConnectToMongoDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties ConnectToSourceMySqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput ConnectToSourceNonSqlTaskOutput(string id = null, string sourceServerBrandVersion = null, Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties serverProperties = null, System.Collections.Generic.IEnumerable<string> databases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput ConnectToSourceOracleSyncTaskOutput(string sourceServerVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string sourceServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties ConnectToSourceOracleSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo inputSourceConnectionInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput ConnectToSourcePostgreSqlSyncTaskOutput(string id = null, string sourceServerVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string sourceServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties ConnectToSourcePostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo inputSourceConnectionInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties ConnectToSourceSqlServerSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput ConnectToSourceSqlServerTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel ConnectToSourceSqlServerTaskOutputAgentJobLevel(string id = null, string name = null, string jobCategory = null, bool? isEnabled = default(bool?), string jobOwner = null, System.DateTimeOffset? lastExecutedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null, Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo migrationEligibility = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel ConnectToSourceSqlServerTaskOutputDatabaseLevel(string id = null, string name = null, double? sizeMB = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo> databaseFiles = null, Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel? compatibilityLevel = default(Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel?), Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState? databaseState = default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputLoginLevel ConnectToSourceSqlServerTaskOutputLoginLevel(string id = null, string name = null, Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType? loginType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType?), string defaultDatabase = null, bool? isEnabled = default(bool?), Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo migrationEligibility = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel ConnectToSourceSqlServerTaskOutputTaskLevel(string id = null, string databases = null, string logins = null, string agentJobs = null, string databaseTdeCertificateMapping = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties ConnectToSourceSqlServerTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> output = null, string taskId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput ConnectToTargetAzureDBForMySqlTaskOutput(string id = null, string serverVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties ConnectToTargetAzureDBForMySqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput(string id = null, string targetServerVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput(string targetServerVersion = null, System.Collections.Generic.IEnumerable<string> databases = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem> databaseSchemaMap = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem(string database = null, System.Collections.Generic.IEnumerable<string> schemas = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo inputTargetConnectionInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties ConnectToTargetSqlDBSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput ConnectToTargetSqlDBTaskOutput(string id = null, string databases = null, string targetServerVersion = null, string targetServerBrandVersion = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties ConnectToTargetSqlDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> output = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput ConnectToTargetSqlMISyncTaskOutput(string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties ConnectToTargetSqlMISyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput ConnectToTargetSqlMITaskOutput(string id = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<string> logins = null, System.Collections.Generic.IEnumerable<string> agentJobs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties ConnectToTargetSqlMITaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.CopyProgressDetails CopyProgressDetails(string tableName = null, string status = null, string parallelCopyType = null, int? usedParallelCopies = default(int?), long? dataRead = default(long?), long? dataWritten = default(long?), long? rowsRead = default(long?), long? rowsCopied = default(long?), System.DateTimeOffset? copyStartOn = default(System.DateTimeOffset?), double? copyThroughput = default(double?), int? copyDuration = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigration DatabaseMigration(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties DatabaseMigrationBaseProperties(string kind = null, string scope = null, Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState? provisioningState = default(Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState?), string migrationStatus = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier migrationService = null, string migrationOperationId = null, Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo migrationFailureError = null, string provisioningError = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties DatabaseMigrationProperties(string scope = null, Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState? provisioningState = default(Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState?), string migrationStatus = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier migrationService = null, string migrationOperationId = null, Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo migrationFailureError = null, string provisioningError = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation sourceSqlConnection = null, string sourceDatabaseName = null, string sourceServerName = null, string targetDatabaseCollation = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlDBData DatabaseMigrationSqlDBData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties DatabaseMigrationSqlDBProperties(string scope = null, Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState? provisioningState = default(Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState?), string migrationStatus = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier migrationService = null, string migrationOperationId = null, Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo migrationFailureError = null, string provisioningError = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation sourceSqlConnection = null, string sourceDatabaseName = null, string sourceServerName = null, string targetDatabaseCollation = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails migrationStatusDetails = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation targetSqlConnection = null, bool? isOfflineMigration = default(bool?), System.Collections.Generic.IEnumerable<string> tableList = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlMIData DatabaseMigrationSqlMIData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties DatabaseMigrationSqlMIProperties(string scope = null, Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState? provisioningState = default(Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState?), string migrationStatus = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier migrationService = null, string migrationOperationId = null, Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo migrationFailureError = null, string provisioningError = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation sourceSqlConnection = null, string sourceDatabaseName = null, string sourceServerName = null, string targetDatabaseCollation = null, Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails migrationStatusDetails = null, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration backupConfiguration = null, Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration offlineConfiguration = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.DatabaseMigrationSqlVmData DatabaseMigrationSqlVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties DatabaseMigrationSqlVmProperties(string scope = null, Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState? provisioningState = default(Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState?), string migrationStatus = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier migrationService = null, string migrationOperationId = null, Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo migrationFailureError = null, string provisioningError = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation sourceSqlConnection = null, string sourceDatabaseName = null, string sourceServerName = null, string targetDatabaseCollation = null, Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails migrationStatusDetails = null, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration backupConfiguration = null, Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration offlineConfiguration = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult DataIntegrityValidationResult(System.Collections.Generic.IReadOnlyDictionary<string, string> failedObjects = null, Azure.ResourceManager.DataMigration.Models.MigrationValidationError validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku DataMigrationAvailableServiceSku(string resourceType = null, Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails sku = null, Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity DataMigrationAvailableServiceSkuCapacity(int? minimum = default(int?), int? maximum = default(int?), int? @default = default(int?), Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability? scaleType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails DataMigrationAvailableServiceSkuDetails(string name = null, string family = null, string size = null, string tier = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo DataMigrationBackupFileInfo(string fileLocation = null, int? familySequenceNumber = default(int?), Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus? status = default(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo DataMigrationBackupSetInfo(string backupSetId = null, string firstLsn = null, string lastLsn = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType? backupType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo> listOfBackupFiles = null, string databaseName = null, System.DateTimeOffset? backupStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? backupFinishedOn = default(System.DateTimeOffset?), bool? isBackupRestored = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation DataMigrationBackupSourceLocation(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare fileShare = null, Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails azureBlob = null, string fileStorageType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties DataMigrationCommandProperties(string commandType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo DataMigrationDatabaseBackupInfo(string databaseName = null, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType? backupType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType?), System.Collections.Generic.IEnumerable<string> backupFiles = null, int? position = default(int?), bool? isDamaged = default(bool?), bool? isCompressed = default(bool?), int? familyCount = default(int?), System.DateTimeOffset? backupFinishedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo DataMigrationDatabaseFileInfo(string databaseName = null, string id = null, string logicalName = null, string physicalFullName = null, string restoreFullName = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType? fileType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType?), double? sizeMB = default(double?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable DataMigrationDatabaseTable(bool? hasRows = default(bool?), string name = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo DataMigrationFileStorageInfo(System.Uri uri = null, System.Collections.Generic.IReadOnlyDictionary<string, string> headers = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand DataMigrationMongoDBCancelCommand(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState?), string inputObjectName = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo DataMigrationMongoDBClusterInfo(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo> databases = null, bool isShardingSupported = false, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType clusterType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType), string version = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo DataMigrationMongoDBCollectionInfo(long averageDocumentSize = (long)0, long dataSize = (long)0, long documentCount = (long)0, string name = null, string qualifiedName = null, string databaseName = null, bool isCapped = false, bool isSystemCollection = false, bool isView = false, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo shardKey = null, bool isShardingSupported = false, string viewOf = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress DataMigrationMongoDBCollectionProgress(long bytesCopied = (long)0, long documentsCopied = (long)0, string elapsedTime = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError> errors = null, long eventsPending = (long)0, long eventsReplayed = (long)0, System.DateTimeOffset? lastEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastReplayOn = default(System.DateTimeOffset?), string name = null, string qualifiedName = null, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState), long totalBytes = (long)0, long totalDocuments = (long)0) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo DataMigrationMongoDBDatabaseInfo(long averageDocumentSize = (long)0, long dataSize = (long)0, long documentCount = (long)0, string name = null, string qualifiedName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo> collections = null, bool isShardingSupported = false) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress DataMigrationMongoDBDatabaseProgress(long bytesCopied = (long)0, long documentsCopied = (long)0, string elapsedTime = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError> errors = null, long eventsPending = (long)0, long eventsReplayed = (long)0, System.DateTimeOffset? lastEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastReplayOn = default(System.DateTimeOffset?), string name = null, string qualifiedName = null, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState), long totalBytes = (long)0, long totalDocuments = (long)0, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress> collections = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError DataMigrationMongoDBError(string code = null, int? count = default(int?), string message = null, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType? errorType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand DataMigrationMongoDBFinishCommand(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState?), Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput input = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress DataMigrationMongoDBMigrationProgress(long bytesCopied = (long)0, long documentsCopied = (long)0, string elapsedTime = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError> errors = null, long eventsPending = (long)0, long eventsReplayed = (long)0, System.DateTimeOffset? lastEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastReplayOn = default(System.DateTimeOffset?), string name = null, string qualifiedName = null, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState), long totalBytes = (long)0, long totalDocuments = (long)0, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress> databases = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo DataMigrationMongoDBObjectInfo(long averageDocumentSize = (long)0, long dataSize = (long)0, long documentCount = (long)0, string name = null, string qualifiedName = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress DataMigrationMongoDBProgress(long bytesCopied = (long)0, long documentsCopied = (long)0, string elapsedTime = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError> errors = null, long eventsPending = (long)0, long eventsReplayed = (long)0, System.DateTimeOffset? lastEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastReplayOn = default(System.DateTimeOffset?), string name = null, string qualifiedName = null, string resultType = null, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState), long totalBytes = (long)0, long totalDocuments = (long)0) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand DataMigrationMongoDBRestartCommand(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState?), string inputObjectName = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo DataMigrationMongoDBShardKeyInfo(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField> fields = null, bool isUnique = false) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties DataMigrationMySqlServerProperties(string serverPlatform = null, string serverName = null, string serverVersion = null, string serverEdition = null, string serverOperatingSystemVersion = null, int? serverDatabaseCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationODataError DataMigrationODataError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> details = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo DataMigrationOracleOciDriverInfo(string driverName = null, string driverSize = null, string archiveChecksum = null, string oracleChecksum = null, string assemblyVersion = null, System.Collections.Generic.IEnumerable<string> supportedOracleVersions = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationProjectData DataMigrationProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform? sourcePlatform = default(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform?), Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp azureAuthenticationInfo = null, Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform? targetPlatform = default(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo sourceConnectionInfo = null, Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo targetConnectionInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo> databasesInfo = null, Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState? provisioningState = default(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationProjectFileData DataMigrationProjectFileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties DataMigrationProjectFileProperties(string extension = null, string filePath = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string mediaType = null, long? size = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationProjectTaskData DataMigrationProjectTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties DataMigrationProjectTaskProperties(string taskType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationQuota DataMigrationQuota(double? currentValue = default(double?), string id = null, double? limit = default(double?), Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName name = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName DataMigrationQuotaName(string localizedValue = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException DataMigrationReportableException(string message = null, string actionableMessage = null, string filePath = null, string lineNumber = null, int? hResult = default(int?), string stackTrace = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.DataMigrationServiceData DataMigrationServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), string kind = null, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku sku = null, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState? provisioningState = default(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState?), string publicKey = null, string virtualSubnetId = null, string virtualNicId = null, string autoStopDelay = null, bool? shouldDeleteResourcesOnStop = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult DataMigrationServiceNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason? reason = default(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse DataMigrationServiceStatusResponse(string agentVersion = null, System.BinaryData agentConfiguration = null, string status = null, string vmSize = null, System.Collections.Generic.IEnumerable<string> supportedTaskTypes = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSku DataMigrationSku(string resourceType = null, string name = null, string tier = null, string size = null, string family = null, string kind = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity capacity = null, System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts> costs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities DataMigrationSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity DataMigrationSkuCapacity(long? minimum = default(long?), long? maximum = default(long?), long? @default = default(long?), Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType? scaleType = default(Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts DataMigrationSkuCosts(string meterId = null, long? quantity = default(long?), string extendedUnit = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions DataMigrationSkuRestrictions(Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType? restrictionsType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo DataMigrationSqlBackupFileInfo(string fileName = null, string status = null, long? totalSize = default(long?), long? dataRead = default(long?), long? dataWritten = default(long?), double? copyThroughput = default(double?), int? copyDuration = default(int?), int? familySequenceNumber = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo DataMigrationSqlBackupSetInfo(System.Guid? backupSetId = default(System.Guid?), string firstLSN = null, string lastLSN = null, string backupType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo> listOfBackupFiles = null, System.DateTimeOffset? backupStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? backupFinishOn = default(System.DateTimeOffset?), bool? isBackupRestored = default(bool?), bool? hasBackupChecksums = default(bool?), int? familyCount = default(int?), System.Collections.Generic.IEnumerable<string> ignoreReasons = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails DataMigrationSqlDBMigrationStatusDetails(string migrationState = null, System.Collections.Generic.IEnumerable<string> sqlDataCopyErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails> listOfCopyProgressDetails = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo DataMigrationSqlServerOrphanedUserInfo(string name = null, string databaseName = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails DataMigrationStatusDetails(string migrationState = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo fullBackupSetInfo = null, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo lastRestoredBackupSetInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo> activeBackupSets = null, System.Collections.Generic.IEnumerable<string> invalidFiles = null, string blobContainerName = null, bool? isFullBackupRestored = default(bool?), string restoreBlockingReason = null, string completeRestoreErrorMessage = null, System.Collections.Generic.IEnumerable<string> fileUploadBlockingErrors = null, string currentRestoringFilename = null, string lastRestoredFilename = null, int? pendingLogBackupsCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ExecutionStatistics ExecutionStatistics(long? executionCount = default(long?), float? cpuTimeInMilliseconds = default(float?), float? elapsedTimeInMilliseconds = default(float?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics> waitStats = null, bool? hasErrors = default(bool?), System.Collections.Generic.IEnumerable<string> sqlErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput GetTdeCertificatesSqlTaskOutput(string base64EncodedCertificates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties GetTdeCertificatesSqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput GetUserTablesMySqlTaskOutput(string id = null, string databasesToTables = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties GetUserTablesMySqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput GetUserTablesOracleTaskOutput(string schemaName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable> tables = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties GetUserTablesOracleTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput GetUserTablesPostgreSqlTaskOutput(string databaseName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable> tables = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties GetUserTablesPostgreSqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput GetUserTablesSqlSyncTaskOutput(string databasesToSourceTables = null, string databasesToTargetTables = null, string tableValidationErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties GetUserTablesSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput GetUserTablesSqlTaskOutput(string id = null, string databasesToTables = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties GetUserTablesSqlTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput> output = null, string taskId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput InstallOciDriverTaskOutput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties InstallOciDriverTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, string inputDriverPackageName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode IntegrationRuntimeMonitoringNode(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null, string nodeName = null, int? availableMemoryInMB = default(int?), int? cpuUtilization = default(int?), int? concurrentJobsLimit = default(int?), int? concurrentJobsRunning = default(int?), int? maxConcurrentJobs = default(int?), double? sentBytes = default(double?), double? receivedBytes = default(double?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult IntegrationRuntimeMonitoringResult(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode> nodes = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties MigrateMISyncCompleteCommandProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState?), string inputSourceDatabaseName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> outputErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties MigrateMongoDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput MigrateMySqlAzureDBForMySqlOfflineTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage?), string statusMessage = null, string message = null, long? numberOfObjects = default(long?), long? numberOfObjectsCompleted = default(long?), long? errorCount = default(long?), string errorPrefix = null, string resultPrefix = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null, System.DateTimeOffset? lastStorageUpdatedOn = default(System.DateTimeOffset?), string objectSummary = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError MigrateMySqlAzureDBForMySqlOfflineTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel MigrateMySqlAzureDBForMySqlOfflineTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), long? durationInSeconds = default(long?), Azure.ResourceManager.DataMigration.Models.DataMigrationStatus? status = default(Azure.ResourceManager.DataMigration.Models.DataMigrationStatus?), string statusMessage = null, string message = null, string databases = null, string databaseSummary = null, Azure.ResourceManager.DataMigration.Models.MigrationReportResult migrationReportResult = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null, System.DateTimeOffset? lastStorageUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel(string id = null, string objectName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), string statusMessage = null, long? itemsCount = default(long?), long? itemsCompletedCount = default(long?), string errorPrefix = null, string resultPrefix = null, System.DateTimeOffset? lastStorageUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties MigrateMySqlAzureDBForMySqlOfflineTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput> output = null, bool? isCloneable = default(bool?), string taskId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput MigrateMySqlAzureDBForMySqlSyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseError(string id = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? migrationState = default(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState?), long? incomingChanges = default(long?), long? appliedChanges = default(long?), long? cdcInsertCounter = default(long?), long? cdcDeleteCounter = default(long?), long? cdcUpdateCounter = default(long?), long? fullLoadCompletedTables = default(long?), long? fullLoadLoadingTables = default(long?), long? fullLoadQueuedTables = default(long?), long? fullLoadErroredTables = default(long?), bool? isInitializationCompleted = default(bool?), long? latency = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError MigrateMySqlAzureDBForMySqlSyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel MigrateMySqlAzureDBForMySqlSyncTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServer = null, string targetServerVersion = null, string targetServer = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel(string id = null, string tableName = null, string databaseName = null, string cdcInsertCounter = null, string cdcUpdateCounter = null, string cdcDeleteCounter = null, System.DateTimeOffset? fullLoadEstFinishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadEndedOn = default(System.DateTimeOffset?), long? fullLoadTotalRows = default(long?), Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState?), long? totalChangesApplied = default(long?), long? dataErrorsCounter = default(long?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties MigrateMySqlAzureDBForMySqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties MigrateOracleAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput MigrateOracleAzureDBPostgreSqlSyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseError(string id = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? migrationState = default(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState?), long? incomingChanges = default(long?), long? appliedChanges = default(long?), long? cdcInsertCounter = default(long?), long? cdcDeleteCounter = default(long?), long? cdcUpdateCounter = default(long?), long? fullLoadCompletedTables = default(long?), long? fullLoadLoadingTables = default(long?), long? fullLoadQueuedTables = default(long?), long? fullLoadErroredTables = default(long?), bool? isInitializationCompleted = default(bool?), long? latency = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError MigrateOracleAzureDBPostgreSqlSyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel MigrateOracleAzureDBPostgreSqlSyncTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServer = null, string targetServerVersion = null, string targetServer = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel MigrateOracleAzureDBPostgreSqlSyncTaskOutputTableLevel(string id = null, string tableName = null, string databaseName = null, long? cdcInsertCounter = default(long?), long? cdcUpdateCounter = default(long?), long? cdcDeleteCounter = default(long?), System.DateTimeOffset? fullLoadEstFinishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadEndedOn = default(System.DateTimeOffset?), long? fullLoadTotalRows = default(long?), Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState?), long? totalChangesApplied = default(long?), long? dataErrorsCounter = default(long?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput(string name = null, string id = null, string targetDatabaseName = null, System.Collections.Generic.IDictionary<string, System.BinaryData> migrationSetting = null, System.Collections.Generic.IDictionary<string, string> sourceSetting = null, System.Collections.Generic.IDictionary<string, string> targetSetting = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput> selectedTables = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput> selectedDatabases = null, Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo targetConnectionInfo = null, Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo sourceConnectionInfo = null, string encryptedKeyForSecureFields = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseError(string id = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? migrationState = default(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState?), long? incomingChanges = default(long?), long? appliedChanges = default(long?), long? cdcInsertCounter = default(long?), long? cdcDeleteCounter = default(long?), long? cdcUpdateCounter = default(long?), long? fullLoadCompletedTables = default(long?), long? fullLoadLoadingTables = default(long?), long? fullLoadQueuedTables = default(long?), long? fullLoadErroredTables = default(long?), bool? isInitializationCompleted = default(bool?), long? latency = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServer = null, string targetServerVersion = null, string targetServer = null, Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource? sourceServerType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource?), Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget? targetServerType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget?), Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState?), float? databaseCount = default(float?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel(string id = null, string tableName = null, string databaseName = null, long? cdcInsertCounter = default(long?), long? cdcUpdateCounter = default(long?), long? cdcDeleteCounter = default(long?), System.DateTimeOffset? fullLoadEstFinishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadEndedOn = default(System.DateTimeOffset?), long? fullLoadTotalRows = default(long?), Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState?), long? totalChangesApplied = default(long?), long? dataErrorsCounter = default(long?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput> output = null, string taskId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? isCloneable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput MigrateSchemaSqlServerSqlDBTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel MigrateSchemaSqlServerSqlDBTaskOutputDatabaseLevel(string id = null, string databaseName = null, Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.SchemaMigrationStage?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string databaseErrorResultPrefix = null, string schemaErrorResultPrefix = null, long? numberOfSuccessfulOperations = default(long?), long? numberOfFailedOperations = default(long?), string fileId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputError MigrateSchemaSqlServerSqlDBTaskOutputError(string id = null, string commandText = null, string errorText = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties MigrateSchemaSqlServerSqlDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput> output = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string taskId = null, bool? isCloneable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError MigrateSchemaSqlTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput MigrateSqlServerSqlDBSyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseError MigrateSqlServerSqlDBSyncTaskOutputDatabaseError(string id = null, string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> events = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? migrationState = default(Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState?), long? incomingChanges = default(long?), long? appliedChanges = default(long?), long? cdcInsertCounter = default(long?), long? cdcDeleteCounter = default(long?), long? cdcUpdateCounter = default(long?), long? fullLoadCompletedTables = default(long?), long? fullLoadLoadingTables = default(long?), long? fullLoadQueuedTables = default(long?), long? fullLoadErroredTables = default(long?), bool? isInitializationCompleted = default(bool?), long? latency = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError MigrateSqlServerSqlDBSyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel MigrateSqlServerSqlDBSyncTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerVersion = null, string sourceServer = null, string targetServerVersion = null, string targetServer = null, int? databaseCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel MigrateSqlServerSqlDBSyncTaskOutputTableLevel(string id = null, string tableName = null, string databaseName = null, long? cdcInsertCounter = default(long?), long? cdcUpdateCounter = default(long?), long? cdcDeleteCounter = default(long?), System.DateTimeOffset? fullLoadEstFinishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? fullLoadEndedOn = default(System.DateTimeOffset?), long? fullLoadTotalRows = default(long?), Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState?), long? totalChangesApplied = default(long?), long? dataErrorsCounter = default(long?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties MigrateSqlServerSqlDBSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput MigrateSqlServerSqlDBTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevel MigrateSqlServerSqlDBTaskOutputDatabaseLevel(string id = null, string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage?), string statusMessage = null, string message = null, long? numberOfObjects = default(long?), long? numberOfObjectsCompleted = default(long?), long? errorCount = default(long?), string errorPrefix = null, string resultPrefix = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null, string objectSummary = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult(string id = null, string migrationId = null, string sourceDatabaseName = null, string targetDatabaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult dataIntegrityValidationResult = null, Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult schemaValidationResult = null, Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult queryAnalysisValidationResult = null, Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus? status = default(Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError MigrateSqlServerSqlDBTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputMigrationLevel MigrateSqlServerSqlDBTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), long? durationInSeconds = default(long?), Azure.ResourceManager.DataMigration.Models.DataMigrationStatus? status = default(Azure.ResourceManager.DataMigration.Models.DataMigrationStatus?), string statusMessage = null, string message = null, string databases = null, string databaseSummary = null, Azure.ResourceManager.DataMigration.Models.MigrationValidationResult migrationValidationResult = null, Azure.ResourceManager.DataMigration.Models.MigrationReportResult migrationReportResult = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputTableLevel MigrateSqlServerSqlDBTaskOutputTableLevel(string id = null, string objectName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), string statusMessage = null, long? itemsCount = default(long?), long? itemsCompletedCount = default(long?), string errorPrefix = null, string resultPrefix = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult MigrateSqlServerSqlDBTaskOutputValidationResult(string id = null, string migrationId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> summaryResults = null, Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus? status = default(Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties MigrateSqlServerSqlDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput> output = null, string taskId = null, bool? isCloneable = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput MigrateSqlServerSqlMISyncTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel(string id = null, string sourceDatabaseName = null, Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState? migrationState = default(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo fullBackupSetInfo = null, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo lastRestoredBackupSetInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo> activeBackupSets = null, string containerName = null, string errorPrefix = null, bool? isFullBackupRestored = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError MigrateSqlServerSqlMISyncTaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel MigrateSqlServerSqlMISyncTaskOutputMigrationLevel(string id = null, int? databaseCount = default(int?), Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string sourceServerName = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerName = null, string targetServerVersion = null, string targetServerBrandVersion = null, int? databaseErrorCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties MigrateSqlServerSqlMISyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput> output = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput MigrateSqlServerSqlMITaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputAgentJobLevel MigrateSqlServerSqlMITaskOutputAgentJobLevel(string id = null, string name = null, bool? isEnabled = default(bool?), Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel MigrateSqlServerSqlMITaskOutputDatabaseLevel(string id = null, string databaseName = null, double? sizeMB = default(double?), Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError MigrateSqlServerSqlMITaskOutputError(string id = null, Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException error = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputLoginLevel MigrateSqlServerSqlMITaskOutputLoginLevel(string id = null, string loginName = null, Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), Azure.ResourceManager.DataMigration.Models.LoginMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.LoginMigrationStage?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel MigrateSqlServerSqlMITaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataMigrationStatus? status = default(Azure.ResourceManager.DataMigration.Models.DataMigrationStatus?), Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), string agentJobs = null, string logins = null, string message = null, string serverRoleResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo> orphanedUsersInfo = null, string databases = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties MigrateSqlServerSqlMITaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput> output = null, string taskId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string parentTaskId = null, bool? isCloneable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput MigrateSsisTaskOutput(string id = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputMigrationLevel MigrateSsisTaskOutputMigrationLevel(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.DataMigrationStatus? status = default(Azure.ResourceManager.DataMigration.Models.DataMigrationStatus?), string message = null, string sourceServerVersion = null, string sourceServerBrandVersion = null, string targetServerVersion = null, string targetServerBrandVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null, Azure.ResourceManager.DataMigration.Models.SsisMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.SsisMigrationStage?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel MigrateSsisTaskOutputProjectLevel(string id = null, string folderName = null, string projectName = null, Azure.ResourceManager.DataMigration.Models.DataMigrationState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationState?), Azure.ResourceManager.DataMigration.Models.SsisMigrationStage? stage = default(Azure.ResourceManager.DataMigration.Models.SsisMigrationStage?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> exceptionsAndWarnings = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties MigrateSsisTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput MigrateSyncCompleteCommandOutput(string id = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> errors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties MigrateSyncCompleteCommandProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState?), Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput input = null, Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput output = null, string commandId = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo MigrationEligibilityInfo(bool? isEligibleForMigration = default(bool?), System.Collections.Generic.IEnumerable<string> validationMessages = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationReportResult MigrationReportResult(string id = null, System.Uri reportUri = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult MigrationValidationDatabaseSummaryResult(string id = null, string migrationId = null, string sourceDatabaseName = null, string targetDatabaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus? status = default(Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationError MigrationValidationError(string text = null, Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity? severity = default(Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationResult MigrationValidationResult(string id = null, string migrationId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> summaryResults = null, Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus? status = default(Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics MigrationValidationWaitStatistics(string waitType = null, float? waitTimeInMilliseconds = default(float?), long? waitCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult QueryAnalysisValidationResult(Azure.ResourceManager.DataMigration.Models.QueryExecutionResult queryResults = null, Azure.ResourceManager.DataMigration.Models.MigrationValidationError validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.QueryExecutionResult QueryExecutionResult(string queryText = null, long? statementsInBatch = default(long?), Azure.ResourceManager.DataMigration.Models.ExecutionStatistics sourceResult = null, Azure.ResourceManager.DataMigration.Models.ExecutionStatistics targetResult = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult SchemaComparisonValidationResult(Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType schemaDifferences = null, Azure.ResourceManager.DataMigration.Models.MigrationValidationError validationErrors = null, System.Collections.Generic.IReadOnlyDictionary<string, long> sourceDatabaseObjectCount = null, System.Collections.Generic.IReadOnlyDictionary<string, long> targetDatabaseObjectCount = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType SchemaComparisonValidationResultType(string objectName = null, Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType? objectType = default(Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType?), Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType? updateAction = default(Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType?)) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys SqlMigrationAuthenticationKeys(string authKey1 = null, string authKey2 = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo SqlMigrationErrorInfo(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.SqlMigrationServiceData SqlMigrationServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, string integrationRuntimeState = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent SyncMigrationDatabaseErrorEvent(string timestampString = null, string eventTypeString = null, string eventText = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput UploadOciDriverTaskOutput(string driverPackageName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties UploadOciDriverTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo inputDriverShare = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties ValidateMigrationInputSqlServerSqlDBSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput ValidateMigrationInputSqlServerSqlMISyncTaskOutput(string id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties ValidateMigrationInputSqlServerSqlMISyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput ValidateMigrationInputSqlServerSqlMITaskOutput(string id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> restoreDatabaseNameErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> backupFolderErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> backupShareCredentialsErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> backupStorageAccountErrors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> existingBackupErrors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo databaseBackupInfo = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties ValidateMigrationInputSqlServerSqlMITaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties ValidateMongoDBTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties ValidateOracleAzureDBForPostgreSqlSyncTaskProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> errors = null, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? state = default(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> commands = null, System.Collections.Generic.IDictionary<string, string> clientData = null, Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput input = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput> output = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput ValidateOracleAzureDBPostgreSqlSyncTaskOutput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput ValidateSyncMigrationInputSqlServerTaskOutput(string id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> validationErrors = null) { throw null; }
    }
    public partial class CheckOciDriverTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>
    {
        internal CheckOciDriverTaskOutput() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo InstalledDriver { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckOciDriverTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>
    {
        public CheckOciDriverTaskProperties() { }
        public string InputServerVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CheckOciDriverTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToMongoDBTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>
    {
        public ConnectToMongoDBTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToMongoDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceMySqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>
    {
        public ConnectToSourceMySqlTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo sourceConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.ServerLevelPermissionsGroup? CheckPermissionsGroup { get { throw null; } set { } }
        public bool? IsOfflineMigration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType? TargetPlatform { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceMySqlTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskProperties>
    {
        public ConnectToSourceMySqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToSourceMySqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceNonSqlTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties ServerProperties { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceOracleSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskProperties>
    {
        public ConnectToSourceOracleSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo InputSourceConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceOracleSyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourcePostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>
    {
        public ConnectToSourcePostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo InputSourceConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourcePostgreSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>
    {
        public ConnectToSourceSqlServerSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput>
    {
        public ConnectToSourceSqlServerTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.ServerLevelPermissionsGroup? CheckPermissionsGroup { get { throw null; } set { } }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public bool? ShouldCollectAgentJobs { get { throw null; } set { } }
        public bool? ShouldCollectDatabases { get { throw null; } set { } }
        public bool? ShouldCollectLogins { get { throw null; } set { } }
        public bool? ShouldCollectTdeCertificateInfo { get { throw null; } set { } }
        public bool? ShouldValidateSsisCatalogOnly { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputAgentJobLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputDatabaseLevel>
    {
        internal ConnectToSourceSqlServerTaskOutputDatabaseLevel() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel? CompatibilityLevel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo> DatabaseFiles { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState? DatabaseState { get { throw null; } }
        public string Name { get { throw null; } }
        public double? SizeMB { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType? LoginType { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationEligibilityInfo MigrationEligibility { get { throw null; } }
        public string Name { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutputTaskLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToSourceSqlServerTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>
    {
        public ConnectToSourceSqlServerTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToSourceSqlServerTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForMySqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput>
    {
        public ConnectToTargetAzureDBForMySqlTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo targetConnectionInfo) { }
        public bool? IsOfflineMigration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForMySqlTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>
    {
        public ConnectToTargetAzureDBForMySqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForMySqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForPostgreSqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput>
    {
        public ConnectToTargetAzureDBForPostgreSqlSyncTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo targetConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties>
    {
        public ConnectToTargetAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetAzureDBForPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutputDatabaseSchemaMapItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>
    {
        public ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo InputTargetConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlDBSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>
    {
        public ConnectToTargetSqlDBSyncTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlDBSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>
    {
        public ConnectToTargetSqlDBSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlDBTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput>
    {
        public ConnectToTargetSqlDBTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo) { }
        public bool? ShouldQueryObjectCounts { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlDBTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>
    {
        public ConnectToTargetSqlDBTaskProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMISyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput>
    {
        public ConnectToTargetSqlMISyncTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp azureApp) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp AzureApp { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMISyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>
    {
        public ConnectToTargetSqlMISyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMISyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMITaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput>
    {
        public ConnectToTargetSqlMITaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo) { }
        public bool? ShouldCollectAgentJobs { get { throw null; } set { } }
        public bool? ShouldCollectLogins { get { throw null; } set { } }
        public bool? ShouldValidateSsisCatalogOnly { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectToTargetSqlMITaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskProperties>
    {
        public ConnectToTargetSqlMITaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ConnectToTargetSqlMITaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.DateTimeOffset? CopyStartOn { get { throw null; } }
        public double? CopyThroughput { get { throw null; } }
        public long? DataRead { get { throw null; } }
        public long? DataWritten { get { throw null; } }
        public string ParallelCopyType { get { throw null; } }
        public long? RowsCopied { get { throw null; } }
        public long? RowsRead { get { throw null; } }
        public string Status { get { throw null; } }
        public string TableName { get { throw null; } }
        public int? UsedParallelCopies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CopyProgressDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.CopyProgressDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigration : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>
    {
        internal DatabaseMigration() { }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DatabaseMigrationBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties>
    {
        protected DatabaseMigrationBaseProperties() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo MigrationFailureError { get { throw null; } }
        public string MigrationOperationId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MigrationService { get { throw null; } set { } }
        public string MigrationStatus { get { throw null; } }
        public string ProvisioningError { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState? ProvisioningState { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>
    {
        public DatabaseMigrationProperties() { }
        public string SourceDatabaseName { get { throw null; } set { } }
        public string SourceServerName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation SourceSqlConnection { get { throw null; } set { } }
        public string TargetDatabaseCollation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationSqlDBProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>
    {
        public DatabaseMigrationSqlDBProperties() { }
        public bool? IsOfflineMigration { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails MigrationStatusDetails { get { throw null; } }
        public System.Collections.Generic.IList<string> TableList { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation TargetSqlConnection { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlDBProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationSqlMIProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>
    {
        public DatabaseMigrationSqlMIProperties() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration BackupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails MigrationStatusDetails { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration OfflineConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlMIProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationSqlVmProperties : Azure.ResourceManager.DataMigration.Models.DatabaseMigrationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DatabaseMigrationSqlVmProperties>
    {
        public DatabaseMigrationSqlVmProperties() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration BackupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails MigrationStatusDetails { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration OfflineConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class DataIntegrityValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>
    {
        internal DataIntegrityValidationResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FailedObjects { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationError ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataIntegrityValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationAadApp : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp>
    {
        public DataMigrationAadApp() { }
        public string AppKey { get { throw null; } set { } }
        public string ApplicationId { get { throw null; } set { } }
        public bool? DoesIgnoreAzurePermissions { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationAuthenticationType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType ActiveDirectoryIntegrated { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType ActiveDirectoryPassword { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType None { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType SqlAuthentication { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType WindowsAuthentication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType left, Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType left, Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationAvailableServiceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku>
    {
        internal DataMigrationAvailableServiceSku() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationAvailableServiceSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity>
    {
        internal DataMigrationAvailableServiceSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability? ScaleType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationAvailableServiceSkuDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails>
    {
        internal DataMigrationAvailableServiceSkuDetails() { }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationAvailableServiceSkuDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationBackupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration>
    {
        public DataMigrationBackupConfiguration() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation SourceLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation TargetLocation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationBackupFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo>
    {
        internal DataMigrationBackupFileInfo() { }
        public int? FamilySequenceNumber { get { throw null; } }
        public string FileLocation { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationBackupFileStatus : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationBackupFileStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus Arrived { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus Restored { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus Restoring { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus Uploaded { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus Uploading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus left, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus left, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationBackupMode : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationBackupMode(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode CreateBackup { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode ExistingBackup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode left, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode left, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationBackupSetInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo>
    {
        internal DataMigrationBackupSetInfo() { }
        public System.DateTimeOffset? BackupFinishedOn { get { throw null; } }
        public string BackupSetId { get { throw null; } }
        public System.DateTimeOffset? BackupStartOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType? BackupType { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public string FirstLsn { get { throw null; } }
        public bool? IsBackupRestored { get { throw null; } }
        public string LastLsn { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupFileInfo> ListOfBackupFiles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationBackupSourceLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation>
    {
        public DataMigrationBackupSourceLocation() { }
        public Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails AzureBlob { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare FileShare { get { throw null; } set { } }
        public string FileStorageType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSourceLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationBackupTargetLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation>
    {
        public DataMigrationBackupTargetLocation() { }
        public string AccountKey { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupTargetLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationBackupType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationBackupType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType Database { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType DifferentialDatabase { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType DifferentialFile { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType DifferentialPartial { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType File { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType Partial { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType TransactionLog { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType left, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType left, Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationBlobShare : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare>
    {
        public DataMigrationBlobShare() { }
        public System.Uri SasUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataMigrationCommandProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties>
    {
        protected DataMigrationCommandProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> Errors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationCommandState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationCommandState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState Running { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState left, Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState left, Azure.ResourceManager.DataMigration.Models.DataMigrationCommandState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationDatabaseBackupInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo>
    {
        internal DataMigrationDatabaseBackupInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> BackupFiles { get { throw null; } }
        public System.DateTimeOffset? BackupFinishedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupType? BackupType { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public int? FamilyCount { get { throw null; } }
        public bool? IsCompressed { get { throw null; } }
        public bool? IsDamaged { get { throw null; } }
        public int? Position { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationDatabaseCompatLevel : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationDatabaseCompatLevel(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel CompatLevel100 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel CompatLevel110 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel CompatLevel120 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel CompatLevel130 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel CompatLevel140 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel CompatLevel80 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel CompatLevel90 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel left, Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel left, Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseCompatLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationDatabaseFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo>
    {
        internal DataMigrationDatabaseFileInfo() { }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType? FileType { get { throw null; } }
        public string Id { get { throw null; } }
        public string LogicalName { get { throw null; } }
        public string PhysicalFullName { get { throw null; } }
        public string RestoreFullName { get { throw null; } }
        public double? SizeMB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationDatabaseObjectType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationDatabaseObjectType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType Function { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType StoredProcedures { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType Table { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType User { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType View { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType left, Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType left, Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationDatabaseTable : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable>
    {
        internal DataMigrationDatabaseTable() { }
        public bool? HasRows { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationFileShareInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo>
    {
        public DataMigrationFileShareInfo(string path) { }
        public string Password { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationFileStorageInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo>
    {
        internal DataMigrationFileStorageInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationFileStorageInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationLoginType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationLoginType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType AsymmetricKey { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType Certificate { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType ExternalGroup { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType ExternalUser { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType SqlLogin { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType WindowsGroup { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType WindowsUser { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType left, Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType left, Azure.ResourceManager.DataMigration.Models.DataMigrationLoginType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationMISqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo>
    {
        public DataMigrationMISqlConnectionInfo(Azure.Core.ResourceIdentifier managedInstanceResourceId) { }
        public Azure.Core.ResourceIdentifier ManagedInstanceResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBCancelCommand : Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand>
    {
        public DataMigrationMongoDBCancelCommand() { }
        public string InputObjectName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCancelCommand>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBClusterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo>
    {
        internal DataMigrationMongoDBClusterInfo() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType ClusterType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo> Databases { get { throw null; } }
        public bool IsShardingSupported { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationMongoDBClusterType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationMongoDBClusterType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType BlobContainer { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType CosmosDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType MongoDB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBClusterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationMongoDBCollectionInfo : Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo>
    {
        internal DataMigrationMongoDBCollectionInfo() { }
        public string DatabaseName { get { throw null; } }
        public bool IsCapped { get { throw null; } }
        public bool IsShardingSupported { get { throw null; } }
        public bool IsSystemCollection { get { throw null; } }
        public bool IsView { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo ShardKey { get { throw null; } }
        public string ViewOf { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBCollectionProgress : Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress>
    {
        internal DataMigrationMongoDBCollectionProgress() : base (default(long), default(long), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>), default(long), default(long), default(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState), default(long), default(long)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBCollectionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings>
    {
        public DataMigrationMongoDBCollectionSettings() { }
        public bool? CanDelete { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting ShardKey { get { throw null; } set { } }
        public int? TargetRUs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBCommandInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput>
    {
        public DataMigrationMongoDBCommandInput() { }
        public string ObjectName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBConnectionInfo : Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo>
    {
        public DataMigrationMongoDBConnectionInfo(string connectionString) { }
        public string AdditionalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType? Authentication { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public bool? DoesEnforceSsl { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ServerBrandVersion { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public bool? ShouldEncryptConnection { get { throw null; } set { } }
        public bool? ShouldTrustServerCertificate { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBDatabaseInfo : Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo>
    {
        internal DataMigrationMongoDBDatabaseInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionInfo> Collections { get { throw null; } }
        public bool IsShardingSupported { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBDatabaseProgress : Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress>
    {
        internal DataMigrationMongoDBDatabaseProgress() : base (default(long), default(long), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>), default(long), default(long), default(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState), default(long), default(long)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionProgress> Collections { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBDatabaseSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings>
    {
        public DataMigrationMongoDBDatabaseSettings(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings> collections) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCollectionSettings> Collections { get { throw null; } }
        public int? TargetRUs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>
    {
        internal DataMigrationMongoDBError() { }
        public string Code { get { throw null; } }
        public int? Count { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType? ErrorType { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationMongoDBErrorType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationMongoDBErrorType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType Error { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType ValidationError { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBErrorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationMongoDBFinishCommand : Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand>
    {
        public DataMigrationMongoDBFinishCommand() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput Input { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommand>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBFinishCommandInput : Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBCommandInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput>
    {
        public DataMigrationMongoDBFinishCommandInput(bool shouldStopReplicationImmediately) { }
        public bool ShouldStopReplicationImmediately { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBFinishCommandInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBMigrationProgress : Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress>
    {
        internal DataMigrationMongoDBMigrationProgress() : base (default(long), default(long), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError>), default(long), default(long), default(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState), default(long), default(long)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseProgress> Databases { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBMigrationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings>
    {
        public DataMigrationMongoDBMigrationSettings(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings> databases, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo source, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo target) { }
        public int? BoostRUs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBDatabaseSettings> Databases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication? Replication { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo Source { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBConnectionInfo Target { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings Throttling { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationMongoDBMigrationState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationMongoDBMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState Complete { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState Copying { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState Finalizing { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState Initializing { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState InitialReplay { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState Replaying { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState Restarting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState ValidatingInput { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationMongoDBObjectInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo>
    {
        internal DataMigrationMongoDBObjectInfo() { }
        public long AverageDocumentSize { get { throw null; } }
        public long DataSize { get { throw null; } }
        public long DocumentCount { get { throw null; } }
        public string Name { get { throw null; } }
        public string QualifiedName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBObjectInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataMigrationMongoDBProgress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress>
    {
        protected DataMigrationMongoDBProgress(long bytesCopied, long documentsCopied, string elapsedTime, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError> errors, long eventsPending, long eventsReplayed, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState state, long totalBytes, long totalDocuments) { }
        public long BytesCopied { get { throw null; } }
        public long DocumentsCopied { get { throw null; } }
        public string ElapsedTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBError> Errors { get { throw null; } }
        public long EventsPending { get { throw null; } }
        public long EventsReplayed { get { throw null; } }
        public System.DateTimeOffset? LastEventOn { get { throw null; } }
        public System.DateTimeOffset? LastReplayOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string QualifiedName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationState State { get { throw null; } }
        public long TotalBytes { get { throw null; } }
        public long TotalDocuments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationMongoDBReplication : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationMongoDBReplication(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication Continuous { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication OneTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBReplication right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationMongoDBRestartCommand : Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand>
    {
        public DataMigrationMongoDBRestartCommand() { }
        public string InputObjectName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBRestartCommand>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBShardKeyField : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField>
    {
        public DataMigrationMongoDBShardKeyField(string name, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder order) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder Order { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBShardKeyInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo>
    {
        internal DataMigrationMongoDBShardKeyInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField> Fields { get { throw null; } }
        public bool IsUnique { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationMongoDBShardKeyOrder : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationMongoDBShardKeyOrder(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder Forward { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder Hashed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder Reverse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder left, Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationMongoDBShardKeySetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting>
    {
        public DataMigrationMongoDBShardKeySetting(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField> fields) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeyField> Fields { get { throw null; } }
        public bool? IsUnique { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBShardKeySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMongoDBThrottlingSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings>
    {
        public DataMigrationMongoDBThrottlingSettings() { }
        public int? MaxParallelism { get { throw null; } set { } }
        public int? MinFreeCpu { get { throw null; } set { } }
        public int? MinFreeMemoryMb { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBThrottlingSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMySqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo>
    {
        public DataMigrationMySqlConnectionInfo(string serverName, int port) { }
        public string AdditionalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType? Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public bool? ShouldEncryptConnection { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationMySqlServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties>
    {
        internal DataMigrationMySqlServerProperties() { }
        public int? ServerDatabaseCount { get { throw null; } }
        public string ServerEdition { get { throw null; } }
        public string ServerName { get { throw null; } }
        public string ServerOperatingSystemVersion { get { throw null; } }
        public string ServerPlatform { get { throw null; } }
        public string ServerVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationMySqlTargetPlatformType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationMySqlTargetPlatformType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType AzureDBForMySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType SqlServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType left, Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType left, Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlTargetPlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationODataError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError>
    {
        internal DataMigrationODataError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> Details { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationODataError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationODataError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationOfflineConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration>
    {
        public DataMigrationOfflineConfiguration() { }
        public bool? IsOfflineMigration { get { throw null; } set { } }
        public string LastBackupName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOfflineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationOracleConnectionInfo : Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo>
    {
        public DataMigrationOracleConnectionInfo(string dataSource) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType? Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationOracleOciDriverInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo>
    {
        internal DataMigrationOracleOciDriverInfo() { }
        public string ArchiveChecksum { get { throw null; } }
        public string AssemblyVersion { get { throw null; } }
        public string DriverName { get { throw null; } }
        public string DriverSize { get { throw null; } }
        public string OracleChecksum { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedOracleVersions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationOracleOciDriverInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationPostgreSqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo>
    {
        public DataMigrationPostgreSqlConnectionInfo(string serverName, int port) { }
        public string AdditionalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType? Authentication { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string ServerBrandVersion { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public bool? ShouldEncryptConnection { get { throw null; } set { } }
        public bool? ShouldTrustServerCertificate { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationProjectDatabaseInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo>
    {
        public DataMigrationProjectDatabaseInfo(string sourceDatabaseName) { }
        public string SourceDatabaseName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectDatabaseInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationProjectFileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties>
    {
        public DataMigrationProjectFileProperties() { }
        public string Extension { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string MediaType { get { throw null; } set { } }
        public long? Size { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectFileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationProjectProvisioningState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationProjectProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState left, Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState left, Azure.ResourceManager.DataMigration.Models.DataMigrationProjectProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationProjectSourcePlatform : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationProjectSourcePlatform(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform MongoDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform MySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform Sql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform left, Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform left, Azure.ResourceManager.DataMigration.Models.DataMigrationProjectSourcePlatform right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationProjectTargetPlatform : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationProjectTargetPlatform(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform AzureDBForMySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform AzureDBForPostgreSql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform MongoDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform SqlDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform SqlMI { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform left, Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform left, Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTargetPlatform right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DataMigrationProjectTaskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties>
    {
        protected DataMigrationProjectTaskProperties() { }
        public System.Collections.Generic.IDictionary<string, string> ClientData { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties> Commands { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationODataError> Errors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationProvisioningState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState left, Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState left, Azure.ResourceManager.DataMigration.Models.DataMigrationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota>
    {
        internal DataMigrationQuota() { }
        public double? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public double? Limit { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationQuotaName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName>
    {
        internal DataMigrationQuotaName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationQuotaName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationReportableException : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException>
    {
        internal DataMigrationReportableException() { }
        public string ActionableMessage { get { throw null; } }
        public string FilePath { get { throw null; } }
        public int? HResult { get { throw null; } }
        public string LineNumber { get { throw null; } }
        public string Message { get { throw null; } }
        public string StackTrace { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationScenarioSource : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationScenarioSource(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource Access { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource DB2 { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource MongoDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource MySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource MySqlRds { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource Oracle { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource PostgreSqlRds { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource Sql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource SqlRds { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource Sybase { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource left, Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource left, Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationScenarioTarget : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationScenarioTarget(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget AzureDBForMySql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget AzureDBForPostgresSql { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget MongoDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget SqlDB { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget SqlDW { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget SqlMI { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget SqlServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget left, Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget left, Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationServiceNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent>
    {
        public DataMigrationServiceNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationServiceNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>
    {
        internal DataMigrationServiceNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationServiceNameUnavailableReason : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationServiceNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason left, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason left, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationServiceProvisioningState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationServiceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState Deploying { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState FailedToStart { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState FailedToStop { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState Starting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState Stopped { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState Stopping { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState left, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState left, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationServiceScalability : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationServiceScalability(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability Automatic { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability Manual { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability left, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability left, Azure.ResourceManager.DataMigration.Models.DataMigrationServiceScalability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationServiceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku>
    {
        public DataMigrationServiceSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationServiceStatusResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>
    {
        internal DataMigrationServiceStatusResponse() { }
        public System.BinaryData AgentConfiguration { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedTaskTypes { get { throw null; } }
        public string VmSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationServiceStatusResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSku>
    {
        internal DataMigrationSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSkuCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities>
    {
        internal DataMigrationSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity>
    {
        internal DataMigrationSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSkuCosts : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts>
    {
        internal DataMigrationSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuCosts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions>
    {
        internal DataMigrationSkuRestrictions() { }
        public Azure.ResourceManager.DataMigration.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationSkuRestrictionsType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationSkuRestrictionsType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType Location { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType left, Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType left, Azure.ResourceManager.DataMigration.Models.DataMigrationSkuRestrictionsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationSqlBackupFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo>
    {
        internal DataMigrationSqlBackupFileInfo() { }
        public int? CopyDuration { get { throw null; } }
        public double? CopyThroughput { get { throw null; } }
        public long? DataRead { get { throw null; } }
        public long? DataWritten { get { throw null; } }
        public int? FamilySequenceNumber { get { throw null; } }
        public string FileName { get { throw null; } }
        public string Status { get { throw null; } }
        public long? TotalSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSqlBackupSetInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo>
    {
        internal DataMigrationSqlBackupSetInfo() { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupFileInfo> ListOfBackupFiles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSqlConnectionInfo : Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo>
    {
        public DataMigrationSqlConnectionInfo(string dataSource) { }
        public string AdditionalSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAuthenticationType? Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlSourcePlatform? Platform { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ServerBrandVersion { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public bool? ShouldEncryptConnection { get { throw null; } set { } }
        public bool? ShouldTrustServerCertificate { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSqlConnectionInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation>
    {
        public DataMigrationSqlConnectionInformation() { }
        public string Authentication { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public bool? ShouldEncryptConnection { get { throw null; } set { } }
        public bool? ShouldTrustServerCertificate { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationSqlDatabaseFileType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationSqlDatabaseFileType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType Filestream { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType Fulltext { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType Log { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType NotSupported { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType Rows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType left, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType left, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseFileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationSqlDatabaseState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationSqlDatabaseState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState Copying { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState Emergency { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState Offline { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState OfflineSecondary { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState Online { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState Recovering { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState RecoveryPending { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState Restoring { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState Suspect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState left, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState left, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDatabaseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationSqlDBMigrationStatusDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails>
    {
        internal DataMigrationSqlDBMigrationStatusDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.CopyProgressDetails> ListOfCopyProgressDetails { get { throw null; } }
        public string MigrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlDataCopyErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlDBMigrationStatusDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSqlFileShare : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare>
    {
        public DataMigrationSqlFileShare() { }
        public string Password { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlFileShare>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMigrationSqlServerOrphanedUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo>
    {
        internal DataMigrationSqlServerOrphanedUserInfo() { }
        public string DatabaseName { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationSqlSourcePlatform : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlSourcePlatform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationSqlSourcePlatform(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSqlSourcePlatform SqlOnPrem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlSourcePlatform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlSourcePlatform left, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlSourcePlatform right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationSqlSourcePlatform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlSourcePlatform left, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlSourcePlatform right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationSsisStoreType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationSsisStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationSsisStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationSsisStoreType SsisCatalog { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationSsisStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationSsisStoreType left, Azure.ResourceManager.DataMigration.Models.DataMigrationSsisStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationSsisStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationSsisStoreType left, Azure.ResourceManager.DataMigration.Models.DataMigrationSsisStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationState Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationState None { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationState Skipped { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationState Stopped { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationState left, Azure.ResourceManager.DataMigration.Models.DataMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationState left, Azure.ResourceManager.DataMigration.Models.DataMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationStatus : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus Configured { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus Connecting { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus Default { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus Error { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus SelectLogins { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus SourceAndTargetSelected { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationStatus left, Azure.ResourceManager.DataMigration.Models.DataMigrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationStatus left, Azure.ResourceManager.DataMigration.Models.DataMigrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMigrationStatusDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails>
    {
        internal DataMigrationStatusDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo> ActiveBackupSets { get { throw null; } }
        public string BlobContainerName { get { throw null; } }
        public string CompleteRestoreErrorMessage { get { throw null; } }
        public string CurrentRestoringFilename { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileUploadBlockingErrors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo FullBackupSetInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InvalidFiles { get { throw null; } }
        public bool? IsFullBackupRestored { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlBackupSetInfo LastRestoredBackupSetInfo { get { throw null; } }
        public string LastRestoredFilename { get { throw null; } }
        public string MigrationState { get { throw null; } }
        public int? PendingLogBackupsCount { get { throw null; } }
        public string RestoreBlockingReason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DataMigrationStatusDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMigrationTaskState : System.IEquatable<Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMigrationTaskState(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState FailedInputValidation { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState Faulted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState Queued { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState Running { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState left, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState left, Azure.ResourceManager.DataMigration.Models.DataMigrationTaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeletedIntegrationRuntimeNodeResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult>
    {
        public DeletedIntegrationRuntimeNodeResult() { }
        public string IntegrationRuntimeName { get { throw null; } set { } }
        public string NodeName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.DeletedIntegrationRuntimeNodeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionStatistics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>
    {
        internal ExecutionStatistics() { }
        public float? CpuTimeInMilliseconds { get { throw null; } }
        public float? ElapsedTimeInMilliseconds { get { throw null; } }
        public long? ExecutionCount { get { throw null; } }
        public bool? HasErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics> WaitStats { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ExecutionStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ExecutionStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ExecutionStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTdeCertificatesSqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput>
    {
        public GetTdeCertificatesSqlTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo connectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo backupFileShare, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput> selectedCertificates) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo BackupFileShare { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput> SelectedCertificates { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetTdeCertificatesSqlTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>
    {
        public GetTdeCertificatesSqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetTdeCertificatesSqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesMySqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput>
    {
        public GetUserTablesMySqlTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedDatabases) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedDatabases { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesMySqlTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>
    {
        public GetUserTablesMySqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesMySqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesOracleTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput>
    {
        public GetUserTablesOracleTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedSchemas) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedSchemas { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable> Tables { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesOracleTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>
    {
        public GetUserTablesOracleTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesOracleTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesPostgreSqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput>
    {
        public GetUserTablesPostgreSqlTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedDatabases) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedDatabases { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseTable> Tables { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesPostgreSqlTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>
    {
        public GetUserTablesPostgreSqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesPostgreSqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput>
    {
        public GetUserTablesSqlSyncTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<string> selectedSourceDatabases, System.Collections.Generic.IEnumerable<string> selectedTargetDatabases) { }
        public System.Collections.Generic.IList<string> SelectedSourceDatabases { get { throw null; } }
        public System.Collections.Generic.IList<string> SelectedTargetDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>
    {
        public GetUserTablesSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput>
    {
        public GetUserTablesSqlTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo connectionInfo, System.Collections.Generic.IEnumerable<string> selectedDatabases) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo ConnectionInfo { get { throw null; } set { } }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedDatabases { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetUserTablesSqlTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>
    {
        public GetUserTablesSqlTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.GetUserTablesSqlTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstallOciDriverTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>
    {
        internal InstallOciDriverTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstallOciDriverTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>
    {
        public InstallOciDriverTaskProperties() { }
        public string InputDriverPackageName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.InstallOciDriverTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationRuntimeMonitoringNode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode>
    {
        internal IntegrationRuntimeMonitoringNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? AvailableMemoryInMB { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public int? ConcurrentJobsRunning { get { throw null; } }
        public int? CpuUtilization { get { throw null; } }
        public int? MaxConcurrentJobs { get { throw null; } }
        public string NodeName { get { throw null; } }
        public double? ReceivedBytes { get { throw null; } }
        public double? SentBytes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationRuntimeMonitoringResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult>
    {
        internal IntegrationRuntimeMonitoringResult() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringNode> Nodes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.IntegrationRuntimeMonitoringResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MigrateMISyncCompleteCommandProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>
    {
        public MigrateMISyncCompleteCommandProperties() { }
        public string InputSourceDatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> OutputErrors { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMISyncCompleteCommandProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMongoDBTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMongoDBTaskProperties>
    {
        public MigrateMongoDBTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBProgress> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput>
    {
        public MigrateMySqlAzureDBForMySqlOfflineTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput> selectedDatabases) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> OptionalAgentSettings { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineDatabaseInput> SelectedDatabases { get { throw null; } }
        public bool? ShouldMakeSourceServerReadOnly { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public System.DateTimeOffset? LastStorageUpdatedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public long? NumberOfObjects { get { throw null; } }
        public long? NumberOfObjectsCompleted { get { throw null; } }
        public string ObjectSummary { get { throw null; } }
        public string ResultPrefix { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputError>
    {
        internal MigrateMySqlAzureDBForMySqlOfflineTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException Error { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public System.DateTimeOffset? LastStorageUpdatedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationReportResult MigrationReportResult { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.DateTimeOffset? LastStorageUpdatedOn { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ResultPrefix { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlOfflineTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskProperties>
    {
        public MigrateMySqlAzureDBForMySqlOfflineTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlOfflineTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput>
    {
        public MigrateMySqlAzureDBForMySqlSyncTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput> selectedDatabases) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMySqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public bool? IsInitializationCompleted { get { throw null; } }
        public long? Latency { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputError>
    {
        internal MigrateMySqlAzureDBForMySqlSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException Error { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.DateTimeOffset? FullLoadEstFinishedOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadStartedOn { get { throw null; } }
        public long? FullLoadTotalRows { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? State { get { throw null; } }
        public string TableName { get { throw null; } }
        public long? TotalChangesApplied { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMySqlAzureDBForMySqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>
    {
        public MigrateMySqlAzureDBForMySqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateMySqlAzureDBForMySqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBForPostgreSqlSyncTaskProperties>
    {
        public MigrateOracleAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput>
    {
        public MigrateOracleAzureDBPostgreSqlSyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo sourceConnectionInfo) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationOracleConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public bool? IsInitializationCompleted { get { throw null; } }
        public long? Latency { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskOutputError>
    {
        internal MigrateOracleAzureDBPostgreSqlSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException Error { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.DateTimeOffset? FullLoadEstFinishedOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadStartedOn { get { throw null; } }
        public long? FullLoadTotalRows { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? State { get { throw null; } }
        public string TableName { get { throw null; } }
        public long? TotalChangesApplied { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseTableInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput>
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo sourceConnectionInfo) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationPostgreSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public bool? IsInitializationCompleted { get { throw null; } }
        public long? Latency { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError>
    {
        internal MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.SyncMigrationDatabaseErrorEvent> Events { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioSource? SourceServerType { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.ReplicateMigrationState? State { get { throw null; } }
        public string TargetServer { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationScenarioTarget? TargetServerType { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.DateTimeOffset? FullLoadEstFinishedOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadStartedOn { get { throw null; } }
        public long? FullLoadTotalRows { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? State { get { throw null; } }
        public string TableName { get { throw null; } }
        public long? TotalChangesApplied { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties>
    {
        public MigratePostgreSqlAzureDBForPostgreSqlSyncTaskProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput>
    {
        public MigrateSchemaSqlServerSqlDBTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput> selectedDatabases) : base (default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo)) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBDatabaseInput> SelectedDatabases { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlServerSqlDBTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>
    {
        public MigrateSchemaSqlServerSqlDBTaskProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSchemaSqlTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSchemaSqlTaskOutputError>
    {
        internal MigrateSchemaSqlTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException Error { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public string Name { get { throw null; } set { } }
        public System.BinaryData SchemaSetting { get { throw null; } set { } }
        public bool? ShouldMakeSourceDBReadOnly { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TableMap { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput>
    {
        public MigrateSqlServerSqlDBSyncTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> selectedDatabases) : base (default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions ValidationOptions { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public bool? IsInitializationCompleted { get { throw null; } }
        public long? Latency { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncDatabaseMigrationReportingState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputError>
    {
        internal MigrateSqlServerSqlDBSyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException Error { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.DateTimeOffset? FullLoadEstFinishedOn { get { throw null; } }
        public System.DateTimeOffset? FullLoadStartedOn { get { throw null; } }
        public long? FullLoadTotalRows { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SyncTableMigrationState? State { get { throw null; } }
        public string TableName { get { throw null; } }
        public long? TotalChangesApplied { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutputTableLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>
    {
        public MigrateSqlServerSqlDBSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput>
    {
        public MigrateSqlServerSqlDBTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput> selectedDatabases) : base (default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo)) { }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBDatabaseInput> SelectedDatabases { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions ValidationOptions { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Message { get { throw null; } }
        public long? NumberOfObjects { get { throw null; } }
        public long? NumberOfObjectsCompleted { get { throw null; } }
        public string ObjectSummary { get { throw null; } }
        public string ResultPrefix { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus? Status { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputDatabaseLevelValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputError>
    {
        internal MigrateSqlServerSqlDBTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException Error { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationReportResult MigrationReportResult { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationResult MigrationValidationResult { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> SummaryResults { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutputValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlDBTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskProperties>
    {
        public MigrateSqlServerSqlDBTaskProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBTaskOutput> Output { get { throw null; } }
        public string TaskId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo BackupFileShare { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string RestoreDatabaseName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMISyncTaskInput : Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput>
    {
        public MigrateSqlServerSqlMISyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, string storageResourceId, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp azureApp) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>), default(string), default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp)) { }
        public float? NumberOfParallelDatabaseMigrations { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>
    {
        internal MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo> ActiveBackupSets { get { throw null; } }
        public string ContainerName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string ErrorPrefix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo FullBackupSetInfo { get { throw null; } }
        public bool? IsFullBackupRestored { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupSetInfo LastRestoredBackupSetInfo { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationState? MigrationState { get { throw null; } }
        public string SourceDatabaseName { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMISyncTaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputError>
    {
        internal MigrateSqlServerSqlMISyncTaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException Error { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerName { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMISyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>
    {
        public MigrateSqlServerSqlMISyncTaskProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMISyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput>
    {
        public MigrateSqlServerSqlMITaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare backupBlobShare) : base (default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo)) { }
        public string AadDomainName { get { throw null; } set { } }
        public System.Uri BackupBlobShareSasUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo BackupFileShare { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode? BackupMode { get { throw null; } set { } }
        public string EncryptedKeyForSecureFields { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SelectedAgentJobs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> SelectedDatabases { get { throw null; } }
        public System.Collections.Generic.IList<string> SelectedLogins { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Message { get { throw null; } }
        public double? SizeMB { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DatabaseMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputDatabaseLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskOutputError : Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputError>
    {
        internal MigrateSqlServerSqlMITaskOutputError() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException Error { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string LoginName { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.LoginMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Logins { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationSqlServerOrphanedUserInfo> OrphanedUsersInfo { get { throw null; } }
        public string ServerRoleResults { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationStatus? Status { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutputMigrationLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlServerSqlMITaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>
    {
        public MigrateSqlServerSqlMITaskProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskInput Input { get { throw null; } set { } }
        public bool? IsCloneable { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskOutput> Output { get { throw null; } }
        public string ParentTaskId { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMITaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSsisTaskInput : Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput>
    {
        public MigrateSsisTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo ssisMigrationInfo) : base (default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo)) { }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo SsisMigrationInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string Message { get { throw null; } }
        public string SourceServerBrandVersion { get { throw null; } }
        public string SourceServerVersion { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationStatus? Status { get { throw null; } }
        public string TargetServerBrandVersion { get { throw null; } }
        public string TargetServerVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExceptionsAndWarnings { get { throw null; } }
        public string FolderName { get { throw null; } }
        public string Message { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationStage? Stage { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationState? State { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutputProjectLevel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSsisTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>
    {
        public MigrateSsisTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSsisTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSyncCompleteCommandInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>
    {
        public MigrateSyncCompleteCommandInput(string databaseName) { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSyncCompleteCommandOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>
    {
        internal MigrateSyncCompleteCommandOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> Errors { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSyncCompleteCommandProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationCommandProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandProperties>
    {
        public MigrateSyncCompleteCommandProperties() { }
        public string CommandId { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandInput Input { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.MigrateSyncCompleteCommandOutput Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationReportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationReportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationReportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationValidationDatabaseSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>
    {
        internal MigrationValidationDatabaseSummaryResult() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string MigrationId { get { throw null; } }
        public string SourceDatabaseName { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus? Status { get { throw null; } }
        public string TargetDatabaseName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationValidationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationError>
    {
        internal MigrationValidationError() { }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity? Severity { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationValidationOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationOptions>
    {
        public MigrationValidationOptions() { }
        public bool? IsDataIntegrityValidationEnabled { get { throw null; } set { } }
        public bool? IsQueryAnalysisValidationEnabled { get { throw null; } set { } }
        public bool? IsSchemaValidationEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataMigration.Models.MigrationValidationDatabaseSummaryResult> SummaryResults { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationValidationSeverity : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationValidationSeverity(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity Message { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity left, Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity left, Azure.ResourceManager.DataMigration.Models.MigrationValidationSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationValidationStatus : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus CompletedWithIssues { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus Default { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus Initialized { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus left, Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus left, Azure.ResourceManager.DataMigration.Models.MigrationValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationValidationWaitStatistics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics>
    {
        internal MigrationValidationWaitStatistics() { }
        public long? WaitCount { get { throw null; } }
        public float? WaitTimeInMilliseconds { get { throw null; } }
        public string WaitType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.MigrationValidationWaitStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationValidatioUpdateActionType : System.IEquatable<Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationValidatioUpdateActionType(string value) { throw null; }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType AddedOnTarget { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType ChangedOnTarget { get { throw null; } }
        public static Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType DeletedOnTarget { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType left, Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType left, Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryAnalysisValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryAnalysisValidationResult>
    {
        internal QueryAnalysisValidationResult() { }
        public Azure.ResourceManager.DataMigration.Models.QueryExecutionResult QueryResults { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationError ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.QueryExecutionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.QueryExecutionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.QueryExecutionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SchemaComparisonValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResult>
    {
        internal SchemaComparisonValidationResult() { }
        public Azure.ResourceManager.DataMigration.Models.SchemaComparisonValidationResultType SchemaDifferences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, long> SourceDatabaseObjectCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, long> TargetDatabaseObjectCount { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidationError ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseObjectType? ObjectType { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.MigrationValidatioUpdateActionType? UpdateAction { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SelectedCertificateInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ServerConnectionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo>
    {
        protected ServerConnectionInfo() { }
        public string Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ServerConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ServerLevelPermissionsGroup
    {
        Default = 0,
        MigrationFromSqlServerToAzureDB = 1,
        MigrationFromSqlServerToAzureMI = 2,
        MigrationFromMySqlToAzureDBForMySql = 3,
        MigrationFromSqlServerToAzureVm = 4,
    }
    public partial class SqlMigrationAuthenticationKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys>
    {
        internal SqlMigrationAuthenticationKeys() { }
        public string AuthKey1 { get { throw null; } }
        public string AuthKey2 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationAuthenticationKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SqlMigrationBlobAuthType
    {
        AccountKey = 0,
        ManagedIdentity = 1,
    }
    public partial class SqlMigrationBlobDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails>
    {
        public SqlMigrationBlobDetails() { }
        public string AccountKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobAuthType? AuthType { get { throw null; } set { } }
        public string BlobContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationBlobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMigrationErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo>
    {
        internal SqlMigrationErrorInfo() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMigrationRegenAuthKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys>
    {
        public SqlMigrationRegenAuthKeys() { }
        public string AuthKey1 { get { throw null; } set { } }
        public string AuthKey2 { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationRegenAuthKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMigrationServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>
    {
        public SqlMigrationServicePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMigrationTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>
    {
        public SqlMigrationTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlMigrationTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerSqlMISyncTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>
    {
        public SqlServerSqlMISyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, string storageResourceId, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp azureApp) { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp AzureApp { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo BackupFileShare { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public string StorageResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SsisMigrationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.SsisMigrationInfo>
    {
        public SsisMigrationInfo() { }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption? EnvironmentOverwriteOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.SsisMigrationOverwriteOption? ProjectOverwriteOption { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSsisStoreType? SsisStoreType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class UploadOciDriverTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>
    {
        internal UploadOciDriverTaskOutput() { }
        public string DriverPackageName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UploadOciDriverTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>
    {
        public UploadOciDriverTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo InputDriverShare { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.UploadOciDriverTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlDBSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>
    {
        public ValidateMigrationInputSqlServerSqlDBSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlDBSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMISyncTaskInput : Azure.ResourceManager.DataMigration.Models.SqlServerSqlMISyncTaskInput, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput>
    {
        public ValidateMigrationInputSqlServerSqlMISyncTaskInput(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, string storageResourceId, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo targetConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp azureApp) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput>), default(string), default(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.DataMigrationMISqlConnectionInfo), default(Azure.ResourceManager.DataMigration.Models.DataMigrationAadApp)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMISyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>
    {
        public ValidateMigrationInputSqlServerSqlMISyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMISyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMITaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>
    {
        public ValidateMigrationInputSqlServerSqlMITaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, Azure.ResourceManager.DataMigration.Models.DataMigrationBlobShare backupBlobShare) { }
        public System.Uri BackupBlobShareSasUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationFileShareInfo BackupFileShare { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationBackupMode? BackupMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlMIDatabaseInput> SelectedDatabases { get { throw null; } }
        public System.Collections.Generic.IList<string> SelectedLogins { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMITaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>
    {
        internal ValidateMigrationInputSqlServerSqlMITaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> BackupFolderErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> BackupShareCredentialsErrors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> BackupStorageAccountErrors { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationDatabaseBackupInfo DatabaseBackupInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ExistingBackupErrors { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> RestoreDatabaseNameErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMigrationInputSqlServerSqlMITaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>
    {
        public ValidateMigrationInputSqlServerSqlMITaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMigrationInputSqlServerSqlMITaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateMongoDBTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>
    {
        public ValidateMongoDBTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationSettings Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationMongoDBMigrationProgress> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateMongoDBTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateOracleAzureDBForPostgreSqlSyncTaskProperties : Azure.ResourceManager.DataMigration.Models.DataMigrationProjectTaskProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>
    {
        public ValidateOracleAzureDBForPostgreSqlSyncTaskProperties() { }
        public Azure.ResourceManager.DataMigration.Models.MigrateOracleAzureDBPostgreSqlSyncTaskInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput> Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBForPostgreSqlSyncTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateOracleAzureDBPostgreSqlSyncTaskOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>
    {
        internal ValidateOracleAzureDBPostgreSqlSyncTaskOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateOracleAzureDBPostgreSqlSyncTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateSyncMigrationInputSqlServerTaskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskInput>
    {
        public ValidateSyncMigrationInputSqlServerTaskInput(Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo sourceConnectionInfo, Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo targetConnectionInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> selectedDatabases) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataMigration.Models.MigrateSqlServerSqlDBSyncDatabaseInput> SelectedDatabases { get { throw null; } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo SourceConnectionInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataMigration.Models.DataMigrationSqlConnectionInfo TargetConnectionInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataMigration.Models.DataMigrationReportableException> ValidationErrors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataMigration.Models.ValidateSyncMigrationInputSqlServerTaskOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
