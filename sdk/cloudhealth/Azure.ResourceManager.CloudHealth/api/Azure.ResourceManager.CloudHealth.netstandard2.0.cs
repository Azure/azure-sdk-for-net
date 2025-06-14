namespace Azure.ResourceManager.CloudHealth
{
    public partial class AuthenticationSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>, System.Collections.IEnumerable
    {
        protected AuthenticationSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authenticationSettingName, Azure.ResourceManager.CloudHealth.AuthenticationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authenticationSettingName, Azure.ResourceManager.CloudHealth.AuthenticationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> Get(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>> GetAsync(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> GetIfExists(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>> GetIfExistsAsync(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AuthenticationSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>
    {
        public AuthenticationSettingData() { }
        public Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.AuthenticationSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.AuthenticationSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthenticationSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AuthenticationSettingResource() { }
        public virtual Azure.ResourceManager.CloudHealth.AuthenticationSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string authenticationSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.AuthenticationSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.AuthenticationSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.AuthenticationSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.AuthenticationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.AuthenticationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerCloudHealthContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCloudHealthContext() { }
        public static Azure.ResourceManager.CloudHealth.AzureResourceManagerCloudHealthContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class CloudHealthExtensions
    {
        public static Azure.ResourceManager.CloudHealth.AuthenticationSettingResource GetAuthenticationSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CloudHealth.DiscoveryRuleResource GetDiscoveryRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CloudHealth.EntityResource GetEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource> GetHealthModel(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.HealthModelResource>> GetHealthModelAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string healthModelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelResource GetHealthModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelCollection GetHealthModels(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CloudHealth.HealthModelResource> GetHealthModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.HealthModelResource> GetHealthModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.RelationshipResource GetRelationshipResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CloudHealth.SignalDefinitionResource GetSignalDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DiscoveryRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>, System.Collections.IEnumerable
    {
        protected DiscoveryRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string discoveryRuleName, Azure.ResourceManager.CloudHealth.DiscoveryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string discoveryRuleName, Azure.ResourceManager.CloudHealth.DiscoveryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> Get(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> GetAll(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> GetAllAsync(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>> GetAsync(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> GetIfExists(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>> GetIfExistsAsync(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>
    {
        public DiscoveryRuleData() { }
        public Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.DiscoveryRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.DiscoveryRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryRuleResource() { }
        public virtual Azure.ResourceManager.CloudHealth.DiscoveryRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string discoveryRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.DiscoveryRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.DiscoveryRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.DiscoveryRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.DiscoveryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.DiscoveryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.EntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.EntityResource>, System.Collections.IEnumerable
    {
        protected EntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.EntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.CloudHealth.EntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.EntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string entityName, Azure.ResourceManager.CloudHealth.EntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.EntityResource> Get(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.EntityResource> GetAll(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.EntityResource> GetAllAsync(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.EntityResource>> GetAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.EntityResource> GetIfExists(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.EntityResource>> GetIfExistsAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.EntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.EntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.EntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.EntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.EntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.EntityData>
    {
        public EntityData() { }
        public Azure.ResourceManager.CloudHealth.Models.EntityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.EntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.EntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.EntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.EntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.EntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.EntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.EntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.EntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.EntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EntityResource() { }
        public virtual Azure.ResourceManager.CloudHealth.EntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string entityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.EntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.EntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.EntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.EntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.EntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.EntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.EntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.EntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.EntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.EntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.EntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.EntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.EntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.HealthModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.HealthModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource> GetAuthenticationSetting(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.AuthenticationSettingResource>> GetAuthenticationSettingAsync(string authenticationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.AuthenticationSettingCollection GetAuthenticationSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource> GetDiscoveryRule(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.DiscoveryRuleResource>> GetDiscoveryRuleAsync(string discoveryRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.DiscoveryRuleCollection GetDiscoveryRules() { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.EntityCollection GetEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.EntityResource> GetEntity(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.EntityResource>> GetEntityAsync(string entityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.RelationshipResource> GetRelationship(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.RelationshipResource>> GetRelationshipAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.RelationshipCollection GetRelationships() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> GetSignalDefinition(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>> GetSignalDefinitionAsync(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.SignalDefinitionCollection GetSignalDefinitions() { throw null; }
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
    public partial class RelationshipCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.RelationshipResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.RelationshipResource>, System.Collections.IEnumerable
    {
        protected RelationshipCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.RelationshipResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relationshipName, Azure.ResourceManager.CloudHealth.RelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.RelationshipResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relationshipName, Azure.ResourceManager.CloudHealth.RelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.RelationshipResource> Get(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.RelationshipResource> GetAll(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.RelationshipResource> GetAllAsync(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.RelationshipResource>> GetAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.RelationshipResource> GetIfExists(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.RelationshipResource>> GetIfExistsAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.RelationshipResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.RelationshipResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.RelationshipResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.RelationshipResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelationshipData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.RelationshipData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.RelationshipData>
    {
        public RelationshipData() { }
        public Azure.ResourceManager.CloudHealth.Models.RelationshipProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.RelationshipData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.RelationshipData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.RelationshipData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.RelationshipData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.RelationshipData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.RelationshipData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.RelationshipData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelationshipResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.RelationshipData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.RelationshipData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelationshipResource() { }
        public virtual Azure.ResourceManager.CloudHealth.RelationshipData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string relationshipName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.RelationshipResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.RelationshipResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.RelationshipData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.RelationshipData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.RelationshipData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.RelationshipData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.RelationshipData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.RelationshipData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.RelationshipData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.RelationshipResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.RelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.RelationshipResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.RelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignalDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>, System.Collections.IEnumerable
    {
        protected SignalDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string signalDefinitionName, Azure.ResourceManager.CloudHealth.SignalDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string signalDefinitionName, Azure.ResourceManager.CloudHealth.SignalDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> Get(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> GetAll(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> GetAllAsync(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>> GetAsync(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> GetIfExists(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>> GetIfExistsAsync(string signalDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SignalDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>
    {
        public SignalDefinitionData() { }
        public Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.SignalDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.SignalDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SignalDefinitionResource() { }
        public virtual Azure.ResourceManager.CloudHealth.SignalDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string healthModelName, string signalDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CloudHealth.SignalDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.SignalDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.SignalDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.SignalDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.SignalDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CloudHealth.SignalDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CloudHealth.SignalDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CloudHealth.Mocking
{
    public partial class MockableCloudHealthArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCloudHealthArmClient() { }
        public virtual Azure.ResourceManager.CloudHealth.AuthenticationSettingResource GetAuthenticationSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.DiscoveryRuleResource GetDiscoveryRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.EntityResource GetEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.HealthModelResource GetHealthModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.RelationshipResource GetRelationshipResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CloudHealth.SignalDefinitionResource GetSignalDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
    public partial class AlertConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AlertConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AlertConfiguration>
    {
        public AlertConfiguration(Azure.ResourceManager.CloudHealth.Models.AlertSeverity severity) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ActionGroupIds { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.AlertSeverity Severity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.AlertConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AlertConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AlertConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.AlertConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AlertConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AlertConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AlertConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertSeverity : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.AlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.AlertSeverity Sev0 { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.AlertSeverity Sev1 { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.AlertSeverity Sev2 { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.AlertSeverity Sev3 { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.AlertSeverity Sev4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.AlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.AlertSeverity left, Azure.ResourceManager.CloudHealth.Models.AlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.AlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.AlertSeverity left, Azure.ResourceManager.CloudHealth.Models.AlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmCloudHealthModelFactory
    {
        public static Azure.ResourceManager.CloudHealth.AuthenticationSettingData AuthenticationSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties AuthenticationSettingProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string authenticationKind = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.DiscoveryRuleData DiscoveryRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties DiscoveryRuleProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string resourceGraphQuery = null, string authenticationSetting = null, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior discoverRelationships = default(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior), Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior addRecommendedSignals = default(Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), string errorMessage = null, int? numberOfDiscoveredEntities = default(int?), string entityName = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.EntityData EntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.EntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.EntityProperties EntityProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string kind = null, Azure.ResourceManager.CloudHealth.Models.EntityCoordinates canvasPosition = null, Azure.ResourceManager.CloudHealth.Models.IconDefinition icon = null, float? healthObjective = default(float?), Azure.ResourceManager.CloudHealth.Models.EntityImpact? impact = default(Azure.ResourceManager.CloudHealth.Models.EntityImpact?), System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ResourceManager.CloudHealth.Models.SignalGroup signals = null, string discoveredBy = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), Azure.ResourceManager.CloudHealth.Models.HealthState? healthState = default(Azure.ResourceManager.CloudHealth.Models.HealthState?), Azure.ResourceManager.CloudHealth.Models.EntityAlerts alerts = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.HealthModelData HealthModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.CloudHealth.Models.HealthModelProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthModelProperties HealthModelProperties(string dataplaneEndpoint = null, Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings discovery = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties LogAnalyticsQuerySignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.RefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.RefreshInterval?), System.Collections.Generic.IDictionary<string, string> labels = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EvaluationRule evaluationRules = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), string queryText = null, string timeGrain = null, string valueColumnName = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties ManagedIdentityAuthenticationSettingProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string managedIdentityName = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties PrometheusMetricsSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.RefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.RefreshInterval?), System.Collections.Generic.IDictionary<string, string> labels = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EvaluationRule evaluationRules = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), string queryText = null, string timeGrain = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.RelationshipData RelationshipData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.RelationshipProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.RelationshipProperties RelationshipProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string parentEntityName = null, string childEntityName = null, System.Collections.Generic.IDictionary<string, string> labels = null, string discoveredBy = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties ResourceMetricSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, Azure.ResourceManager.CloudHealth.Models.RefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.RefreshInterval?), System.Collections.Generic.IDictionary<string, string> labels = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EvaluationRule evaluationRules = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), string metricNamespace = null, string metricName = null, string timeGrain = null, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType aggregationType = default(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType), string dimension = null, string dimensionFilter = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.SignalDefinitionData SignalDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties SignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? provisioningState = default(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState?), string displayName = null, string signalKind = null, Azure.ResourceManager.CloudHealth.Models.RefreshInterval? refreshInterval = default(Azure.ResourceManager.CloudHealth.Models.RefreshInterval?), System.Collections.Generic.IDictionary<string, string> labels = null, string dataUnit = null, Azure.ResourceManager.CloudHealth.Models.EvaluationRule evaluationRules = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?)) { throw null; }
    }
    public abstract partial class AuthenticationSettingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties>
    {
        protected AuthenticationSettingProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMonitorWorkspaceSignalGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup>
    {
        public AzureMonitorWorkspaceSignalGroup(string authenticationSetting, Azure.Core.ResourceIdentifier azureMonitorWorkspaceResourceId) { }
        public string AuthenticationSetting { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AzureMonitorWorkspaceResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.SignalAssignment> SignalAssignments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.SignalAssignment> SignalAssignments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType left, Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DependenciesSignalGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>
    {
        public DependenciesSignalGroup(Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType aggregationType) { }
        public Azure.ResourceManager.CloudHealth.Models.DependenciesAggregationType AggregationType { get { throw null; } set { } }
        public string DegradedThreshold { get { throw null; } set { } }
        public string UnhealthyThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties>
    {
        public DiscoveryRuleProperties(string resourceGraphQuery, string authenticationSetting, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRelationshipDiscoveryBehavior discoverRelationships, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior addRecommendedSignals, string entityName) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel left, Azure.ResourceManager.CloudHealth.Models.DynamicThresholdModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityAlerts : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>
    {
        public EntityAlerts() { }
        public Azure.ResourceManager.CloudHealth.Models.AlertConfiguration Degraded { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.AlertConfiguration Unhealthy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityAlerts System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityAlerts System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityAlerts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityCoordinates : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>
    {
        public EntityCoordinates(float x, float y) { }
        public float X { get { throw null; } set { } }
        public float Y { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityCoordinates System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityCoordinates System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityCoordinates>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.EntityImpact left, Azure.ResourceManager.CloudHealth.Models.EntityImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityProperties>
    {
        public EntityProperties() { }
        public Azure.ResourceManager.CloudHealth.Models.EntityAlerts Alerts { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityCoordinates CanvasPosition { get { throw null; } set { } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string DiscoveredBy { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public float? HealthObjective { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthState? HealthState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.IconDefinition Icon { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EntityImpact? Impact { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.SignalGroup Signals { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EvaluationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EvaluationRule>
    {
        public EvaluationRule() { }
        public Azure.ResourceManager.CloudHealth.Models.ThresholdRule DegradedRule { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.DynamicDetectionRule DynamicDetectionRule { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.ThresholdRule UnhealthyRule { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EvaluationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EvaluationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.EvaluationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.EvaluationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EvaluationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EvaluationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.EvaluationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthModelPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.HealthModelPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.HealthModelPatch>
    {
        public HealthModelPatch() { }
        public Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings HealthModelUpdateDiscovery { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState left, Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthState : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.HealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthState(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.HealthState Degraded { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.HealthState Deleted { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.HealthState Error { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.HealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.HealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.HealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.HealthState left, Azure.ResourceManager.CloudHealth.Models.HealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.HealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.HealthState left, Azure.ResourceManager.CloudHealth.Models.HealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IconDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.IconDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.IconDefinition>
    {
        public IconDefinition(string iconName) { }
        public string CustomData { get { throw null; } set { } }
        public string IconName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.IconDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.IconDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.IconDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.IconDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.IconDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.IconDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.IconDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsQuerySignalDefinitionProperties : Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsQuerySignalDefinitionProperties>
    {
        public LogAnalyticsQuerySignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.EvaluationRule evaluationRules, string queryText) : base (default(Azure.ResourceManager.CloudHealth.Models.EvaluationRule)) { }
        public string QueryText { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        public string ValueColumnName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.CloudHealth.Models.SignalAssignment> SignalAssignments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedIdentityAuthenticationSettingProperties : Azure.ResourceManager.CloudHealth.Models.AuthenticationSettingProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties>
    {
        public ManagedIdentityAuthenticationSettingProperties(string managedIdentityName) { }
        public string ManagedIdentityName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.MetricAggregationType left, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelDiscoverySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>
    {
        public ModelDiscoverySettings(string scope, Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior addRecommendedSignals) { }
        public Azure.ResourceManager.CloudHealth.Models.DiscoveryRuleRecommendedSignalsBehavior AddRecommendedSignals { get { throw null; } set { } }
        public string Identity { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ModelDiscoverySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusMetricsSignalDefinitionProperties : Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>
    {
        public PrometheusMetricsSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.EvaluationRule evaluationRules, string queryText) : base (default(Azure.ResourceManager.CloudHealth.Models.EvaluationRule)) { }
        public string QueryText { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.PrometheusMetricsSignalDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RefreshInterval : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.RefreshInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RefreshInterval(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.RefreshInterval PT10M { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.RefreshInterval PT1H { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.RefreshInterval PT1M { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.RefreshInterval PT2H { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.RefreshInterval PT30M { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.RefreshInterval PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.RefreshInterval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.RefreshInterval left, Azure.ResourceManager.CloudHealth.Models.RefreshInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.RefreshInterval (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.RefreshInterval left, Azure.ResourceManager.CloudHealth.Models.RefreshInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelationshipProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.RelationshipProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.RelationshipProperties>
    {
        public RelationshipProperties(string parentEntityName, string childEntityName) { }
        public string ChildEntityName { get { throw null; } set { } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string DiscoveredBy { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string ParentEntityName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.RelationshipProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.RelationshipProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.RelationshipProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.RelationshipProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.RelationshipProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.RelationshipProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.RelationshipProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceMetricSignalDefinitionProperties : Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>
    {
        public ResourceMetricSignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.EvaluationRule evaluationRules, string metricNamespace, string metricName, string timeGrain, Azure.ResourceManager.CloudHealth.Models.MetricAggregationType aggregationType) : base (default(Azure.ResourceManager.CloudHealth.Models.EvaluationRule)) { }
        public Azure.ResourceManager.CloudHealth.Models.MetricAggregationType AggregationType { get { throw null; } set { } }
        public string Dimension { get { throw null; } set { } }
        public string DimensionFilter { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string TimeGrain { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ResourceMetricSignalDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalAssignment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalAssignment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalAssignment>
    {
        public SignalAssignment(System.Collections.Generic.IEnumerable<string> signalDefinitions) { }
        public System.Collections.Generic.IList<string> SignalDefinitions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalAssignment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalAssignment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalAssignment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalAssignment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalAssignment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalAssignment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalAssignment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SignalDefinitionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties>
    {
        protected SignalDefinitionProperties(Azure.ResourceManager.CloudHealth.Models.EvaluationRule evaluationRules) { }
        public string DataUnit { get { throw null; } set { } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.EvaluationRule EvaluationRules { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.HealthModelProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CloudHealth.Models.RefreshInterval? RefreshInterval { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalGroup>
    {
        public SignalGroup() { }
        public Azure.ResourceManager.CloudHealth.Models.LogAnalyticsSignalGroup AzureLogAnalytics { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.AzureMonitorWorkspaceSignalGroup AzureMonitorWorkspace { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.AzureResourceSignalGroup AzureResource { get { throw null; } set { } }
        public Azure.ResourceManager.CloudHealth.Models.DependenciesSignalGroup Dependencies { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.SignalGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.SignalGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.SignalGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalOperator : System.IEquatable<Azure.ResourceManager.CloudHealth.Models.SignalOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalOperator(string value) { throw null; }
        public static Azure.ResourceManager.CloudHealth.Models.SignalOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.SignalOperator GreaterOrEquals { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.SignalOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.SignalOperator LowerOrEquals { get { throw null; } }
        public static Azure.ResourceManager.CloudHealth.Models.SignalOperator LowerThan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CloudHealth.Models.SignalOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CloudHealth.Models.SignalOperator left, Azure.ResourceManager.CloudHealth.Models.SignalOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.CloudHealth.Models.SignalOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CloudHealth.Models.SignalOperator left, Azure.ResourceManager.CloudHealth.Models.SignalOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThresholdRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ThresholdRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ThresholdRule>
    {
        public ThresholdRule(Azure.ResourceManager.CloudHealth.Models.SignalOperator @operator, string threshold) { }
        public Azure.ResourceManager.CloudHealth.Models.SignalOperator Operator { get { throw null; } set { } }
        public string Threshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ThresholdRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ThresholdRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CloudHealth.Models.ThresholdRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CloudHealth.Models.ThresholdRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ThresholdRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ThresholdRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CloudHealth.Models.ThresholdRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
