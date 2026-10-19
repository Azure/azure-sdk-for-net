namespace Azure.ResourceManager.ArcData
{
    public partial class ActiveDirectoryConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>, System.Collections.IEnumerable
    {
        protected ActiveDirectoryConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string activeDirectoryConnectorName, Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string activeDirectoryConnectorName, Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> Get(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>> GetAsync(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> GetIfExists(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>> GetIfExistsAsync(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ActiveDirectoryConnectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>
    {
        public ActiveDirectoryConnectorData(Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties properties) { }
        public Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActiveDirectoryConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ActiveDirectoryConnectorResource() { }
        public virtual Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataControllerName, string activeDirectoryConnectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ArcDataExtensions
    {
        public static Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource GetActiveDirectoryConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public Azure.ResourceManager.ArcData.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource> GetActiveDirectoryConnector(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource>> GetActiveDirectoryConnectorAsync(string activeDirectoryConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArcData.ActiveDirectoryConnectorCollection GetActiveDirectoryConnectors() { throw null; }
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
        public Azure.ResourceManager.ArcData.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> AddDatabases(Azure.ResourceManager.ArcData.Models.Databases databases, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> AddDatabasesAsync(Azure.ResourceManager.ArcData.Models.Databases databases, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> FailoverMiLink(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId managedInstanceResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> FailoverMiLinkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId managedInstanceResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> ForceFailoverAllowDataLoss(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> ForceFailoverAllowDataLossAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> RemoveDatabases(Azure.ResourceManager.ArcData.Models.Databases databases, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> RemoveDatabasesAsync(Azure.ResourceManager.ArcData.Models.Databases databases, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> CreateAvailabilityGroup(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration createAgConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> CreateAvailabilityGroupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration createAgConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> CreateDistributedAvailabilityGroup(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration createDagConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> CreateDistributedAvailabilityGroupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration createDagConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource> CreateManagedInstanceLink(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration createManagedInstanceLinkConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupResource>> CreateManagedInstanceLinkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration createManagedInstanceLinkConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArcData.ActiveDirectoryConnectorResource GetActiveDirectoryConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccountProvisioningMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.AccountProvisioningMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccountProvisioningMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AccountProvisioningMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.AccountProvisioningMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.AccountProvisioningMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.AccountProvisioningMode left, Azure.ResourceManager.ArcData.Models.AccountProvisioningMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.AccountProvisioningMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.AccountProvisioningMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.AccountProvisioningMode left, Azure.ResourceManager.ArcData.Models.AccountProvisioningMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivationState : System.IEquatable<Azure.ResourceManager.ArcData.Models.ActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivationState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActivationState Activated { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ActivationState Deactivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ActivationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ActivationState left, Azure.ResourceManager.ArcData.Models.ActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ActivationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ActivationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ActivationState left, Azure.ResourceManager.ArcData.Models.ActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
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
        public Azure.ResourceManager.ArcData.Models.AccountProvisioningMode? ServiceAccountProvisioning { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.BasicLoginInformation DomainServiceAccountLoginInformation { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.ResourceUpdateMode? ResourceUpdateMode { get { throw null; } set { } }
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
        public static Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType ServerCAL { get { throw null; } }
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
        public static Azure.ResourceManager.ArcData.ActiveDirectoryConnectorData ActiveDirectoryConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails ActiveDirectoryConnectorDnsDetails(string domainName = null, System.Collections.Generic.IEnumerable<string> nameserverIpAddresses = null, long? replicas = default(long?), bool? shouldPreferK8sDnsForPtrLookups = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails ActiveDirectoryConnectorDomainDetails(string realm = null, string netbiosDomainName = null, Azure.ResourceManager.ArcData.Models.AccountProvisioningMode? serviceAccountProvisioning = default(Azure.ResourceManager.ArcData.Models.AccountProvisioningMode?), string ouDistinguishedName = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers domainControllers = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorProperties ActiveDirectoryConnectorProperties(Azure.ResourceManager.ArcData.Models.BasicLoginInformation domainServiceAccountLoginInformation = null, string provisioningState = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec spec = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus status = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorSpec ActiveDirectoryConnectorSpec(Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDomainDetails activeDirectory = null, Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorDnsDetails dns = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryConnectorStatus ActiveDirectoryConnectorStatus(string lastUpdateTime = null, long? observedGeneration = default(long?), string state = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController ActiveDirectoryDomainController(string hostname = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainControllers ActiveDirectoryDomainControllers(string primaryDomainControllerHostname = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.ActiveDirectoryDomainController> secondaryDomainControllers = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes AdditionalMigrationJobAttributes(string keyName = null, string keyValue = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsRequestContent ArcDataSqlServerInstanceJobsRequestContent(string featureName = null, string jobType = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceJobsStatusRequestContent ArcDataSqlServerInstanceJobsStatusRequestContent(string featureName = null, string jobType = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent ArcDataSqlServerInstanceManagedInstanceLinkAssessmentRequestContent(Azure.Core.ResourceIdentifier azureManagedInstanceResourceId = null, Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole? azureManagedInstanceRole = default(Azure.ResourceManager.ArcData.Models.AzureManagedInstanceRole?), System.Collections.Generic.IEnumerable<string> databaseNames = null, string availabilityGroupName = null, string distributedAvailabilityGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory> assessmentCategories = null, string sqlServerIPAddress = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent(Azure.ResourceManager.ArcData.Models.ResourceUpdateMode? resourceUpdateMode = default(Azure.ResourceManager.ArcData.Models.ResourceUpdateMode?), bool? shouldIncludeFileLevelRequirements = default(bool?), string targetLocation = null, int? percentile = default(int?), int? lookbackPeriodInDays = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent ArcDataSqlServerInstanceTargetRecommendationReportsRequestContent(int? reportOffset = default(int?), int? sectionOffset = default(int?), Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType? sectionType = default(Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType?), System.Collections.Generic.IEnumerable<string> databaseNames = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure AvailabilityGroupConfigure(string endpointName = null, string endpointUri = null, Azure.ResourceManager.ArcData.Models.ConnectionAuth? endpointAuthenticationMode = default(Azure.ResourceManager.ArcData.Models.ConnectionAuth?), string certificateName = null, string endpointConnectLogin = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? availabilityMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode?), string availabilityModeDescription = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? failoverMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode?), string failoverModeDescription = null, int? sessionTimeout = default(int?), Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections? primaryAllowConnections = default(Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections?), string primaryRoleAllowConnectionsDescription = null, Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections? secondaryAllowConnections = default(Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections?), string secondaryRoleAllowConnectionsDescription = null, System.DateTimeOffset? replicaCreateOn = default(System.DateTimeOffset?), System.DateTimeOffset? replicaModifyOn = default(System.DateTimeOffset?), int? backupPriority = default(int?), string readOnlyRoutingUri = null, string readWriteRoutingUri = null, Azure.ResourceManager.ArcData.Models.SeedingMode? seedingMode = default(Azure.ResourceManager.ArcData.Models.SeedingMode?), string seedingModeDescription = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration AvailabilityGroupCreateUpdateConfiguration(string availabilityGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration> replicas = null, System.Collections.Generic.IEnumerable<string> databases = null, Azure.ResourceManager.ArcData.Models.AutomatedBackupPreference? automatedBackupPreference = default(Azure.ResourceManager.ArcData.Models.AutomatedBackupPreference?), Azure.ResourceManager.ArcData.Models.FailureConditionLevel? failureConditionLevel = default(Azure.ResourceManager.ArcData.Models.FailureConditionLevel?), int? healthCheckTimeout = default(int?), Azure.ResourceManager.ArcData.Models.DbFailover? dbFailover = default(Azure.ResourceManager.ArcData.Models.DbFailover?), Azure.ResourceManager.ArcData.Models.DtcSupport? dtcSupport = default(Azure.ResourceManager.ArcData.Models.DtcSupport?), int? requiredSynchronizedSecondariesToCommit = default(int?), Azure.ResourceManager.ArcData.Models.ClusterType? clusterType = default(Azure.ResourceManager.ArcData.Models.ClusterType?), Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties listener = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration AvailabilityGroupCreateUpdateReplicaConfiguration(string serverInstance = null, string endpointName = null, string endpointUri = null, Azure.ResourceManager.ArcData.Models.ConnectionAuth? endpointAuthenticationMode = default(Azure.ResourceManager.ArcData.Models.ConnectionAuth?), string certificateName = null, string endpointConnectLogin = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? availabilityMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode?), Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? failoverMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode?), Azure.ResourceManager.ArcData.Models.SeedingMode? seedingMode = default(Azure.ResourceManager.ArcData.Models.SeedingMode?), int? backupPriority = default(int?), Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections? secondaryRoleAllowConnections = default(Azure.ResourceManager.ArcData.Models.SecondaryAllowConnections?), string secondaryRoleReadOnlyRoutingUri = null, Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections? primaryRoleAllowConnections = default(Azure.ResourceManager.ArcData.Models.PrimaryAllowConnections?), System.Collections.Generic.IEnumerable<string> primaryRoleReadOnlyRoutingList = null, int? sessionTimeout = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo AvailabilityGroupInfo(int? failureConditionLevel = default(int?), int? healthCheckTimeout = default(int?), string automatedBackupPreferenceDescription = null, int? version = default(int?), bool? hasBasicFeatures = default(bool?), bool? dtcSupport = default(bool?), bool? isDbFailoverSupported = default(bool?), bool? isDistributed = default(bool?), string clusterTypeDescription = null, int? requiredSynchronizedSecondariesToCommit = default(int?), bool? isContained = default(bool?), string primaryReplica = null, string primaryRecoveryHealthDescription = null, string secondaryRecoveryHealthDescription = null, string synchronizationHealthDescription = null, Azure.ResourceManager.ArcData.Models.ReplicationPartnerType? replicationPartnerType = default(Azure.ResourceManager.ArcData.Models.ReplicationPartnerType?), Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties listener = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupRetrievalFilters AvailabilityGroupRetrievalFilters(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter? availabilityGroupTypeFilter = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityGroupTypeFilter?), Azure.ResourceManager.ArcData.Models.ReplicationPartnerType? replicationPartnerTypeFilter = default(Azure.ResourceManager.ArcData.Models.ReplicationPartnerType?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AvailabilityGroupState AvailabilityGroupState(string availabilityGroupReplicaRole = null, string operationalStateDescription = null, string recoveryHealthDescription = null, string synchronizationHealthDescription = null, string connectedStateDescription = null, string lastConnectErrorDescription = null, System.DateTimeOffset? lastConnectErrorOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.BackgroundJob BackgroundJob(Azure.ResourceManager.ArcData.Models.BackgroundJobState? state = default(Azure.ResourceManager.ArcData.Models.BackgroundJobState?), Azure.ResourceManager.ArcData.Models.ExecutionState? executionState = default(Azure.ResourceManager.ArcData.Models.ExecutionState?), System.DateTimeOffset? startsOn = default(System.DateTimeOffset?), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.LastExecutionStatus? lastExecutionStatus = default(Azure.ResourceManager.ArcData.Models.LastExecutionStatus?), System.DateTimeOffset? lastExecutionOn = default(System.DateTimeOffset?), System.DateTimeOffset? nextExecutionOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.BackupPolicy BackupPolicy(int? retentionPeriodDays = default(int?), int? fullBackupDays = default(int?), Azure.ResourceManager.ArcData.Models.DifferentialBackupHours? differentialBackupHours = default(Azure.ResourceManager.ArcData.Models.DifferentialBackupHours?), int? transactionLogBackupMinutes = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.BasicLoginInformation BasicLoginInformation(string username = null, string password = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.BestPracticesAssessment BestPracticesAssessment(bool? enabled = default(bool?), Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule schedule = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.BestPracticesAssessmentSchedule BestPracticesAssessmentSchedule(bool? enabled = default(bool?), Azure.ResourceManager.ArcData.Models.CronTrigger cronTrigger = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.CommonSku CommonSku(string name = null, bool? isDevTestEnabled = default(bool?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues CostOptionSelectedValues(string computeAndStorageCostOption = null, string sqlLicenseCostOption = null, string windowsLicenseCostOption = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.CostTypeValues CostTypeValues(float? computeCost = default(float?), float? storageCost = default(float?), float? iopsCost = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.CronTrigger CronTrigger(string startTime = null, string timeZone = null, string expression = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem DatabaseAssessmentsItem(string appliesToMigrationTargetPlatform = null, string featureId = null, string issueCategory = null, string moreInformation = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMigration DatabaseMigration(Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment assessment = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem> jobs = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMigrationAssessment DatabaseMigrationAssessment(System.DateTimeOffset? assessmentUploadOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetRecommendationGenerationOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DatabaseAssessmentsItem> databaseAssessments = null, Azure.ResourceManager.ArcData.Models.TargetReadiness targetReadiness = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DatabaseMigrationJobsItem DatabaseMigrationJobsItem(string migrationTrackingId = null, Azure.ResourceManager.ArcData.Models.MigrationMode? migrationMode = default(Azure.ResourceManager.ArcData.Models.MigrationMode?), Azure.ResourceManager.ArcData.Models.InitiatedFrom? initiatedFrom = default(Azure.ResourceManager.ArcData.Models.InitiatedFrom?), Azure.ResourceManager.ArcData.Models.MigrationStatus? status = default(Azure.ResourceManager.ArcData.Models.MigrationStatus?), string lastError = null, Azure.ResourceManager.ArcData.Models.TargetType? targetType = default(Azure.ResourceManager.ArcData.Models.TargetType?), string targetResourceId = null, System.DateTimeOffset? startsOn = default(System.DateTimeOffset?), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.AdditionalMigrationJobAttributes> additionalAttributes = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.Databases Databases(System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.ArcData.DataControllerData DataControllerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.DataControllerProperties properties = null, Azure.ResourceManager.ArcData.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DataControllerPatch DataControllerPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.DataControllerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DataControllerProperties DataControllerProperties(Azure.ResourceManager.ArcData.Models.DataControllerInfrastructure? infrastructure = default(Azure.ResourceManager.ArcData.Models.DataControllerInfrastructure?), Azure.ResourceManager.ArcData.Models.OnPremiseProperty onPremiseProperty = null, System.BinaryData k8sRaw = null, Azure.ResourceManager.ArcData.Models.UploadWatermark uploadWatermark = null, System.DateTimeOffset? lastUploadedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.BasicLoginInformation basicLoginInformation = null, Azure.ResourceManager.ArcData.Models.BasicLoginInformation metricsDashboardCredential = null, Azure.ResourceManager.ArcData.Models.BasicLoginInformation logsDashboardCredential = null, Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig logAnalyticsWorkspaceConfig = null, Azure.ResourceManager.ArcData.Models.UploadServicePrincipal uploadServicePrincipal = null, string provisioningState = null, string clusterId = null, string extensionId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DbmEndpoint DbmEndpoint(string endpointName = null, Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole? role = default(Azure.ResourceManager.ArcData.Models.DatabaseMirroringRole?), bool? isEncryptionEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm? encryptionAlgorithm = default(Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm?), Azure.ResourceManager.ArcData.Models.ConnectionAuth? connectionAuth = default(Azure.ResourceManager.ArcData.Models.ConnectionAuth?), int? port = default(int?), bool? isDynamicPort = default(bool?), string ipAddress = null, string certificateName = null, System.DateTimeOffset? certificateExpiryOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DiskSizes DiskSizes(string diskType = null, string redundancy = null, string size = null, string caching = null, float? maxSizeInGib = default(float?), float? maxThroughputInMbps = default(float?), float? maxIops = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration(Azure.Core.ResourceIdentifier availabilityGroup = null, System.Uri listenerUri = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? availabilityMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode?), Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode? failoverMode = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerFailoverMode?), Azure.ResourceManager.ArcData.Models.SeedingMode? seedingMode = default(Azure.ResourceManager.ArcData.Models.SeedingMode?), string certificateName = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration DistributedAvailabilityGroupCreateUpdateConfiguration(string availabilityGroupName = null, Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration primaryAvailabilityGroup = null, Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration secondaryAvailabilityGroup = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.EntraAuthentication EntraAuthentication(Azure.ResourceManager.ArcData.Models.IdentityType? identityType = default(Azure.ResourceManager.ArcData.Models.IdentityType?), string clientId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ExtendedLocation ExtendedLocation(string name = null, Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes? type = default(Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.FailoverCluster FailoverCluster(string id = null, string networkName = null, System.Collections.Generic.IEnumerable<string> sqlInstanceIds = null, System.Collections.Generic.IEnumerable<string> hostNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.HostIPAddressInformation> hostIPAddresses = null) { throw null; }
        public static Azure.ResourceManager.ArcData.FailoverGroupData FailoverGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ArcData.Models.FailoverGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.FailoverGroupProperties FailoverGroupProperties(Azure.ResourceManager.ArcData.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ArcData.Models.ProvisioningState?), string partnerManagedInstanceId = null, Azure.ResourceManager.ArcData.Models.FailoverGroupSpec spec = null, System.BinaryData status = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.FailoverGroupSpec FailoverGroupSpec(string sharedName = null, string sourceMI = null, string partnerMI = null, string partnerMirroringUri = null, string partnerMirroringCert = null, Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode? partnerSyncMode = default(Azure.ResourceManager.ArcData.Models.FailoverGroupPartnerSyncMode?), Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole role = default(Azure.ResourceManager.ArcData.Models.InstanceFailoverGroupRole), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId FailoverMiLinkResourceId(Azure.Core.ResourceIdentifier managedInstanceId = null, bool? shouldForce = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.HostIPAddressInformation HostIPAddressInformation(string ipAddress = null, string subnetMask = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo ImpactedObjectsInfo(string featureId = null, int? numberImpacted = default(int?), string issueCategory = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary ImpactedObjectsSuitabilitySummary(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo> azureSqlDatabase = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo> azureSqlManagedInstance = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sActiveDirectory K8sActiveDirectory(Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector connector = null, string accountName = null, string keytabSecret = null, System.Collections.Generic.IEnumerable<string> encryptionTypes = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sActiveDirectoryConnector K8sActiveDirectoryConnector(string name = null, string @namespace = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sNetworkSettings K8sNetworkSettings(int? forceencryption = default(int?), string tlsciphers = null, string tlsprotocols = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sResourceRequirements K8sResourceRequirements(System.Collections.Generic.IDictionary<string, string> requests = null, System.Collections.Generic.IDictionary<string, string> limits = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sScheduling K8sScheduling(Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig @default = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sSchedulingConfig K8sSchedulingConfig(Azure.ResourceManager.ArcData.Models.K8sResourceRequirements resources = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sSecurity K8sSecurity(string adminLoginSecret = null, string serviceCertificateSecret = null, Azure.ResourceManager.ArcData.Models.K8sActiveDirectory activeDirectory = null, Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption transparentDataEncryption = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sSettings K8sSettings(Azure.ResourceManager.ArcData.Models.K8sNetworkSettings network = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.K8sTransparentDataEncryption K8sTransparentDataEncryption(string mode = null, string protectorSecret = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig LogAnalyticsWorkspaceConfig(string workspaceId = null, string primaryKey = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration ManagedInstanceLinkCreateUpdateConfiguration(Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration availabilityGroup = null, Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration distributedAvailabilityGroup = null, string miLinkInstanceAvailabilityGroupName = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.MigrationAssessment MigrationAssessment(bool? enabled = default(bool?), System.DateTimeOffset? assessmentUploadOn = default(System.DateTimeOffset?), System.DateTimeOffset? assessmentViewedOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetRecommendationGenerationOn = default(System.DateTimeOffset?), string version = null, Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings settings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem> serverAssessments = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResults skuRecommendationResults = null, Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary impactedObjectsSummary = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.MigrationAssessmentSettings MigrationAssessmentSettings(string targetLocation = null, float? percentile = default(float?), int? lookbackPeriodInDays = default(int?), int? comfortFactor = default(int?), string strategy = null, string currency = null, float? discountPercentage = default(float?), Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues costOptions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.OnPremiseProperty OnPremiseProperty(string id = null, string publicSigningKey = null, string signingCertificateThumbprint = null) { throw null; }
        public static Azure.ResourceManager.ArcData.PostgresInstanceData PostgresInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties properties = null, Azure.ResourceManager.ArcData.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.ArcData.Models.PostgresInstanceSku sku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.PostgresInstancePatch PostgresInstancePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.PostgresInstanceProperties PostgresInstanceProperties(string dataControllerId = null, string admin = null, Azure.ResourceManager.ArcData.Models.BasicLoginInformation basicLoginInformation = null, System.BinaryData k8sRaw = null, System.DateTimeOffset? lastUploadedOn = default(System.DateTimeOffset?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.PostgresInstanceSku PostgresInstanceSku(string name = null, bool? isDevTestEnabled = default(bool?), string size = null, string family = null, int? capacity = default(int?), Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier? tier = default(Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SequencerAction SequencerAction(string actionId = null, Azure.ResourceManager.ArcData.Models.SequencerState? state = default(Azure.ResourceManager.ArcData.Models.SequencerState?), Azure.ResourceManager.ArcData.Models.SequencerActionResult? result = default(Azure.ResourceManager.ArcData.Models.SequencerActionResult?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ServerAssessmentsItem ServerAssessmentsItem(string appliesToMigrationTargetPlatform = null, string featureId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem> impactedObjects = null, string issueCategory = null, string moreInformation = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ServerAssessmentsPropertiesItemsItem ServerAssessmentsPropertiesItemsItem(string impactDetail = null, string name = null, string objectType = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResults SkuRecommendationResults(Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase azureSqlDatabase = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance azureSqlManagedInstance = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine azureSqlVirtualMachine = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabase SkuRecommendationResultsAzureSqlDatabase(Azure.ResourceManager.ArcData.Models.RecommendationStatus? recommendationStatus = default(Azure.ResourceManager.ArcData.Models.RecommendationStatus?), int? numberOfServerBlockerIssues = default(int?), Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost monthlyCost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> monthlyCostOptions = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku targetSku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSku SkuRecommendationResultsAzureSqlDatabaseTargetSku(Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory category = null, int? computeSize = default(int?), float? storageMaxSizeInMb = default(float?), float? predictedDataSizeInMb = default(float?), float? predictedLogSizeInMb = default(float?), float? maxStorageIops = default(float?), float? maxThroughputMBps = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory SkuRecommendationResultsAzureSqlDatabaseTargetSkuCategory(string computeTier = null, string hardwareType = null, string sqlPurchasingModel = null, string sqlServiceTier = null, bool? isZoneRedundancyAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstance SkuRecommendationResultsAzureSqlManagedInstance(Azure.ResourceManager.ArcData.Models.RecommendationStatus? recommendationStatus = default(Azure.ResourceManager.ArcData.Models.RecommendationStatus?), int? numberOfServerBlockerIssues = default(int?), Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost monthlyCost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> monthlyCostOptions = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku targetSku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSku SkuRecommendationResultsAzureSqlManagedInstanceTargetSku(Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory category = null, int? computeSize = default(int?), float? storageMaxSizeInMb = default(float?), float? predictedDataSizeInMb = default(float?), float? predictedLogSizeInMb = default(float?), float? maxStorageIops = default(float?), float? maxThroughputMBps = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory SkuRecommendationResultsAzureSqlManagedInstanceTargetSkuCategory(string computeTier = null, string hardwareType = null, string sqlPurchasingModel = null, string sqlServiceTier = null, bool? isZoneRedundancyAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachine SkuRecommendationResultsAzureSqlVirtualMachine(Azure.ResourceManager.ArcData.Models.RecommendationStatus? recommendationStatus = default(Azure.ResourceManager.ArcData.Models.RecommendationStatus?), int? numberOfServerBlockerIssues = default(int?), Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost monthlyCost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> monthlyCostOptions = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku targetSku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSku SkuRecommendationResultsAzureSqlVirtualMachineTargetSku(Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory category = null, int? computeSize = default(int?), float? predictedDataSizeInMb = default(float?), float? predictedLogSizeInMb = default(float?), Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize virtualMachineSize = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DiskSizes> dataDiskSizes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DiskSizes> logDiskSizes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.DiskSizes> tempDBDiskSizes = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuCategory(System.Collections.Generic.IEnumerable<string> availableVmSkus = null, string virtualMachineFamily = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize SkuRecommendationResultsAzureSqlVirtualMachineTargetSkuVirtualMachineSize(string virtualMachineFamily = null, string sizeName = null, int? computeSize = default(int?), string azureSkuName = null, int? vcpUsAvailable = default(int?), int? maxNetworkInterfaces = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost SkuRecommendationResultsMonthlyCost(float? computeCost = default(float?), float? storageCost = default(float?), float? iopsCost = default(float?), float? sqlLicenseCost = default(float?), float? windowsLicenseCost = default(float?), float? totalCost = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem SkuRecommendationResultsMonthlyCostOptionItem(string keyName = null, Azure.ResourceManager.ArcData.Models.CostTypeValues keyValue = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary SkuRecommendationSummary(int? numOfBlockerIssues = default(int?), Azure.ResourceManager.ArcData.Models.RecommendationStatus? recommendationStatus = default(Azure.ResourceManager.ArcData.Models.RecommendationStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo> impactedObjectsSummary = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost monthlyCost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> monthlyCostOptions = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku targetSku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSku SkuRecommendationSummaryTargetSku(Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory category = null, int? computeSize = default(int?), float? storageMaxSizeInMb = default(float?), float? predictedDataSizeInMb = default(float?), float? predictedLogSizeInMb = default(float?), float? maxStorageIops = default(float?), float? maxThroughputMBps = default(float?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SkuRecommendationSummaryTargetSkuCategory SkuRecommendationSummaryTargetSkuCategory(string computeTier = null, string hardwareType = null, string sqlPurchasingModel = null, string sqlServiceTier = null, bool? isZoneRedundancyAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties SqlAvailabilityGroupDatabaseReplicaResourceProperties(string databaseName = null, string replicaName = null, bool? isLocal = default(bool?), bool? isPrimaryReplica = default(bool?), string synchronizationStateDescription = null, bool? isCommitParticipant = default(bool?), string synchronizationHealthDescription = null, string databaseStateDescription = null, bool? isSuspended = default(bool?), string suspendReasonDescription = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem(string ipAddress = null, string mask = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties SqlAvailabilityGroupReplicaResourceProperties(string replicaId = null, string replicaName = null, Azure.Core.ResourceIdentifier replicaResourceId = null, Azure.ResourceManager.ArcData.Models.AvailabilityGroupConfigure configure = null, Azure.ResourceManager.ArcData.Models.AvailabilityGroupState state = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties SqlAvailabilityGroupStaticIPListenerProperties(string dnsName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupIPv4AddressesAndMasksPropertiesItem> ipv4AddressesAndMasks = null, System.Collections.Generic.IEnumerable<string> ipv6Addresses = null, int? port = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlManagedInstanceData SqlManagedInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties properties = null, Azure.ResourceManager.ArcData.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku sku = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw SqlManagedInstanceK8sRaw(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec spec = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sSpec SqlManagedInstanceK8sSpec(Azure.ResourceManager.ArcData.Models.K8sScheduling scheduling = null, int? replicas = default(int?), Azure.ResourceManager.ArcData.Models.K8sSecurity security = null, Azure.ResourceManager.ArcData.Models.K8sSettings settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstancePatch SqlManagedInstancePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceProperties SqlManagedInstanceProperties(string dataControllerId = null, string admin = null, string startTime = null, string endTime = null, Azure.ResourceManager.ArcData.Models.SqlManagedInstanceK8sRaw k8sRaw = null, Azure.ResourceManager.ArcData.Models.BasicLoginInformation basicLoginInformation = null, System.DateTimeOffset? lastUploadedOn = default(System.DateTimeOffset?), string provisioningState = null, string activeDirectoryInformationKeytab = null, Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType? licenseType = default(Azure.ResourceManager.ArcData.Models.ArcSqlManagedInstanceLicenseType?), string clusterId = null, string extensionId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSku SqlManagedInstanceSku(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSkuTier? tier = default(Azure.ResourceManager.ArcData.Models.SqlManagedInstanceSkuTier?), bool? isDevTestEnabled = default(bool?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAuthentication SqlServerAuthentication(Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode? mode = default(Azure.ResourceManager.ArcData.Models.SqlServerAuthenticationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.EntraAuthentication> sqlServerEntraIdentity = null) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerAvailabilityGroupData SqlServerAvailabilityGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupPatch SqlServerAvailabilityGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourceProperties SqlServerAvailabilityGroupResourceProperties(string availabilityGroupId = null, string serverName = null, string instanceName = null, string vmId = null, System.DateTimeOffset? collectionOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.AvailabilityGroupInfo info = null, Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas replicas = null, Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases databases = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesDatabases SqlServerAvailabilityGroupResourcePropertiesDatabases(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupDatabaseReplicaResourceProperties> value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerAvailabilityGroupResourcePropertiesReplicas SqlServerAvailabilityGroupResourcePropertiesReplicas(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupReplicaResourceProperties> value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig SqlServerDatabaseConfig(bool? isAutoCloseOn = default(bool?), bool? isAutoShrinkOn = default(bool?), bool? isAutoCreateStatsOn = default(bool?), bool? isAutoUpdateStatsOn = default(bool?), bool? isRemoteDataArchiveEnabled = default(bool?), bool? isMemoryOptimizationEnabled = default(bool?), bool? isEncrypted = default(bool?), bool? isTrustworthyOn = default(bool?), bool? isHekatonFilesOn = default(bool?), int? numberOfHekatonFiles = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerDatabaseData SqlServerDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerDatabasePatch SqlServerDatabasePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourceProperties SqlServerDatabaseResourceProperties(string collationName = null, System.DateTimeOffset? databaseCreatedOn = default(System.DateTimeOffset?), int? compatibilityLevel = default(int?), float? sizeMB = default(float?), float? logFileSizeMB = default(float?), float? dataFileSizeMB = default(float?), float? spaceAvailableMB = default(float?), Azure.ResourceManager.ArcData.Models.DatabaseState? state = default(Azure.ResourceManager.ArcData.Models.DatabaseState?), bool? isReadOnly = default(bool?), Azure.ResourceManager.ArcData.Models.RecoveryMode? recoveryMode = default(Azure.ResourceManager.ArcData.Models.RecoveryMode?), Azure.ResourceManager.ArcData.Models.SqlServerDatabaseConfig databaseOptions = null, Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation backupInformation = null, Azure.ResourceManager.ArcData.Models.BackupPolicy backupPolicy = null, System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.DatabaseCreateMode? createMode = default(Azure.ResourceManager.ArcData.Models.DatabaseCreateMode?), string sourceDatabaseId = null, string vmId = null, System.DateTimeOffset? restorePointInTime = default(System.DateTimeOffset?), string provisioningState = null, System.DateTimeOffset? lastDatabaseUploadOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.DatabaseMigration migration = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerDatabaseResourcePropertiesBackupInformation SqlServerDatabaseResourcePropertiesBackupInformation(System.DateTimeOffset? lastFullBackup = default(System.DateTimeOffset?), System.DateTimeOffset? lastLogBackup = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerEsuLicenseData SqlServerEsuLicenseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicensePatch SqlServerEsuLicensePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseProperties SqlServerEsuLicenseProperties(Azure.ResourceManager.ArcData.Models.BillingPlan billingPlan = default(Azure.ResourceManager.ArcData.Models.BillingPlan), Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion version = default(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion), string uniqueId = null, int physicalCores = 0, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState activationState = default(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState), Azure.ResourceManager.ArcData.Models.ScopeType scopeType = default(Azure.ResourceManager.ArcData.Models.ScopeType), System.DateTimeOffset? activatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? terminatedOn = default(System.DateTimeOffset?), string tenantId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseUpdateProperties SqlServerEsuLicenseUpdateProperties(Azure.ResourceManager.ArcData.Models.BillingPlan? billingPlan = default(Azure.ResourceManager.ArcData.Models.BillingPlan?), Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion? version = default(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion?), string uniqueId = null, int? physicalCores = default(int?), Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState? activationState = default(Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState?), Azure.ResourceManager.ArcData.Models.ScopeType? scopeType = default(Azure.ResourceManager.ArcData.Models.ScopeType?), System.DateTimeOffset? activatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? terminatedOn = default(System.DateTimeOffset?), string tenantId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerInstanceData SqlServerInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob SqlServerInstanceJob(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.JobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.JobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.BackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsResult SqlServerInstanceJobsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJob> jobs = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobsStatusResult SqlServerInstanceJobsStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus> jobsStatus = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceJobStatus SqlServerInstanceJobStatus(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.JobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.JobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.BackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment SqlServerInstanceManagedInstanceLinkAssessment(string name = null, Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory? category = default(Azure.ResourceManager.ArcData.Models.MiLinkAssessmentCategory?), Azure.ResourceManager.ArcData.Models.AssessmentStatus? status = default(Azure.ResourceManager.ArcData.Models.AssessmentStatus?), string information = null, string additionalInformation = null, System.Collections.Generic.IEnumerable<string> failingDbs = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessmentResult SqlServerInstanceManagedInstanceLinkAssessmentResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceManagedInstanceLinkAssessment> assessments = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration SqlServerInstanceMigration(Azure.ResourceManager.ArcData.Models.MigrationAssessment assessment = null, System.DateTimeOffset? targetSelectedOn = default(System.DateTimeOffset?), string targetResourceId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigrationReadinessReportResult SqlServerInstanceMigrationReadinessReportResult(string report = null, bool? isCompressed = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstancePatch SqlServerInstancePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceProperties SqlServerInstanceProperties(Azure.ResourceManager.ArcData.Models.SqlVersion? version = default(Azure.ResourceManager.ArcData.Models.SqlVersion?), Azure.ResourceManager.ArcData.Models.EditionType? edition = default(Azure.ResourceManager.ArcData.Models.EditionType?), string containerResourceId = null, string vmId = null, string createTime = null, string vCore = null, string cores = null, Azure.ResourceManager.ArcData.Models.ConnectionStatus? status = default(Azure.ResourceManager.ArcData.Models.ConnectionStatus?), Azure.ResourceManager.ArcData.Models.DiscoverySource? discoverySource = default(Azure.ResourceManager.ArcData.Models.DiscoverySource?), string patchLevel = null, string collation = null, bool? hasDbMasterKey = default(bool?), bool? isHadrEnabled = default(bool?), System.Collections.Generic.IEnumerable<int> traceFlags = null, string currentVersion = null, string instanceName = null, string tcpDynamicPorts = null, string tcpStaticPorts = null, string productId = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType? licenseType = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType?), System.DateTimeOffset? azureDefenderStatusLastUpdated = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.DefenderStatus? azureDefenderStatus = default(Azure.ResourceManager.ArcData.Models.DefenderStatus?), string provisioningState = null, System.DateTimeOffset? lastInventoryUploadOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUsageUploadOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.HostType? hostType = default(Azure.ResourceManager.ArcData.Models.HostType?), Azure.ResourceManager.ArcData.Models.AlwaysOnRole? alwaysOnRole = default(Azure.ResourceManager.ArcData.Models.AlwaysOnRole?), Azure.ResourceManager.ArcData.Models.DbmEndpoint databaseMirroringEndpoint = null, Azure.ResourceManager.ArcData.Models.FailoverCluster failoverCluster = null, Azure.ResourceManager.ArcData.Models.BackupPolicy backupPolicy = null, System.DateTimeOffset? upgradeLockedUntil = default(System.DateTimeOffset?), bool? isMonitoringEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration migration = null, Azure.ResourceManager.ArcData.Models.BestPracticesAssessment bestPracticesAssessment = null, bool? isClientConnectionEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.ServiceType? serviceType = default(Azure.ResourceManager.ArcData.Models.ServiceType?), long? maxServerMemoryMB = default(long?), bool? isMicrosoftPkiCertTrustConfigured = default(bool?), bool? isDigiCertPkiCertTrustConfigured = default(bool?), Azure.ResourceManager.ArcData.Models.SqlServerAuthentication authentication = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunBestPracticesAssessmentResult SqlServerInstanceRunBestPracticesAssessmentResult(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.JobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.JobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.BackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationAssessmentResult SqlServerInstanceRunMigrationAssessmentResult(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.JobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.JobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.BackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunMigrationReadinessAssessmentResult SqlServerInstanceRunMigrationReadinessAssessmentResult(string id = null, string instanceName = null, Azure.ResourceManager.ArcData.Models.JobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.JobStatus?), string jobException = null, Azure.ResourceManager.ArcData.Models.BackgroundJob backgroundJob = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SequencerAction> sequencerActions = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceRunTargetRecommendationJobResult SqlServerInstanceRunTargetRecommendationJobResult(Azure.ResourceManager.ArcData.Models.JobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.JobStatus?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport SqlServerInstanceTargetRecommendationReport(string reportId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection> sections = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSection SqlServerInstanceTargetRecommendationReportSection(string data = null, Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType? type = default(Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType?), string databaseName = null, bool? isCompressed = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportsResult SqlServerInstanceTargetRecommendationReportsResult(Azure.ResourceManager.ArcData.Models.JobStatus? jobStatus = default(Azure.ResourceManager.ArcData.Models.JobStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReport> reports = null, int? totalReportCount = default(int?), int? nextReportOffset = default(int?), int? nextSectionOffset = default(int?)) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceUpdateProperties SqlServerInstanceUpdateProperties(Azure.ResourceManager.ArcData.Models.SqlVersion? version = default(Azure.ResourceManager.ArcData.Models.SqlVersion?), Azure.ResourceManager.ArcData.Models.EditionType? edition = default(Azure.ResourceManager.ArcData.Models.EditionType?), string containerResourceId = null, string vmId = null, string createTime = null, string vCore = null, string cores = null, Azure.ResourceManager.ArcData.Models.ConnectionStatus? status = default(Azure.ResourceManager.ArcData.Models.ConnectionStatus?), Azure.ResourceManager.ArcData.Models.DiscoverySource? discoverySource = default(Azure.ResourceManager.ArcData.Models.DiscoverySource?), string patchLevel = null, string collation = null, bool? hasDbMasterKey = default(bool?), bool? isHadrEnabled = default(bool?), System.Collections.Generic.IEnumerable<int> traceFlags = null, string currentVersion = null, string instanceName = null, string tcpDynamicPorts = null, string tcpStaticPorts = null, string productId = null, Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType? licenseType = default(Azure.ResourceManager.ArcData.Models.ArcSqlServerLicenseType?), System.DateTimeOffset? azureDefenderStatusLastUpdated = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.DefenderStatus? azureDefenderStatus = default(Azure.ResourceManager.ArcData.Models.DefenderStatus?), string provisioningState = null, System.DateTimeOffset? lastInventoryUploadOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUsageUploadOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArcData.Models.HostType? hostType = default(Azure.ResourceManager.ArcData.Models.HostType?), Azure.ResourceManager.ArcData.Models.AlwaysOnRole? alwaysOnRole = default(Azure.ResourceManager.ArcData.Models.AlwaysOnRole?), Azure.ResourceManager.ArcData.Models.FailoverCluster failoverCluster = null, Azure.ResourceManager.ArcData.Models.BackupPolicy backupPolicy = null, System.DateTimeOffset? upgradeLockedUntil = default(System.DateTimeOffset?), bool? isMonitoringEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.SqlServerInstanceMigration migration = null, Azure.ResourceManager.ArcData.Models.BestPracticesAssessment bestPracticesAssessment = null, bool? isClientConnectionEnabled = default(bool?), Azure.ResourceManager.ArcData.Models.ServiceType? serviceType = default(Azure.ResourceManager.ArcData.Models.ServiceType?), Azure.ResourceManager.ArcData.Models.SqlServerAuthentication authentication = null, Azure.ResourceManager.ArcData.Models.DbmEndpoint databaseMirroringEndpoint = null, bool? isMicrosoftPkiCertTrustConfigured = default(bool?), bool? isDigiCertPkiCertTrustConfigured = default(bool?), long? maxServerMemoryMB = default(long?)) { throw null; }
        public static Azure.ResourceManager.ArcData.SqlServerLicenseData SqlServerLicenseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicensePatch SqlServerLicensePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseProperties SqlServerLicenseProperties(Azure.ResourceManager.ArcData.Models.BillingPlan billingPlan = default(Azure.ResourceManager.ArcData.Models.BillingPlan), int physicalCores = 0, Azure.ResourceManager.ArcData.Models.LicenseCategory licenseCategory = default(Azure.ResourceManager.ArcData.Models.LicenseCategory), Azure.ResourceManager.ArcData.Models.ActivationState activationState = default(Azure.ResourceManager.ArcData.Models.ActivationState), Azure.ResourceManager.ArcData.Models.ScopeType scopeType = default(Azure.ResourceManager.ArcData.Models.ScopeType), System.DateTimeOffset? lastActivatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeactivatedOn = default(System.DateTimeOffset?), string tenantId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties SqlServerLicenseUpdateProperties(Azure.ResourceManager.ArcData.Models.BillingPlan? billingPlan = default(Azure.ResourceManager.ArcData.Models.BillingPlan?), int? physicalCores = default(int?), Azure.ResourceManager.ArcData.Models.LicenseCategory? licenseCategory = default(Azure.ResourceManager.ArcData.Models.LicenseCategory?), Azure.ResourceManager.ArcData.Models.ActivationState? activationState = default(Azure.ResourceManager.ArcData.Models.ActivationState?), Azure.ResourceManager.ArcData.Models.ScopeType? scopeType = default(Azure.ResourceManager.ArcData.Models.ScopeType?), System.DateTimeOffset? lastActivatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeactivatedOn = default(System.DateTimeOffset?), string tenantId = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.TargetReadiness TargetReadiness(Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary azureSqlDatabase = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary azureSqlManagedInstance = null, Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary azureSqlVirtualMachine = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.UploadServicePrincipal UploadServicePrincipal(string clientId = null, string tenantId = null, string authority = null, string clientSecret = null) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.UploadWatermark UploadWatermark(System.DateTimeOffset? metrics = default(System.DateTimeOffset?), System.DateTimeOffset? logs = default(System.DateTimeOffset?), System.DateTimeOffset? usages = default(System.DateTimeOffset?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.AssessmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.AssessmentStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.AssessmentStatus Success { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.AssessmentStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.AssessmentStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.AssessmentStatus left, Azure.ResourceManager.ArcData.Models.AssessmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.AssessmentStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.AssessmentStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.AssessmentStatus left, Azure.ResourceManager.ArcData.Models.AssessmentStatus right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.ArcData.Models.ConnectionAuth? EndpointAuthenticationMode { get { throw null; } set { } }
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
        public int? SessionTimeout { get { throw null; } set { } }
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
    public partial class AvailabilityGroupCreateUpdateConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration>
    {
        public AvailabilityGroupCreateUpdateConfiguration() { }
        public Azure.ResourceManager.ArcData.Models.AutomatedBackupPreference? AutomatedBackupPreference { get { throw null; } set { } }
        public string AvailabilityGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ClusterType? ClusterType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.DbFailover? DbFailover { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DtcSupport? DtcSupport { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.FailureConditionLevel? FailureConditionLevel { get { throw null; } set { } }
        public int? HealthCheckTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.SqlAvailabilityGroupStaticIPListenerProperties Listener { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration> Replicas { get { throw null; } }
        public int? RequiredSynchronizedSecondariesToCommit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilityGroupCreateUpdateReplicaConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateReplicaConfiguration>
    {
        public AvailabilityGroupCreateUpdateReplicaConfiguration() { }
        public Azure.ResourceManager.ArcData.Models.ArcSqlServerAvailabilityMode? AvailabilityMode { get { throw null; } set { } }
        public int? BackupPriority { get { throw null; } set { } }
        public string CertificateName { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ConnectionAuth? EndpointAuthenticationMode { get { throw null; } set { } }
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
        public int? SessionTimeout { get { throw null; } set { } }
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
        public bool? DtcSupport { get { throw null; } set { } }
        public int? FailureConditionLevel { get { throw null; } set { } }
        public bool? HasBasicFeatures { get { throw null; } set { } }
        public int? HealthCheckTimeout { get { throw null; } set { } }
        public bool? IsContained { get { throw null; } set { } }
        public bool? IsDbFailoverSupported { get { throw null; } set { } }
        public bool? IsDistributed { get { throw null; } set { } }
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
    public partial class BackgroundJob : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BackgroundJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BackgroundJob>
    {
        internal BackgroundJob() { }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.ExecutionState? ExecutionState { get { throw null; } }
        public System.DateTimeOffset? LastExecutionOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.LastExecutionStatus? LastExecutionStatus { get { throw null; } }
        public System.DateTimeOffset? NextExecutionOn { get { throw null; } }
        public System.DateTimeOffset? StartsOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.BackgroundJobState? State { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.BackgroundJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.BackgroundJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.BackgroundJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BackgroundJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BackgroundJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.BackgroundJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BackgroundJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BackgroundJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BackgroundJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackgroundJobState : System.IEquatable<Azure.ResourceManager.ArcData.Models.BackgroundJobState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackgroundJobState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.BackgroundJobState Completed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.BackgroundJobState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.BackgroundJobState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.BackgroundJobState Enabled { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.BackgroundJobState Faulted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.BackgroundJobState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.BackgroundJobState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.BackgroundJobState left, Azure.ResourceManager.ArcData.Models.BackgroundJobState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.BackgroundJobState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.BackgroundJobState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.BackgroundJobState left, Azure.ResourceManager.ArcData.Models.BackgroundJobState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BackupPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BackupPolicy>
    {
        public BackupPolicy() { }
        public Azure.ResourceManager.ArcData.Models.DifferentialBackupHours? DifferentialBackupHours { get { throw null; } set { } }
        public int? FullBackupDays { get { throw null; } set { } }
        public int? RetentionPeriodDays { get { throw null; } set { } }
        public int? TransactionLogBackupMinutes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.BackupPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.BackupPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.BackupPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BackupPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BackupPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.BackupPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BackupPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BackupPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BackupPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BasicLoginInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BasicLoginInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BasicLoginInformation>
    {
        public BasicLoginInformation() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.BasicLoginInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.BasicLoginInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.BasicLoginInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BasicLoginInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.BasicLoginInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.BasicLoginInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BasicLoginInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BasicLoginInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.BasicLoginInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingPlan : System.IEquatable<Azure.ResourceManager.ArcData.Models.BillingPlan>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingPlan(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.BillingPlan Paid { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.BillingPlan Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.BillingPlan other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.BillingPlan left, Azure.ResourceManager.ArcData.Models.BillingPlan right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.BillingPlan (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.BillingPlan? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.BillingPlan left, Azure.ResourceManager.ArcData.Models.BillingPlan right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ClusterType
    {
        Wsfc = 0,
        None = 1,
    }
    public partial class CommonSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CommonSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CommonSku>
    {
        public CommonSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public bool? IsDevTestEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.CommonSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.CommonSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.CommonSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CommonSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CommonSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.CommonSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CommonSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CommonSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CommonSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionAuth : System.IEquatable<Azure.ResourceManager.ArcData.Models.ConnectionAuth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionAuth(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth Certificate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth CertificateWindowsKerberos { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth CertificateWindowsNegotiate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth CertificateWindowsNtlm { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth WindowsKerberos { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth WindowsKerberosCertificate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth WindowsNegotiate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth WindowsNegotiateCertificate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth WindowsNtlm { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionAuth WindowsNtlmCertificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ConnectionAuth other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ConnectionAuth left, Azure.ResourceManager.ArcData.Models.ConnectionAuth right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ConnectionAuth (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ConnectionAuth? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ConnectionAuth left, Azure.ResourceManager.ArcData.Models.ConnectionAuth right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.ConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionStatus Discovered { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionStatus Registered { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ConnectionStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ConnectionStatus left, Azure.ResourceManager.ArcData.Models.ConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ConnectionStatus left, Azure.ResourceManager.ArcData.Models.ConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostOptionSelectedValues : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues>
    {
        public CostOptionSelectedValues() { }
        public string ComputeAndStorageCostOption { get { throw null; } set { } }
        public string SqlLicenseCostOption { get { throw null; } set { } }
        public string WindowsLicenseCostOption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CostTypeValues : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CostTypeValues>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CostTypeValues>
    {
        internal CostTypeValues() { }
        public float? ComputeCost { get { throw null; } }
        public float? IopsCost { get { throw null; } }
        public float? StorageCost { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.CostTypeValues JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.CostTypeValues PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.CostTypeValues System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CostTypeValues>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.CostTypeValues>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.CostTypeValues System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CostTypeValues>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CostTypeValues>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.CostTypeValues>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.ArcData.Models.TargetReadiness TargetReadiness { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.InitiatedFrom? InitiatedFrom { get { throw null; } set { } }
        public string LastError { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.MigrationMode? MigrationMode { get { throw null; } set { } }
        public string MigrationTrackingId { get { throw null; } set { } }
        public System.DateTimeOffset? StartsOn { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.MigrationStatus? Status { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.TargetType? TargetType { get { throw null; } set { } }
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
    public partial class Databases : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.Databases>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.Databases>
    {
        public Databases() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.Databases JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.Databases PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.Databases System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.Databases>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.Databases>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.Databases System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.Databases>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.Databases>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.Databases>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.ArcData.Models.BasicLoginInformation BasicLoginInformation { get { throw null; } set { } }
        public string ClusterId { get { throw null; } set { } }
        public string ExtensionId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DataControllerInfrastructure? Infrastructure { get { throw null; } set { } }
        public System.BinaryData K8sRaw { get { throw null; } set { } }
        public System.DateTimeOffset? LastUploadedOn { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.LogAnalyticsWorkspaceConfig LogAnalyticsWorkspaceConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BasicLoginInformation LogsDashboardCredential { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BasicLoginInformation MetricsDashboardCredential { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.OnPremiseProperty OnPremiseProperty { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.UploadServicePrincipal UploadServicePrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.UploadWatermark UploadWatermark { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.ConnectionAuth? ConnectionAuth { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm? EncryptionAlgorithm { get { throw null; } }
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
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource ADS { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource AzureArc { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource AzureMigrate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource DMSCLI { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource DMSPortal { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource DMSPS { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.DiscoverySource DMSSDK { get { throw null; } }
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
    public partial class DistributedAvailabilityGroupCreateUpdateConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration>
    {
        public DistributedAvailabilityGroupCreateUpdateConfiguration() { }
        public string AvailabilityGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration PrimaryAvailabilityGroup { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateAvailabilityGroupConfiguration SecondaryAvailabilityGroup { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DtcSupport
    {
        PerDb = 0,
        None = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EditionType : System.IEquatable<Azure.ResourceManager.ArcData.Models.EditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EditionType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.EditionType BusinessIntelligence { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EditionType Developer { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EditionType Enterprise { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EditionType Evaluation { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EditionType Express { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EditionType Standard { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EditionType StandardDeveloper { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EditionType Unknown { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EditionType Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.EditionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.EditionType left, Azure.ResourceManager.ArcData.Models.EditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.EditionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.EditionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.EditionType left, Azure.ResourceManager.ArcData.Models.EditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionAlgorithm : System.IEquatable<Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm Aes { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm AesRc4 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm NoneAes { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm NoneAesRc4 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm NoneRC4 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm NoneRc4Aes { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm RC4 { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm Rc4Aes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm left, Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm left, Azure.ResourceManager.ArcData.Models.EncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntraAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.EntraAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.EntraAuthentication>
    {
        public EntraAuthentication() { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.IdentityType? IdentityType { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionState : System.IEquatable<Azure.ResourceManager.ArcData.Models.ExecutionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ExecutionState Running { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ExecutionState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ExecutionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ExecutionState left, Azure.ResourceManager.ArcData.Models.ExecutionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ExecutionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ExecutionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ExecutionState left, Azure.ResourceManager.ArcData.Models.ExecutionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ExtendedLocation>
    {
        public ExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ExtendedLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ExtendedLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationTypes : System.IEquatable<Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationTypes(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes CustomLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes left, Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes left, Azure.ResourceManager.ArcData.Models.ExtendedLocationTypes right) { throw null; }
        public override string ToString() { throw null; }
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
        public FailoverGroupProperties(string partnerManagedInstanceId, Azure.ResourceManager.ArcData.Models.FailoverGroupSpec spec) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string PartnerManagedInstanceId { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ProvisioningState? ProvisioningState { get { throw null; } }
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
    public partial class FailoverMiLinkResourceId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId>
    {
        public FailoverMiLinkResourceId() { }
        public Azure.Core.ResourceIdentifier ManagedInstanceId { get { throw null; } set { } }
        public bool? ShouldForce { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.FailoverMiLinkResourceId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct HostType : System.IEquatable<Azure.ResourceManager.ArcData.Models.HostType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.HostType AWSKubernetesService { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType AWSVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType AWSVMWareVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType AzureKubernetesService { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType AzureVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType AzureVMWareVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType Container { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType GCPKubernetesService { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType GCPVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType GCPVMWareVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType HyperVVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType Other { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType PhysicalServer { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.HostType VirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.HostType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.HostType left, Azure.ResourceManager.ArcData.Models.HostType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.HostType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.HostType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.HostType left, Azure.ResourceManager.ArcData.Models.HostType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.ArcData.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.IdentityType SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.IdentityType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.IdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.IdentityType left, Azure.ResourceManager.ArcData.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.IdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.IdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.IdentityType left, Azure.ResourceManager.ArcData.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpactedObjectsInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo>
    {
        internal ImpactedObjectsInfo() { }
        public string FeatureId { get { throw null; } }
        public string IssueCategory { get { throw null; } }
        public int? NumberImpacted { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactedObjectsSuitabilitySummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary>
    {
        public ImpactedObjectsSuitabilitySummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo> AzureSqlDatabase { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo> AzureSqlManagedInstance { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InitiatedFrom : System.IEquatable<Azure.ResourceManager.ArcData.Models.InitiatedFrom>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InitiatedFrom(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.InitiatedFrom ADS { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InitiatedFrom AzureArc { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InitiatedFrom DMSCLI { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InitiatedFrom DMSPortal { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InitiatedFrom DMSPS { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InitiatedFrom DMSSDK { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InitiatedFrom Other { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InitiatedFrom Ssma { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.InitiatedFrom Ssms { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.InitiatedFrom other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.InitiatedFrom left, Azure.ResourceManager.ArcData.Models.InitiatedFrom right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.InitiatedFrom (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.InitiatedFrom? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.InitiatedFrom left, Azure.ResourceManager.ArcData.Models.InitiatedFrom right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.JobStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.JobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.JobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.JobStatus left, Azure.ResourceManager.ArcData.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.JobStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.JobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.JobStatus left, Azure.ResourceManager.ArcData.Models.JobStatus right) { throw null; }
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
        public int? Forceencryption { get { throw null; } set { } }
        public string Tlsciphers { get { throw null; } set { } }
        public string Tlsprotocols { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LastExecutionStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.LastExecutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LastExecutionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.LastExecutionStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.LastExecutionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.LastExecutionStatus Faulted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.LastExecutionStatus Postponed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.LastExecutionStatus Rescheduled { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.LastExecutionStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.LastExecutionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.LastExecutionStatus left, Azure.ResourceManager.ArcData.Models.LastExecutionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.LastExecutionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.LastExecutionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.LastExecutionStatus left, Azure.ResourceManager.ArcData.Models.LastExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseCategory : System.IEquatable<Azure.ResourceManager.ArcData.Models.LicenseCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseCategory(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.LicenseCategory Core { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.LicenseCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.LicenseCategory left, Azure.ResourceManager.ArcData.Models.LicenseCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.LicenseCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.LicenseCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.LicenseCategory left, Azure.ResourceManager.ArcData.Models.LicenseCategory right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ManagedInstanceLinkCreateUpdateConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration>
    {
        public ManagedInstanceLinkCreateUpdateConfiguration() { }
        public Azure.ResourceManager.ArcData.Models.AvailabilityGroupCreateUpdateConfiguration AvailabilityGroup { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DistributedAvailabilityGroupCreateUpdateConfiguration DistributedAvailabilityGroup { get { throw null; } set { } }
        public string MiLinkInstanceAvailabilityGroupName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.ManagedInstanceLinkCreateUpdateConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.MigrationAssessment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.MigrationAssessment>
    {
        public MigrationAssessment() { }
        public System.DateTimeOffset? AssessmentUploadOn { get { throw null; } }
        public System.DateTimeOffset? AssessmentViewedOn { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ImpactedObjectsSuitabilitySummary ImpactedObjectsSummary { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.CostOptionSelectedValues CostOptions { get { throw null; } set { } }
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
        public static Azure.ResourceManager.ArcData.Models.MigrationMode MILink { get { throw null; } }
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
    public partial class OnPremiseProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.OnPremiseProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.OnPremiseProperty>
    {
        public OnPremiseProperty(string id, string publicSigningKey) { }
        public string Id { get { throw null; } set { } }
        public string PublicSigningKey { get { throw null; } set { } }
        public string SigningCertificateThumbprint { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.OnPremiseProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.OnPremiseProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.OnPremiseProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.OnPremiseProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.OnPremiseProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.OnPremiseProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.OnPremiseProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.OnPremiseProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.OnPremiseProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.ArcData.Models.BasicLoginInformation BasicLoginInformation { get { throw null; } set { } }
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
    public partial class PostgresInstanceSku : Azure.ResourceManager.ArcData.Models.CommonSku, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.PostgresInstanceSku>
    {
        public PostgresInstanceSku(string name) : base (default(string)) { }
        public Azure.ResourceManager.ArcData.Models.PostgresInstanceSkuTier? Tier { get { throw null; } set { } }
        protected override Azure.ResourceManager.ArcData.Models.CommonSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ArcData.Models.CommonSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        ALL = 0,
        ReadWrite = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ArcData.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ProvisioningState left, Azure.ResourceManager.ArcData.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ProvisioningState left, Azure.ResourceManager.ArcData.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationStatus : System.IEquatable<Azure.ResourceManager.ArcData.Models.RecommendationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.RecommendationStatus NotReady { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.RecommendationStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.RecommendationStatus ReadyWithConditions { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.RecommendationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.RecommendationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.RecommendationStatus left, Azure.ResourceManager.ArcData.Models.RecommendationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.RecommendationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.RecommendationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.RecommendationStatus left, Azure.ResourceManager.ArcData.Models.RecommendationStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceUpdateMode : System.IEquatable<Azure.ResourceManager.ArcData.Models.ResourceUpdateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceUpdateMode(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ResourceUpdateMode SkipResourceUpdate { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ResourceUpdateMode UpdateAllTargetRecommendationDetails { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ResourceUpdateMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ResourceUpdateMode left, Azure.ResourceManager.ArcData.Models.ResourceUpdateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ResourceUpdateMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ResourceUpdateMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ResourceUpdateMode left, Azure.ResourceManager.ArcData.Models.ResourceUpdateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScopeType : System.IEquatable<Azure.ResourceManager.ArcData.Models.ScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScopeType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ScopeType ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ScopeType Subscription { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ScopeType Tenant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ScopeType left, Azure.ResourceManager.ArcData.Models.ScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ScopeType left, Azure.ResourceManager.ArcData.Models.ScopeType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceType : System.IEquatable<Azure.ResourceManager.ArcData.Models.ServiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.ServiceType Engine { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ServiceType Pbirs { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ServiceType Ssas { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ServiceType Ssis { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.ServiceType Ssrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.ServiceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.ServiceType left, Azure.ResourceManager.ArcData.Models.ServiceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ServiceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.ServiceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.ServiceType left, Azure.ResourceManager.ArcData.Models.ServiceType right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.ArcData.Models.RecommendationStatus? RecommendationStatus { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.RecommendationStatus? RecommendationStatus { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.RecommendationStatus? RecommendationStatus { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.ArcData.Models.DiskSizes> TempDBDiskSizes { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.CostTypeValues KeyValue { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.ImpactedObjectsInfo> ImpactedObjectsSummary { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCost MonthlyCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArcData.Models.SkuRecommendationResultsMonthlyCostOptionItem> MonthlyCostOptions { get { throw null; } }
        public int? NumOfBlockerIssues { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.RecommendationStatus? RecommendationStatus { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.BasicLoginInformation BasicLoginInformation { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.BackupPolicy BackupPolicy { get { throw null; } set { } }
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
        public SqlServerEsuLicenseProperties(Azure.ResourceManager.ArcData.Models.BillingPlan billingPlan, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseVersion version, int physicalCores, Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState activationState, Azure.ResourceManager.ArcData.Models.ScopeType scopeType) { }
        public System.DateTimeOffset? ActivatedOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SqlServerEsuLicenseActivationState ActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BillingPlan BillingPlan { get { throw null; } set { } }
        public int PhysicalCores { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ScopeType ScopeType { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public int? PhysicalCores { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ScopeType? ScopeType { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.BackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.JobStatus? JobStatus { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.BackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.JobStatus? JobStatus { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.AssessmentStatus? Status { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.BackupPolicy BackupPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BestPracticesAssessment BestPracticesAssessment { get { throw null; } set { } }
        public string Collation { get { throw null; } }
        public string ContainerResourceId { get { throw null; } }
        public string Cores { get { throw null; } set { } }
        public string CreateTime { get { throw null; } }
        public string CurrentVersion { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.DbmEndpoint DatabaseMirroringEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DiscoverySource? DiscoverySource { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.EditionType? Edition { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.FailoverCluster FailoverCluster { get { throw null; } set { } }
        public bool? HasDbMasterKey { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.HostType? HostType { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.ServiceType? ServiceType { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ConnectionStatus? Status { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.BackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.JobStatus? JobStatus { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.BackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.JobStatus? JobStatus { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.BackgroundJob BackgroundJob { get { throw null; } }
        public string Id { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string JobException { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.JobStatus? JobStatus { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.JobStatus? JobStatus { get { throw null; } }
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
        public static Azure.ResourceManager.ArcData.Models.SqlServerInstanceTargetRecommendationReportSectionType SqlDBTargetRecommendationPerDatabase { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.JobStatus? JobStatus { get { throw null; } }
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
        public Azure.ResourceManager.ArcData.Models.BackupPolicy BackupPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BestPracticesAssessment BestPracticesAssessment { get { throw null; } set { } }
        public string Collation { get { throw null; } }
        public string ContainerResourceId { get { throw null; } }
        public string Cores { get { throw null; } set { } }
        public string CreateTime { get { throw null; } }
        public string CurrentVersion { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.DbmEndpoint DatabaseMirroringEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.DiscoverySource? DiscoverySource { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.EditionType? Edition { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.FailoverCluster FailoverCluster { get { throw null; } set { } }
        public bool? HasDbMasterKey { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.HostType? HostType { get { throw null; } set { } }
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
        public Azure.ResourceManager.ArcData.Models.ServiceType? ServiceType { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ConnectionStatus? Status { get { throw null; } }
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
        public SqlServerLicenseProperties(Azure.ResourceManager.ArcData.Models.BillingPlan billingPlan, int physicalCores, Azure.ResourceManager.ArcData.Models.LicenseCategory licenseCategory, Azure.ResourceManager.ArcData.Models.ActivationState activationState, Azure.ResourceManager.ArcData.Models.ScopeType scopeType) { }
        public Azure.ResourceManager.ArcData.Models.ActivationState ActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BillingPlan BillingPlan { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivatedOn { get { throw null; } }
        public System.DateTimeOffset? LastDeactivatedOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.LicenseCategory LicenseCategory { get { throw null; } set { } }
        public int PhysicalCores { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ScopeType ScopeType { get { throw null; } set { } }
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
    public partial class SqlServerLicenseUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.SqlServerLicenseUpdateProperties>
    {
        public SqlServerLicenseUpdateProperties() { }
        public Azure.ResourceManager.ArcData.Models.ActivationState? ActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.BillingPlan? BillingPlan { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivatedOn { get { throw null; } }
        public System.DateTimeOffset? LastDeactivatedOn { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.LicenseCategory? LicenseCategory { get { throw null; } set { } }
        public int? PhysicalCores { get { throw null; } set { } }
        public Azure.ResourceManager.ArcData.Models.ScopeType? ScopeType { get { throw null; } set { } }
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
    public partial class TargetReadiness : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.TargetReadiness>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.TargetReadiness>
    {
        internal TargetReadiness() { }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary AzureSqlDatabase { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary AzureSqlManagedInstance { get { throw null; } }
        public Azure.ResourceManager.ArcData.Models.SkuRecommendationSummary AzureSqlVirtualMachine { get { throw null; } }
        protected virtual Azure.ResourceManager.ArcData.Models.TargetReadiness JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.TargetReadiness PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.TargetReadiness System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.TargetReadiness>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.TargetReadiness>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.TargetReadiness System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.TargetReadiness>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.TargetReadiness>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.TargetReadiness>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetType : System.IEquatable<Azure.ResourceManager.ArcData.Models.TargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetType(string value) { throw null; }
        public static Azure.ResourceManager.ArcData.Models.TargetType AzureSqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.TargetType AzureSqlManagedInstance { get { throw null; } }
        public static Azure.ResourceManager.ArcData.Models.TargetType AzureSqlVirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArcData.Models.TargetType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArcData.Models.TargetType left, Azure.ResourceManager.ArcData.Models.TargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.TargetType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArcData.Models.TargetType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArcData.Models.TargetType left, Azure.ResourceManager.ArcData.Models.TargetType right) { throw null; }
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
    public partial class UploadWatermark : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.UploadWatermark>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.UploadWatermark>
    {
        public UploadWatermark() { }
        public System.DateTimeOffset? Logs { get { throw null; } set { } }
        public System.DateTimeOffset? Metrics { get { throw null; } set { } }
        public System.DateTimeOffset? Usages { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ArcData.Models.UploadWatermark JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArcData.Models.UploadWatermark PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArcData.Models.UploadWatermark System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.UploadWatermark>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArcData.Models.UploadWatermark>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArcData.Models.UploadWatermark System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.UploadWatermark>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.UploadWatermark>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArcData.Models.UploadWatermark>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
