namespace Azure.ResourceManager.Migrate
{
    public partial class AzureResourceManagerMigrateContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMigrateContext() { }
        public static Azure.ResourceManager.Migrate.AzureResourceManagerMigrateContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MigrateExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult> CreateWavesFromPlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult>> CreateWavesFromPlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult> GenerateWavePlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult>> GenerateWavePlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migrate.MigrateTaskResource> GetMigrateTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateTaskResource>> GetMigrateTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateTaskResource GetMigrateTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateTaskCollection GetMigrateTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult> GetMigrateTaskSummary(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult>> GetMigrateTaskSummaryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migrate.MigrateWaveResource> GetMigrateWave(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateWaveResource>> GetMigrateWaveAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult> GetMigrateWavePlanSasUri(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult>> GetMigrateWavePlanSasUriAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateWaveResource GetMigrateWaveResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateWaveCollection GetMigrateWaves(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrationEntityCollection GetMigrationEntities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityResource> GetMigrationEntity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityResource>> GetMigrationEntityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> GetMigrationEntityGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>> GetMigrationEntityGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrationEntityGroupResource GetMigrationEntityGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrationEntityGroupCollection GetMigrationEntityGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrationEntityResource GetMigrationEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migrate.Models.GetWavePlansResult> GetWavePlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, Azure.ResourceManager.Migrate.Models.GetWavePlansContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.GetWavePlansResult>> GetWavePlansAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, Azure.ResourceManager.Migrate.Models.GetWavePlansContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult> ImportWavePlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.ImportWavePlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult>> ImportWavePlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.ImportWavePlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult> RefreshMigrationEntities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult>> RefreshMigrationEntitiesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateTaskResource>, System.Collections.IEnumerable
    {
        protected MigrateTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.Migrate.MigrateTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.Migrate.MigrateTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateTaskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateTaskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateTaskResource> GetIfExists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateTaskResource>> GetIfExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateTaskData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateTaskData>
    {
        public MigrateTaskData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateTaskProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.MigrateTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateTaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateTaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateTaskResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migrate.MigrateTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateTaskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateTaskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateWaveCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateWaveResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateWaveResource>, System.Collections.IEnumerable
    {
        protected MigrateWaveCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateWaveResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string waveName, Azure.ResourceManager.Migrate.MigrateWaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateWaveResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string waveName, Azure.ResourceManager.Migrate.MigrateWaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateWaveResource> Get(string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateWaveResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateWaveResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateWaveResource>> GetAsync(string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateWaveResource> GetIfExists(string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateWaveResource>> GetIfExistsAsync(string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateWaveResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateWaveResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateWaveResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateWaveResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateWaveData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateWaveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateWaveData>
    {
        public MigrateWaveData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateWaveProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.MigrateWaveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateWaveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateWaveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateWaveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateWaveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateWaveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateWaveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateWaveResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateWaveData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateWaveData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateWaveResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateWaveData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string waveName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateWaveResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateWaveResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migrate.MigrateWaveData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateWaveData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateWaveData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateWaveData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateWaveData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateWaveData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateWaveData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateWaveProperties> TriggerRefresh(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateWaveProperties>> TriggerRefreshAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateWaveResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateWaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateWaveResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateWaveData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrationEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrationEntityResource>, System.Collections.IEnumerable
    {
        protected MigrationEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrationEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string migrationEntityName, Azure.ResourceManager.Migrate.MigrationEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrationEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string migrationEntityName, Azure.ResourceManager.Migrate.MigrationEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityResource> Get(string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrationEntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrationEntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityResource>> GetAsync(string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrationEntityResource> GetIfExists(string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrationEntityResource>> GetIfExistsAsync(string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrationEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrationEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrationEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrationEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityData>
    {
        public MigrationEntityData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrationEntityProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.MigrationEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrationEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationEntityGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>, System.Collections.IEnumerable
    {
        protected MigrationEntityGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string migrationEntityGroupName, Azure.ResourceManager.Migrate.MigrationEntityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string migrationEntityGroupName, Azure.ResourceManager.Migrate.MigrationEntityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> Get(string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>> GetAsync(string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> GetIfExists(string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>> GetIfExistsAsync(string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationEntityGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>
    {
        public MigrationEntityGroupData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.MigrationEntityGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrationEntityGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationEntityGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationEntityGroupResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrationEntityGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string migrationEntityGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migrate.MigrationEntityGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrationEntityGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrationEntityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrationEntityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationEntityResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrationEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string migrationEntityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migrate.MigrationEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrationEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrationEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrationEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrationEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrationEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrationEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrationEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Migrate.Mocking
{
    public partial class MockableMigrateArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrateArmClient() { }
        public virtual Azure.ResourceManager.Migrate.MigrateTaskResource GetMigrateTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateWaveResource GetMigrateWaveResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrationEntityGroupResource GetMigrationEntityGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrationEntityResource GetMigrationEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMigrateResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrateResourceGroupResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult> CreateWavesFromPlan(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult>> CreateWavesFromPlanAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult> GenerateWavePlan(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult>> GenerateWavePlanAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateTaskResource> GetMigrateTask(string projectName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateTaskResource>> GetMigrateTaskAsync(string projectName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateTaskCollection GetMigrateTasks(string projectName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult> GetMigrateTaskSummary(string projectName, Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult>> GetMigrateTaskSummaryAsync(string projectName, Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateWaveResource> GetMigrateWave(string projectName, string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateWaveResource>> GetMigrateWaveAsync(string projectName, string waveName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult> GetMigrateWavePlanSasUri(string projectName, Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult>> GetMigrateWavePlanSasUriAsync(string projectName, Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateWaveCollection GetMigrateWaves(string projectName) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrationEntityCollection GetMigrationEntities(string projectName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityResource> GetMigrationEntity(string projectName, string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityResource>> GetMigrationEntityAsync(string projectName, string migrationEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityGroupResource> GetMigrationEntityGroup(string projectName, string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrationEntityGroupResource>> GetMigrationEntityGroupAsync(string projectName, string migrationEntityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrationEntityGroupCollection GetMigrationEntityGroups(string projectName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.Models.GetWavePlansResult> GetWavePlans(string projectName, Azure.ResourceManager.Migrate.Models.GetWavePlansContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.GetWavePlansResult>> GetWavePlansAsync(string projectName, Azure.ResourceManager.Migrate.Models.GetWavePlansContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult> ImportWavePlan(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.ImportWavePlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult>> ImportWavePlanAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.ImportWavePlanContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult> RefreshMigrationEntities(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult>> RefreshMigrationEntitiesAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Migrate.Models
{
    public static partial class ArmMigrateModelFactory
    {
        public static Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent CreateWavesFromPlanContent(Azure.Core.ResourceIdentifier assessmentArmId = null, string migrationPath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem> waveSelection = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult CreateWavesFromPlanResult(int totalWaves = 0, int succeededWaves = 0, int failedWaves = 0, int skippedWaves = 0, System.Uri sasUri = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent GenerateWavePlanContent(Azure.Core.ResourceIdentifier assessmentArmId = null, string migrationPath = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult GenerateWavePlanResult(string wavePlanName = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState), Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource planSource = default(Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource), Azure.Core.ResourceIdentifier assessmentArmId = null, string migrationPath = null, Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties artifactProperties = null, Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary summary = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.GetWavePlansContent GetWavePlansContent(Azure.Core.ResourceIdentifier assessmentArmId = null, string migrationPath = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.GetWavePlansResult GetWavePlansResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem> value = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ImportWavePlanContent ImportWavePlanContent(Azure.Core.ResourceIdentifier assessmentArmId = null, string migrationPath = null, string sasVersionId = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ImportWavePlanResult ImportWavePlanResult(string wavePlanName = null, Azure.Core.ResourceIdentifier assessmentArmId = null, string migrationPath = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState), Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource planSource = default(Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource), Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties artifactProperties = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateTaskData MigrateTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateTaskProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskProperties MigrateTaskProperties(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), Azure.Core.ResourceIdentifier scopeId = null, string stage = null, Azure.ResourceManager.Migrate.Models.MigrateTaskType taskType = default(Azure.ResourceManager.Migrate.Models.MigrateTaskType), string displayName = null, bool isEditable = false, string status = null, Azure.ResourceManager.Migrate.Models.MigrateTaskScope scope = default(Azure.ResourceManager.Migrate.Models.MigrateTaskScope), string description = null, System.DateTimeOffset? completionOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount MigrateTaskStatusCount(string status = null, int count = 0) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent MigrateTaskSummaryContent(Azure.Core.ResourceIdentifier scopeId = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem MigrateTaskSummaryItem(string stage = null, string aggregatedStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount> statusCounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateTaskData> tasks = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult MigrateTaskSummaryResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem> items = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateWaveData MigrateWaveData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateWaveProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties MigrateWavePlanArtifactProperties(Azure.Core.ResourceIdentifier artifactId = null, string versionId = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem MigrateWavePlanListItem(string wavePlanName = null, Azure.Core.ResourceIdentifier assessmentArmId = null, string migrationPath = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState), Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource planSource = default(Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource), Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties artifactProperties = null, Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary summary = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent MigrateWavePlanSasUriContent(Azure.Core.ResourceIdentifier assessmentArmId = null, string migrationPath = null, string sasVersionId = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult MigrateWavePlanSasUriResult(System.Uri sasUri = null, System.DateTimeOffset expiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary MigrateWavePlanSummary(int numberOfWaves = 0, string risk = null, string confidence = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateWaveProperties MigrateWaveProperties(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), string description = null, string displayName = null, string argQuery = null, string status = null, System.DateTimeOffset plannedStartsOn = default(System.DateTimeOffset), System.DateTimeOffset? plannedCompletionOn = default(System.DateTimeOffset?), System.DateTimeOffset? actualStartsOn = default(System.DateTimeOffset?), string stage = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem MigrateWaveSelectionItem(string waveName = null, string waveDisplayName = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrationEntityData MigrationEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrationEntityProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrationEntityGroupData MigrationEntityGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties MigrationEntityGroupProperties(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), string applicationId = null, string applicationDisplayName = null, Azure.Core.ResourceIdentifier associatedAssessmentId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedWaveIds = null, string executionStatus = null, System.DateTimeOffset? executionStartsOn = default(System.DateTimeOffset?), string migrationPath = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrationEntityProperties MigrationEntityProperties(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), Azure.Core.ResourceIdentifier partnerResourceArmId = null, Azure.Core.ResourceIdentifier targetAzureResourceArmId = null, Azure.Core.ResourceIdentifier associatedInventoryResourceId = null, string inventoryDisplayName = null, Azure.Core.ResourceIdentifier associatedAssessmentId = null, Azure.Core.ResourceIdentifier associatedWaveId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedMigrationEntityGroupIds = null, System.DateTimeOffset? executionStartsOn = default(System.DateTimeOffset?), string target = null, Azure.ResourceManager.Migrate.Models.MigrationStrategy? migrationStrategy = default(Azure.ResourceManager.Migrate.Models.MigrationStrategy?), string executionStage = null, string executionStatus = null, string executionReadiness = null, Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties migrationSpecificProperties = null, string migrationTool = null, string migrationPath = null, Azure.Core.ResourceIdentifier assessedEntityArmId = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties MigrationSpecificProperties(string instanceType = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent RefreshMigrationEntitiesContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> migrationEntityIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> migrationEntityGroupIds = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult RefreshMigrationEntitiesResult(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> migrationEntityIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> migrationEntityGroupIds = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties ServerMigrationSpecificProperties(Azure.Core.ResourceIdentifier drApplianceInventoryId = null, Azure.Core.ResourceIdentifier currentJobId = null) { throw null; }
    }
    public partial class CreateWavesFromPlanContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent>
    {
        public CreateWavesFromPlanContent(Azure.Core.ResourceIdentifier assessmentArmId, string migrationPath) { }
        public Azure.Core.ResourceIdentifier AssessmentArmId { get { throw null; } }
        public string MigrationPath { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem> WaveSelection { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateWavesFromPlanResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult>
    {
        internal CreateWavesFromPlanResult() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public int FailedWaves { get { throw null; } }
        public System.Uri SasUri { get { throw null; } }
        public int SkippedWaves { get { throw null; } }
        public int SucceededWaves { get { throw null; } }
        public int TotalWaves { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CreateWavesFromPlanResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateWavePlanContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent>
    {
        public GenerateWavePlanContent() { }
        public Azure.Core.ResourceIdentifier AssessmentArmId { get { throw null; } set { } }
        public string MigrationPath { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateWavePlanResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult>
    {
        internal GenerateWavePlanResult() { }
        public Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties ArtifactProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier AssessmentArmId { get { throw null; } }
        public string MigrationPath { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource PlanSource { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary Summary { get { throw null; } }
        public string WavePlanName { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GenerateWavePlanResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetWavePlansContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GetWavePlansContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GetWavePlansContent>
    {
        public GetWavePlansContent(Azure.Core.ResourceIdentifier assessmentArmId) { }
        public Azure.Core.ResourceIdentifier AssessmentArmId { get { throw null; } }
        public string MigrationPath { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Migrate.Models.GetWavePlansContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.GetWavePlansContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.GetWavePlansContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GetWavePlansContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GetWavePlansContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.GetWavePlansContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GetWavePlansContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GetWavePlansContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GetWavePlansContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetWavePlansResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GetWavePlansResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GetWavePlansResult>
    {
        internal GetWavePlansResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.GetWavePlansResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.GetWavePlansResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.GetWavePlansResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GetWavePlansResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.GetWavePlansResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.GetWavePlansResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GetWavePlansResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GetWavePlansResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.GetWavePlansResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportWavePlanContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanContent>
    {
        public ImportWavePlanContent(Azure.Core.ResourceIdentifier assessmentArmId, string migrationPath) { }
        public Azure.Core.ResourceIdentifier AssessmentArmId { get { throw null; } }
        public string MigrationPath { get { throw null; } }
        public string SasVersionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Migrate.Models.ImportWavePlanContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.ImportWavePlanContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.ImportWavePlanContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.ImportWavePlanContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportWavePlanResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult>
    {
        internal ImportWavePlanResult() { }
        public Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties ArtifactProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier AssessmentArmId { get { throw null; } }
        public string MigrationPath { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource PlanSource { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState ProvisioningState { get { throw null; } }
        public string WavePlanName { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.ImportWavePlanResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.ImportWavePlanResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.ImportWavePlanResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.ImportWavePlanResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImportWavePlanResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateProvisioningState : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState left, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState left, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateTaskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskProperties>
    {
        public MigrateTaskProperties(Azure.Core.ResourceIdentifier scopeId, string displayName, string status, Azure.ResourceManager.Migrate.Models.MigrateTaskScope scope) { }
        public System.DateTimeOffset? CompletionOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool IsEditable { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateTaskScope Scope { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ScopeId { get { throw null; } set { } }
        public string Stage { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateTaskType TaskType { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateTaskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateTaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateTaskScope : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateTaskScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateTaskScope(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskScope MigrationEntity { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskScope MigrationEntityGroup { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskScope Wave { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateTaskScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateTaskScope left, Azure.ResourceManager.Migrate.Models.MigrateTaskScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateTaskScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateTaskScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateTaskScope left, Azure.ResourceManager.Migrate.Models.MigrateTaskScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateTaskStatusCount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount>
    {
        internal MigrateTaskStatusCount() { }
        public int Count { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateTaskSummaryContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent>
    {
        public MigrateTaskSummaryContent(Azure.Core.ResourceIdentifier scopeId) { }
        public Azure.Core.ResourceIdentifier ScopeId { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateTaskSummaryItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem>
    {
        internal MigrateTaskSummaryItem() { }
        public string AggregatedStatus { get { throw null; } }
        public string Stage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.MigrateTaskStatusCount> StatusCounts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.MigrateTaskData> Tasks { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateTaskSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult>
    {
        internal MigrateTaskSummaryResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryItem> Items { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateTaskSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateTaskType : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateTaskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateTaskType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskType SystemDefined { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateTaskType UserDefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateTaskType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateTaskType left, Azure.ResourceManager.Migrate.Models.MigrateTaskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateTaskType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateTaskType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateTaskType left, Azure.ResourceManager.Migrate.Models.MigrateTaskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateWavePlanArtifactProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties>
    {
        internal MigrateWavePlanArtifactProperties() { }
        public Azure.Core.ResourceIdentifier ArtifactId { get { throw null; } }
        public string VersionId { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateWavePlanListItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem>
    {
        internal MigrateWavePlanListItem() { }
        public Azure.ResourceManager.Migrate.Models.MigrateWavePlanArtifactProperties ArtifactProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier AssessmentArmId { get { throw null; } }
        public string MigrationPath { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource PlanSource { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary Summary { get { throw null; } }
        public string WavePlanName { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanListItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateWavePlanSasUriContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent>
    {
        public MigrateWavePlanSasUriContent(Azure.Core.ResourceIdentifier assessmentArmId, string migrationPath) { }
        public Azure.Core.ResourceIdentifier AssessmentArmId { get { throw null; } }
        public string MigrationPath { get { throw null; } }
        public string SasVersionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateWavePlanSasUriResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult>
    {
        internal MigrateWavePlanSasUriResult() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public System.Uri SasUri { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSasUriResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateWavePlanSource : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateWavePlanSource(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource Imported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource SystemGenerated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource left, Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource left, Azure.ResourceManager.Migrate.Models.MigrateWavePlanSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateWavePlanSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary>
    {
        internal MigrateWavePlanSummary() { }
        public string Confidence { get { throw null; } }
        public int NumberOfWaves { get { throw null; } }
        public string Risk { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWavePlanSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateWaveProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWaveProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWaveProperties>
    {
        public MigrateWaveProperties(string displayName, string argQuery, System.DateTimeOffset plannedStartsOn) { }
        public System.DateTimeOffset? ActualStartsOn { get { throw null; } }
        public string ArgQuery { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? PlannedCompletionOn { get { throw null; } set { } }
        public System.DateTimeOffset PlannedStartsOn { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } }
        public string Stage { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWaveProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWaveProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateWaveProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWaveProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWaveProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateWaveProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWaveProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWaveProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWaveProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateWaveSelectionItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem>
    {
        public MigrateWaveSelectionItem(string waveName) { }
        public string WaveDisplayName { get { throw null; } set { } }
        public string WaveName { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateWaveSelectionItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationEntityGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties>
    {
        public MigrationEntityGroupProperties(string applicationId, string applicationDisplayName) { }
        public string ApplicationDisplayName { get { throw null; } set { } }
        public string ApplicationId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AssociatedAssessmentId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> AssociatedWaveIds { get { throw null; } }
        public System.DateTimeOffset? ExecutionStartsOn { get { throw null; } }
        public string ExecutionStatus { get { throw null; } }
        public string MigrationPath { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationEntityGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationEntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationEntityProperties>
    {
        public MigrationEntityProperties(Azure.Core.ResourceIdentifier associatedInventoryResourceId, string inventoryDisplayName) { }
        public Azure.Core.ResourceIdentifier AssessedEntityArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AssociatedAssessmentId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AssociatedInventoryResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> AssociatedMigrationEntityGroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier AssociatedWaveId { get { throw null; } set { } }
        public string ExecutionReadiness { get { throw null; } }
        public string ExecutionStage { get { throw null; } }
        public System.DateTimeOffset? ExecutionStartsOn { get { throw null; } }
        public string ExecutionStatus { get { throw null; } }
        public string InventoryDisplayName { get { throw null; } set { } }
        public string MigrationPath { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties MigrationSpecificProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrationStrategy? MigrationStrategy { get { throw null; } }
        public string MigrationTool { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PartnerResourceArmId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } }
        public string Target { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureResourceArmId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrationEntityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrationEntityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrationEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrationEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MigrationSpecificProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties>
    {
        internal MigrationSpecificProperties() { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationStrategy : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrationStrategy None { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrationStrategy Rearchitect { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrationStrategy Rebuild { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrationStrategy Refactor { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrationStrategy Rehost { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrationStrategy Replace { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrationStrategy Replatform { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrationStrategy Retain { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrationStrategy Retire { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrationStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrationStrategy left, Azure.ResourceManager.Migrate.Models.MigrationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrationStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrationStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrationStrategy left, Azure.ResourceManager.Migrate.Models.MigrationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RefreshMigrationEntitiesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent>
    {
        public RefreshMigrationEntitiesContent() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MigrationEntityGroupIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MigrationEntityIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RefreshMigrationEntitiesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult>
    {
        internal RefreshMigrationEntitiesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> MigrationEntityGroupIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> MigrationEntityIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.RefreshMigrationEntitiesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerMigrationSpecificProperties : Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties>
    {
        public ServerMigrationSpecificProperties() { }
        public Azure.Core.ResourceIdentifier CurrentJobId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DrApplianceInventoryId { get { throw null; } set { } }
        protected override Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Migrate.Models.MigrationSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ServerMigrationSpecificProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
