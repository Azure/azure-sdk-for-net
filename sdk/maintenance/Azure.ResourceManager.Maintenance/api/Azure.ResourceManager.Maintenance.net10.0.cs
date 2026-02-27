namespace Azure.ResourceManager.Maintenance
{
    public partial class ApplyUpdateCollection : Azure.ResourceManager.ArmCollection
    {
        protected ApplyUpdateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.ApplyUpdateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applyUpdateName, Azure.ResourceManager.Maintenance.ApplyUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applyUpdateName, Azure.ResourceManager.Maintenance.ApplyUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource> Get(string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> GetAsync(string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetIfExists(string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> GetIfExistsAsync(string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplyUpdateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>
    {
        public ApplyUpdateData() { }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.UpdateStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.ApplyUpdateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.ApplyUpdateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplyUpdateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplyUpdateResource() { }
        public virtual Azure.ResourceManager.Maintenance.ApplyUpdateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource> Get(string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> GetAsync(string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Maintenance.ApplyUpdateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.ApplyUpdateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.ApplyUpdateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.ApplyUpdateResource> Update(Azure.WaitUntil waitUntil, string applyUpdateName, Azure.ResourceManager.Maintenance.ApplyUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> UpdateAsync(Azure.WaitUntil waitUntil, string applyUpdateName, Azure.ResourceManager.Maintenance.ApplyUpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerMaintenanceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMaintenanceContext() { }
        public static Azure.ResourceManager.Maintenance.AzureResourceManagerMaintenanceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConfigurationAssignmentCollection : Azure.ResourceManager.ArmCollection
    {
        protected ConfigurationAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationAssignmentName, Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationAssignmentName, Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> Get(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource>> GetAsync(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetIfExists(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource>> GetIfExistsAsync(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationAssignmentResource() { }
        public virtual Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceConfigurationAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>
    {
        public MaintenanceConfigurationAssignmentData() { }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter Filter { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MaintenanceConfigurationId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceConfigurationCollection : Azure.ResourceManager.ArmCollection
    {
        protected MaintenanceConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceConfigurationResource() { }
        public virtual Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> Update(Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> UpdateAsync(Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MaintenanceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult> Acknowledge(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string resourceType, string resourceName, string scheduledEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult>> AcknowledgeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string resourceType, string resourceName, string scheduledEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource> CreateOrUpdate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource> CreateOrUpdateApplyUpdateByParent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> CreateOrUpdateApplyUpdateByParentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> CreateOrUpdateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetAll(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetAll(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetAllAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetAllAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetApplyUpdate(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> GetApplyUpdateAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.ApplyUpdateResource GetApplyUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maintenance.ApplyUpdateCollection GetApplyUpdates(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetApplyUpdates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetApplyUpdatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource>> GetConfigurationAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource GetConfigurationAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maintenance.ConfigurationAssignmentCollection GetConfigurationAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignmentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfiguration(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetMaintenanceConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetMaintenanceConfigurationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceConfigurationCollection GetMaintenanceConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceConfigurationCollection GetMaintenanceConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfigurationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.Models.Update> GetUpdates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.Models.Update> GetUpdatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.Models.Update> GetUpdatesByParent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.Models.Update> GetUpdatesByParentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenancePublicConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>
    {
        public MaintenancePublicConfigurationData() { }
        public string Duration { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExtensionProperties { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration InstallPatches { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceScope? MaintenanceScope { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string RecurEvery { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility? Visibility { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Maintenance.Mocking
{
    public partial class MockableMaintenanceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMaintenanceArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetApplyUpdate(Azure.Core.ResourceIdentifier scope, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> GetApplyUpdateAsync(Azure.Core.ResourceIdentifier scope, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Maintenance.ApplyUpdateResource GetApplyUpdateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Maintenance.ApplyUpdateCollection GetApplyUpdates(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignment(Azure.Core.ResourceIdentifier scope, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource>> GetConfigurationAssignmentAsync(Azure.Core.ResourceIdentifier scope, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource GetConfigurationAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Maintenance.ConfigurationAssignmentCollection GetConfigurationAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource GetMaintenanceConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMaintenanceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMaintenanceResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignments(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignmentsAsync(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfiguration(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetMaintenanceConfigurationAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Maintenance.MaintenanceConfigurationCollection GetMaintenanceConfigurations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableMaintenanceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMaintenanceSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult> Acknowledge(string resourceGroupName, string resourceType, string resourceName, string scheduledEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult>> AcknowledgeAsync(string resourceGroupName, string resourceType, string resourceName, string scheduledEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource> CreateOrUpdate(string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource> CreateOrUpdateApplyUpdateByParent(string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> CreateOrUpdateApplyUpdateByParentAsync(string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.ApplyUpdateResource>> CreateOrUpdateAsync(string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetAll(string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetAllAsync(string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetApplyUpdates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ApplyUpdateResource> GetApplyUpdatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignments(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.ConfigurationAssignmentResource> GetConfigurationAssignmentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfiguration(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetMaintenanceConfigurationAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Maintenance.MaintenanceConfigurationCollection GetMaintenanceConfigurations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.Models.Update> GetUpdates(string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.Models.Update> GetUpdatesAsync(string resourceGroupName, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.Models.Update> GetUpdatesByParent(string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.Models.Update> GetUpdatesByParentAsync(string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Maintenance.Models
{
    public static partial class ArmMaintenanceModelFactory
    {
        public static Azure.ResourceManager.Maintenance.ApplyUpdateData ApplyUpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Maintenance.Models.UpdateStatus? status = default(Azure.ResourceManager.Maintenance.Models.UpdateStatus?), Azure.Core.ResourceIdentifier resourceId = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceConfigurationAssignmentData MaintenanceConfigurationAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier maintenanceConfigurationId = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter filter = null, string location = null) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter MaintenanceConfigurationAssignmentFilter(Azure.Core.ResourceType? resourceTypes = default(Azure.Core.ResourceType?), System.Collections.Generic.IEnumerable<string> resourceGroups = null, System.Collections.Generic.IEnumerable<string> osTypes = null, Azure.Core.AzureLocation? locations = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Maintenance.Models.VmTagSettings tagSettings = null) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings MaintenanceLinuxPatchSettings(System.Collections.Generic.IEnumerable<string> packageNameMasksToExclude = null, System.Collections.Generic.IEnumerable<string> packageNameMasksToInclude = null, System.Collections.Generic.IEnumerable<string> classificationsToInclude = null) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationData MaintenancePublicConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string @namespace = null, System.Collections.Generic.IDictionary<string, string> extensionProperties = null, Azure.ResourceManager.Maintenance.Models.MaintenanceScope? maintenanceScope = default(Azure.ResourceManager.Maintenance.Models.MaintenanceScope?), Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility? visibility = default(Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility?), Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration installPatches = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string duration = null, string timeZone = null, string recurEvery = null, string location = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings MaintenanceWindowsPatchSettings(System.Collections.Generic.IEnumerable<string> kbNumbersToExclude = null, System.Collections.Generic.IEnumerable<string> kbNumbersToInclude = null, System.Collections.Generic.IEnumerable<string> classificationsToInclude = null, bool? isExcludeKbsRebootRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult ScheduledEventApproveResult(string value = null) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.Update Update(Azure.ResourceManager.Maintenance.Models.MaintenanceScope? maintenanceScope = default(Azure.ResourceManager.Maintenance.Models.MaintenanceScope?), Azure.ResourceManager.Maintenance.Models.ImpactType? impactType = default(Azure.ResourceManager.Maintenance.Models.ImpactType?), Azure.ResourceManager.Maintenance.Models.UpdateStatus? status = default(Azure.ResourceManager.Maintenance.Models.UpdateStatus?), int? impactDurationInSec = default(int?), System.DateTimeOffset? notBefore = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.VmTagSettings VmTagSettings(System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> tags = null, Azure.ResourceManager.Maintenance.Models.VmTagOperator? filterOperator = default(Azure.ResourceManager.Maintenance.Models.VmTagOperator?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpactType : System.IEquatable<Azure.ResourceManager.Maintenance.Models.ImpactType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpactType(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.ImpactType Freeze { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.ImpactType None { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.ImpactType Redeploy { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.ImpactType Restart { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.ImpactType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.ImpactType left, Azure.ResourceManager.Maintenance.Models.ImpactType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.ImpactType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.ImpactType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.ImpactType left, Azure.ResourceManager.Maintenance.Models.ImpactType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceConfigurationAssignmentFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter>
    {
        public MaintenanceConfigurationAssignmentFilter() { }
        public Azure.Core.AzureLocation? Locations { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OsTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceGroups { get { throw null; } }
        public Azure.Core.ResourceType? ResourceTypes { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.VmTagSettings TagSettings { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceConfigurationVisibility : System.IEquatable<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceConfigurationVisibility(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility Custom { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility left, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility left, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceLinuxPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings>
    {
        public MaintenanceLinuxPatchSettings() { }
        public System.Collections.Generic.IList<string> ClassificationsToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToInclude { get { throw null; } }
        protected virtual Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenancePatchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration>
    {
        public MaintenancePatchConfiguration() { }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceLinuxPatchSettings LinuxParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.RebootOptions? RebootSetting { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings WindowsParameters { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenancePatchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceScope : System.IEquatable<Azure.ResourceManager.Maintenance.Models.MaintenanceScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceScope(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope Extension { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope Host { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope InGuestPatch { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope OSImage { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope Resource { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope SQLDB { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope SQLManagedInstance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.MaintenanceScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.MaintenanceScope left, Azure.ResourceManager.Maintenance.Models.MaintenanceScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.MaintenanceScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.MaintenanceScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.MaintenanceScope left, Azure.ResourceManager.Maintenance.Models.MaintenanceScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceWindowsPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings>
    {
        public MaintenanceWindowsPatchSettings() { }
        public System.Collections.Generic.IList<string> ClassificationsToInclude { get { throw null; } }
        public bool? IsExcludeKbsRebootRequired { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KbNumbersToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> KbNumbersToInclude { get { throw null; } }
        protected virtual Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.MaintenanceWindowsPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RebootOptions : System.IEquatable<Azure.ResourceManager.Maintenance.Models.RebootOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RebootOptions(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.RebootOptions Always { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.RebootOptions IfRequired { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.RebootOptions Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.RebootOptions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.RebootOptions left, Azure.ResourceManager.Maintenance.Models.RebootOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.RebootOptions (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.RebootOptions? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.RebootOptions left, Azure.ResourceManager.Maintenance.Models.RebootOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledEventApproveResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult>
    {
        internal ScheduledEventApproveResult() { }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.ScheduledEventApproveResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Update : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.Update>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.Update>
    {
        internal Update() { }
        public int? ImpactDurationInSec { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.ImpactType? ImpactType { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceScope? MaintenanceScope { get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.UpdateStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Maintenance.Models.Update JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maintenance.Models.Update PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.Models.Update System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.Update>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.Update>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.Models.Update System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.Update>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.Update>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.Update>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateStatus : System.IEquatable<Azure.ResourceManager.Maintenance.Models.UpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.UpdateStatus Cancel { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.UpdateStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.UpdateStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.UpdateStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.UpdateStatus NoUpdatesPending { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.UpdateStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.UpdateStatus RetryLater { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.UpdateStatus RetryNow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.UpdateStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.UpdateStatus left, Azure.ResourceManager.Maintenance.Models.UpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.UpdateStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.UpdateStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.UpdateStatus left, Azure.ResourceManager.Maintenance.Models.UpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum VmTagOperator
    {
        All = 0,
        Any = 1,
    }
    public partial class VmTagSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.VmTagSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.VmTagSettings>
    {
        public VmTagSettings() { }
        public Azure.ResourceManager.Maintenance.Models.VmTagOperator? FilterOperator { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Maintenance.Models.VmTagSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maintenance.Models.VmTagSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maintenance.Models.VmTagSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.VmTagSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maintenance.Models.VmTagSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maintenance.Models.VmTagSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.VmTagSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.VmTagSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maintenance.Models.VmTagSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
