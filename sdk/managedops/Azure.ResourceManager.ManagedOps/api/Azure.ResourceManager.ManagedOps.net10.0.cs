namespace Azure.ResourceManager.ManagedOps
{
    public partial class AzureResourceManagerManagedOpsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerManagedOpsContext() { }
        public static Azure.ResourceManager.ManagedOps.AzureResourceManagerManagedOpsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ManagedOpCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedOps.ManagedOpResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedOps.ManagedOpResource>, System.Collections.IEnumerable
    {
        protected ManagedOpCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedOps.ManagedOpResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedOpsName, Azure.ResourceManager.ManagedOps.ManagedOpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedOps.ManagedOpResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedOpsName, Azure.ResourceManager.ManagedOps.ManagedOpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedOps.ManagedOpResource> Get(string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedOps.ManagedOpResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedOps.ManagedOpResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedOps.ManagedOpResource>> GetAsync(string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedOps.ManagedOpResource> GetIfExists(string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedOps.ManagedOpResource>> GetIfExistsAsync(string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedOps.ManagedOpResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedOps.ManagedOpResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedOps.ManagedOpResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedOps.ManagedOpResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedOpData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.ManagedOpData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.ManagedOpData>
    {
        public ManagedOpData() { }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedOps.ManagedOpData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.ManagedOpData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedOpResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.ManagedOpData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.ManagedOpData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedOpResource() { }
        public virtual Azure.ResourceManager.ManagedOps.ManagedOpData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string managedOpsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedOps.ManagedOpResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedOps.ManagedOpResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedOps.ManagedOpData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.ManagedOpData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.ManagedOpData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedOps.ManagedOpResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedOps.ManagedOpResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ManagedOpsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ManagedOps.ManagedOpResource> GetManagedOp(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedOps.ManagedOpResource>> GetManagedOpAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedOps.ManagedOpResource GetManagedOpResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedOps.ManagedOpCollection GetManagedOps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedOps.Mocking
{
    public partial class MockableManagedOpsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedOpsArmClient() { }
        public virtual Azure.ResourceManager.ManagedOps.ManagedOpResource GetManagedOpResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableManagedOpsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedOpsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ManagedOps.ManagedOpResource> GetManagedOp(string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedOps.ManagedOpResource>> GetManagedOpAsync(string managedOpsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedOps.ManagedOpCollection GetManagedOps() { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedOps.Models
{
    public static partial class ArmManagedOpsModelFactory
    {
        public static Azure.ResourceManager.ManagedOps.ManagedOpData ManagedOpData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation ManagedOpsAzureMonitorInformation(Azure.Core.ResourceIdentifier dcrId = null, Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus enablementStatus = default(Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus)) { throw null; }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation ManagedOpsChangeTrackingInformation(Azure.Core.ResourceIdentifier dcrId = null, Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus enablementStatus = default(Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus)) { throw null; }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties ManagedOpsProperties(Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku sku = null, Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState?), Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration desiredConfiguration = null, Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation services = null, Azure.Core.ResourceIdentifier policyInitiativeAssignmentId = null) { throw null; }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation ManagedOpsServiceInformation(Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation changeTrackingAndInventory = null, Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation azureMonitorInsights = null, Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus? azureUpdateManagerEnablementStatus = default(Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus?), Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus? azurePolicyAndMachineEnablementStatus = default(Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus?), Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus? defenderForServersEnablementStatus = default(Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus?), Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus? defenderCspmEnablementStatus = default(Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus?)) { throw null; }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku ManagedOpsSku(string name = null, string tier = null) { throw null; }
    }
    public partial class ManagedOpPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch>
    {
        public ManagedOpPatch() { }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate ManagedOpUpdateDesiredConfiguration { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedOpsAzureMonitorInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation>
    {
        internal ManagedOpsAzureMonitorInformation() { }
        public Azure.Core.ResourceIdentifier DcrId { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus EnablementStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedOpsChangeTrackingInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation>
    {
        internal ManagedOpsChangeTrackingInformation() { }
        public Azure.Core.ResourceIdentifier DcrId { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus EnablementStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedOpsDesiredConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration>
    {
        public ManagedOpsDesiredConfiguration(Azure.Core.ResourceIdentifier changeTrackingAndInventoryLogAnalyticsWorkspaceId, Azure.Core.ResourceIdentifier azureMonitorWorkspaceId, Azure.Core.ResourceIdentifier userAssignedManagedIdentityId) { }
        public Azure.Core.ResourceIdentifier AzureMonitorWorkspaceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ChangeTrackingAndInventoryLogAnalyticsWorkspaceId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState? DefenderCspm { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState? DefenderForServers { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedManagedIdentityId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedOpsDesiredConfigurationUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate>
    {
        public ManagedOpsDesiredConfigurationUpdate() { }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState? DefenderCspm { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState? DefenderForServers { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfigurationUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedOpsDesiredEnablementState : System.IEquatable<Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedOpsDesiredEnablementState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState Disable { get { throw null; } }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState left, Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState left, Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredEnablementState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedOpsEnablementStatus : System.IEquatable<Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedOpsEnablementStatus(string value) { throw null; }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus left, Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus left, Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedOpsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties>
    {
        public ManagedOpsProperties(Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration desiredConfiguration) { }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsDesiredConfiguration DesiredConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyInitiativeAssignmentId { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation Services { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku Sku { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedOpsProvisioningState : System.IEquatable<Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedOpsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState left, Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState left, Azure.ResourceManager.ManagedOps.Models.ManagedOpsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedOpsServiceInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation>
    {
        internal ManagedOpsServiceInformation() { }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsAzureMonitorInformation AzureMonitorInsights { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus? AzurePolicyAndMachineEnablementStatus { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus? AzureUpdateManagerEnablementStatus { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsChangeTrackingInformation ChangeTrackingAndInventory { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus? DefenderCspmEnablementStatus { get { throw null; } }
        public Azure.ResourceManager.ManagedOps.Models.ManagedOpsEnablementStatus? DefenderForServersEnablementStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsServiceInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedOpsSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku>
    {
        internal ManagedOpsSku() { }
        public string Name { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedOps.Models.ManagedOpsSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
