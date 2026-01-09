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
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProperties Properties { get { throw null; } set { } }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string entityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class ArmCloudHealthModelFactory
    {
        public static Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup AzureMonitorWorkspaceSignalGroup(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment> signalAssignments = null, string authenticationSetting = null, Azure.Core.ResourceIdentifier azureMonitorWorkspaceResourceId = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup AzureResourceSignalGroup(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment> signalAssignments = null, string authenticationSetting = null, Azure.Core.ResourceIdentifier azureResourceId = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityAlertConfiguration EntityAlertConfiguration(Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity severity = default(Azure.ResourceManager.CloudHealth.Models.EntityAlertSeverity), string description = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> actionGroupIds = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment EntitySignalAssignment(System.Collections.Generic.IEnumerable<string> signalDefinitions = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelAuthenticationSettingData HealthModelAuthenticationSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelAuthenticationSettingProperties HealthModelAuthenticationSettingProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string authenticationKind = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelData HealthModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CloudHealth.Models.HealthModelProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelDiscoveryRuleData HealthModelDiscoveryRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelDiscoveryRuleProperties HealthModelDiscoveryRuleProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string resourceGraphQuery = null, string authenticationSetting = null, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior discoverRelationships = default(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior), Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior addRecommendedSignals = default(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), string errorMessage = null, int? numberOfDiscoveredEntities = default(int?), string entityName = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelEntityData HealthModelEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelEntityProperties HealthModelEntityProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string kind = null, Azure.ResourceManager.CloudHealth.Models.EntityCoordinates canvasPosition = null, Azure.ResourceManager.CloudHealth.Models.EntityIcon icon = null, float? healthObjective = default(float?), Azure.ResourceManager.CloudHealth.Models.EntityImpact? impact = default(Azure.ResourceManager.CloudHealth.Models.EntityImpact?), System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup signals = null, string discoveredBy = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), Azure.ResourceManager.CloudHealth.Models.EntityHealthState? healthState = default(Azure.ResourceManager.CloudHealth.Models.EntityHealthState?), Azure.ResourceManager.CloudHealth.Models.EntityAlerts alerts = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelPatch HealthModelPatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings healthModelUpdateDiscovery = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelProperties HealthModelProperties(string dataplaneEndpoint = null, Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings discovery = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelRelationshipData HealthModelRelationshipData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelRelationshipProperties HealthModelRelationshipProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string parentEntityName = null, string childEntityName = null, System.Collections.Generic.IDictionary<string, string> labels = null, string discoveredBy = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelSignalDefinitionData HealthModelSignalDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties HealthModelSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string signalKind = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), System.Collections.Generic.IDictionary<string, string> labels = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties LogAnalyticsQuerySignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), System.Collections.Generic.IDictionary<string, string> labels = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), string queryText = null, string timeGrain = null, string valueColumnName = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup LogAnalyticsSignalGroup(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment> signalAssignments = null, string authenticationSetting = null, Azure.Core.ResourceIdentifier logAnalyticsWorkspaceResourceId = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties ManagedIdentityAuthenticationSettingProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string managedIdentityName = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties PrometheusMetricsSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), System.Collections.Generic.IDictionary<string, string> labels = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), string queryText = null, string timeGrain = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties ResourceMetricSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval?), System.Collections.Generic.IDictionary<string, string> labels = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), string metricNamespace = null, string metricName = null, string timeGrain = null, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType aggregationType = default(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType), string dimension = null, string dimensionFilter = null) { throw null; }
    }
    public partial class AzureMonitorWorkspaceSignalGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup>
    {
        public AzureMonitorWorkspaceSignalGroup(string authenticationSetting, Azure.Core.ResourceIdentifier azureMonitorWorkspaceResourceId) { }
        public string AuthenticationSetting { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AzureMonitorWorkspaceResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment> SignalAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceSignalGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup>
    {
        public AzureResourceSignalGroup(string authenticationSetting, Azure.Core.ResourceIdentifier azureResourceId) { }
        public string AuthenticationSetting { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment> SignalAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependenciesAggregationType : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependenciesAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType Thresholds { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType WorstOf { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType left, Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType left, Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DependenciesSignalGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>
    {
        public DependenciesSignalGroup(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType aggregationType) { }
        public Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType AggregationType { get { throw null; } set { } }
        public string DegradedThreshold { get { throw null; } set { } }
        public string UnhealthyThreshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior left, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior left, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynamicDetectionRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule>
    {
        public DynamicDetectionRule(Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel dynamicThresholdModel, float modelSensitivity, Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection dynamicThresholdDirection) { }
        public Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection DynamicThresholdDirection { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel DynamicThresholdModel { get { throw null; } set { } }
        public float ModelSensitivity { get { throw null; } set { } }
        public System.DateTimeOffset? TrainingStartOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicThresholdDirection : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicThresholdDirection(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection GreaterOrLowerThan { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection LowerThan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection left, Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection left, Azure.ResourceManager.CloudHealth.Models.DynamicThresholdDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicThresholdModel : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicThresholdModel(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel AnomalyDetection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel left, Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel left, Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel right) { throw null; }
        public override string ToString() { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityHealthState : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.EntityHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityHealthState(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Degraded { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Deleted { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Error { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntityHealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.EntityHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.EntityHealthState left, Azure.ResourceManager.CloudHealth.Models.EntityHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityHealthState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityHealthState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntityHealthState left, Azure.ResourceManager.CloudHealth.Models.EntityHealthState right) { throw null; }
        public override string ToString() { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.EntityImpact left, Azure.ResourceManager.CloudHealth.Models.EntityImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityImpact (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntityImpact? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntityImpact left, Azure.ResourceManager.CloudHealth.Models.EntityImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntitySignalAssignment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment>
    {
        public EntitySignalAssignment(System.Collections.Generic.IEnumerable<string> signalDefinitions) { }
        public System.Collections.Generic.IList<string> SignalDefinitions { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitySignalEvaluationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule>
    {
        public EntitySignalEvaluationRule() { }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule DegradedRule { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule DynamicDetectionRule { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule UnhealthyRule { get { throw null; } set { } }
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
    public partial class EntitySignalGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup>
    {
        public EntitySignalGroup() { }
        public Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup AzureLogAnalytics { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup AzureMonitorWorkspace { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup AzureResource { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup Dependencies { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntitySignalOperator : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntitySignalOperator(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator GreaterOrEquals { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator LowerOrEquals { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator LowerThan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval left, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval left, Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntitySignalThresholdRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule>
    {
        public EntitySignalThresholdRule(Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator @operator, string threshold) { }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalOperator Operator { get { throw null; } set { } }
        public string Threshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntitySignalThresholdRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public HealthModelDiscoveryRuleProperties(string resourceGraphQuery, string authenticationSetting, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior discoverRelationships, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior addRecommendedSignals) { }
        public Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior AddRecommendedSignals { get { throw null; } set { } }
        public string AuthenticationSetting { get { throw null; } set { } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior DiscoverRelationships { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string EntityName { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? NumberOfDiscoveredEntities { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGraphQuery { get { throw null; } set { } }
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
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string DiscoveredBy { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public float? HealthObjective { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityHealthState? HealthState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntityIcon Icon { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityImpact? Impact { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalGroup Signals { get { throw null; } set { } }
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
        public Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings HealthModelUpdateDiscovery { get { throw null; } set { } }
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
    public partial class HealthModelProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelProperties>
    {
        public HealthModelProperties() { }
        public string DataplaneEndpoint { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings Discovery { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.HealthModelProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.HealthModelProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.HealthModelProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string DiscoveredBy { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string ParentEntityName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
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
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule EvaluationRules { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.EntitySignalRefreshInterval? RefreshInterval { get { throw null; } set { } }
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
    public partial class LogAnalyticsSignalGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>
    {
        public LogAnalyticsSignalGroup(string authenticationSetting, Azure.Core.ResourceIdentifier logAnalyticsWorkspaceResourceId) { }
        public string AuthenticationSetting { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.EntitySignalAssignment> SignalAssignments { get { throw null; } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType left, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.MetricAggregationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.MetricAggregationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType left, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelDiscoverySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>
    {
        public ModelDiscoverySettings(string scope, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior addRecommendedSignals) { }
        public Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior AddRecommendedSignals { get { throw null; } set { } }
        public string Identity { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResourceMetricSignalDefinitionProperties : Azure.ResourceManager.CloudHealth.Models.HealthModelSignalDefinitionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>
    {
        public ResourceMetricSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.EntitySignalEvaluationRule evaluationRules, string metricNamespace, string metricName, string timeGrain, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType aggregationType) { }
        public Azure.ResourceManager.CloudHealth.Models.MetricAggregationType AggregationType { get { throw null; } set { } }
        public string Dimension { get { throw null; } set { } }
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
}
