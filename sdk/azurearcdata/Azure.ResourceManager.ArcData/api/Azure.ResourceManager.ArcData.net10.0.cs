namespace Azure.ResourceManager.ArcData
{
    public partial class ArcDataActiveDirectoryConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>, System.Collections.IEnumerable
    {
        protected ArcDataActiveDirectoryConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string activeDirectoryConnectorName, Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string activeDirectoryConnectorName, Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> Get(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>> GetAsync(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> GetIfExists(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>> GetIfExistsAsync(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcDataActiveDirectoryConnectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>
    {
        public ArcDataActiveDirectoryConnectorData(Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties properties) { }
        public Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcDataActiveDirectoryConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcDataActiveDirectoryConnectorResource() { }
        public virtual Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataControllerName, string activeDirectoryConnectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ArcDataExtensions
    {
        public static Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource GetArcDataActiveDirectoryConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource> GetDataController(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource>> GetDataControllerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArcData.DataControllerResource GetDataControllerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArcData.DataControllerCollection GetDataControllers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ArcData.DataControllerResource> GetDataControllers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ArcData.DataControllerResource> GetDataControllersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArcData.FailoverGroupResource GetFailoverGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource> GetPostgresInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource>> GetPostgresInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArcData.PostgresInstanceResource GetPostgresInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArcData.PostgresInstanceCollection GetPostgresInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ArcData.PostgresInstanceResource> GetPostgresInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ArcData.PostgresInstanceResource> GetPostgresInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> GetSqlManagedInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> GetSqlManagedInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlManagedInstanceResource GetSqlManagedInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlManagedInstanceCollection GetSqlManagedInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> GetSqlManagedInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> GetSqlManagedInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource GetSqlServerAvailabilityGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerDatabaseResource GetSqlServerDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> GetSqlServerEsuLicense(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> GetSqlServerEsuLicenseAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource GetSqlServerEsuLicenseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerEsuLicenseCollection GetSqlServerEsuLicenses(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> GetSqlServerEsuLicenses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> GetSqlServerEsuLicensesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource> GetSqlServerInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> GetSqlServerInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerInstanceResource GetSqlServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerInstanceCollection GetSqlServerInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerInstanceResource> GetSqlServerInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerInstanceResource> GetSqlServerInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource> GetSqlServerLicense(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> GetSqlServerLicenseAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerLicenseResource GetSqlServerLicenseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerLicenseCollection GetSqlServerLicenses(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerLicenseResource> GetSqlServerLicenses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerLicenseResource> GetSqlServerLicensesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerArcDataContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerArcDataContext() { }
        public static Azure.ResourceManager.ArcData.AzureResourceManagerArcDataContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DataControllerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.DataControllerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.DataControllerResource>, System.Collections.IEnumerable
    {
        protected DataControllerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.DataControllerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataControllerName, Azure.ResourceManager.ArcData.DataControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.DataControllerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataControllerName, Azure.ResourceManager.ArcData.DataControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource> Get(string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.DataControllerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.DataControllerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource>> GetAsync(string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.DataControllerResource> GetIfExists(string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.DataControllerResource>> GetIfExistsAsync(string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.DataControllerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.DataControllerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.DataControllerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.DataControllerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataControllerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.DataControllerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.DataControllerData>
    {
        public DataControllerData(Azure.Core.AzureLocation location, Azure.ResourceManager.ArcData.Models.DataControllerProperties properties) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DataControllerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.DataControllerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.DataControllerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.DataControllerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.DataControllerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.DataControllerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.DataControllerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.DataControllerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataControllerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.DataControllerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.DataControllerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataControllerResource() { }
        public virtual Azure.ResourceManager.ArcData.DataControllerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataControllerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource> GetArcDataActiveDirectoryConnector(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource>> GetArcDataActiveDirectoryConnectorAsync(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorCollection GetArcDataActiveDirectoryConnectors() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.DataControllerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.DataControllerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.DataControllerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.DataControllerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.DataControllerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.DataControllerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.DataControllerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.DataControllerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.DataControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.DataControllerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.DataControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FailoverGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.FailoverGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.FailoverGroupResource>, System.Collections.IEnumerable
    {
        protected FailoverGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.FailoverGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.ArcData.FailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.FailoverGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string failoverGroupName, Azure.ResourceManager.ArcData.FailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.FailoverGroupResource> Get(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.FailoverGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.FailoverGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.FailoverGroupResource>> GetAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.FailoverGroupResource> GetIfExists(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.FailoverGroupResource>> GetIfExistsAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.FailoverGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.FailoverGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.FailoverGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.FailoverGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FailoverGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.FailoverGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.FailoverGroupData>
    {
        public FailoverGroupData(Azure.ResourceManager.ArcData.Models.FailoverGroupProperties properties) { }
        public Azure.ResourceManager.ArcData.Models.FailoverGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.FailoverGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.FailoverGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.FailoverGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.FailoverGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.FailoverGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.FailoverGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.FailoverGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FailoverGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.FailoverGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.FailoverGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FailoverGroupResource() { }
        public virtual Azure.ResourceManager.ArcData.FailoverGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlManagedInstanceName, string failoverGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.FailoverGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.FailoverGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.FailoverGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.FailoverGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.FailoverGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.FailoverGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.FailoverGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.FailoverGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.FailoverGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.FailoverGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.FailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.FailoverGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.FailoverGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgresInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.PostgresInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.PostgresInstanceResource>, System.Collections.IEnumerable
    {
        protected PostgresInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.PostgresInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string postgresInstanceName, Azure.ResourceManager.ArcData.PostgresInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.PostgresInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string postgresInstanceName, Azure.ResourceManager.ArcData.PostgresInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource> Get(string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.PostgresInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.PostgresInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource>> GetAsync(string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.PostgresInstanceResource> GetIfExists(string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.PostgresInstanceResource>> GetIfExistsAsync(string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.PostgresInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.PostgresInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.PostgresInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.PostgresInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgresInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.PostgresInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.PostgresInstanceData>
    {
        public PostgresInstanceData(Azure.Core.AzureLocation location, Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties properties) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.PostgresInstanceSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.PostgresInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.PostgresInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgresInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.PostgresInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.PostgresInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgresInstanceResource() { }
        public virtual Azure.ResourceManager.ArcData.PostgresInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string postgresInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.PostgresInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.PostgresInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.PostgresInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource> Update(Azure.ResourceManager.ArcData.Models.PostgresInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource>> UpdateAsync(Azure.ResourceManager.ArcData.Models.PostgresInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlManagedInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>, System.Collections.IEnumerable
    {
        protected SqlManagedInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlManagedInstanceName, Azure.ResourceManager.ArcData.SqlManagedInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlManagedInstanceName, Azure.ResourceManager.ArcData.SqlManagedInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> Get(string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> GetAsync(string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> GetIfExists(string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> GetIfExistsAsync(string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlManagedInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>
    {
        public SqlManagedInstanceData(Azure.Core.AzureLocation location, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties properties) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.SqlManagedInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlManagedInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlManagedInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlManagedInstanceResource() { }
        public virtual Azure.ResourceManager.ArcData.SqlManagedInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlManagedInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.FailoverGroupResource> GetFailoverGroup(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.FailoverGroupResource>> GetFailoverGroupAsync(string failoverGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.FailoverGroupCollection GetFailoverGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.SqlManagedInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlManagedInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlManagedInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> Update(Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> UpdateAsync(Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlServerAvailabilityGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>, System.Collections.IEnumerable
    {
        protected SqlServerAvailabilityGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string availabilityGroupName, Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string availabilityGroupName, Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string availabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string availabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> Get(string availabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> GetAsync(string availabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> GetIfExists(string availabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> GetIfExistsAsync(string availabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlServerAvailabilityGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>
    {
        public SqlServerAvailabilityGroupData(Azure.Core.AzureLocation location, Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties properties) { }
        public Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerAvailabilityGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlServerAvailabilityGroupResource() { }
        public virtual Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> AddDatabases(Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> AddDatabasesAsync(Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlServerInstanceName, string availabilityGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteMiLink(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteMiLinkAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> DetailView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> DetailViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> Failover(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> FailoverAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> FailoverMiLink(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> FailoverMiLinkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> ForceFailoverAllowDataLoss(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> ForceFailoverAllowDataLossAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> RemoveDatabases(Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> RemoveDatabasesAsync(Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlServerDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>, System.Collections.IEnumerable
    {
        protected SqlServerDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.ArcData.SqlServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.ArcData.SqlServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlServerDatabaseData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>
    {
        public SqlServerDatabaseData(Azure.Core.AzureLocation location, Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties properties) { }
        public Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerDatabaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlServerDatabaseResource() { }
        public virtual Azure.ResourceManager.ArcData.SqlServerDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlServerInstanceName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlServerEsuLicenseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>, System.Collections.IEnumerable
    {
        protected SqlServerEsuLicenseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlServerEsuLicenseName, Azure.ResourceManager.ArcData.SqlServerEsuLicenseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlServerEsuLicenseName, Azure.ResourceManager.ArcData.SqlServerEsuLicenseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> Get(string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> GetAsync(string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> GetIfExists(string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> GetIfExistsAsync(string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlServerEsuLicenseData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>
    {
        public SqlServerEsuLicenseData(Azure.Core.AzureLocation location, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties properties) { }
        public Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerEsuLicenseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerEsuLicenseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerEsuLicenseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlServerEsuLicenseResource() { }
        public virtual Azure.ResourceManager.ArcData.SqlServerEsuLicenseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlServerEsuLicenseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerEsuLicenseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerEsuLicenseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerEsuLicenseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> Update(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> UpdateAsync(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SqlServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlServerInstanceName, Azure.ResourceManager.ArcData.SqlServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlServerInstanceName, Azure.ResourceManager.ArcData.SqlServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource> Get(string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> GetAsync(string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerInstanceResource> GetIfExists(string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> GetIfExistsAsync(string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.SqlServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.SqlServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>
    {
        public SqlServerInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlServerInstanceResource() { }
        public virtual Azure.ResourceManager.ArcData.SqlServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> CreateAvailabilityGroup(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> CreateAvailabilityGroupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> CreateDistributedAvailabilityGroup(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> CreateDistributedAvailabilityGroupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> CreateManagedInstanceLink(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> CreateManagedInstanceLinkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlServerInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> GetAllAvailabilityGroups(Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters availabilityGroupRetrievalFilters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> GetAllAvailabilityGroupsAsync(Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters availabilityGroupRetrievalFilters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult> GetJobs(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult>> GetJobsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult> GetJobsStatus(Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult>> GetJobsStatusAsync(Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult> GetMigrationReadinessReport(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult>> GetMigrationReadinessReportAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> GetSqlServerAvailabilityGroup(string availabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> GetSqlServerAvailabilityGroupAsync(string availabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupCollection GetSqlServerAvailabilityGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource> GetSqlServerDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerDatabaseResource>> GetSqlServerDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerDatabaseCollection GetSqlServerDatabases() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult> GetTargetRecommendationReports(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult>> GetTargetRecommendationReportsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource> PostUpgrade(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> PostUpgradeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource> PreUpgrade(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> PreUpgradeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult> RunBestPracticeAssessment(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult>> RunBestPracticeAssessmentAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult> RunBestPracticesAssessment(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult>> RunBestPracticesAssessmentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult> RunManagedInstanceLinkAssessment(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult>> RunManagedInstanceLinkAssessmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult> RunMigrationAssessment(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult>> RunMigrationAssessmentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult> RunMigrationReadinessAssessment(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult>> RunMigrationReadinessAssessmentAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult> RunTargetRecommendationJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult>> RunTargetRecommendationJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlServerLicenseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerLicenseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerLicenseResource>, System.Collections.IEnumerable
    {
        protected SqlServerLicenseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerLicenseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlServerLicenseName, Azure.ResourceManager.ArcData.SqlServerLicenseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlServerLicenseName, Azure.ResourceManager.ArcData.SqlServerLicenseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource> Get(string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerLicenseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerLicenseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> GetAsync(string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerLicenseResource> GetIfExists(string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> GetIfExistsAsync(string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.SqlServerLicenseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.SqlServerLicenseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.SqlServerLicenseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.SqlServerLicenseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlServerLicenseData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>
    {
        public SqlServerLicenseData(Azure.Core.AzureLocation location, Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties properties) { }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerLicenseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerLicenseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerLicenseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlServerLicenseResource() { }
        public virtual Azure.ResourceManager.ArcData.SqlServerLicenseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlServerLicenseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.SqlServerLicenseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.SqlServerLicenseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.SqlServerLicenseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource> Update(Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> UpdateAsync(Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ArcData.Mocking
{
    public partial class MockableArcDataArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableArcDataArmClient() { }
        public virtual Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorResource GetArcDataActiveDirectoryConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArcData.DataControllerResource GetDataControllerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArcData.FailoverGroupResource GetFailoverGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArcData.PostgresInstanceResource GetPostgresInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlManagedInstanceResource GetSqlManagedInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource GetSqlServerAvailabilityGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerDatabaseResource GetSqlServerDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource GetSqlServerEsuLicenseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerInstanceResource GetSqlServerInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerLicenseResource GetSqlServerLicenseResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableArcDataResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableArcDataResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource> GetDataController(string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.DataControllerResource>> GetDataControllerAsync(string dataControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.DataControllerCollection GetDataControllers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource> GetPostgresInstance(string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.PostgresInstanceResource>> GetPostgresInstanceAsync(string postgresInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.PostgresInstanceCollection GetPostgresInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> GetSqlManagedInstance(string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlManagedInstanceResource>> GetSqlManagedInstanceAsync(string sqlManagedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlManagedInstanceCollection GetSqlManagedInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> GetSqlServerEsuLicense(string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource>> GetSqlServerEsuLicenseAsync(string sqlServerEsuLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerEsuLicenseCollection GetSqlServerEsuLicenses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource> GetSqlServerInstance(string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerInstanceResource>> GetSqlServerInstanceAsync(string sqlServerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerInstanceCollection GetSqlServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource> GetSqlServerLicense(string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerLicenseResource>> GetSqlServerLicenseAsync(string sqlServerLicenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.SqlServerLicenseCollection GetSqlServerLicenses() { throw null; }
    }
    public partial class MockableArcDataSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableArcDataSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.DataControllerResource> GetDataControllers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.DataControllerResource> GetDataControllersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.PostgresInstanceResource> GetPostgresInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.PostgresInstanceResource> GetPostgresInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> GetSqlManagedInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlManagedInstanceResource> GetSqlManagedInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> GetSqlServerEsuLicenses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerEsuLicenseResource> GetSqlServerEsuLicensesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerInstanceResource> GetSqlServerInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerInstanceResource> GetSqlServerInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.SqlServerLicenseResource> GetSqlServerLicenses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.SqlServerLicenseResource> GetSqlServerLicensesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ArcData.Models
{
    public partial class ActiveDirectoryConnectorDnsDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails>
    {
        public ActiveDirectoryConnectorDnsDetails(System.Collections.Generic.IEnumerable<string> nameserverIpAddresses) { }
        public string DomainName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NameserverIpAddresses { get { throw null; } }
        public long? Replicas { get { throw null; } set { } }
        public bool? ShouldPreferK8sDnsForPtrLookups { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActiveDirectoryConnectorDomainDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails>
    {
        public ActiveDirectoryConnectorDomainDetails(string realm) { }
        public Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers DomainControllers { get { throw null; } set { } }
        public string NetbiosDomainName { get { throw null; } set { } }
        public string OuDistinguishedName { get { throw null; } set { } }
        public string Realm { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode? ServiceAccountProvisioning { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActiveDirectoryConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties>
    {
        public ActiveDirectoryConnectorProperties(Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec spec) { }
        public Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation DomainServiceAccountLoginInformation { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec Spec { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActiveDirectoryConnectorSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec>
    {
        public ActiveDirectoryConnectorSpec(Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails activeDirectory, Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails dns) { }
        public Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails ActiveDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails Dns { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActiveDirectoryConnectorStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus>
    {
        public ActiveDirectoryConnectorStatus() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string LastUpdateTime { get { throw null; } set { } }
        public long? ObservedGeneration { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActiveDirectoryDomainController : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController>
    {
        public ActiveDirectoryDomainController(string hostname) { }
        public string Hostname { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActiveDirectoryDomainControllers : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers>
    {
        public ActiveDirectoryDomainControllers() { }
        public string PrimaryDomainControllerHostname { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController> SecondaryDomainControllers { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActiveDirectoryServiceAccountProvisioningMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActiveDirectoryServiceAccountProvisioningMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode left, Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode left, Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdditionalMigrationJobAttributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes>
    {
        public AdditionalMigrationJobAttributes() { }
        public string KeyName { get { throw null; } set { } }
        public string KeyValue { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlwaysOnRole : System.IEquatable<Azure.ResourceManager.ArcData.Models.AlwaysOnRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlwaysOnRole(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AlwaysOnRole AvailabilityGroupReplica { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.AlwaysOnRole FailoverClusterInstance { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.AlwaysOnRole FailoverClusterNode { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.AlwaysOnRole None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.AlwaysOnRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.AlwaysOnRole left, Azure.ResourceManager.ArcData.Models.AlwaysOnRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.AlwaysOnRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.AlwaysOnRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.AlwaysOnRole left, Azure.ResourceManager.ArcData.Models.AlwaysOnRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcDataBasicLoginInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation>
    {
        public ArcDataBasicLoginInformation() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcDataProvisioningState : System.IEquatable<Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcDataProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState left, Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState left, Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcDataSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSku>
    {
        public ArcDataSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public bool? IsDevTestEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ArcDataSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ArcDataSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcDataSqlServerInstanceJobsRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent>
    {
        public ArcDataSqlServerInstanceJobsRequestContent() { }
        public string FeatureName { get { throw null; } set { } }
        public string JobType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcDataSqlServerInstanceJobsStatusRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent>
    {
        public ArcDataSqlServerInstanceJobsStatusRequestContent() { }
        public string FeatureName { get { throw null; } set { } }
        public string JobType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent>
    {
        public ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent(Azure.Core.ResourceIdentifier azureManagedInstanceResourceId, System.Collections.Generic.IEnumerable<string> databaseNames, string availabilityGroupName, string distributedAvailabilityGroupName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory> AssessmentCategories { get { throw null; } }
        public string AvailabilityGroupName { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzureManagedInstanceResourceId { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole? AzureManagedInstanceRole { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DatabaseNames { get { throw null; } }
        public string DistributedAvailabilityGroupName { get { throw null; } }
        public string SqlServerIPAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent>
    {
        public ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent() { }
        public int? LookbackPeriodInDays { get { throw null; } set { } }
        public int? Percentile { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode? ResourceUpdateMode { get { throw null; } set { } }
        public bool? ShouldIncludeFileLevelRequirements { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent>
    {
        public ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent() { }
        public System.Collections.Generic.IList<string> DatabaseNames { get { throw null; } }
        public int? ReportOffset { get { throw null; } set { } }
        public int? SectionOffset { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType? SectionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSqlManagedInstanceLicenseType : System.IEquatable<Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSqlManagedInstanceLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType BasePrice { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType left, Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType left, Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSqlServerAvailabilityGroupTypeFilter : System.IEquatable<Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSqlServerAvailabilityGroupTypeFilter(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter Contained { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter Default { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter Distributed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter left, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter left, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSqlServerAvailabilityMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSqlServerAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode AsynchronousCommit { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode SynchronousCommit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode left, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode left, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSqlServerFailoverMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSqlServerFailoverMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode External { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode Manual { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode left, Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode left, Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSqlServerHostType : System.IEquatable<Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSqlServerHostType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType AwsKubernetesService { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType AwsVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType AwsVmwareVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType AzureKubernetesService { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType AzureVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType AzureVmwareVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType Container { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType GcpKubernetesService { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType GcpVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType GcpVmwareVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType HyperVVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType Other { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType PhysicalServer { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType VirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType left, Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType left, Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSqlServerLicenseType : System.IEquatable<Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSqlServerLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType FabricCapacity { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType Free { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType Hadr { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType LicenseOnly { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType Paid { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType Payg { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType ServerCal { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType left, Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType left, Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmArcDataModelFactory
    {
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails ActiveDirectoryConnectorDnsDetails(string domainName = null, System.Collections.Generic.IEnumerable<string> nameserverIpAddresses = null, long? replicas = default(long?), bool? shouldPreferK8sDnsForPtrLookups = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails ActiveDirectoryConnectorDomainDetails(string realm = null, string netbiosDomainName = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode? serviceAccountProvisioning = default(Azure.ResourceManager.ArcData.Models.ActiveDirectoryServiceAccountProvisioningMode?), string ouDistinguishedName = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers domainControllers = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties ActiveDirectoryConnectorProperties(Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation domainServiceAccountLoginInformation = null, string provisioningState = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec spec = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus status = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec ActiveDirectoryConnectorSpec(Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails activeDirectory = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails dns = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus ActiveDirectoryConnectorStatus(string lastUpdateTime = null, long? observedGeneration = default(long?), string state = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController ActiveDirectoryDomainController(string hostname = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers ActiveDirectoryDomainControllers(string primaryDomainControllerHostname = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController> secondaryDomainControllers = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes AdditionalMigrationJobAttributes(string keyName = null, string keyValue = null) { throw null; }
        public static Azure.ResourceManager.ArcData.ArcDataActiveDirectoryConnectorData ArcDataActiveDirectoryConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation ArcDataBasicLoginInformation(string username = null, string password = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSku ArcDataSku(string name = null, bool? isDevTestEnabled = default(bool?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent ArcDataSqlServerInstanceJobsRequestContent(string featureName = null, string jobType = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent ArcDataSqlServerInstanceJobsStatusRequestContent(string featureName = null, string jobType = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent(Azure.Core.ResourceIdentifier azureManagedInstanceResourceId = null, Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole? azureManagedInstanceRole = default(Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole?), System.Collections.Generic.IEnumerable<string> databaseNames = null, string availabilityGroupName = null, string distributedAvailabilityGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory> assessmentCategories = null, string sqlServerIPAddress = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent(Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode? resourceUpdateMode = default(Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode?), bool? shouldIncludeFileLevelRequirements = default(bool?), string targetLocation = null, int? percentile = default(int?), int? lookbackPeriodInDays = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent(int? reportOffset = default(int?), int? sectionOffset = default(int?), Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType? sectionType = default(Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType?), System.Collections.Generic.IEnumerable<string> databaseNames = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure AvailabilityGroupConfigure(string endpointName = null, string endpointUri = null, Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType? endpointAuthenticationMode = default(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType?), string certificateName = null, string endpointConnectLogin = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? availabilityMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode?), string availabilityModeDescription = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? failoverMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode?), string failoverModeDescription = null, int? sessionTimeoutInSeconds = default(int?), Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections? primaryAllowConnections = default(Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections?), string primaryRoleAllowConnectionsDescription = null, Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections? secondaryAllowConnections = default(Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections?), string secondaryRoleAllowConnectionsDescription = null, System.DateTimeOffset? replicaCreateOn = default(System.DateTimeOffset?), System.DateTimeOffset? replicaModifyOn = default(System.DateTimeOffset?), int? backupPriority = default(int?), string readOnlyRoutingUri = null, string readWriteRoutingUri = null, Azure.ResourceManager.ArcData.Models.SeedingMode? seedingMode = default(Azure.ResourceManager.ArcData.Models.SeedingMode?), string seedingModeDescription = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration AvailabilityGroupCreateUpdateReplicaConfiguration(string serverInstance = null, string endpointName = null, string endpointUri = null, Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType? endpointAuthenticationMode = default(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType?), string certificateName = null, string endpointConnectLogin = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? availabilityMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode?), Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? failoverMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode?), Azure.ResourceManager.ArcData.Models.SeedingMode? seedingMode = default(Azure.ResourceManager.ArcData.Models.SeedingMode?), int? backupPriority = default(int?), Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections? secondaryRoleAllowConnections = default(Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections?), string secondaryRoleReadOnlyRoutingUri = null, Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections? primaryRoleAllowConnections = default(Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections?), System.Collections.Generic.IEnumerable<string> primaryRoleReadOnlyRoutingList = null, int? sessionTimeoutInSeconds = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo AvailabilityGroupInfo(int? failureConditionLevel = default(int?), int? healthCheckTimeoutInMilliseconds = default(int?), string automatedBackupPreferenceDescription = null, int? version = default(int?), bool? hasBasicFeatures = default(bool?), bool? isDtcSupportEnabled = default(bool?), bool? isDbFailoverSupported = default(bool?), bool? isDistributed = default(bool?), string clusterTypeDescription = null, int? requiredSynchronizedSecondariesToCommit = default(int?), bool? isContained = default(bool?), string primaryReplica = null, string primaryRecoveryHealthDescription = null, string secondaryRecoveryHealthDescription = null, string synchronizationHealthDescription = null, Azure.ResourceManager.ArcData.Models.ReplicationPartnerType? replicationPartnerType = default(Azure.ResourceManager.ArcData.Models.ReplicationPartnerType?), Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties listener = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters AvailabilityGroupRetrievalFilters(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter? availabilityGroupTypeFilter = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter?), Azure.ResourceManager.ArcData.Models.ReplicationPartnerType? replicationPartnerTypeFilter = default(Azure.ResourceManager.ArcData.Models.ReplicationPartnerType?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupState AvailabilityGroupState(string availabilityGroupReplicaRole = null, string operationalStateDescription = null, string recoveryHealthDescription = null, string synchronizationHealthDescription = null, string connectedStateDescription = null, string lastConnectErrorDescription = null, System.DateTimeOffset? lastConnectErrorOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.BestPracticesAssessment BestPracticesAssessment(bool? enabled = default(bool?), Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule schedule = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule BestPracticesAssessmentSchedule(bool? enabled = default(bool?), Azure.ResourceManager.ArcData.Models.CronTrigger cronTrigger = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.CronTrigger CronTrigger(string startTime = null, string timeZone = null, string expression = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem DatabaseAssessmentsItem(string appliesToMigrationTargetPlatform = null, string featureId = null, string issueCategory = null, string moreInformation = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMigration DatabaseMigration(Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment assessment = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem> jobs = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment DatabaseMigrationAssessment(System.DateTimeOffset? assessmentUploadOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetRecommendationGenerationOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem> databaseAssessments = null, Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness targetReadiness = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem DatabaseMigrationJobsItem(string migrationTrackingId = null, Azure.ResourceManager.ArcData.Models.MigrationMode? migrationMode = default(Azure.ResourceManager.ArcData.Models.MigrationMode?), Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource? initiatedFrom = default(Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource?), Azure.ResourceManager.ArcData.Models.MigrationStatus? status = default(Azure.ResourceManager.ArcData.Models.MigrationStatus?), string lastError = null, Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType? targetType = default(Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType?), string targetResourceId = null, System.DateTimeOffset? startsOn = default(System.DateTimeOffset?), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes> additionalAttributes = null) { throw null; }
        public static Azure.ResourceManager.ArcData.DataControllerData DataControllerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.DataControllerProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig DataControllerOnPremisesConfig(string id = null, string publicSigningKey = null, string signingCertificateThumbprint = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DataControllerPatch DataControllerPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.DataControllerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DataControllerProperties DataControllerProperties(Azure.ResourceManager.ArcData.Models.DataControllerInfrastructure? infrastructure = default(Azure.ResourceManager.ArcData.Models.DataControllerInfrastructure?), Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig onPremiseProperty = null, System.BinaryData k8sRaw = null, Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark uploadWatermark = null, System.DateTimeOffset? lastUploadedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation basicLoginInformation = null, Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation metricsDashboardCredential = null, Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation logsDashboardCredential = null, Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig logAnalyticsWorkspaceConfig = null, Azure.ResourceManager.ArcData.Models.UploadServicePrincipal uploadServicePrincipal = null, string provisioningState = null, string clusterId = null, string extensionId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark DataControllerUploadWatermark(System.DateTimeOffset? metrics = default(System.DateTimeOffset?), System.DateTimeOffset? logs = default(System.DateTimeOffset?), System.DateTimeOffset? usages = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DbmEndpoint DbmEndpoint(string endpointName = null, Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole? role = default(Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole?), bool? isEncryptionEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm? encryptionAlgorithm = default(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm?), Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType? connectionAuth = default(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType?), int? port = default(int?), bool? isDynamicPort = default(bool?), string ipAddress = null, string certificateName = null, System.DateTimeOffset? certificateExpiryOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DiskSizes DiskSizes(string diskType = null, string redundancy = null, string size = null, string caching = null, float? maxSizeInGib = default(float?), float? maxThroughputInMbps = default(float?), float? maxIops = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration(Azure.Core.ResourceIdentifier availabilityGroup = null, System.Uri listenerUri = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? availabilityMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode?), Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? failoverMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode?), Azure.ResourceManager.ArcData.Models.SeedingMode? seedingMode = default(Azure.ResourceManager.ArcData.Models.SeedingMode?), string certificateName = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.EntraAuthentication EntraAuthentication(Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType? identityType = default(Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType?), string clientId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.FailoverCluster FailoverCluster(string id = null, string networkName = null, System.Collections.Generic.IEnumerable<string> sqlInstanceIds = null, System.Collections.Generic.IEnumerable<string> hostNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation> hostIPAddresses = null) { throw null; }
        public static Azure.ResourceManager.ArcData.FailoverGroupData FailoverGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ArcData.Models.FailoverGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.FailoverGroupProperties FailoverGroupProperties(Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState? provisioningState = default(Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState?), Azure.Core.ResourceIdentifier partnerManagedInstanceId = null, Azure.ResourceManager.ArcData.Models.FailoverGroupSpec spec = null, System.BinaryData status = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.FailoverGroupSpec FailoverGroupSpec(string sharedName = null, string sourceMI = null, string partnerMI = null, string partnerMirroringUri = null, string partnerMirroringCert = null, Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode? partnerSyncMode = default(Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode?), Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole role = default(Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.HostIPAddressInformation HostIPAddressInformation(string ipAddress = null, string subnetMask = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sActiveDirectory K8sActiveDirectory(Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector connector = null, string accountName = null, string keytabSecret = null, System.Collections.Generic.IEnumerable<string> encryptionTypes = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector K8sActiveDirectoryConnector(string name = null, string @namespace = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sNetworkSettings K8sNetworkSettings(int? forceEncryption = default(int?), string tlsCiphers = null, string tlsProtocols = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sResourceRequirements K8sResourceRequirements(System.Collections.Generic.IDictionary<string, string> requests = null, System.Collections.Generic.IDictionary<string, string> limits = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sScheduling K8sScheduling(Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig @default = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig K8sSchedulingConfig(Azure.ResourceManager.ArcData.Models.K8sResourceRequirements resources = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sSecurity K8sSecurity(string adminLoginSecret = null, string serviceCertificateSecret = null, Azure.ResourceManager.ArcData.Models.K8sActiveDirectory activeDirectory = null, Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption transparentDataEncryption = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sSettings K8sSettings(Azure.ResourceManager.ArcData.Models.K8sNetworkSettings network = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption K8sTransparentDataEncryption(string mode = null, string protectorSecret = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig LogAnalyticsWorkspaceConfig(string workspaceId = null, string primaryKey = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.MigrationAssessment MigrationAssessment(bool? enabled = default(bool?), System.DateTimeOffset? assessmentUploadOn = default(System.DateTimeOffset?), System.DateTimeOffset? assessmentViewedOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetRecommendationGenerationOn = default(System.DateTimeOffset?), string version = null, Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings settings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem> serverAssessments = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResults skuRecommendationResults = null, Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary impactedObjectsSummary = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings MigrationAssessmentSettings(string targetLocation = null, float? percentile = default(float?), int? lookbackPeriodInDays = default(int?), int? comfortFactor = default(int?), string strategy = null, string currency = null, float? discountPercentage = default(float?), Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions costOptions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.PostgresInstanceData PostgresInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.ArcData.Models.PostgresInstanceSku sku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.PostgresInstancePatch PostgresInstancePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties PostgresInstanceProperties(string dataControllerId = null, string admin = null, Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation basicLoginInformation = null, System.BinaryData k8sRaw = null, System.DateTimeOffset? lastUploadedOn = default(System.DateTimeOffset?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.PostgresInstanceSku PostgresInstanceSku(string name = null, bool? isDevTestEnabled = default(bool?), string size = null, string family = null, int? capacity = default(int?), Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier? tier = default(Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SequencerAction SequencerAction(string actionId = null, Azure.ResourceManager.ArcData.Models.SequencerState? state = default(Azure.ResourceManager.ArcData.Models.SequencerState?), Azure.ResourceManager.ArcData.Models.SequencerActionResult? result = default(Azure.ResourceManager.ArcData.Models.SequencerActionResult?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem ServerAssessmentsItem(string appliesToMigrationTargetPlatform = null, string featureId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem> impactedObjects = null, string issueCategory = null, string moreInformation = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem ServerAssessmentsPropertiesItemsItem(string impactDetail = null, string name = null, string objectType = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResults SkuRecommendationResults(Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase azureSqlDatabase = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance azureSqlManagedInstance = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine azureSqlVirtualMachine = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase SkuRecommendationResultsAzureSqlDatabase(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus? recommendationStatus = default(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus?), int? numberOfServerBlockerIssues = default(int?), Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost monthlyCost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> monthlyCostOptions = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku targetSku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku SkuRecommendationResultsAzureSqlDatabaseTargetSku(Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory category = null, int? computeSize = default(int?), float? storageMaxSizeInMb = default(float?), float? predictedDataSizeInMb = default(float?), float? predictedLogSizeInMb = default(float?), float? maxStorageIops = default(float?), float? maxThroughputMBps = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory(string computeTier = null, string hardwareType = null, string sqlPurchasingModel = null, string sqlServiceTier = null, bool? isZoneRedundancyAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance SkuRecommendationResultsAzureSqlManagedInstance(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus? recommendationStatus = default(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus?), int? numberOfServerBlockerIssues = default(int?), Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost monthlyCost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> monthlyCostOptions = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku targetSku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku SkuRecommendationResultsAzureSqlManagedInstanceTargetSku(Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory category = null, int? computeSize = default(int?), float? storageMaxSizeInMb = default(float?), float? predictedDataSizeInMb = default(float?), float? predictedLogSizeInMb = default(float?), float? maxStorageIops = default(float?), float? maxThroughputMBps = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory(string computeTier = null, string hardwareType = null, string sqlPurchasingModel = null, string sqlServiceTier = null, bool? isZoneRedundancyAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine SkuRecommendationResultsAzureSqlVirtualMachine(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus? recommendationStatus = default(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus?), int? numberOfServerBlockerIssues = default(int?), Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost monthlyCost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> monthlyCostOptions = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku targetSku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku SkuRecommendationResultsAzureSqlVirtualMachineTargetSku(Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory category = null, int? computeSize = default(int?), float? predictedDataSizeInMb = default(float?), float? predictedLogSizeInMb = default(float?), Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize virtualMachineSize = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DiskSizes> dataDiskSizes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DiskSizes> logDiskSizes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DiskSizes> tempDbDiskSizes = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory(System.Collections.Generic.IEnumerable<string> availableVmSkus = null, string virtualMachineFamily = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize(string virtualMachineFamily = null, string sizeName = null, int? computeSize = default(int?), string azureSkuName = null, int? vcpUsAvailable = default(int?), int? maxNetworkInterfaces = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost SkuRecommendationResultsMonthlyCost(float? computeCost = default(float?), float? storageCost = default(float?), float? iopsCost = default(float?), float? sqlLicenseCost = default(float?), float? windowsLicenseCost = default(float?), float? totalCost = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem SkuRecommendationResultsMonthlyCostOptionItem(string keyName = null, Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown keyValue = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary SkuRecommendationSummary(int? numOfBlockerIssues = default(int?), Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus? recommendationStatus = default(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo> impactedObjectsSummary = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost monthlyCost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> monthlyCostOptions = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku targetSku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku SkuRecommendationSummaryTargetSku(Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory category = null, int? computeSize = default(int?), float? storageMaxSizeInMb = default(float?), float? predictedDataSizeInMb = default(float?), float? predictedLogSizeInMb = default(float?), float? maxStorageIops = default(float?), float? maxThroughputMBps = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory SkuRecommendationSummaryTargetSkuCategory(string computeTier = null, string hardwareType = null, string sqlPurchasingModel = null, string sqlServiceTier = null, bool? isZoneRedundancyAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent SqlAvailabilityGroupContent(string availabilityGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration> replicas = null, System.Collections.Generic.IEnumerable<string> databases = null, Azure.ResourceManager.ArcData.Models.AutomatedBackupPreference? automatedBackupPreference = default(Azure.ResourceManager.ArcData.Models.AutomatedBackupPreference?), Azure.ResourceManager.ArcData.Models.FailureConditionLevel? failureConditionLevel = default(Azure.ResourceManager.ArcData.Models.FailureConditionLevel?), int? healthCheckTimeoutInMilliseconds = default(int?), Azure.ResourceManager.ArcData.Models.DbFailover? dbFailover = default(Azure.ResourceManager.ArcData.Models.DbFailover?), Azure.ResourceManager.ArcData.Models.DtcSupport? dtcSupport = default(Azure.ResourceManager.ArcData.Models.DtcSupport?), int? requiredSynchronizedSecondariesToCommit = default(int?), Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupClusterType? clusterType = default(Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupClusterType?), Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties listener = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties SqlAvailabilityGroupDatabaseReplicaResourceProperties(string databaseName = null, string replicaName = null, bool? isLocal = default(bool?), bool? isPrimaryReplica = default(bool?), string synchronizationStateDescription = null, bool? isCommitParticipant = default(bool?), string synchronizationHealthDescription = null, string databaseStateDescription = null, bool? isSuspended = default(bool?), string suspendReasonDescription = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent SqlAvailabilityGroupDatabasesContent(System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem(string ipAddress = null, string mask = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties SqlAvailabilityGroupReplicaResourceProperties(string replicaId = null, string replicaName = null, Azure.Core.ResourceIdentifier replicaResourceId = null, Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure configure = null, Azure.ResourceManager.ArcData.Models.AvailabilityGroupState state = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties SqlAvailabilityGroupStaticIPListenerProperties(string dnsName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem> ipv4AddressesAndMasks = null, System.Collections.Generic.IEnumerable<string> ipv6Addresses = null, int? port = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent SqlDistributedAvailabilityGroupContent(string availabilityGroupName = null, Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration primaryAvailabilityGroup = null, Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration secondaryAvailabilityGroup = null) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlManagedInstanceData SqlManagedInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku sku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw SqlManagedInstanceK8sRaw(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec spec = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec SqlManagedInstanceK8sSpec(Azure.ResourceManager.ArcData.Models.K8sScheduling scheduling = null, int? replicas = default(int?), Azure.ResourceManager.ArcData.Models.K8sSecurity security = null, Azure.ResourceManager.ArcData.Models.K8sSettings settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent SqlManagedInstanceLinkContent(Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent availabilityGroup = null, Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent distributedAvailabilityGroup = null, string miLinkInstanceAvailabilityGroupName = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent SqlManagedInstanceLinkFailoverContent(Azure.Core.ResourceIdentifier managedInstanceId = null, bool? shouldForce = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch SqlManagedInstancePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties SqlManagedInstanceProperties(string dataControllerId = null, string admin = null, string startTime = null, string endTime = null, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw k8sRaw = null, Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation basicLoginInformation = null, System.DateTimeOffset? lastUploadedOn = default(System.DateTimeOffset?), string provisioningState = null, string activeDirectoryInformationKeytab = null, Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType? licenseType = default(Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType?), string clusterId = null, string extensionId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku SqlManagedInstanceSku(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSkuTier? tier = default(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSkuTier?), bool? isDevTestEnabled = default(bool?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo SqlMigrationImpactedObjectInfo(string featureId = null, int? numberImpacted = default(int?), string issueCategory = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary SqlMigrationImpactedObjectsSuitabilitySummary(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo> azureSqlDatabase = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo> azureSqlManagedInstance = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness SqlMigrationTargetReadiness(Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary azureSqlDatabase = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary azureSqlManagedInstance = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary azureSqlVirtualMachine = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAuthentication SqlServerAuthentication(Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode? mode = default(Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.EntraAuthentication> sqlServerEntraIdentity = null) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData SqlServerAvailabilityGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch SqlServerAvailabilityGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties SqlServerAvailabilityGroupResourceProperties(string availabilityGroupId = null, string serverName = null, string instanceName = null, string vmId = null, System.DateTimeOffset? collectionOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo info = null, Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas replicas = null, Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases databases = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases SqlServerAvailabilityGroupResourcePropertiesDatabases(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties> value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas SqlServerAvailabilityGroupResourcePropertiesReplicas(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties> value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob SqlServerBackgroundJob(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState? state = default(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState?), Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState? executionState = default(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState?), System.DateTimeOffset? startsOn = default(System.DateTimeOffset?), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus? lastExecutionStatus = default(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus?), System.DateTimeOffset? lastExecutionOn = default(System.DateTimeOffset?), System.DateTimeOffset? nextExecutionOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy SqlServerBackupPolicy(int? retentionPeriodDays = default(int?), int? fullBackupDays = default(int?), Azure.ResourceManager.ArcData.Models.DifferentialBackupHours? differentialBackupHours = default(Azure.ResourceManager.ArcData.Models.DifferentialBackupHours?), int? transactionLogBackupMinutes = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig SqlServerDatabaseConfig(bool? isAutoCloseOn = default(bool?), bool? isAutoShrinkOn = default(bool?), bool? isAutoCreateStatsOn = default(bool?), bool? isAutoUpdateStatsOn = default(bool?), bool? isRemoteDataArchiveEnabled = default(bool?), bool? isMemoryOptimizationEnabled = default(bool?), bool? isEncrypted = default(bool?), bool? isTrustworthyOn = default(bool?), bool? isHekatonFilesOn = default(bool?), int? numberOfHekatonFiles = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerDatabaseData SqlServerDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch SqlServerDatabasePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties SqlServerDatabaseResourceProperties(string collationName = null, System.DateTimeOffset? databaseCreatedOn = default(System.DateTimeOffset?), int? compatibilityLevel = default(int?), float? sizeMB = default(float?), float? logFileSizeMB = default(float?), float? dataFileSizeMB = default(float?), float? spaceAvailableMB = default(float?), Azure.ResourceManager.ArcData.Models.DatabaseState? state = default(Azure.ResourceManager.ArcData.Models.DatabaseState?), bool? isReadOnly = default(bool?), Azure.ResourceManager.ArcData.Models.RecoveryMode? recoveryMode = default(Azure.ResourceManager.ArcData.Models.RecoveryMode?), Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig databaseOptions = null, Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation backupInformation = null, Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy backupPolicy = null, System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.DatabaseCreateMode? createMode = default(Azure.ResourceManager.ArcData.Models.DatabaseCreateMode?), string sourceDatabaseId = null, string vmId = null, System.DateTimeOffset? restorePointInTime = default(System.DateTimeOffset?), string provisioningState = null, System.DateTimeOffset? lastDatabaseUploadOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.DatabaseMigration migration = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation SqlServerDatabaseResourcePropertiesBackupInformation(System.DateTimeOffset? lastFullBackup = default(System.DateTimeOffset?), System.DateTimeOffset? lastLogBackup = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerEsuLicenseData SqlServerEsuLicenseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch SqlServerEsuLicensePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties SqlServerEsuLicenseProperties(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan billingPlan = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan), Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion version = default(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion), string uniqueId = null, int physicalCores = 0, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState activationState = default(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState), Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType scopeType = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType), System.DateTimeOffset? activatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? terminatedOn = default(System.DateTimeOffset?), string tenantId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties SqlServerEsuLicenseUpdateProperties(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan? billingPlan = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan?), Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion? version = default(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion?), string uniqueId = null, int? physicalCores = default(int?), Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState? activationState = default(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState?), Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType? scopeType = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType?), System.DateTimeOffset? activatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? terminatedOn = default(System.DateTimeOffset?), string tenantId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerInstanceData SqlServerInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob SqlServerInstanceJob(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult SqlServerInstanceJobsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob> jobs = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult SqlServerInstanceJobsStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus> jobsStatus = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus SqlServerInstanceJobStatus(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment SqlServerInstanceManagedInstanceLinkAssessment(string name = null, Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory? category = default(Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory?), Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus? status = default(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus?), string information = null, string additionalInformation = null, System.Collections.Generic.IEnumerable<string> failingDbs = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult SqlServerInstanceManagedInstanceLinkAssessmentResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment> assessments = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration SqlServerInstanceMigration(Azure.ResourceManager.ArcData.Models.MigrationAssessment assessment = null, System.DateTimeOffset? targetSelectedOn = default(System.DateTimeOffset?), string targetResourceId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult SqlServerInstanceMigrationReadinessReportResult(string report = null, bool? isCompressed = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch SqlServerInstancePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties SqlServerInstanceProperties(Azure.ResourceManager.ArcData.Models.SqlVersion? version = default(Azure.ResourceManager.ArcData.Models.SqlVersion?), Azure.ResourceManager.ArcData.Models.SqlServerEditionType? edition = default(Azure.ResourceManager.ArcData.Models.SqlServerEditionType?), string containerResourceId = null, string vmId = null, string createTime = null, string vCore = null, string cores = null, Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus? status = default(Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus?), Azure.ResourceManager.ArcData.Models.DiscoverySource? discoverySource = default(Azure.ResourceManager.ArcData.Models.DiscoverySource?), string patchLevel = null, string collation = null, bool? hasDbMasterKey = default(bool?), bool? isHadrEnabled = default(bool?), System.Collections.Generic.IEnumerable<int> traceFlags = null, string currentVersion = null, string instanceName = null, string tcpDynamicPorts = null, string tcpStaticPorts = null, string productId = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType? licenseType = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType?), System.DateTimeOffset? azureDefenderStatusLastUpdated = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.DefenderStatus? azureDefenderStatus = default(Azure.ResourceManager.ArcData.Models.DefenderStatus?), string provisioningState = null, System.DateTimeOffset? lastInventoryUploadOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUsageUploadOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType? hostType = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType?), Azure.ResourceManager.ArcData.Models.AlwaysOnRole? alwaysOnRole = default(Azure.ResourceManager.ArcData.Models.AlwaysOnRole?), Azure.ResourceManager.ArcData.Models.DbmEndpoint databaseMirroringEndpoint = null, Azure.ResourceManager.ArcData.Models.FailoverCluster failoverCluster = null, Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy backupPolicy = null, System.DateTimeOffset? upgradeLockedUntil = default(System.DateTimeOffset?), bool? isMonitoringEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration migration = null, Azure.ResourceManager.ArcData.Models.BestPracticesAssessment bestPracticesAssessment = null, bool? isClientConnectionEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.SqlServerServiceType? serviceType = default(Azure.ResourceManager.ArcData.Models.SqlServerServiceType?), long? maxServerMemoryMB = default(long?), bool? isMicrosoftPkiCertTrustConfigured = default(bool?), bool? isDigiCertPkiCertTrustConfigured = default(bool?), Azure.ResourceManager.ArcData.Models.SqlServerAuthentication authentication = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult SqlServerInstanceRunBestPracticesAssessmentResult(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult SqlServerInstanceRunMigrationAssessmentResult(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult SqlServerInstanceRunMigrationReadinessAssessmentResult(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult SqlServerInstanceRunTargetRecommendationJobResult(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport SqlServerInstanceTargetRecommendationReport(string reportId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection> sections = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection SqlServerInstanceTargetRecommendationReportSection(string data = null, Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType? type = default(Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType?), string databaseName = null, bool? isCompressed = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult SqlServerInstanceTargetRecommendationReportsResult(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport> reports = null, int? totalReportCount = default(int?), int? nextReportOffset = default(int?), int? nextSectionOffset = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties SqlServerInstanceUpdateProperties(Azure.ResourceManager.ArcData.Models.SqlVersion? version = default(Azure.ResourceManager.ArcData.Models.SqlVersion?), Azure.ResourceManager.ArcData.Models.SqlServerEditionType? edition = default(Azure.ResourceManager.ArcData.Models.SqlServerEditionType?), string containerResourceId = null, string vmId = null, string createTime = null, string vCore = null, string cores = null, Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus? status = default(Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus?), Azure.ResourceManager.ArcData.Models.DiscoverySource? discoverySource = default(Azure.ResourceManager.ArcData.Models.DiscoverySource?), string patchLevel = null, string collation = null, bool? hasDbMasterKey = default(bool?), bool? isHadrEnabled = default(bool?), System.Collections.Generic.IEnumerable<int> traceFlags = null, string currentVersion = null, string instanceName = null, string tcpDynamicPorts = null, string tcpStaticPorts = null, string productId = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType? licenseType = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType?), System.DateTimeOffset? azureDefenderStatusLastUpdated = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.DefenderStatus? azureDefenderStatus = default(Azure.ResourceManager.ArcData.Models.DefenderStatus?), string provisioningState = null, System.DateTimeOffset? lastInventoryUploadOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUsageUploadOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType? hostType = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType?), Azure.ResourceManager.ArcData.Models.AlwaysOnRole? alwaysOnRole = default(Azure.ResourceManager.ArcData.Models.AlwaysOnRole?), Azure.ResourceManager.ArcData.Models.FailoverCluster failoverCluster = null, Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy backupPolicy = null, System.DateTimeOffset? upgradeLockedUntil = default(System.DateTimeOffset?), bool? isMonitoringEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration migration = null, Azure.ResourceManager.ArcData.Models.BestPracticesAssessment bestPracticesAssessment = null, bool? isClientConnectionEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.SqlServerServiceType? serviceType = default(Azure.ResourceManager.ArcData.Models.SqlServerServiceType?), Azure.ResourceManager.ArcData.Models.SqlServerAuthentication authentication = null, Azure.ResourceManager.ArcData.Models.DbmEndpoint databaseMirroringEndpoint = null, bool? isMicrosoftPkiCertTrustConfigured = default(bool?), bool? isDigiCertPkiCertTrustConfigured = default(bool?), long? maxServerMemoryMB = default(long?)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerLicenseData SqlServerLicenseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch SqlServerLicensePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties SqlServerLicenseProperties(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan billingPlan = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan), int physicalCores = 0, Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory licenseCategory = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory), Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState activationState = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState), Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType scopeType = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType), System.DateTimeOffset? lastActivatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeactivatedOn = default(System.DateTimeOffset?), string tenantId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties SqlServerLicenseUpdateProperties(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan? billingPlan = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan?), int? physicalCores = default(int?), Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory? licenseCategory = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory?), Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState? activationState = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState?), Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType? scopeType = default(Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType?), System.DateTimeOffset? lastActivatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeactivatedOn = default(System.DateTimeOffset?), string tenantId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown SqlSkuRecommendationCostBreakdown(float? computeCost = default(float?), float? storageCost = default(float?), float? iopsCost = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions SqlSkuRecommendationCostOptions(string computeAndStorageCostOption = null, string sqlLicenseCostOption = null, string windowsLicenseCostOption = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.UploadServicePrincipal UploadServicePrincipal(string clientId = null, string tenantId = null, string authority = null, string clientSecret = null) { throw null; }
    }
    public enum AutomatedBackupPreference
    {
        Primary = 0,
        SecondaryOnly = 1,
        Secondary = 2,
        None = 3,
    }
    public partial class AvailabilityGroupConfigure : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure>
    {
        public AvailabilityGroupConfigure() { }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? AvailabilityMode { get { throw null; } set { } }
        public string AvailabilityModeDescription { get { throw null; } }
        public int? BackupPriority { get { throw null; } set { } }
        public string CertificateName { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType? EndpointAuthenticationMode { get { throw null; } set { } }
        public string EndpointConnectLogin { get { throw null; } set { } }
        public string EndpointName { get { throw null; } set { } }
        public string EndpointUri { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? FailoverMode { get { throw null; } set { } }
        public string FailoverModeDescription { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections? PrimaryAllowConnections { get { throw null; } set { } }
        public string PrimaryRoleAllowConnectionsDescription { get { throw null; } }
        public string ReadOnlyRoutingUri { get { throw null; } set { } }
        public string ReadWriteRoutingUri { get { throw null; } set { } }
        public System.DateTimeOffset? ReplicaCreateOn { get { throw null; } }
        public System.DateTimeOffset? ReplicaModifyOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections? SecondaryAllowConnections { get { throw null; } set { } }
        public string SecondaryRoleAllowConnectionsDescription { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SeedingMode? SeedingMode { get { throw null; } set { } }
        public string SeedingModeDescription { get { throw null; } }
        public int? SessionTimeoutInSeconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilityGroupCreateUpdateReplicaConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration>
    {
        public AvailabilityGroupCreateUpdateReplicaConfiguration() { }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? AvailabilityMode { get { throw null; } set { } }
        public int? BackupPriority { get { throw null; } set { } }
        public string CertificateName { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType? EndpointAuthenticationMode { get { throw null; } set { } }
        public string EndpointConnectLogin { get { throw null; } set { } }
        public string EndpointName { get { throw null; } set { } }
        public string EndpointUri { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? FailoverMode { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections? PrimaryRoleAllowConnections { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrimaryRoleReadOnlyRoutingList { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections? SecondaryRoleAllowConnections { get { throw null; } set { } }
        public string SecondaryRoleReadOnlyRoutingUri { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SeedingMode? SeedingMode { get { throw null; } set { } }
        public string ServerInstance { get { throw null; } set { } }
        public int? SessionTimeoutInSeconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilityGroupInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo>
    {
        public AvailabilityGroupInfo() { }
        public string AutomatedBackupPreferenceDescription { get { throw null; } }
        public string ClusterTypeDescription { get { throw null; } }
        public int? FailureConditionLevel { get { throw null; } set { } }
        public bool? HasBasicFeatures { get { throw null; } set { } }
        public int? HealthCheckTimeoutInMilliseconds { get { throw null; } set { } }
        public bool? IsContained { get { throw null; } set { } }
        public bool? IsDbFailoverSupported { get { throw null; } set { } }
        public bool? IsDistributed { get { throw null; } set { } }
        public bool? IsDtcSupportEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties Listener { get { throw null; } set { } }
        public string PrimaryRecoveryHealthDescription { get { throw null; } }
        public string PrimaryReplica { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.ReplicationPartnerType? ReplicationPartnerType { get { throw null; } }
        public int? RequiredSynchronizedSecondariesToCommit { get { throw null; } set { } }
        public string SecondaryRecoveryHealthDescription { get { throw null; } }
        public string SynchronizationHealthDescription { get { throw null; } }
        public int? Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilityGroupRetrievalFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters>
    {
        public AvailabilityGroupRetrievalFilters() { }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter? AvailabilityGroupTypeFilter { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ReplicationPartnerType? ReplicationPartnerTypeFilter { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilityGroupState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupState>
    {
        public AvailabilityGroupState() { }
        public string AvailabilityGroupReplicaRole { get { throw null; } }
        public string ConnectedStateDescription { get { throw null; } }
        public string LastConnectErrorDescription { get { throw null; } }
        public System.DateTimeOffset? LastConnectErrorOn { get { throw null; } }
        public string OperationalStateDescription { get { throw null; } }
        public string RecoveryHealthDescription { get { throw null; } }
        public string SynchronizationHealthDescription { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureManagedInstanceRole : System.IEquatable<Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureManagedInstanceRole(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole Primary { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole left, Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole left, Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BestPracticesAssessment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessment>
    {
        public BestPracticesAssessment() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule Schedule { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.BestPracticesAssessment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.BestPracticesAssessment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.BestPracticesAssessment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.BestPracticesAssessment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BestPracticesAssessmentSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule>
    {
        public BestPracticesAssessmentSchedule() { }
        public Azure.ResourceManager.ArcData.Models.CronTrigger CronTrigger { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CronTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CronTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CronTrigger>
    {
        public CronTrigger() { }
        public string Expression { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.CronTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.CronTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.CronTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CronTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CronTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.CronTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CronTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CronTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CronTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseAssessmentsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem>
    {
        internal DatabaseAssessmentsItem() { }
        public string AppliesToMigrationTargetPlatform { get { throw null; } }
        public string FeatureId { get { throw null; } }
        public string IssueCategory { get { throw null; } }
        public string MoreInformation { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseCreateMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.DatabaseCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseCreateMode PointInTimeRestore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.DatabaseCreateMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.DatabaseCreateMode left, Azure.ResourceManager.ArcData.Models.DatabaseCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DatabaseCreateMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DatabaseCreateMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.DatabaseCreateMode left, Azure.ResourceManager.ArcData.Models.DatabaseCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseMigration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseMigration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigration>
    {
        public DatabaseMigration() { }
        public Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment Assessment { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem> Jobs { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.DatabaseMigration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DatabaseMigration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DatabaseMigration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseMigration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseMigration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DatabaseMigration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationAssessment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment>
    {
        public DatabaseMigrationAssessment() { }
        public System.DateTimeOffset? AssessmentUploadOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem> DatabaseAssessments { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness TargetReadiness { get { throw null; } }
        public System.DateTimeOffset? TargetRecommendationGenerationOn { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseMigrationJobsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem>
    {
        public DatabaseMigrationJobsItem() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes> AdditionalAttributes { get { throw null; } }
        public System.DateTimeOffset? EndsOn { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource? InitiatedFrom { get { throw null; } set { } }
        public string LastError { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.MigrationMode? MigrationMode { get { throw null; } set { } }
        public string MigrationTrackingId { get { throw null; } set { } }
        public System.DateTimeOffset? StartsOn { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.MigrationStatus? Status { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType? TargetType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseMirroringRole : System.IEquatable<Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseMirroringRole(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole All { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole None { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole Partner { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole Witness { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole left, Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole left, Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseState : System.IEquatable<Azure.ResourceManager.ArcData.Models.DatabaseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseState Copying { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseState Emergency { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseState Offline { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseState OfflineSecondary { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseState Online { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseState Recovering { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseState RecoveryPending { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseState Restoring { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DatabaseState Suspect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.DatabaseState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.DatabaseState left, Azure.ResourceManager.ArcData.Models.DatabaseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DatabaseState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DatabaseState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.DatabaseState left, Azure.ResourceManager.ArcData.Models.DatabaseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DataControllerInfrastructure
    {
        Azure = 0,
        Gcp = 1,
        Aws = 2,
        Alibaba = 3,
        Onpremises = 4,
        Other = 5,
    }
    public partial class DataControllerOnPremisesConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig>
    {
        public DataControllerOnPremisesConfig(string id, string publicSigningKey) { }
        public string Id { get { throw null; } set { } }
        public string PublicSigningKey { get { throw null; } set { } }
        public string SigningCertificateThumbprint { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataControllerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerPatch>
    {
        public DataControllerPatch() { }
        public Azure.ResourceManager.ArcData.Models.DataControllerProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.DataControllerPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DataControllerPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DataControllerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DataControllerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataControllerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerProperties>
    {
        public DataControllerProperties() { }
        public Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation BasicLoginInformation { get { throw null; } set { } }
        public string ClusterId { get { throw null; } set { } }
        public string ExtensionId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DataControllerInfrastructure? Infrastructure { get { throw null; } set { } }
        public System.BinaryData K8sRaw { get { throw null; } set { } }
        public System.DateTimeOffset? LastUploadedOn { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig LogAnalyticsWorkspaceConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation LogsDashboardCredential { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation MetricsDashboardCredential { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DataControllerOnPremisesConfig OnPremiseProperty { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.UploadServicePrincipal UploadServicePrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark UploadWatermark { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.DataControllerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DataControllerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DataControllerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DataControllerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataControllerUploadWatermark : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark>
    {
        public DataControllerUploadWatermark() { }
        public System.DateTimeOffset? Logs { get { throw null; } set { } }
        public System.DateTimeOffset? Metrics { get { throw null; } set { } }
        public System.DateTimeOffset? Usages { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DataControllerUploadWatermark>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DbFailover
    {
        On = 0,
        Off = 1,
    }
    public partial class DbmEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DbmEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DbmEndpoint>
    {
        public DbmEndpoint() { }
        public System.DateTimeOffset? CertificateExpiryOn { get { throw null; } }
        public string CertificateName { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType? ConnectionAuth { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm? EncryptionAlgorithm { get { throw null; } }
        public string EndpointName { get { throw null; } }
        public string IpAddress { get { throw null; } }
        public bool? IsDynamicPort { get { throw null; } }
        public bool? IsEncryptionEnabled { get { throw null; } }
        public int? Port { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole? Role { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.DbmEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DbmEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DbmEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DbmEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DbmEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DbmEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DbmEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DbmEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DbmEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefenderStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.DefenderStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefenderStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DefenderStatus Protected { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DefenderStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DefenderStatus Unprotected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.DefenderStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.DefenderStatus left, Azure.ResourceManager.ArcData.Models.DefenderStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DefenderStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DefenderStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.DefenderStatus left, Azure.ResourceManager.ArcData.Models.DefenderStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DifferentialBackupHours
    {
        Twelve = 12,
        TwentyFour = 24,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoverySource : System.IEquatable<Azure.ResourceManager.ArcData.Models.DiscoverySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoverySource(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource Ads { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource AzureArc { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource AzureMigrate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource DmsCli { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource DmsPortal { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource DmsPs { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource DmsSdk { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource Import { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource Other { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource Ssma { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource Ssms { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.DiscoverySource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.DiscoverySource left, Azure.ResourceManager.ArcData.Models.DiscoverySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DiscoverySource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.DiscoverySource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.DiscoverySource left, Azure.ResourceManager.ArcData.Models.DiscoverySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskSizes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DiskSizes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DiskSizes>
    {
        internal DiskSizes() { }
        public string Caching { get { throw null; } }
        public string DiskType { get { throw null; } }
        public float? MaxIops { get { throw null; } }
        public float? MaxSizeInGib { get { throw null; } }
        public float? MaxThroughputInMbps { get { throw null; } }
        public string Redundancy { get { throw null; } }
        public string Size { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.DiskSizes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DiskSizes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DiskSizes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DiskSizes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DiskSizes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DiskSizes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DiskSizes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DiskSizes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DiskSizes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration>
    {
        public DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration() { }
        public Azure.Core.ResourceIdentifier AvailabilityGroup { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? AvailabilityMode { get { throw null; } set { } }
        public string CertificateName { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? FailoverMode { get { throw null; } set { } }
        public System.Uri ListenerUri { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SeedingMode? SeedingMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DtcSupport
    {
        PerDb = 0,
        None = 1,
    }
    public partial class EntraAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.EntraAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.EntraAuthentication>
    {
        public EntraAuthentication() { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType? IdentityType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.EntraAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.EntraAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.EntraAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.EntraAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.EntraAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.EntraAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.EntraAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.EntraAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.EntraAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FailoverCluster : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverCluster>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverCluster>
    {
        public FailoverCluster() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation> HostIPAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> HostNames { get { throw null; } }
        public string Id { get { throw null; } }
        public string NetworkName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlInstanceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.FailoverCluster JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.FailoverCluster PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.FailoverCluster System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.FailoverCluster System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailoverGroupPartnerSyncMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailoverGroupPartnerSyncMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode Async { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode Sync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode left, Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode left, Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FailoverGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverGroupProperties>
    {
        public FailoverGroupProperties(Azure.Core.ResourceIdentifier partnerManagedInstanceId, Azure.ResourceManager.ArcData.Models.FailoverGroupSpec spec) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier PartnerManagedInstanceId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcDataProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.FailoverGroupSpec Spec { get { throw null; } set { } }
        public System.BinaryData Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.FailoverGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.FailoverGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.FailoverGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.FailoverGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FailoverGroupSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverGroupSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverGroupSpec>
    {
        public FailoverGroupSpec(Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole role) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string PartnerMI { get { throw null; } set { } }
        public string PartnerMirroringCert { get { throw null; } set { } }
        public string PartnerMirroringUri { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode? PartnerSyncMode { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole Role { get { throw null; } set { } }
        public string SharedName { get { throw null; } set { } }
        public string SourceMI { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.FailoverGroupSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.FailoverGroupSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.FailoverGroupSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverGroupSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverGroupSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.FailoverGroupSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverGroupSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverGroupSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverGroupSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FailureConditionLevel
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
    }
    public partial class HostIPAddressInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation>
    {
        internal HostIPAddressInformation() { }
        public string IPAddress { get { throw null; } }
        public string SubnetMask { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.HostIPAddressInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.HostIPAddressInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.HostIPAddressInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.HostIPAddressInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstanceFailoverGroupRole : System.IEquatable<Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceFailoverGroupRole(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole ForcePrimaryAllowDataLoss { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole ForceSecondary { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole Primary { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole left, Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole left, Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class K8sActiveDirectory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectory>
    {
        public K8sActiveDirectory() { }
        public string AccountName { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector Connector { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EncryptionTypes { get { throw null; } }
        public string KeytabSecret { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sActiveDirectory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sActiveDirectory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.K8sActiveDirectory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.K8sActiveDirectory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class K8sActiveDirectoryConnector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector>
    {
        public K8sActiveDirectoryConnector() { }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class K8sNetworkSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sNetworkSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sNetworkSettings>
    {
        public K8sNetworkSettings() { }
        public int? ForceEncryption { get { throw null; } set { } }
        public string TlsCiphers { get { throw null; } set { } }
        public string TlsProtocols { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sNetworkSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sNetworkSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.K8sNetworkSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sNetworkSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sNetworkSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.K8sNetworkSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sNetworkSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sNetworkSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sNetworkSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class K8sResourceRequirements : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sResourceRequirements>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sResourceRequirements>
    {
        public K8sResourceRequirements() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Limits { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Requests { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sResourceRequirements JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sResourceRequirements PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.K8sResourceRequirements System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sResourceRequirements>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sResourceRequirements>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.K8sResourceRequirements System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sResourceRequirements>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sResourceRequirements>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sResourceRequirements>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class K8sScheduling : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sScheduling>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sScheduling>
    {
        public K8sScheduling() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig Default { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sScheduling JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sScheduling PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.K8sScheduling System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sScheduling>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sScheduling>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.K8sScheduling System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sScheduling>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sScheduling>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sScheduling>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class K8sSchedulingConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig>
    {
        public K8sSchedulingConfig() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.K8sResourceRequirements Resources { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class K8sSecurity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sSecurity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSecurity>
    {
        public K8sSecurity() { }
        public Azure.ResourceManager.ArcData.Models.K8sActiveDirectory ActiveDirectory { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string AdminLoginSecret { get { throw null; } set { } }
        public string ServiceCertificateSecret { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption TransparentDataEncryption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sSecurity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sSecurity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.K8sSecurity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sSecurity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sSecurity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.K8sSecurity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSecurity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSecurity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSecurity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class K8sSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSettings>
    {
        public K8sSettings() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.K8sNetworkSettings Network { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.K8sSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.K8sSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class K8sTransparentDataEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption>
    {
        public K8sTransparentDataEncryption() { }
        public string Mode { get { throw null; } set { } }
        public string ProtectorSecret { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsWorkspaceConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig>
    {
        public LogAnalyticsWorkspaceConfig() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.MigrationAssessment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.MigrationAssessment>
    {
        public MigrationAssessment() { }
        public System.DateTimeOffset? AssessmentUploadOn { get { throw null; } }
        public System.DateTimeOffset? AssessmentViewedOn { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary ImpactedObjectsSummary { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem> ServerAssessments { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings Settings { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResults SkuRecommendationResults { get { throw null; } }
        public System.DateTimeOffset? TargetRecommendationGenerationOn { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.MigrationAssessment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.MigrationAssessment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.MigrationAssessment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.MigrationAssessment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.MigrationAssessment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.MigrationAssessment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.MigrationAssessment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.MigrationAssessment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.MigrationAssessment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings>
    {
        public MigrationAssessmentSettings() { }
        public int? ComfortFactor { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions CostOptions { get { throw null; } set { } }
        public string Currency { get { throw null; } set { } }
        public float? DiscountPercentage { get { throw null; } set { } }
        public int? LookbackPeriodInDays { get { throw null; } set { } }
        public float? Percentile { get { throw null; } set { } }
        public string Strategy { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.MigrationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.MigrationMode Logical { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationMode LogShipping { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationMode MiLink { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationMode Other { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationMode Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.MigrationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.MigrationMode left, Azure.ResourceManager.ArcData.Models.MigrationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.MigrationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.MigrationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.MigrationMode left, Azure.ResourceManager.ArcData.Models.MigrationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.MigrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.MigrationStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationStatus InProgressWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationStatus Successful { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MigrationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.MigrationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.MigrationStatus left, Azure.ResourceManager.ArcData.Models.MigrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.MigrationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.MigrationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.MigrationStatus left, Azure.ResourceManager.ArcData.Models.MigrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MiLinkAssessmentCategory : System.IEquatable<Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MiLinkAssessmentCategory(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory BoxToMiNetworkConnectivity { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory Certificates { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory DagCrossValidation { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory ManagedInstance { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory ManagedInstanceCrossValidation { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory ManagedInstanceDatabase { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory MiToBoxNetworkConnectivity { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory SqlInstance { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory SqlInstanceAg { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory SqlInstanceDatabase { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory left, Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory left, Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgresInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstancePatch>
    {
        public PostgresInstancePatch() { }
        public Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.PostgresInstancePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.PostgresInstancePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.PostgresInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.PostgresInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgresInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties>
    {
        public PostgresInstanceProperties() { }
        public string Admin { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation BasicLoginInformation { get { throw null; } set { } }
        public string DataControllerId { get { throw null; } set { } }
        public System.BinaryData K8sRaw { get { throw null; } set { } }
        public System.DateTimeOffset? LastUploadedOn { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgresInstanceSku : Azure.ResourceManager.ArcData.Models.ArcDataSku, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceSku>
    {
        public PostgresInstanceSku(string name) : base (default(string)) { }
        public Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier? Tier { get { throw null; } set { } }
        protected override Azure.ResourceManager.ArcData.Models.ArcDataSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ArcData.Models.ArcDataSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.PostgresInstanceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.PostgresInstanceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgresInstanceSkuTier : System.IEquatable<Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgresInstanceSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier Hyperscale { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier left, Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier left, Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum PrimaryAllowConnections
    {
        All = 0,
        ReadWrite = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.RecoveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.RecoveryMode BulkLogged { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.RecoveryMode Full { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.RecoveryMode Simple { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.RecoveryMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.RecoveryMode left, Azure.ResourceManager.ArcData.Models.RecoveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.RecoveryMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.RecoveryMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.RecoveryMode left, Azure.ResourceManager.ArcData.Models.RecoveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ReplicationPartnerType
    {
        SqlServer = 0,
        AzureSqlVm = 1,
        AzureSqlManagedInstance = 2,
        Unknown = 3,
    }
    public enum SecondaryAllowConnections
    {
        No = 0,
        All = 1,
        ReadOnly = 2,
    }
    public enum SeedingMode
    {
        Automatic = 0,
        Manual = 1,
    }
    public partial class SequencerAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SequencerAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SequencerAction>
    {
        internal SequencerAction() { }
        public string ActionId { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SequencerActionResult? Result { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SequencerState? State { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SequencerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SequencerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SequencerAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SequencerAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SequencerAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SequencerAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SequencerAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SequencerAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SequencerAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SequencerActionResult : System.IEquatable<Azure.ResourceManager.ArcData.Models.SequencerActionResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SequencerActionResult(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SequencerActionResult Failed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SequencerActionResult NotCompleted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SequencerActionResult Skipped { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SequencerActionResult Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SequencerActionResult TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SequencerActionResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SequencerActionResult left, Azure.ResourceManager.ArcData.Models.SequencerActionResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SequencerActionResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SequencerActionResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SequencerActionResult left, Azure.ResourceManager.ArcData.Models.SequencerActionResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SequencerState : System.IEquatable<Azure.ResourceManager.ArcData.Models.SequencerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SequencerState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SequencerState Completed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SequencerState CreatingSuccessors { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SequencerState ExecutingAction { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SequencerState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SequencerState WaitingPredecessors { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SequencerState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SequencerState left, Azure.ResourceManager.ArcData.Models.SequencerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SequencerState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SequencerState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SequencerState left, Azure.ResourceManager.ArcData.Models.SequencerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerAssessmentsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem>
    {
        internal ServerAssessmentsItem() { }
        public string AppliesToMigrationTargetPlatform { get { throw null; } }
        public string FeatureId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem> ImpactedObjects { get { throw null; } }
        public string IssueCategory { get { throw null; } }
        public string MoreInformation { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerAssessmentsPropertiesItemsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem>
    {
        internal ServerAssessmentsPropertiesItemsItem() { }
        public string ImpactDetail { get { throw null; } }
        public string Name { get { throw null; } }
        public string ObjectType { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResults>
    {
        internal SkuRecommendationResults() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase AzureSqlDatabase { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance AzureSqlManagedInstance { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine AzureSqlVirtualMachine { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlDatabase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase>
    {
        internal SkuRecommendationResultsAzureSqlDatabase() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost MonthlyCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> MonthlyCostOptions { get { throw null; } }
        public int? NumberOfServerBlockerIssues { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus? RecommendationStatus { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku TargetSku { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlDatabaseTargetSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku>
    {
        internal SkuRecommendationResultsAzureSqlDatabaseTargetSku() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory Category { get { throw null; } }
        public int? ComputeSize { get { throw null; } }
        public float? MaxStorageIops { get { throw null; } }
        public float? MaxThroughputMBps { get { throw null; } }
        public float? PredictedDataSizeInMb { get { throw null; } }
        public float? PredictedLogSizeInMb { get { throw null; } }
        public float? StorageMaxSizeInMb { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory>
    {
        internal SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory() { }
        public string ComputeTier { get { throw null; } }
        public string HardwareType { get { throw null; } }
        public bool? IsZoneRedundancyAvailable { get { throw null; } }
        public string SqlPurchasingModel { get { throw null; } }
        public string SqlServiceTier { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlManagedInstance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance>
    {
        internal SkuRecommendationResultsAzureSqlManagedInstance() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost MonthlyCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> MonthlyCostOptions { get { throw null; } }
        public int? NumberOfServerBlockerIssues { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus? RecommendationStatus { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku TargetSku { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlManagedInstanceTargetSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku>
    {
        internal SkuRecommendationResultsAzureSqlManagedInstanceTargetSku() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory Category { get { throw null; } }
        public int? ComputeSize { get { throw null; } }
        public float? MaxStorageIops { get { throw null; } }
        public float? MaxThroughputMBps { get { throw null; } }
        public float? PredictedDataSizeInMb { get { throw null; } }
        public float? PredictedLogSizeInMb { get { throw null; } }
        public float? StorageMaxSizeInMb { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory>
    {
        internal SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory() { }
        public string ComputeTier { get { throw null; } }
        public string HardwareType { get { throw null; } }
        public bool? IsZoneRedundancyAvailable { get { throw null; } }
        public string SqlPurchasingModel { get { throw null; } }
        public string SqlServiceTier { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlVirtualMachine : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine>
    {
        internal SkuRecommendationResultsAzureSqlVirtualMachine() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost MonthlyCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> MonthlyCostOptions { get { throw null; } }
        public int? NumberOfServerBlockerIssues { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus? RecommendationStatus { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku TargetSku { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlVirtualMachineTargetSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku>
    {
        internal SkuRecommendationResultsAzureSqlVirtualMachineTargetSku() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory Category { get { throw null; } }
        public int? ComputeSize { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.DiskSizes> DataDiskSizes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.DiskSizes> LogDiskSizes { get { throw null; } }
        public float? PredictedDataSizeInMb { get { throw null; } }
        public float? PredictedLogSizeInMb { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.DiskSizes> TempDbDiskSizes { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize VirtualMachineSize { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory>
    {
        internal SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory() { }
        public System.Collections.Generic.IList<string> AvailableVmSkus { get { throw null; } }
        public string VirtualMachineFamily { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize>
    {
        internal SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize() { }
        public string AzureSkuName { get { throw null; } }
        public int? ComputeSize { get { throw null; } }
        public int? MaxNetworkInterfaces { get { throw null; } }
        public string SizeName { get { throw null; } }
        public int? VCPUsAvailable { get { throw null; } }
        public string VirtualMachineFamily { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsMonthlyCost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost>
    {
        internal SkuRecommendationResultsMonthlyCost() { }
        public float? ComputeCost { get { throw null; } }
        public float? IopsCost { get { throw null; } }
        public float? SqlLicenseCost { get { throw null; } }
        public float? StorageCost { get { throw null; } }
        public float? TotalCost { get { throw null; } }
        public float? WindowsLicenseCost { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationResultsMonthlyCostOptionItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem>
    {
        internal SkuRecommendationResultsMonthlyCostOptionItem() { }
        public string KeyName { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown KeyValue { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary>
    {
        internal SkuRecommendationSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo> ImpactedObjectsSummary { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost MonthlyCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> MonthlyCostOptions { get { throw null; } }
        public int? NumOfBlockerIssues { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus? RecommendationStatus { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku TargetSku { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationSummaryTargetSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku>
    {
        internal SkuRecommendationSummaryTargetSku() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory Category { get { throw null; } }
        public int? ComputeSize { get { throw null; } }
        public float? MaxStorageIops { get { throw null; } }
        public float? MaxThroughputMBps { get { throw null; } }
        public float? PredictedDataSizeInMb { get { throw null; } }
        public float? PredictedLogSizeInMb { get { throw null; } }
        public float? StorageMaxSizeInMb { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuRecommendationSummaryTargetSkuCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory>
    {
        internal SkuRecommendationSummaryTargetSkuCategory() { }
        public string ComputeTier { get { throw null; } }
        public string HardwareType { get { throw null; } }
        public bool? IsZoneRedundancyAvailable { get { throw null; } }
        public string SqlPurchasingModel { get { throw null; } }
        public string SqlServiceTier { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SqlAvailabilityGroupClusterType
    {
        Wsfc = 0,
        None = 1,
    }
    public partial class SqlAvailabilityGroupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent>
    {
        public SqlAvailabilityGroupContent() { }
        public Azure.ResourceManager.ArcData.Models.AutomatedBackupPreference? AutomatedBackupPreference { get { throw null; } set { } }
        public string AvailabilityGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupClusterType? ClusterType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.DbFailover? DbFailover { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DtcSupport? DtcSupport { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.FailureConditionLevel? FailureConditionLevel { get { throw null; } set { } }
        public int? HealthCheckTimeoutInMilliseconds { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties Listener { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration> Replicas { get { throw null; } }
        public int? RequiredSynchronizedSecondariesToCommit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAvailabilityGroupDatabaseReplicaResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties>
    {
        public SqlAvailabilityGroupDatabaseReplicaResourceProperties() { }
        public string DatabaseName { get { throw null; } set { } }
        public string DatabaseStateDescription { get { throw null; } }
        public bool? IsCommitParticipant { get { throw null; } }
        public bool? IsLocal { get { throw null; } }
        public bool? IsPrimaryReplica { get { throw null; } }
        public bool? IsSuspended { get { throw null; } }
        public string ReplicaName { get { throw null; } }
        public string SuspendReasonDescription { get { throw null; } }
        public string SynchronizationHealthDescription { get { throw null; } }
        public string SynchronizationStateDescription { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAvailabilityGroupDatabasesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent>
    {
        public SqlAvailabilityGroupDatabasesContent() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabasesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem>
    {
        public SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem() { }
        public string IPAddress { get { throw null; } set { } }
        public string Mask { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAvailabilityGroupReplicaResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties>
    {
        public SqlAvailabilityGroupReplicaResourceProperties() { }
        public Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure Configure { get { throw null; } set { } }
        public string ReplicaId { get { throw null; } }
        public string ReplicaName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ReplicaResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.AvailabilityGroupState State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAvailabilityGroupStaticIPListenerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties>
    {
        public SqlAvailabilityGroupStaticIPListenerProperties() { }
        public string DnsName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem> IPv4AddressesAndMasks { get { throw null; } }
        public System.Collections.Generic.IList<string> IPv6Addresses { get { throw null; } }
        public int? Port { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDistributedAvailabilityGroupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent>
    {
        public SqlDistributedAvailabilityGroupContent() { }
        public string AvailabilityGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration PrimaryAvailabilityGroup { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration SecondaryAvailabilityGroup { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlManagedInstanceK8sRaw : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw>
    {
        public SqlManagedInstanceK8sRaw() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec Spec { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlManagedInstanceK8sSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec>
    {
        public SqlManagedInstanceK8sSpec() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? Replicas { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.K8sScheduling Scheduling { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.K8sSecurity Security { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.K8sSettings Settings { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlManagedInstanceLinkAssessmentStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlManagedInstanceLinkAssessmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus Success { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus left, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus left, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlManagedInstanceLinkContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent>
    {
        public SqlManagedInstanceLinkContent() { }
        public Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupContent AvailabilityGroup { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlDistributedAvailabilityGroupContent DistributedAvailabilityGroup { get { throw null; } set { } }
        public string MiLinkInstanceAvailabilityGroupName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlManagedInstanceLinkFailoverContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent>
    {
        public SqlManagedInstanceLinkFailoverContent() { }
        public Azure.Core.ResourceIdentifier ManagedInstanceId { get { throw null; } set { } }
        public bool? ShouldForce { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkFailoverContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlManagedInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch>
    {
        public SqlManagedInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlManagedInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties>
    {
        public SqlManagedInstanceProperties() { }
        public string ActiveDirectoryInformationKeytab { get { throw null; } set { } }
        public string Admin { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcDataBasicLoginInformation BasicLoginInformation { get { throw null; } set { } }
        public string ClusterId { get { throw null; } set { } }
        public string DataControllerId { get { throw null; } set { } }
        public string EndTime { get { throw null; } set { } }
        public string ExtensionId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw K8sRaw { get { throw null; } set { } }
        public System.DateTimeOffset? LastUploadedOn { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType? LicenseType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string StartTime { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlManagedInstanceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku>
    {
        public SqlManagedInstanceSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public bool? IsDevTestEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SqlManagedInstanceSkuTier
    {
        GeneralPurpose = 0,
        BusinessCritical = 1,
    }
    public partial class SqlMigrationImpactedObjectInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo>
    {
        internal SqlMigrationImpactedObjectInfo() { }
        public string FeatureId { get { throw null; } }
        public string IssueCategory { get { throw null; } }
        public int? NumberImpacted { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMigrationImpactedObjectsSuitabilitySummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary>
    {
        public SqlMigrationImpactedObjectsSuitabilitySummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo> AzureSqlDatabase { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectInfo> AzureSqlManagedInstance { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationImpactedObjectsSuitabilitySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlMigrationInitiationSource : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlMigrationInitiationSource(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource Ads { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource AzureArc { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource DmsCli { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource DmsPortal { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource DmsPs { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource DmsSdk { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource Other { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource Ssma { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource Ssms { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource left, Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource left, Azure.ResourceManager.ArcData.Models.SqlMigrationInitiationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlMigrationTargetReadiness : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness>
    {
        internal SqlMigrationTargetReadiness() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary AzureSqlDatabase { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary AzureSqlManagedInstance { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary AzureSqlVirtualMachine { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlMigrationTargetReadiness>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlMigrationTargetType : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlMigrationTargetType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType AzureSqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType AzureSqlManagedInstance { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType AzureSqlVirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType left, Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType left, Azure.ResourceManager.ArcData.Models.SqlMigrationTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlMirroringEndpointAuthenticationType : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlMirroringEndpointAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType Certificate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType CertificateWindowsKerberos { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType CertificateWindowsNegotiate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType CertificateWindowsNtlm { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType WindowsKerberos { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType WindowsKerberosCertificate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType WindowsNegotiate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType WindowsNegotiateCertificate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType WindowsNtlm { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType WindowsNtlmCertificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType left, Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType left, Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlMirroringEndpointEncryptionAlgorithm : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlMirroringEndpointEncryptionAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm Aes { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm AesRc4 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm NoneAes { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm NoneAesRc4 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm NoneRC4 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm NoneRc4Aes { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm RC4 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm Rc4Aes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm left, Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm left, Azure.ResourceManager.ArcData.Models.SqlMirroringEndpointEncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAuthentication>
    {
        public SqlServerAuthentication() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.EntraAuthentication> SqlServerEntraIdentity { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerAuthenticationMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerAuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode Mixed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode Undefined { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode left, Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode left, Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerAvailabilityGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch>
    {
        public SqlServerAvailabilityGroupPatch() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerAvailabilityGroupResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties>
    {
        public SqlServerAvailabilityGroupResourceProperties() { }
        public string AvailabilityGroupId { get { throw null; } }
        public System.DateTimeOffset? CollectionOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases Databases { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo Info { get { throw null; } set { } }
        public string InstanceName { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas Replicas { get { throw null; } set { } }
        public string ServerName { get { throw null; } }
        public string VmId { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerAvailabilityGroupResourcePropertiesDatabases : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases>
    {
        public SqlServerAvailabilityGroupResourcePropertiesDatabases() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerAvailabilityGroupResourcePropertiesReplicas : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas>
    {
        public SqlServerAvailabilityGroupResourcePropertiesReplicas() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerBackgroundJob : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob>
    {
        internal SqlServerBackgroundJob() { }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState? ExecutionState { get { throw null; } }
        public System.DateTimeOffset? LastExecutionOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus? LastExecutionStatus { get { throw null; } }
        public System.DateTimeOffset? NextExecutionOn { get { throw null; } }
        public System.DateTimeOffset? StartsOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState? State { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerBackgroundJobExecutionState : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerBackgroundJobExecutionState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState Running { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState left, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState left, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobExecutionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerBackgroundJobLastExecutionStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerBackgroundJobLastExecutionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus Faulted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus Postponed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus Rescheduled { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus left, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus left, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobLastExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerBackgroundJobState : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerBackgroundJobState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState Completed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState Enabled { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState Faulted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState left, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState left, Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJobState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerBackupPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy>
    {
        public SqlServerBackupPolicy() { }
        public Azure.ResourceManager.ArcData.Models.DifferentialBackupHours? DifferentialBackupHours { get { throw null; } set { } }
        public int? FullBackupDays { get { throw null; } set { } }
        public int? RetentionPeriodDays { get { throw null; } set { } }
        public int? TransactionLogBackupMinutes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerConnectionStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus Discovered { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus Registered { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus left, Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus left, Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerDatabaseConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig>
    {
        public SqlServerDatabaseConfig() { }
        public bool? IsAutoCloseOn { get { throw null; } set { } }
        public bool? IsAutoCreateStatsOn { get { throw null; } set { } }
        public bool? IsAutoShrinkOn { get { throw null; } set { } }
        public bool? IsAutoUpdateStatsOn { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } set { } }
        public bool? IsHekatonFilesOn { get { throw null; } set { } }
        public bool? IsMemoryOptimizationEnabled { get { throw null; } set { } }
        public bool? IsRemoteDataArchiveEnabled { get { throw null; } set { } }
        public bool? IsTrustworthyOn { get { throw null; } set { } }
        public int? NumberOfHekatonFiles { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerDatabasePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch>
    {
        public SqlServerDatabasePatch() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerDatabaseResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties>
    {
        public SqlServerDatabaseResourceProperties() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation BackupInformation { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy BackupPolicy { get { throw null; } set { } }
        public string CollationName { get { throw null; } set { } }
        public int? CompatibilityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DatabaseCreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? DatabaseCreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig DatabaseOptions { get { throw null; } set { } }
        public float? DataFileSizeMB { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } set { } }
        public System.DateTimeOffset? LastDatabaseUploadOn { get { throw null; } }
        public float? LogFileSizeMB { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DatabaseMigration Migration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.RecoveryMode? RecoveryMode { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public float? SizeMB { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public float? SpaceAvailableMB { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DatabaseState? State { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerDatabaseResourcePropertiesBackupInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation>
    {
        public SqlServerDatabaseResourcePropertiesBackupInformation() { }
        public System.DateTimeOffset? LastFullBackup { get { throw null; } set { } }
        public System.DateTimeOffset? LastLogBackup { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerEditionType : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerEditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerEditionType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEditionType BusinessIntelligence { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEditionType Developer { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEditionType Enterprise { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEditionType Evaluation { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEditionType Express { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEditionType Standard { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEditionType StandardDeveloper { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEditionType Unknown { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEditionType Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerEditionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerEditionType left, Azure.ResourceManager.ArcData.Models.SqlServerEditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerEditionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerEditionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerEditionType left, Azure.ResourceManager.ArcData.Models.SqlServerEditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerEntraIdentityType : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerEntraIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType left, Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType left, Azure.ResourceManager.ArcData.Models.SqlServerEntraIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerEsuLicenseActivationState : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerEsuLicenseActivationState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState Active { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState Inactive { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState Terminated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState left, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState left, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerEsuLicensePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch>
    {
        public SqlServerEsuLicensePatch() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerEsuLicenseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties>
    {
        public SqlServerEsuLicenseProperties(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan billingPlan, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion version, int physicalCores, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState activationState, Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType scopeType) { }
        public System.DateTimeOffset? ActivatedOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState ActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan BillingPlan { get { throw null; } set { } }
        public int PhysicalCores { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType ScopeType { get { throw null; } set { } }
        public string TenantId { get { throw null; } }
        public System.DateTimeOffset? TerminatedOn { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerEsuLicenseUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties>
    {
        public SqlServerEsuLicenseUpdateProperties() { }
        public System.DateTimeOffset? ActivatedOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState? ActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan? BillingPlan { get { throw null; } set { } }
        public int? PhysicalCores { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType? ScopeType { get { throw null; } set { } }
        public string TenantId { get { throw null; } }
        public System.DateTimeOffset? TerminatedOn { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion? Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerEsuLicenseVersion : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerEsuLicenseVersion(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion SqlServer2012 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion SqlServer2014 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion SqlServer2016 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion left, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion left, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerInstanceJob : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob>
    {
        internal SqlServerInstanceJob() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? JobStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SequencerAction> SequencerActions { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceJobsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult>
    {
        internal SqlServerInstanceJobsResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob> Jobs { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceJobsStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult>
    {
        internal SqlServerInstanceJobsStatusResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus> JobsStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceJobStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus>
    {
        internal SqlServerInstanceJobStatus() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? JobStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SequencerAction> SequencerActions { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceManagedInstanceLinkAssessment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment>
    {
        internal SqlServerInstanceManagedInstanceLinkAssessment() { }
        public string AdditionalInformation { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory? Category { get { throw null; } }
        public System.Collections.Generic.IList<string> FailingDbs { get { throw null; } }
        public string Information { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlManagedInstanceLinkAssessmentStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceManagedInstanceLinkAssessmentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult>
    {
        internal SqlServerInstanceManagedInstanceLinkAssessmentResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment> Assessments { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceMigration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration>
    {
        public SqlServerInstanceMigration() { }
        public Azure.ResourceManager.ArcData.Models.MigrationAssessment Assessment { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public System.DateTimeOffset? TargetSelectedOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceMigrationReadinessReportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult>
    {
        internal SqlServerInstanceMigrationReadinessReportResult() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? IsCompressed { get { throw null; } }
        public string Report { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch>
    {
        public SqlServerInstancePatch() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties>
    {
        public SqlServerInstanceProperties() { }
        public Azure.ResourceManager.ArcData.Models.AlwaysOnRole? AlwaysOnRole { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DefenderStatus? AzureDefenderStatus { get { throw null; } }
        public System.DateTimeOffset? AzureDefenderStatusLastUpdated { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy BackupPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BestPracticesAssessment BestPracticesAssessment { get { throw null; } set { } }
        public string Collation { get { throw null; } }
        public string ContainerResourceId { get { throw null; } }
        public string Cores { get { throw null; } set { } }
        public string CreateTime { get { throw null; } }
        public string CurrentVersion { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.DbmEndpoint DatabaseMirroringEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DiscoverySource? DiscoverySource { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerEditionType? Edition { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.FailoverCluster FailoverCluster { get { throw null; } set { } }
        public bool? HasDbMasterKey { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType? HostType { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public bool? IsClientConnectionEnabled { get { throw null; } set { } }
        public bool? IsDigiCertPkiCertTrustConfigured { get { throw null; } }
        public bool? IsHadrEnabled { get { throw null; } }
        public bool? IsMicrosoftPkiCertTrustConfigured { get { throw null; } }
        public bool? IsMonitoringEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastInventoryUploadOn { get { throw null; } }
        public System.DateTimeOffset? LastUsageUploadOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType? LicenseType { get { throw null; } }
        public long? MaxServerMemoryMB { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration Migration { get { throw null; } set { } }
        public string PatchLevel { get { throw null; } }
        public string ProductId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerServiceType? ServiceType { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus? Status { get { throw null; } }
        public string TcpDynamicPorts { get { throw null; } }
        public string TcpStaticPorts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> TraceFlags { get { throw null; } }
        public System.DateTimeOffset? UpgradeLockedUntil { get { throw null; } set { } }
        public string VCore { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlVersion? Version { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceRunBestPracticesAssessmentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult>
    {
        internal SqlServerInstanceRunBestPracticesAssessmentResult() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? JobStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SequencerAction> SequencerActions { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceRunMigrationAssessmentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult>
    {
        internal SqlServerInstanceRunMigrationAssessmentResult() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? JobStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SequencerAction> SequencerActions { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceRunMigrationReadinessAssessmentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult>
    {
        internal SqlServerInstanceRunMigrationReadinessAssessmentResult() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? JobStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.SequencerAction> SequencerActions { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceRunTargetRecommendationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult>
    {
        internal SqlServerInstanceRunTargetRecommendationJobResult() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? JobStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceTargetRecommendationReport : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport>
    {
        internal SqlServerInstanceTargetRecommendationReport() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string ReportId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection> Sections { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceTargetRecommendationReportSection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection>
    {
        internal SqlServerInstanceTargetRecommendationReportSection() { }
        public string Data { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public bool? IsCompressed { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerInstanceTargetRecommendationReportSectionType : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerInstanceTargetRecommendationReportSectionType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType FileRequirementsPerDatabase { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType RequirementsPerDatabase { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType RequirementsPerInstance { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType SqlDbTargetRecommendationPerDatabase { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType SqlMiTargetRecommendationPerInstance { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType SqlVmTargetRecommendationPerInstance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType left, Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType left, Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerInstanceTargetRecommendationReportsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult>
    {
        internal SqlServerInstanceTargetRecommendationReportsResult() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? JobStatus { get { throw null; } }
        public int? NextReportOffset { get { throw null; } }
        public int? NextSectionOffset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport> Reports { get { throw null; } }
        public int? TotalReportCount { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerInstanceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties>
    {
        public SqlServerInstanceUpdateProperties() { }
        public Azure.ResourceManager.ArcData.Models.AlwaysOnRole? AlwaysOnRole { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DefenderStatus? AzureDefenderStatus { get { throw null; } }
        public System.DateTimeOffset? AzureDefenderStatusLastUpdated { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerBackupPolicy BackupPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BestPracticesAssessment BestPracticesAssessment { get { throw null; } set { } }
        public string Collation { get { throw null; } }
        public string ContainerResourceId { get { throw null; } }
        public string Cores { get { throw null; } set { } }
        public string CreateTime { get { throw null; } }
        public string CurrentVersion { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.DbmEndpoint DatabaseMirroringEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DiscoverySource? DiscoverySource { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerEditionType? Edition { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.FailoverCluster FailoverCluster { get { throw null; } set { } }
        public bool? HasDbMasterKey { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerHostType? HostType { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public bool? IsClientConnectionEnabled { get { throw null; } set { } }
        public bool? IsDigiCertPkiCertTrustConfigured { get { throw null; } set { } }
        public bool? IsHadrEnabled { get { throw null; } }
        public bool? IsMicrosoftPkiCertTrustConfigured { get { throw null; } set { } }
        public bool? IsMonitoringEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastInventoryUploadOn { get { throw null; } }
        public System.DateTimeOffset? LastUsageUploadOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType? LicenseType { get { throw null; } }
        public long? MaxServerMemoryMB { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration Migration { get { throw null; } set { } }
        public string PatchLevel { get { throw null; } }
        public string ProductId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerServiceType? ServiceType { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerConnectionStatus? Status { get { throw null; } }
        public string TcpDynamicPorts { get { throw null; } }
        public string TcpStaticPorts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> TraceFlags { get { throw null; } }
        public System.DateTimeOffset? UpgradeLockedUntil { get { throw null; } set { } }
        public string VCore { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlVersion? Version { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerJobStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerJobStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerJobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerJobStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerJobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerJobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus left, Azure.ResourceManager.ArcData.Models.SqlServerJobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerJobStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerJobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerJobStatus left, Azure.ResourceManager.ArcData.Models.SqlServerJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerLicenseActivationState : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerLicenseActivationState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState Activated { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState Deactivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState left, Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState left, Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerLicenseBillingPlan : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerLicenseBillingPlan(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan Paid { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan left, Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan left, Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerLicenseCategory : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerLicenseCategory(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory Core { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory left, Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory left, Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerLicensePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch>
    {
        public SqlServerLicensePatch() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlServerLicenseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties>
    {
        public SqlServerLicenseProperties(Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan billingPlan, int physicalCores, Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory licenseCategory, Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState activationState, Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType scopeType) { }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState ActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan BillingPlan { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivatedOn { get { throw null; } }
        public System.DateTimeOffset? LastDeactivatedOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory LicenseCategory { get { throw null; } set { } }
        public int PhysicalCores { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType ScopeType { get { throw null; } set { } }
        public string TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerLicenseScopeType : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerLicenseScopeType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType Subscription { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType Tenant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType left, Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType left, Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerLicenseUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties>
    {
        public SqlServerLicenseUpdateProperties() { }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseActivationState? ActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseBillingPlan? BillingPlan { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivatedOn { get { throw null; } }
        public System.DateTimeOffset? LastDeactivatedOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseCategory? LicenseCategory { get { throw null; } set { } }
        public int? PhysicalCores { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlServerLicenseScopeType? ScopeType { get { throw null; } set { } }
        public string TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerRecommendationResourceUpdateMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerRecommendationResourceUpdateMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode SkipResourceUpdate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode UpdateAllTargetRecommendationDetails { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode left, Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode left, Azure.ResourceManager.ArcData.Models.SqlServerRecommendationResourceUpdateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerServiceType : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlServerServiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerServiceType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerServiceType Engine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerServiceType Pbirs { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerServiceType Ssas { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerServiceType Ssis { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlServerServiceType Ssrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlServerServiceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlServerServiceType left, Azure.ResourceManager.ArcData.Models.SqlServerServiceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerServiceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlServerServiceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlServerServiceType left, Azure.ResourceManager.ArcData.Models.SqlServerServiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlSkuRecommendationCostBreakdown : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown>
    {
        internal SqlSkuRecommendationCostBreakdown() { }
        public float? ComputeCost { get { throw null; } }
        public float? IopsCost { get { throw null; } }
        public float? StorageCost { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostBreakdown>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlSkuRecommendationCostOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions>
    {
        public SqlSkuRecommendationCostOptions() { }
        public string ComputeAndStorageCostOption { get { throw null; } set { } }
        public string SqlLicenseCostOption { get { throw null; } set { } }
        public string WindowsLicenseCostOption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationCostOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlSkuRecommendationStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlSkuRecommendationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus NotReady { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus ReadyWithConditions { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus left, Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus left, Azure.ResourceManager.ArcData.Models.SqlSkuRecommendationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVersion : System.IEquatable<Azure.ResourceManager.ArcData.Models.SqlVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVersion(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlVersion SqlServer2012 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlVersion SqlServer2014 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlVersion SqlServer2016 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlVersion SqlServer2017 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlVersion SqlServer2019 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlVersion SqlServer2022 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlVersion SqlServer2025 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.SqlVersion Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.SqlVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.SqlVersion left, Azure.ResourceManager.ArcData.Models.SqlVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.SqlVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.SqlVersion left, Azure.ResourceManager.ArcData.Models.SqlVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UploadServicePrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.UploadServicePrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.UploadServicePrincipal>
    {
        public UploadServicePrincipal() { }
        public string Authority { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.UploadServicePrincipal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.UploadServicePrincipal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.UploadServicePrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.UploadServicePrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.UploadServicePrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.UploadServicePrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.UploadServicePrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.UploadServicePrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.UploadServicePrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
