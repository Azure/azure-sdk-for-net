namespace Azure.ResourceManager.CloudHealth
{
    public partial class AzureResourceManagerCloudHealthContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCloudHealthContext() { }
        public static Azure.ResourceManager.CloudHealth.AzureResourceManagerCloudHealthContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class CloudHealthExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource> GetHealthModel(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource>> GetHealthModelAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource GetHealthModelAuthenticationSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource GetHealthModelDiscoveryRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelEntityResource GetHealthModelEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource GetHealthModelRelationshipResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelResource GetHealthModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelCollection GetHealthModels(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CloudHealth.HealthModelResource> GetHealthModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.HealthModelResource> GetHealthModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource GetHealthModelSignalDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HealthModelAuthenticationSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>, System.Collections.IEnumerable
    {
        protected HealthModelAuthenticationSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authenticationSettingName, Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authenticationSettingName, Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> Get(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>> GetAsync(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> GetIfExists(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>> GetIfExistsAsync(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthModelAuthenticationSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>
    {
        public HealthModelAuthenticationSettingData() { }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelAuthenticationSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthModelAuthenticationSettingResource() { }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string authenticationSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelResource>, System.Collections.IEnumerable
    {
        protected HealthModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string healthModelName, Azure.ResourceManager.CloudHealth.HealthModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string healthModelName, Azure.ResourceManager.CloudHealth.HealthModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource> Get(string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.HealthModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.HealthModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource>> GetAsync(string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelResource> GetIfExists(string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelResource>> GetIfExistsAsync(string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.HealthModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.HealthModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthModelData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>
    {
        public HealthModelData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? HealthModelProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelDiscoveryRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>, System.Collections.IEnumerable
    {
        protected HealthModelDiscoveryRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string discoveryRuleName, Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string discoveryRuleName, Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> Get(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> GetAll(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> GetAllAsync(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>> GetAsync(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> GetIfExists(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>> GetIfExistsAsync(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthModelDiscoveryRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>
    {
        public HealthModelDiscoveryRuleData() { }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelDiscoveryRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthModelDiscoveryRuleResource() { }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string discoveryRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthModelEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>, System.Collections.IEnumerable
    {
        protected HealthModelEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.CloudHealth.HealthModelEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.CloudHealth.HealthModelEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> Get(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> GetAll(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> GetAllAsync(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>> GetAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> GetIfExists(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>> GetIfExistsAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthModelEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>
    {
        public HealthModelEntityData() { }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthModelEntityResource() { }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation> AddDataAnnotation(Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation>> AddDataAnnotationAsync(Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string entityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult> GetDataAnnotations(Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult>> GetDataAnnotationsAsync(Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult> GetHistory(Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult>> GetHistoryAsync(Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult> GetSignalHistory(Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult>> GetSignalHistoryAsync(Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult> GetSignalRecommendations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult>> GetSignalRecommendationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response IngestHealthReport(Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> IngestHealthReportAsync(Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthModelRelationshipCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>, System.Collections.IEnumerable
    {
        protected HealthModelRelationshipCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relationshipName, Azure.ResourceManager.CloudHealth.HealthModelRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relationshipName, Azure.ResourceManager.CloudHealth.HealthModelRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> Get(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> GetAll(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> GetAllAsync(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>> GetAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> GetIfExists(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>> GetIfExistsAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthModelRelationshipData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>
    {
        public HealthModelRelationshipData() { }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelRelationshipData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelRelationshipData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelRelationshipResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthModelRelationshipResource() { }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelRelationshipData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string relationshipName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelRelationshipData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelRelationshipData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelRelationshipData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthModelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthModelResource() { }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource> GetHealthModelAuthenticationSetting(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource>> GetHealthModelAuthenticationSettingAsync(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingCollection GetHealthModelAuthenticationSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource> GetHealthModelDiscoveryRule(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource>> GetHealthModelDiscoveryRuleAsync(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleCollection GetHealthModelDiscoveryRules() { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelEntityCollection GetHealthModelEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> GetHealthModelEntity(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>> GetHealthModelEntityAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource> GetHealthModelRelationship(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource>> GetHealthModelRelationshipAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelRelationshipCollection GetHealthModelRelationships() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> GetHealthModelSignalDefinition(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>> GetHealthModelSignalDefinitionAsync(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionCollection GetHealthModelSignalDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.Models.HealthModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.Models.HealthModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthModelSignalDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>, System.Collections.IEnumerable
    {
        protected HealthModelSignalDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string signalDefinitionName, Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string signalDefinitionName, Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> Get(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> GetAll(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> GetAllAsync(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>> GetAsync(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> GetIfExists(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>> GetIfExistsAsync(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthModelSignalDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>
    {
        public HealthModelSignalDefinitionData() { }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelSignalDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthModelSignalDefinitionResource() { }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string signalDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CloudHealth.Mocking
{
    public partial class MockableCloudHealthArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCloudHealthArmClient() { }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingResource GetHealthModelAuthenticationSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleResource GetHealthModelDiscoveryRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelEntityResource GetHealthModelEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelRelationshipResource GetHealthModelRelationshipResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelResource GetHealthModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionResource GetHealthModelSignalDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCloudHealthResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCloudHealthResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource> GetHealthModel(string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource>> GetHealthModelAsync(string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelCollection GetHealthModels() { throw null; }
    }
    public partial class MockableCloudHealthSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCloudHealthSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.HealthModelResource> GetHealthModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.HealthModelResource> GetHealthModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CloudHealth.Models
{
    public partial class ApplicationInsightsTopologySpecification : Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification>
    {
        public ApplicationInsightsTopologySpecification(Azure.Core.ResourceIdentifier applicationInsightsResourceId) { }
        public Azure.Core.ResourceIdentifier ApplicationInsightsResourceId { get { throw null; } set { } }
        protected override Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmCloudHealthModelFactory
    {
        public static Azure.ResourceManager.CloudHealth.Models.ApplicationInsightsTopologySpecification ApplicationInsightsTopologySpecification(Azure.Core.ResourceIdentifier applicationInsightsResourceId = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2 DependenciesSignalGroupV2(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType aggregationType = default(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType), double? degradedThreshold = default(double?), double? unhealthyThreshold = default(double?), Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit? unit = default(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit?), bool? ignoreUnknown = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DiscoveryError DiscoveryError(string message = null, System.Collections.Generic.IEnumerable<string> context = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification DiscoveryRuleSpecification(string kind = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent EntityAddDataAnnotationContent(System.Collections.Generic.IDictionary<string, string> annotationDetails = null, string description = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration EntityAlertConfiguration(Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity severity = default(Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity), string description = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> actionGroupIds = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityAlerts EntityAlerts(Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration unhealthy = null, Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration degraded = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityCoordinates EntityCoordinates(float x = 0f, float y = 0f) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation EntityDataAnnotation(string annotationId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> annotationDetails = null, string description = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent EntityGetDataAnnotationsContent(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), int? top = default(int?), string nextMarker = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult EntityGetDataAnnotationsResult(string entityName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation> annotations = null, string nextMarker = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult EntityGetSignalRecommendationsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration> recommendedSignals = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration> recommendedConfigurations = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent EntityHealthReportContent(string signalName = null, Azure.ResourceManager.CloudHealth.Models.EntityHealthState healthState = default(Azure.ResourceManager.CloudHealth.Models.EntityHealthState), double? value = default(double?), Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule evaluationRules = null, int? expiresInMinutes = default(int?), string additionalContext = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent EntityHistoryContent(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), int? top = default(int?), string nextMarker = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult EntityHistoryResult(string entityName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.HealthStateTransition> history = null, string nextMarker = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityIcon EntityIcon(string iconName = null, string customData = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule EntitySignalEvaluationRule(Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 degradedRule = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 unhealthyRule = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups EntitySignalGroups(Azure.ResourceManager.CloudHealth.Models.ResourceSignals azureResource = null, Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals azureLogAnalytics = null, Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals azureMonitorWorkspace = null, Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2 dependencies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.ExternalSignal> externalSignals = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent EntitySignalHistoryContent(string signalName = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), int? top = default(int?), string nextMarker = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult EntitySignalHistoryResult(string entityName = null, string signalName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint> history = null, string nextMarker = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 EntitySignalThresholdRuleV2(Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator signalOperator = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator), double? threshold = default(double?), Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity? sensitivity = default(Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity?), Azure.ResourceManager.CloudHealth.Models.LookBackWindow? lookBackWindow = default(Azure.ResourceManager.CloudHealth.Models.LookBackWindow?)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ExternalSignal ExternalSignal(string name = null, string signalDefinitionName = null, Azure.ResourceManager.CloudHealth.Models.SignalStatus status = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData HealthModelAuthenticationSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties HealthModelAuthenticationSettingProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string authenticationKind = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelData HealthModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? healthModelProvisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData HealthModelDiscoveryRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties HealthModelDiscoveryRuleProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string authenticationSetting = null, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior discoverRelationships = default(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior), Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior addRecommendedSignals = default(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior), Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification specification = null, Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior? addResourceHealthSignal = default(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior?), Azure.ResourceManager.CloudHealth.Models.DiscoveryError error = null, string entityName = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelEntityData HealthModelEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties HealthModelEntityProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntityCoordinates canvasPosition = null, Azure.ResourceManager.CloudHealth.Models.EntityIcon icon = null, float? healthObjective = default(float?), Azure.ResourceManager.CloudHealth.Models.EntityImpact? impact = default(Azure.ResourceManager.CloudHealth.Models.EntityImpact?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups signalGroups = null, string discoveredBy = null, Azure.ResourceManager.CloudHealth.Models.EntityHealthState? healthState = default(Azure.ResourceManager.CloudHealth.Models.EntityHealthState?), Azure.ResourceManager.CloudHealth.Models.EntityAlerts alerts = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelPatch HealthModelPatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelRelationshipData HealthModelRelationshipData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties HealthModelRelationshipProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string parentEntityName = null, string childEntityName = null, System.Collections.Generic.IDictionary<string, string> tags = null, string discoveredBy = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData HealthModelSignalDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties HealthModelSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string signalKind = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), System.Collections.Generic.IDictionary<string, string> tags = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule HealthReportEvaluationRule(Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 degradedRule = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 unhealthyRule = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthStateTransition HealthStateTransition(Azure.ResourceManager.CloudHealth.Models.EntityHealthState previousState = default(Azure.ResourceManager.CloudHealth.Models.EntityHealthState), Azure.ResourceManager.CloudHealth.Models.EntityHealthState newState = default(Azure.ResourceManager.CloudHealth.Models.EntityHealthState), System.DateTimeOffset occurredOn = default(System.DateTimeOffset), string reason = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties LogAnalyticsQuerySignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), System.Collections.Generic.IDictionary<string, string> tags = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null, string queryText = null, string timeGrain = null, string valueColumnName = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal LogAnalyticsSignal(string name = null, string signalDefinitionName = null, Azure.ResourceManager.CloudHealth.Models.SignalStatus status = null, string queryText = null, string timeGrain = null, string valueColumnName = null, string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals LogAnalyticsSignals(string authenticationSetting = null, Azure.Core.ResourceIdentifier logAnalyticsWorkspaceResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal> signals = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties ManagedIdentityAuthenticationSettingProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string managedIdentityName = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals MonitorWorkspaceSignals(string authenticationSetting = null, Azure.Core.ResourceIdentifier azureMonitorWorkspaceResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal> signals = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal PrometheusMetricsSignal(string name = null, string signalDefinitionName = null, Azure.ResourceManager.CloudHealth.Models.SignalStatus status = null, string queryText = null, string timeGrain = null, string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties PrometheusMetricsSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), System.Collections.Generic.IDictionary<string, string> tags = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null, string queryText = null, string timeGrain = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification ResourceGraphQuerySpecification(string resourceGraphQuery = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal ResourceHealthSignal(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior? enabled = default(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior?), string signalName = null, Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus status = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus ResourceHealthSignalStatus(Azure.ResourceManager.CloudHealth.Models.EntityHealthState? healthState = default(Azure.ResourceManager.CloudHealth.Models.EntityHealthState?), double? value = default(double?), System.DateTimeOffset? reportedOn = default(System.DateTimeOffset?), string error = null, string additionalContext = null, Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState? availabilityState = default(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState?), Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory? category = default(Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory?), string detailedStatus = null, string summary = null, Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType? reasonType = default(Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType?), Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity? reasonChronicity = default(Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity?), System.DateTimeOffset? availabilityReportedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties ResourceMetricSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), System.Collections.Generic.IDictionary<string, string> tags = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null, string metricNamespace = null, string metricName = null, string timeGrain = null, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType aggregationType = default(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType), string dimensionFilter = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceSignal ResourceSignal(string name = null, string signalDefinitionName = null, Azure.ResourceManager.CloudHealth.Models.SignalStatus status = null, string metricNamespace = null, string metricName = null, string timeGrain = null, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType? aggregationType = default(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType?), string dimensionFilter = null, string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceSignals ResourceSignals(string authenticationSetting = null, Azure.Core.ResourceIdentifier azureResourceId = null, string azureResourceKind = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.ResourceSignal> signals = null, Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal resourceHealth = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.SignalConfiguration SignalConfiguration(string signalId = null, string metricNamespace = null, string metricName = null, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType? aggregationType = default(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType?), string unit = null, string timeGrain = null, string dimensionFilter = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint SignalHistoryDataPoint(System.DateTimeOffset occurredOn = default(System.DateTimeOffset), double? value = default(double?), Azure.ResourceManager.CloudHealth.Models.EntityHealthState healthState = default(Azure.ResourceManager.CloudHealth.Models.EntityHealthState), string additionalContext = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties SignalInstanceProperties(string signalKind = null, string name = null, string signalDefinitionName = null, Azure.ResourceManager.CloudHealth.Models.SignalStatus status = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.SignalStatus SignalStatus(Azure.ResourceManager.CloudHealth.Models.EntityHealthState? healthState = default(Azure.ResourceManager.CloudHealth.Models.EntityHealthState?), double? value = default(double?), System.DateTimeOffset? reportedOn = default(System.DateTimeOffset?), string error = null, string additionalContext = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependenciesAggregationType : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependenciesAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType MaxNotHealthy { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType MinHealthy { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType WorstOf { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType left, Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType left, Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependenciesAggregationUnit : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependenciesAggregationUnit(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit Absolute { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit Percentage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit left, Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit left, Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DependenciesSignalGroupV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2>
    {
        public DependenciesSignalGroupV2(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType aggregationType) { }
        public Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType AggregationType { get { throw null; } set { } }
        public double? DegradedThreshold { get { throw null; } set { } }
        public bool? IgnoreUnknown { get { throw null; } set { } }
        public double? UnhealthyThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationUnit? Unit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2 JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2 PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryError>
    {
        internal DiscoveryError() { }
        public System.Collections.Generic.IReadOnlyList<string> Context { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DiscoveryError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DiscoveryError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.DiscoveryError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.DiscoveryError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryRuleRecommendedSignalsBehavior : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryRuleRecommendedSignalsBehavior(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior Disabled { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior left, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior left, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryRuleRelationshipDiscoveryBehavior : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryRuleRelationshipDiscoveryBehavior(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior Disabled { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior left, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior left, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DiscoveryRuleSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification>
    {
        internal DiscoveryRuleSpecification() { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityAddDataAnnotationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent>
    {
        public EntityAddDataAnnotationContent(System.Collections.Generic.IDictionary<string, string> annotationDetails) { }
        public System.Collections.Generic.IDictionary<string, string> AnnotationDetails { get { throw null; } }
        public string Description { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAddDataAnnotationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityAlertConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration>
    {
        public EntityAlertConfiguration(Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity severity) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ActionGroupIds { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity Severity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityAlerts : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>
    {
        public EntityAlerts() { }
        public Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration Degraded { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration Unhealthy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityAlerts JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityAlerts PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityAlerts System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityAlerts System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityAlertSeverity : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityAlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity Sev0 { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity Sev1 { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity Sev2 { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity Sev3 { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity Sev4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity left, Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity left, Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityCoordinates : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>
    {
        public EntityCoordinates(float x, float y) { }
        public float X { get { throw null; } set { } }
        public float Y { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityCoordinates JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityCoordinates PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityCoordinates System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityCoordinates System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityDataAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation>
    {
        internal EntityDataAnnotation() { }
        public System.Collections.Generic.IDictionary<string, string> AnnotationDetails { get { throw null; } }
        public string AnnotationId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityDynamicThresholdSensitivity : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityDynamicThresholdSensitivity(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity High { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity Low { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity left, Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity left, Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityGetDataAnnotationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent>
    {
        public EntityGetDataAnnotationsContent() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string NextMarker { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityGetDataAnnotationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult>
    {
        internal EntityGetDataAnnotationsResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.EntityDataAnnotation> Annotations { get { throw null; } }
        public string EntityName { get { throw null; } }
        public string NextMarker { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetDataAnnotationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityGetSignalRecommendationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult>
    {
        internal EntityGetSignalRecommendationsResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration> RecommendedConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration> RecommendedSignals { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityGetSignalRecommendationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityHealthReportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent>
    {
        public EntityHealthReportContent(string signalName, Azure.ResourceManager.CloudHealth.Models.EntityHealthState healthState) { }
        public string AdditionalContext { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule EvaluationRules { get { throw null; } set { } }
        public int? ExpiresInMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityHealthState HealthState { get { throw null; } }
        public string SignalName { get { throw null; } }
        public double? Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHealthReportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityHealthState : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.EntityHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityHealthState(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Degraded { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Deleted { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.EntityHealthState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.EntityHealthState left, Azure.ResourceManager.CloudHealth.Models.EntityHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityHealthState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityHealthState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntityHealthState left, Azure.ResourceManager.CloudHealth.Models.EntityHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityHistoryContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent>
    {
        public EntityHistoryContent() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string NextMarker { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityHistoryResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult>
    {
        internal EntityHistoryResult() { }
        public string EntityName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.HealthStateTransition> History { get { throw null; } }
        public string NextMarker { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityHistoryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityIcon : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityIcon>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityIcon>
    {
        public EntityIcon(string iconName) { }
        public string CustomData { get { throw null; } set { } }
        public string IconName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityIcon JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntityIcon PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntityIcon System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityIcon>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityIcon>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityIcon System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityIcon>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityIcon>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityIcon>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityImpact : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.EntityImpact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityImpact(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityImpact Limited { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityImpact Standard { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityImpact Suppressed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.EntityImpact other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.EntityImpact left, Azure.ResourceManager.CloudHealth.Models.EntityImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityImpact (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityImpact? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntityImpact left, Azure.ResourceManager.CloudHealth.Models.EntityImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntitySignalEvaluationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule>
    {
        public EntitySignalEvaluationRule(Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 unhealthyRule) { }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 DegradedRule { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 UnhealthyRule { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitySignalGroups : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups>
    {
        public EntitySignalGroups() { }
        public Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals AzureLogAnalytics { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals AzureMonitorWorkspace { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.ResourceSignals AzureResource { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroupV2 Dependencies { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CloudHealth.Models.ExternalSignal> ExternalSignals { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitySignalHistoryContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent>
    {
        public EntitySignalHistoryContent(string signalName) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string NextMarker { get { throw null; } set { } }
        public string SignalName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitySignalHistoryResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult>
    {
        internal EntitySignalHistoryResult() { }
        public string EntityName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint> History { get { throw null; } }
        public string NextMarker { get { throw null; } }
        public string SignalName { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalHistoryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntitySignalOperator : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntitySignalOperator(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator Dynamic { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator NotEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator left, Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator left, Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntitySignalRefreshInterval : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntitySignalRefreshInterval(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval PT10M { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval PT1H { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval PT1M { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval PT2H { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval PT30M { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval left, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval left, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntitySignalThresholdRuleV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2>
    {
        public EntitySignalThresholdRuleV2(Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator signalOperator) { }
        public Azure.ResourceManager.CloudHealth.Models.LookBackWindow? LookBackWindow { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityDynamicThresholdSensitivity? Sensitivity { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator SignalOperator { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalSignal : Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ExternalSignal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ExternalSignal>
    {
        internal ExternalSignal() { }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule EvaluationRules { get { throw null; } }
        protected override Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ExternalSignal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ExternalSignal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ExternalSignal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ExternalSignal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ExternalSignal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ExternalSignal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ExternalSignal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class HealthModelAuthenticationSettingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties>
    {
        internal HealthModelAuthenticationSettingProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelDiscoveryRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties>
    {
        public HealthModelDiscoveryRuleProperties(string authenticationSetting, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior discoverRelationships, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior addRecommendedSignals, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification specification) { }
        public Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior AddRecommendedSignals { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior? AddResourceHealthSignal { get { throw null; } set { } }
        public string AuthenticationSetting { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior DiscoverRelationships { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string EntityName { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.DiscoveryError Error { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification Specification { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelEntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties>
    {
        public HealthModelEntityProperties() { }
        public Azure.ResourceManager.CloudHealth.Models.EntityAlerts Alerts { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityCoordinates CanvasPosition { get { throw null; } set { } }
        public string DiscoveredBy { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public float? HealthObjective { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityHealthState? HealthState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntityIcon Icon { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityImpact? Impact { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalGroups SignalGroups { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelPatch>
    {
        public HealthModelPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.HealthModelPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.HealthModelPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthModelProvisioningState : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthModelProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState left, Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState left, Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthModelRelationshipProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties>
    {
        public HealthModelRelationshipProperties(string parentEntityName, string childEntityName) { }
        public string ChildEntityName { get { throw null; } set { } }
        public string DiscoveredBy { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string ParentEntityName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class HealthModelSignalDefinitionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties>
    {
        internal HealthModelSignalDefinitionProperties() { }
        public string DataUnit { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule EvaluationRules { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? RefreshInterval { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthReportEvaluationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule>
    {
        public HealthReportEvaluationRule(Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 unhealthyRule) { }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 DegradedRule { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRuleV2 UnhealthyRule { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthReportEvaluationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthStateTransition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthStateTransition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthStateTransition>
    {
        internal HealthStateTransition() { }
        public Azure.ResourceManager.CloudHealth.Models.EntityHealthState NewState { get { throw null; } }
        public System.DateTimeOffset OccurredOn { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntityHealthState PreviousState { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthStateTransition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthStateTransition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.HealthStateTransition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthStateTransition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthStateTransition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.HealthStateTransition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthStateTransition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthStateTransition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthStateTransition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsQuerySignalDefinitionProperties : Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties>
    {
        public LogAnalyticsQuerySignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules, string queryText) { }
        public string QueryText { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        public string ValueColumnName { get { throw null; } set { } }
        protected override Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsSignal : Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal>
    {
        public LogAnalyticsSignal(string name) { }
        public string DataUnit { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule EvaluationRules { get { throw null; } set { } }
        public string QueryText { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? RefreshInterval { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        public string ValueColumnName { get { throw null; } set { } }
        protected override Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsSignals : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals>
    {
        public LogAnalyticsSignals(string authenticationSetting, Azure.Core.ResourceIdentifier logAnalyticsWorkspaceResourceId) { }
        public string AuthenticationSetting { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignal> Signals { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignals>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LookBackWindow : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.LookBackWindow>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LookBackWindow(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.LookBackWindow PT15M { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.LookBackWindow PT1H { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.LookBackWindow PT30M { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.LookBackWindow PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.LookBackWindow other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.LookBackWindow left, Azure.ResourceManager.CloudHealth.Models.LookBackWindow right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.LookBackWindow (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.LookBackWindow? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.LookBackWindow left, Azure.ResourceManager.CloudHealth.Models.LookBackWindow right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIdentityAuthenticationSettingProperties : Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties>
    {
        public ManagedIdentityAuthenticationSettingProperties(string managedIdentityName) { }
        public string ManagedIdentityName { get { throw null; } set { } }
        protected override Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricAggregationType : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.MetricAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.MetricAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.MetricAggregationType Count { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.MetricAggregationType Maximum { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.MetricAggregationType Minimum { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.MetricAggregationType None { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.MetricAggregationType Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType left, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.MetricAggregationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.MetricAggregationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType left, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorWorkspaceSignals : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals>
    {
        public MonitorWorkspaceSignals(string authenticationSetting, Azure.Core.ResourceIdentifier azureMonitorWorkspaceResourceId) { }
        public string AuthenticationSetting { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AzureMonitorWorkspaceResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal> Signals { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.MonitorWorkspaceSignals>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusMetricsSignal : Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal>
    {
        public PrometheusMetricsSignal(string name) { }
        public string DataUnit { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule EvaluationRules { get { throw null; } set { } }
        public string QueryText { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? RefreshInterval { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        protected override Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusMetricsSignalDefinitionProperties : Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>
    {
        public PrometheusMetricsSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules, string queryText) { }
        public string QueryText { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        protected override Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGraphQuerySpecification : Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification>
    {
        public ResourceGraphQuerySpecification(string resourceGraphQuery) { }
        public string ResourceGraphQuery { get { throw null; } set { } }
        protected override Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceGraphQuerySpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthAvailabilityState : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthAvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState Available { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState Degraded { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState Unavailable { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthAvailabilityStateSignalBehavior : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthAvailabilityStateSignalBehavior(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior Disabled { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthCategory : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthCategory(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory Planned { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory Unplanned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthReasonChronicity : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthReasonChronicity(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity Persistent { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity Transient { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthReasonType : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthReasonType(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType Planned { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType Unplanned { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType UserInitiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType left, Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceHealthSignal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal>
    {
        public ResourceHealthSignal() { }
        public Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityStateSignalBehavior? Enabled { get { throw null; } set { } }
        public string SignalName { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthSignalStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus>
    {
        internal ResourceHealthSignalStatus() { }
        public string AdditionalContext { get { throw null; } }
        public System.DateTimeOffset? AvailabilityReportedOn { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.ResourceHealthAvailabilityState? AvailabilityState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.ResourceHealthCategory? Category { get { throw null; } }
        public string DetailedStatus { get { throw null; } }
        public string Error { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntityHealthState? HealthState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonChronicity? ReasonChronicity { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.ResourceHealthReasonType? ReasonType { get { throw null; } }
        public System.DateTimeOffset? ReportedOn { get { throw null; } }
        public string Summary { get { throw null; } }
        public double? Value { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignalStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceMetricSignalDefinitionProperties : Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>
    {
        public ResourceMetricSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules, string metricNamespace, string metricName, string timeGrain, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType aggregationType) { }
        public Azure.ResourceManager.CloudHealth.Models.MetricAggregationType AggregationType { get { throw null; } set { } }
        public string DimensionFilter { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        protected override Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSignal : Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignal>
    {
        public ResourceSignal(string name) { }
        public Azure.ResourceManager.CloudHealth.Models.MetricAggregationType? AggregationType { get { throw null; } set { } }
        public string DataUnit { get { throw null; } set { } }
        public string DimensionFilter { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule EvaluationRules { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? RefreshInterval { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        protected override Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ResourceSignal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ResourceSignal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSignals : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignals>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignals>
    {
        public ResourceSignals(string authenticationSetting, Azure.Core.ResourceIdentifier azureResourceId) { }
        public string AuthenticationSetting { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } set { } }
        public string AzureResourceKind { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.ResourceHealthSignal ResourceHealth { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.ResourceSignal> Signals { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.ResourceSignals JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.ResourceSignals PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ResourceSignals System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignals>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignals>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ResourceSignals System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignals>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignals>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceSignals>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration>
    {
        internal SignalConfiguration() { }
        public Azure.ResourceManager.CloudHealth.Models.MetricAggregationType? AggregationType { get { throw null; } }
        public string DimensionFilter { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule EvaluationRules { get { throw null; } }
        public string MetricName { get { throw null; } }
        public string MetricNamespace { get { throw null; } }
        public string SignalId { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.SignalConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.SignalConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.SignalConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalHistoryDataPoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint>
    {
        internal SignalHistoryDataPoint() { }
        public string AdditionalContext { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntityHealthState HealthState { get { throw null; } }
        public System.DateTimeOffset OccurredOn { get { throw null; } }
        public double? Value { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalHistoryDataPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SignalInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties>
    {
        internal SignalInstanceProperties() { }
        public string Name { get { throw null; } set { } }
        public string SignalDefinitionName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.SignalStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalStatus>
    {
        internal SignalStatus() { }
        public string AdditionalContext { get { throw null; } }
        public string Error { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntityHealthState? HealthState { get { throw null; } }
        public System.DateTimeOffset? ReportedOn { get { throw null; } }
        public double? Value { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.SignalStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.SignalStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.SignalStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
