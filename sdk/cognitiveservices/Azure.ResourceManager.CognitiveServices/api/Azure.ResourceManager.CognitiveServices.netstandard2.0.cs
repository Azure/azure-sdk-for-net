namespace Azure.ResourceManager.CognitiveServices
{
    public partial class AzureResourceManagerCognitiveServicesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCognitiveServicesContext() { }
        public static Azure.ResourceManager.CognitiveServices.AzureResourceManagerCognitiveServicesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CognitiveServicesAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>
    {
        public CognitiveServicesAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesAccountDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesAccountDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesAccountDeploymentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>
    {
        public CognitiveServicesAccountDeploymentData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesAccountDeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesAccountDeploymentResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesAccountResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> GetCognitiveServicesAccountDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> GetCognitiveServicesAccountDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentCollection GetCognitiveServicesAccountDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource> GetCognitiveServicesCapabilityHost(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource>> GetCognitiveServicesCapabilityHostAsync(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostCollection GetCognitiveServicesCapabilityHosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> GetCognitiveServicesConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>> GetCognitiveServicesConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionCollection GetCognitiveServicesConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> GetCognitiveServicesEncryptionScope(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>> GetCognitiveServicesEncryptionScopeAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeCollection GetCognitiveServicesEncryptionScopes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> GetCognitiveServicesPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> GetCognitiveServicesPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionCollection GetCognitiveServicesPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> GetCognitiveServicesProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>> GetCognitiveServicesProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCollection GetCognitiveServicesProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> GetCommitmentPlan(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> GetCommitmentPlanAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanCollection GetCommitmentPlans() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> GetDefenderForAISetting(string defenderForAISettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>> GetDefenderForAISettingAsync(string defenderForAISettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.DefenderForAISettingCollection GetDefenderForAISettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel> GetModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel> GetModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource> GetNetworkSecurityPerimeterConfiguration(string nspConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource>> GetNetworkSecurityPerimeterConfigurationAsync(string nspConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationCollection GetNetworkSecurityPerimeterConfigurations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> GetRaiBlocklist(string raiBlocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> GetRaiBlocklistAsync(string raiBlocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.RaiBlocklistCollection GetRaiBlocklists() { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.RaiPolicyCollection GetRaiPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> GetRaiPolicy(string raiPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>> GetRaiPolicyAsync(string raiPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys> RegenerateKey(Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>> RegenerateKeyAsync(Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesCapabilityHostCollection : Azure.ResourceManager.ArmCollection
    {
        protected CognitiveServicesCapabilityHostCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capabilityHostName, Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capabilityHostName, Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource> Get(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource>> GetAsync(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource> GetIfExists(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource>> GetIfExistsAsync(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesCapabilityHostData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>
    {
        public CognitiveServicesCapabilityHostData(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties properties) { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesCapabilityHostResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesCapabilityHostResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string capabilityHostName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesCommitmentPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesCommitmentPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string commitmentPlanName, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string commitmentPlanName, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> Get(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> GetAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetIfExists(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> GetIfExistsAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesCommitmentPlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesCommitmentPlanResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string commitmentPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> GetCommitmentPlanAccountAssociation(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> GetCommitmentPlanAccountAssociationAsync(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationCollection GetCommitmentPlanAccountAssociations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku commitmentPlan, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku commitmentPlan, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> GetAll(string target = null, string category = null, bool? includeAll = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> GetAllAsync(string target = null, string category = null, bool? includeAll = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> GetIfExists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>> GetIfExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>
    {
        public CognitiveServicesConnectionData(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties properties) { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesConnectionResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource> Update(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource>> UpdateAsync(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesDeletedAccountCollection : Azure.ResourceManager.ArmCollection
    {
        protected CognitiveServicesDeletedAccountCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> Get(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> GetAsync(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetIfExists(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesDeletedAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesDeletedAccountResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesEncryptionScopeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesEncryptionScopeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string encryptionScopeName, Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string encryptionScopeName, Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> Get(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>> GetAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> GetIfExists(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>> GetIfExistsAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesEncryptionScopeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>
    {
        public CognitiveServicesEncryptionScopeData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesEncryptionScopeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesEncryptionScopeResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string encryptionScopeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CognitiveServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult> CalculateModelCapacity(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult>> CalculateModelCapacityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList> CheckDomainAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>> CheckDomainAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList> CheckSkuAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList> CheckSkuAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetCognitiveServicesAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> GetCognitiveServicesAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource GetCognitiveServicesAccountDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource GetCognitiveServicesAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountCollection GetCognitiveServicesAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetCognitiveServicesAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetCognitiveServicesAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource GetCognitiveServicesCapabilityHostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetCognitiveServicesCommitmentPlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> GetCognitiveServicesCommitmentPlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource GetCognitiveServicesCommitmentPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanCollection GetCognitiveServicesCommitmentPlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetCognitiveServicesCommitmentPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetCognitiveServicesCommitmentPlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource GetCognitiveServicesConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetCognitiveServicesDeletedAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> GetCognitiveServicesDeletedAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource GetCognitiveServicesDeletedAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountCollection GetCognitiveServicesDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource GetCognitiveServicesEncryptionScopeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource GetCognitiveServicesPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource GetCognitiveServicesProjectCapabilityHostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource GetCognitiveServicesProjectConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource GetCognitiveServicesProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource GetCommitmentPlanAccountAssociationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CommitmentPlanResource GetCommitmentPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier> GetCommitmentTiers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier> GetCommitmentTiersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource GetDefenderForAISettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetDeletedAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem> GetLocationBasedModelCapacities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string modelFormat, string modelName, string modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem> GetLocationBasedModelCapacitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string modelFormat, string modelName, string modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem> GetModelCapacities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string modelFormat, string modelName, string modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem> GetModelCapacitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string modelFormat, string modelName, string modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel> GetModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel> GetModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource GetNetworkSecurityPerimeterConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource GetRaiBlocklistItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.RaiBlocklistResource GetRaiBlocklistResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource> GetRaiContentFilter(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource>> GetRaiContentFilterAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.RaiContentFilterResource GetRaiContentFilterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.RaiContentFilterCollection GetRaiContentFilters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.RaiPolicyResource GetRaiPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku> GetResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku> GetResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesPrivateEndpointConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>
    {
        public CognitiveServicesPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesProjectCapabilityHostCollection : Azure.ResourceManager.ArmCollection
    {
        protected CognitiveServicesProjectCapabilityHostCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capabilityHostName, Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capabilityHostName, Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource> Get(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource>> GetAsync(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource> GetIfExists(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource>> GetIfExistsAsync(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesProjectCapabilityHostResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesProjectCapabilityHostResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string projectName, string capabilityHostName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesProjectConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesProjectConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> GetAll(string target = null, string category = null, bool? includeAll = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> GetAllAsync(string target = null, string category = null, bool? includeAll = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> GetIfExists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>> GetIfExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesProjectConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesProjectConnectionResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string projectName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> Update(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>> UpdateAsync(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesProjectData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>
    {
        public CognitiveServicesProjectData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesProjectResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource> GetCognitiveServicesProjectCapabilityHost(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource>> GetCognitiveServicesProjectCapabilityHostAsync(string capabilityHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostCollection GetCognitiveServicesProjectCapabilityHosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource> GetCognitiveServicesProjectConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource>> GetCognitiveServicesProjectConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionCollection GetCognitiveServicesProjectConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommitmentPlanAccountAssociationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>, System.Collections.IEnumerable
    {
        protected CommitmentPlanAccountAssociationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string commitmentPlanAssociationName, Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string commitmentPlanAssociationName, Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> Get(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> GetAsync(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> GetIfExists(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> GetIfExistsAsync(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommitmentPlanAccountAssociationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>
    {
        public CommitmentPlanAccountAssociationData() { }
        public string AccountId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitmentPlanAccountAssociationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommitmentPlanAccountAssociationResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string commitmentPlanName, string commitmentPlanAssociationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommitmentPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>, System.Collections.IEnumerable
    {
        protected CommitmentPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string commitmentPlanName, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string commitmentPlanName, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> Get(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> GetAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> GetIfExists(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> GetIfExistsAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommitmentPlanData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>
    {
        public CommitmentPlanData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitmentPlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommitmentPlanResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string commitmentPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.CommitmentPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.CommitmentPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefenderForAISettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>, System.Collections.IEnumerable
    {
        protected DefenderForAISettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string defenderForAISettingName, Azure.ResourceManager.CognitiveServices.DefenderForAISettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string defenderForAISettingName, Azure.ResourceManager.CognitiveServices.DefenderForAISettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string defenderForAISettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string defenderForAISettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> Get(string defenderForAISettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>> GetAsync(string defenderForAISettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> GetIfExists(string defenderForAISettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>> GetIfExistsAsync(string defenderForAISettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DefenderForAISettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>
    {
        public DefenderForAISettingData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState? State { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.DefenderForAISettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.DefenderForAISettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefenderForAISettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DefenderForAISettingResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.DefenderForAISettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string defenderForAISettingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.DefenderForAISettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.DefenderForAISettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.DefenderForAISettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource> Update(Azure.ResourceManager.CognitiveServices.DefenderForAISettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource>> UpdateAsync(Azure.ResourceManager.CognitiveServices.DefenderForAISettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource>, System.Collections.IEnumerable
    {
        protected NetworkSecurityPerimeterConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string nspConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nspConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource> Get(string nspConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource>> GetAsync(string nspConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource> GetIfExists(string nspConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string nspConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>
    {
        public NetworkSecurityPerimeterConfigurationData() { }
        public Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkSecurityPerimeterConfigurationResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string nspConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource> Reconcile(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource>> ReconcileAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiBlocklistCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>, System.Collections.IEnumerable
    {
        protected RaiBlocklistCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string raiBlocklistName, Azure.ResourceManager.CognitiveServices.RaiBlocklistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string raiBlocklistName, Azure.ResourceManager.CognitiveServices.RaiBlocklistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string raiBlocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string raiBlocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> Get(string raiBlocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> GetAsync(string raiBlocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> GetIfExists(string raiBlocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> GetIfExistsAsync(string raiBlocklistName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RaiBlocklistData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>
    {
        public RaiBlocklistData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string RaiBlocklistDescription { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiBlocklistData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiBlocklistData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiBlocklistItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>, System.Collections.IEnumerable
    {
        protected RaiBlocklistItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string raiBlocklistItemName, Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string raiBlocklistItemName, Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string raiBlocklistItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string raiBlocklistItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> Get(string raiBlocklistItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>> GetAsync(string raiBlocklistItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> GetIfExists(string raiBlocklistItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>> GetIfExistsAsync(string raiBlocklistItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RaiBlocklistItemData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>
    {
        public RaiBlocklistItemData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiBlocklistItemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RaiBlocklistItemResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string raiBlocklistName, string raiBlocklistItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RaiBlocklistResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RaiBlocklistResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.RaiBlocklistData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> BatchAddRaiBlocklistItem(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent> content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> BatchAddRaiBlocklistItemAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent> content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response BatchDeleteRaiBlocklistItem(System.BinaryData raiBlocklistItemsNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchDeleteRaiBlocklistItemAsync(System.BinaryData raiBlocklistItemsNames, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string raiBlocklistName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource> GetRaiBlocklistItem(string raiBlocklistItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource>> GetRaiBlocklistItemAsync(string raiBlocklistItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.RaiBlocklistItemCollection GetRaiBlocklistItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.RaiBlocklistData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiBlocklistData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiBlocklistData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.RaiBlocklistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiBlocklistResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.RaiBlocklistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RaiContentFilterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource>, System.Collections.IEnumerable
    {
        protected RaiContentFilterCollection() { }
        public virtual Azure.Response<bool> Exists(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource> Get(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource>> GetAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource> GetIfExists(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource>> GetIfExistsAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RaiContentFilterData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>
    {
        public RaiContentFilterData() { }
        public Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiContentFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiContentFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiContentFilterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RaiContentFilterResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.RaiContentFilterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string filterName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.RaiContentFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiContentFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiContentFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>, System.Collections.IEnumerable
    {
        protected RaiPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string raiPolicyName, Azure.ResourceManager.CognitiveServices.RaiPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string raiPolicyName, Azure.ResourceManager.CognitiveServices.RaiPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string raiPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string raiPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> Get(string raiPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>> GetAsync(string raiPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> GetIfExists(string raiPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>> GetIfExistsAsync(string raiPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RaiPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>
    {
        public RaiPolicyData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RaiPolicyResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.RaiPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string raiPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CognitiveServices.RaiPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.RaiPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.RaiPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.RaiPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.RaiPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.RaiPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CognitiveServices.Mocking
{
    public partial class MockableCognitiveServicesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCognitiveServicesArmClient() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource GetCognitiveServicesAccountDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource GetCognitiveServicesAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostResource GetCognitiveServicesCapabilityHostResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource GetCognitiveServicesCommitmentPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionResource GetCognitiveServicesConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource GetCognitiveServicesDeletedAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeResource GetCognitiveServicesEncryptionScopeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource GetCognitiveServicesPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectCapabilityHostResource GetCognitiveServicesProjectCapabilityHostResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectConnectionResource GetCognitiveServicesProjectConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectResource GetCognitiveServicesProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource GetCommitmentPlanAccountAssociationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanResource GetCommitmentPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.DefenderForAISettingResource GetDefenderForAISettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationResource GetNetworkSecurityPerimeterConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.RaiBlocklistItemResource GetRaiBlocklistItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.RaiBlocklistResource GetRaiBlocklistResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.RaiContentFilterResource GetRaiContentFilterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.RaiPolicyResource GetRaiPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCognitiveServicesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCognitiveServicesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetCognitiveServicesAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> GetCognitiveServicesAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountCollection GetCognitiveServicesAccounts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetCognitiveServicesCommitmentPlan(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> GetCognitiveServicesCommitmentPlanAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanCollection GetCognitiveServicesCommitmentPlans() { throw null; }
    }
    public partial class MockableCognitiveServicesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCognitiveServicesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult> CalculateModelCapacity(Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult>> CalculateModelCapacityAsync(Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList> CheckDomainAvailability(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>> CheckDomainAvailabilityAsync(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList> CheckSkuAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList> CheckSkuAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetCognitiveServicesAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetCognitiveServicesAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetCognitiveServicesCommitmentPlans(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetCognitiveServicesCommitmentPlansAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetCognitiveServicesDeletedAccount(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> GetCognitiveServicesDeletedAccountAsync(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountCollection GetCognitiveServicesDeletedAccounts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier> GetCommitmentTiers(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier> GetCommitmentTiersAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetDeletedAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetDeletedAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem> GetLocationBasedModelCapacities(Azure.Core.AzureLocation location, string modelFormat, string modelName, string modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem> GetLocationBasedModelCapacitiesAsync(Azure.Core.AzureLocation location, string modelFormat, string modelName, string modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem> GetModelCapacities(string modelFormat, string modelName, string modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem> GetModelCapacitiesAsync(string modelFormat, string modelName, string modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel> GetModels(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel> GetModelsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource> GetRaiContentFilter(Azure.Core.AzureLocation location, string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.RaiContentFilterResource>> GetRaiContentFilterAsync(Azure.Core.AzureLocation location, string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.RaiContentFilterCollection GetRaiContentFilters(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku> GetResourceSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku> GetResourceSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage> GetUsages(Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage> GetUsagesAsync(Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public partial class AadAuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties>
    {
        public AadAuthTypeConnectionProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbusePenalty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AbusePenalty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AbusePenalty>
    {
        internal AbusePenalty() { }
        public Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction? Action { get { throw null; } }
        public System.DateTimeOffset? Expiration { get { throw null; } }
        public float? RateLimitPercentage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AbusePenalty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AbusePenalty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AbusePenalty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AbusePenalty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AbusePenalty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AbusePenalty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AbusePenalty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AbusePenaltyAction : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AbusePenaltyAction(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction Block { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction Throttle { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction left, Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction left, Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessKeyAuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties>
    {
        public AccessKeyAuthTypeConnectionProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey Credentials { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountKeyAuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties>
    {
        public AccountKeyAuthTypeConnectionProperties() { }
        public string CredentialsKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIFoundryNetworkInjection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection>
    {
        public AIFoundryNetworkInjection() { }
        public Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType? Scenario { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetArmId { get { throw null; } set { } }
        public bool? UseMicrosoftManagedNetwork { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AIFoundryNetworkInjectionScenarioType : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AIFoundryNetworkInjectionScenarioType(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType Agent { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType left, Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType left, Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjectionScenarioType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiKeyAuthConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties>
    {
        public ApiKeyAuthConnectionProperties() { }
        public string CredentialsKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmCognitiveServicesModelFactory
    {
        public static Azure.ResourceManager.CognitiveServices.Models.AadAuthTypeConnectionProperties AadAuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.AbusePenalty AbusePenalty(Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction? action = default(Azure.ResourceManager.CognitiveServices.Models.AbusePenaltyAction?), float? rateLimitPercentage = default(float?), System.DateTimeOffset? expiration = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.AccessKeyAuthTypeConnectionProperties AccessKeyAuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey credentials = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.AccountKeyAuthTypeConnectionProperties AccountKeyAuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), string credentialsKey = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ApiKeyAuthConnectionProperties ApiKeyAuthConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), string credentialsKey = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku AvailableCognitiveServicesSku(string resourceType = null, string name = null, string tier = null, string kind = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult CalculateModelCapacityResult(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel model = null, string skuName = null, Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity estimatedCapacity = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity CalculateModelCapacityResultEstimatedCapacity(int? value = default(int?), int? deployableValue = default(int?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData CognitiveServicesAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string kind = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData CognitiveServicesAccountDeploymentData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku sku, Azure.ETag? etag, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties properties) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData CognitiveServicesAccountDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku sku = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel CognitiveServicesAccountDeploymentModel(string format, string name, string version, string source, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel CognitiveServicesAccountDeploymentModel(string publisher = null, string format = null, string name = null, string version = null, string source = null, Azure.Core.ResourceIdentifier sourceAccount = null, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties CognitiveServicesAccountDeploymentProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState? provisioningState, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel model, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings scaleSettings, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities, string raiPolicyName, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> rateLimits, Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption? versionUpgradeOption) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties CognitiveServicesAccountDeploymentProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState? provisioningState, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel model, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings scaleSettings, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities, string raiPolicyName, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> rateLimits, Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption? versionUpgradeOption, bool? isDynamicThrottlingEnabled, int? currentCapacity, Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings capacitySettings, string parentDeploymentName) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties CognitiveServicesAccountDeploymentProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState? provisioningState = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel model = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings scaleSettings = null, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities = null, string raiPolicyName = null, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> rateLimits = null, Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption? versionUpgradeOption = default(Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption?), bool? isDynamicThrottlingEnabled = default(bool?), int? currentCapacity = default(int?), Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings capacitySettings = null, string parentDeploymentName = null, string spilloverDeploymentName = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings CognitiveServicesAccountDeploymentScaleSettings(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType? scaleType = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType?), int? capacity = default(int?), int? activeCapacity = default(int?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel CognitiveServicesAccountModel(string format, string name, string version, string source, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel baseModel, bool? isDefaultVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku> skus, int? maxCapacity, System.Collections.Generic.IDictionary<string, string> capabilities, System.Collections.Generic.IDictionary<string, string> finetuneCapabilities, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo deprecation, Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus? lifecycleStatus, Azure.ResourceManager.Models.SystemData systemData) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel CognitiveServicesAccountModel(string publisher = null, string format = null, string name = null, string version = null, string source = null, Azure.Core.ResourceIdentifier sourceAccount = null, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel baseModel = null, bool? isDefaultVersion = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku> skus = null, int? maxCapacity = default(int?), System.Collections.Generic.IDictionary<string, string> capabilities = null, System.Collections.Generic.IDictionary<string, string> finetuneCapabilities = null, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo deprecation = null, Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus? lifecycleStatus = default(Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus?), Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties CognitiveServicesAccountProperties(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState? provisioningState, string endpoint, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability> capabilities, bool? isMigrated, string migrationToken, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo skuChangeInfo, string customSubDomainName, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet networkAcls, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties encryption, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage> userOwnedStorage, Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace amlWorkspace, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties apiProperties, System.DateTimeOffset? createdOn, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit, bool? enableDynamicThrottling, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit quotaLimit, bool? restrictOutboundNetworkAccess, System.Collections.Generic.IEnumerable<string> allowedFqdnList, bool? disableLocalAuth, System.Collections.Generic.IReadOnlyDictionary<string, string> endpoints, bool? restore, System.DateTimeOffset? deletedOn, string scheduledPurgeDate, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings locations, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation> commitmentPlanAssociations, Azure.ResourceManager.CognitiveServices.Models.AbusePenalty abusePenalty, Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig raiMonitorConfig) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties CognitiveServicesAccountProperties(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState? provisioningState = default(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState?), string endpoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability> capabilities = null, bool? isMigrated = default(bool?), string migrationToken = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo skuChangeInfo = null, string customSubDomainName = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet networkAcls = null, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties encryption = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage> userOwnedStorage = null, Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace amlWorkspace = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess?), Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties apiProperties = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit = null, bool? enableDynamicThrottling = default(bool?), Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit quotaLimit = null, bool? restrictOutboundNetworkAccess = default(bool?), System.Collections.Generic.IEnumerable<string> allowedFqdnList = null, bool? disableLocalAuth = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> endpoints = null, bool? restore = default(bool?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), string scheduledPurgeDate = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation> commitmentPlanAssociations = null, Azure.ResourceManager.CognitiveServices.Models.AbusePenalty abusePenalty = null, Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig raiMonitorConfig = null, Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection networkInjections = null, bool? allowProjectManagement = default(bool?), string defaultProject = null, System.Collections.Generic.IEnumerable<string> associatedProjects = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties CognitiveServicesAccountProperties(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState? provisioningState, string endpoint, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability> capabilities, bool? isMigrated, string migrationToken, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo skuChangeInfo, string customSubDomainName, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet networkAcls, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties encryption, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage> userOwnedStorage, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties apiProperties, System.DateTimeOffset? createdOn, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit callRateLimit, bool? enableDynamicThrottling, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit quotaLimit, bool? restrictOutboundNetworkAccess, System.Collections.Generic.IEnumerable<string> allowedFqdnList, bool? disableLocalAuth, System.Collections.Generic.IReadOnlyDictionary<string, string> endpoints, bool? restore, System.DateTimeOffset? deletedOn, string scheduledPurgeDate, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings locations, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation> commitmentPlanAssociations, Azure.ResourceManager.CognitiveServices.Models.AbusePenalty abusePenalty) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku CognitiveServicesAccountSku(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku sku = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesCapabilityHostData CognitiveServicesCapabilityHostData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties CognitiveServicesCapabilityHostProperties(string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<string> aiServicesConnections = null, Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind? capabilityHostKind = default(Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind?), string customerSubnet = null, Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState? provisioningState = default(Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState?), System.Collections.Generic.IEnumerable<string> storageConnections = null, System.Collections.Generic.IEnumerable<string> threadStorageConnections = null, System.Collections.Generic.IEnumerable<string> vectorStoreConnections = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesConnectionData CognitiveServicesConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties CognitiveServicesConnectionProperties(string authType = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent CognitiveServicesDomainAvailabilityContent(string subdomainName = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), string kind = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList CognitiveServicesDomainAvailabilityList(bool? isSubdomainAvailable = default(bool?), string reason = null, string subdomainName = null, string domainAvailabilityType = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesEncryptionScopeData CognitiveServicesEncryptionScopeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties CognitiveServicesEncryptionScopeProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties keyVaultProperties = null, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource? keySource = default(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource?), Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState? provisioningState = default(Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState?), Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState? state = default(Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel CognitiveServicesModel(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel model, string kind, string skuName) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel CognitiveServicesModel(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel model = null, string kind = null, string skuName = null, string description = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku CognitiveServicesModelSku(string name, string usageName, System.DateTimeOffset? deprecationOn, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig capacity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit> rateLimits) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku CognitiveServicesModelSku(string name = null, string usageName = null, System.DateTimeOffset? deprecationOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig capacity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit> rateLimits = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo> cost = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData CognitiveServicesPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState?), System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource CognitiveServicesPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties CognitiveServicesPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesProjectData CognitiveServicesProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties CognitiveServicesProjectProperties(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState? provisioningState = default(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState?), string displayName = null, string description = null, System.Collections.Generic.IReadOnlyDictionary<string, string> endpoints = null, bool? isDefault = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku CognitiveServicesResourceSku(string resourceType = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku sku = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig capacity = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList CognitiveServicesSkuAvailabilityList(string kind = null, string skuAvailabilityType = null, string skuName = null, bool? isSkuAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability CognitiveServicesSkuCapability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo CognitiveServicesSkuChangeInfo(float? countOfDowngrades = default(float?), float? countOfUpgradesAfterDowngrades = default(float?), System.DateTimeOffset? lastChangedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo CognitiveServicesSkuRestrictionInfo(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions CognitiveServicesSkuRestrictions(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionsType? restrictionsType = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo restrictionInfo = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode? reasonCode = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentCost CommitmentCost(string commitmentMeterId = null, string overageMeterId = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod CommitmentPeriod(string tier = null, int? count = default(int?), Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota quota = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData CommitmentPlanAccountAssociationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, string accountId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData CommitmentPlanAccountAssociationData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ETag? etag, string accountId) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation CommitmentPlanAssociation(Azure.Core.ResourceIdentifier commitmentPlanId = null, string commitmentPlanLocation = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CommitmentPlanData CommitmentPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string kind = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties CommitmentPlanProperties(Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState? provisioningState = default(Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState?), System.Guid? commitmentPlanGuid = default(System.Guid?), Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel? hostingModel = default(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel?), string planType = null, Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod current = null, bool? autoRenew = default(bool?), Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod next = null, Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod last = null, System.Collections.Generic.IEnumerable<string> provisioningIssues = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota CommitmentQuota(long? quantity = default(long?), string unit = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentTier CommitmentTier(string kind = null, string skuName = null, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel? hostingModel = default(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel?), string planType = null, string tier = null, int? maxCount = default(int?), Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota quota = null, Azure.ResourceManager.CognitiveServices.Models.CommitmentCost cost = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties CustomKeysConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), System.Collections.Generic.IDictionary<string, string> credentialsKeys = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.DefenderForAISettingData DefenderForAISettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState? state = default(Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties ManagedIdentityAuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity credentials = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem ModelCapacityListResultValueItem(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.NetworkSecurityPerimeterConfigurationData NetworkSecurityPerimeterConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties NetworkSecurityPerimeterConfigurationProperties(string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue> provisioningIssues = null, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter networkSecurityPerimeter = null, Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo resourceAssociation = null, Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo profile = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties NoneAuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties OAuth2AuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2 credentials = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties PatAuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), string credentialsPat = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.RaiBlocklistData RaiBlocklistData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, string raiBlocklistDescription = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.RaiBlocklistItemData RaiBlocklistItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.RaiContentFilterData RaiContentFilterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.RaiPolicyData RaiPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties RaiPolicyProperties(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType? policyType = default(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType?), Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode? mode = default(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode?), string basePolicyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter> contentFilters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig> customBlocklists = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties SASAuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), string credentialsSas = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys ServiceAccountApiKeys(string key1 = null, string key2 = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit ServiceAccountCallRateLimit(float? count = default(float?), float? renewalPeriod = default(float?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> rules = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit ServiceAccountQuotaLimit(float? count = default(float?), float? renewalPeriod = default(float?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> rules = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern ServiceAccountThrottlingMatchPattern(string path = null, string method = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule ServiceAccountThrottlingRule(string key = null, float? renewalPeriod = default(float?), float? count = default(float?), float? minCount = default(float?), bool? isDynamicThrottlingEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern> matchPatterns = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage ServiceAccountUsage(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType? unit = default(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType?), Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName name = null, string quotaPeriod = null, double? limit = default(double?), double? currentValue = default(double?), string nextResetTime = null, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus? status = default(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus?)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName ServiceAccountUsageMetricName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties ServicePrincipalAuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal credentials = null) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties UsernamePasswordAuthTypeConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? category = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory?), Azure.Core.ResourceIdentifier createdByWorkspaceArmId = null, string error = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? group = default(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup?), bool? isSharedToAll = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? peRequirement = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement?), Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? peStatus = default(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus?), System.Collections.Generic.IEnumerable<string> sharedUserList = null, string target = null, bool? useWorkspaceManagedIdentity = default(bool?), Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword credentials = null) { throw null; }
    }
    public partial class AvailableCognitiveServicesSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku>
    {
        internal AvailableCognitiveServicesSku() { }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingMeterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo>
    {
        public BillingMeterInfo() { }
        public string MeterId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CalculateModelCapacityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent>
    {
        public CalculateModelCapacityContent() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel Model { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload> Workloads { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CalculateModelCapacityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult>
    {
        internal CalculateModelCapacityResult() { }
        public Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity EstimatedCapacity { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel Model { get { throw null; } }
        public string SkuName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CalculateModelCapacityResultEstimatedCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity>
    {
        internal CalculateModelCapacityResultEstimatedCapacity() { }
        public int? DeployableValue { get { throw null; } }
        public int? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CalculateModelCapacityResultEstimatedCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapabilityHostKind : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapabilityHostKind(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind Agents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind left, Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind left, Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapabilityHostProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapabilityHostProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesAccountDeploymentModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel>
    {
        public CognitiveServicesAccountDeploymentModel() { }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public string Format { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceAccount { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesAccountDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties>
    {
        public CognitiveServicesAccountDeploymentProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings CapacitySettings { get { throw null; } set { } }
        public int? CurrentCapacity { get { throw null; } set { } }
        public bool? IsDynamicThrottlingEnabled { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel Model { get { throw null; } set { } }
        public string ParentDeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public string RaiPolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> RateLimits { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings ScaleSettings { get { throw null; } set { } }
        public string SpilloverDeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption? VersionUpgradeOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesAccountDeploymentProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesAccountDeploymentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesAccountDeploymentScaleSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings>
    {
        public CognitiveServicesAccountDeploymentScaleSettings() { }
        public int? ActiveCapacity { get { throw null; } }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType? ScaleType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesAccountDeploymentScaleType : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesAccountDeploymentScaleType(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesAccountModel : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel>
    {
        public CognitiveServicesAccountModel() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel BaseModel { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Capabilities { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo Deprecation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> FinetuneCapabilities { get { throw null; } }
        public bool? IsDefaultVersion { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus? LifecycleStatus { get { throw null; } set { } }
        public int? MaxCapacity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku> Skus { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesAccountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties>
    {
        public CognitiveServicesAccountProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.AbusePenalty AbusePenalty { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedFqdnList { get { throw null; } }
        public bool? AllowProjectManagement { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace AmlWorkspace { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties ApiProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AssociatedProjects { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation> CommitmentPlanAssociations { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string CustomSubDomainName { get { throw null; } set { } }
        public string DefaultProject { get { throw null; } set { } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnableDynamicThrottling { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties Encryption { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Endpoints { get { throw null; } }
        public bool? IsMigrated { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings Locations { get { throw null; } set { } }
        public string MigrationToken { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.AIFoundryNetworkInjection NetworkInjections { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit QuotaLimit { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig RaiMonitorConfig { get { throw null; } set { } }
        public bool? Restore { get { throw null; } set { } }
        public bool? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public string ScheduledPurgeDate { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo SkuChangeInfo { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage> UserOwnedStorage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesAccountSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku>
    {
        internal CognitiveServicesAccountSku() { }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesCapabilityHostProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties>
    {
        public CognitiveServicesCapabilityHostProperties() { }
        public System.Collections.Generic.IList<string> AiServicesConnections { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CapabilityHostKind? CapabilityHostKind { get { throw null; } set { } }
        public string CustomerSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CapabilityHostProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> StorageConnections { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ThreadStorageConnections { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorStoreConnections { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapabilityHostProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesCapacityConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig>
    {
        public CognitiveServicesCapacityConfig() { }
        public System.Collections.Generic.IList<int> AllowedValues { get { throw null; } }
        public int? Default { get { throw null; } set { } }
        public int? Maximum { get { throw null; } set { } }
        public int? Minimum { get { throw null; } set { } }
        public int? Step { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesCommitmentPlanPatch : Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch>
    {
        public CognitiveServicesCommitmentPlanPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesConnectionAccessKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey>
    {
        public CognitiveServicesConnectionAccessKey() { }
        public string AccessKeyId { get { throw null; } set { } }
        public string SecretAccessKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionAccessKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesConnectionCategory : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesConnectionCategory(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AdlsGen2 { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AIServices { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AmazonMws { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AmazonRdsForOracle { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AmazonRdsForSqlServer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AmazonRedshift { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AmazonS3Compatible { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory ApiKey { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureBlob { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureDatabricksDeltaLake { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureDataExplorer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureMariaDB { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureMySqlDB { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureOneLake { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureOpenAI { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzurePostgresDB { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureSqlDB { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureSqlMI { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureSynapseAnalytics { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory AzureTableStorage { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory BingLLMSearch { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Cassandra { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory CognitiveSearch { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory CognitiveService { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Concur { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory ContainerRegistry { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory CosmosDB { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory CosmosDBMongoDBApi { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Couchbase { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory CustomKeys { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Db2 { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Drill { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Dynamics { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory DynamicsAx { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory DynamicsCrm { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Elasticsearch { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Eloqua { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory FileServer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory FtpServer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory GenericContainerRegistry { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory GenericHttp { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory GenericRest { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Git { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory GoogleAdWords { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory GoogleBigQuery { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory GoogleCloudStorage { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Greenplum { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Hbase { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Hdfs { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Hive { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Hubspot { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Impala { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Informix { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Jira { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Magento { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory ManagedOnlineEndpoint { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory MariaDB { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Marketo { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory MicrosoftAccess { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory MongoDBAtlas { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory MongoDBV2 { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory MySql { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Netezza { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory ODataRest { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Odbc { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Office365 { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory OpenAI { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Oracle { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory OracleCloudStorage { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory OracleServiceCloud { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory PayPal { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Phoenix { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Pinecone { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Presto { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory PythonFeed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory QuickBooks { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Redis { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Responsys { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory S3 { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Salesforce { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SalesforceMarketingCloud { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SalesforceServiceCloud { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SapBw { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SapCloudForCustomer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SapEcc { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SapHana { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SapOpenHub { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SapTable { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Serp { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Serverless { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory ServiceNow { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Sftp { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SharePointOnlineList { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Shopify { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Snowflake { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Spark { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory SqlServer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Square { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Sybase { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Teradata { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Vertica { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory WebTable { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Xero { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory Zoho { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesConnectionGroup : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesConnectionGroup(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup Azure { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup AzureAI { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup Database { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup File { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup GenericProtocol { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup NoSQL { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup ServicesAndApps { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesConnectionManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity>
    {
        public CognitiveServicesConnectionManagedIdentity() { }
        public string ClientId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesConnectionOAuth2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2>
    {
        public CognitiveServicesConnectionOAuth2() { }
        public System.Uri AuthUri { get { throw null; } set { } }
        public System.Guid? ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string DeveloperToken { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch>
    {
        public CognitiveServicesConnectionPatch() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CognitiveServicesConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties>
    {
        protected CognitiveServicesConnectionProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionCategory? Category { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CreatedByWorkspaceArmId { get { throw null; } }
        public string Error { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionGroup? Group { get { throw null; } }
        public bool? IsSharedToAll { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement? PeRequirement { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus? PeStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SharedUserList { get { throw null; } }
        public string Target { get { throw null; } set { } }
        public bool? UseWorkspaceManagedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesConnectionServicePrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal>
    {
        public CognitiveServicesConnectionServicePrincipal() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesConnectionUsernamePassword : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword>
    {
        public CognitiveServicesConnectionUsernamePassword() { }
        public string Password { get { throw null; } set { } }
        public string SecurityToken { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesDomainAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent>
    {
        public CognitiveServicesDomainAvailabilityContent(string subdomainName, Azure.Core.ResourceType resourceType) { }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public string SubdomainName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesDomainAvailabilityList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>
    {
        internal CognitiveServicesDomainAvailabilityList() { }
        public string DomainAvailabilityType { get { throw null; } }
        public bool? IsSubdomainAvailable { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Reason { get { throw null; } }
        public string SubdomainName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesEncryptionScopeProperties : Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties>
    {
        public CognitiveServicesEncryptionScopeProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState? State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesEncryptionScopeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule>
    {
        public CognitiveServicesIPRule(string value) { }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties>
    {
        public CognitiveServicesKeyVaultProperties() { }
        public System.Guid? IdentityClientId { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel>
    {
        internal CognitiveServicesModel() { }
        public string Description { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel Model { get { throw null; } }
        public string SkuName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesModelSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku>
    {
        public CognitiveServicesModelSku() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig Capacity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.BillingMeterInfo> Cost { get { throw null; } }
        public System.DateTimeOffset? DeprecationOn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit> RateLimits { get { throw null; } }
        public string UsageName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesModelSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesMultiRegionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings>
    {
        public CognitiveServicesMultiRegionSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting> Regions { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod? RoutingMethod { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesNetworkRuleAction : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesNetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesNetworkRuleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet>
    {
        public CognitiveServicesNetworkRuleSet() { }
        public Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesNetworkSecurityPerimeter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter>
    {
        public CognitiveServicesNetworkSecurityPerimeter() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Guid? PerimeterGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesPatchResourceTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags>
    {
        public CognitiveServicesPatchResourceTags() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesPrivateLinkResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource>
    {
        public CognitiveServicesPrivateLinkResource() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties>
    {
        public CognitiveServicesPrivateLinkResourceProperties() { }
        public string DisplayName { get { throw null; } }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState>
    {
        public CognitiveServicesPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesProjectProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties>
    {
        public CognitiveServicesProjectProperties() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Endpoints { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesProjectProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesRegionSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting>
    {
        public CognitiveServicesRegionSetting() { }
        public string Customsubdomain { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public float? Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesResourceBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase>
    {
        public CognitiveServicesResourceBase() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesResourceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku>
    {
        internal CognitiveServicesResourceSku() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCapacityConfig Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesRoutingMethod : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesRoutingMethod(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod Performance { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod Priority { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod Weighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku>
    {
        public CognitiveServicesSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesSkuAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent>
    {
        public CognitiveServicesSkuAvailabilityContent(System.Collections.Generic.IEnumerable<string> skus, string kind, Azure.Core.ResourceType resourceType) { }
        public string Kind { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public System.Collections.Generic.IList<string> Skus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesSkuAvailabilityList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList>
    {
        internal CognitiveServicesSkuAvailabilityList() { }
        public bool? IsSkuAvailable { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        public string SkuAvailabilityType { get { throw null; } }
        public string SkuName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesSkuCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability>
    {
        internal CognitiveServicesSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesSkuChangeInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo>
    {
        internal CognitiveServicesSkuChangeInfo() { }
        public float? CountOfDowngrades { get { throw null; } }
        public float? CountOfUpgradesAfterDowngrades { get { throw null; } }
        public System.DateTimeOffset? LastChangedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesSkuRestrictionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo>
    {
        internal CognitiveServicesSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesSkuRestrictionReasonCode : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesSkuRestrictionReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions>
    {
        internal CognitiveServicesSkuRestrictions() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CognitiveServicesSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesSkuTier : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Enterprise { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesVirtualNetworkRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule>
    {
        public CognitiveServicesVirtualNetworkRule(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitmentCost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentCost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentCost>
    {
        internal CommitmentCost() { }
        public string CommitmentMeterId { get { throw null; } }
        public string OverageMeterId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentCost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentCost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitmentPeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod>
    {
        public CommitmentPeriod() { }
        public int? Count { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota Quota { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitmentPlanAssociation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation>
    {
        internal CommitmentPlanAssociation() { }
        public Azure.Core.ResourceIdentifier CommitmentPlanId { get { throw null; } }
        public string CommitmentPlanLocation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitmentPlanProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties>
    {
        public CommitmentPlanProperties() { }
        public bool? AutoRenew { get { throw null; } set { } }
        public System.Guid? CommitmentPlanGuid { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod Current { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel? HostingModel { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod Last { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod Next { get { throw null; } set { } }
        public string PlanType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> ProvisioningIssues { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommitmentPlanProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommitmentPlanProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommitmentQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota>
    {
        internal CommitmentQuota() { }
        public long? Quantity { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitmentTier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier>
    {
        internal CommitmentTier() { }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentCost Cost { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel? HostingModel { get { throw null; } }
        public string Kind { get { throw null; } }
        public int? MaxCount { get { throw null; } }
        public string PlanType { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota Quota { get { throw null; } }
        public string SkuName { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentTier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CommitmentTier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomBlocklistConfig : Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig>
    {
        public CustomBlocklistConfig() { }
        public Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource? Source { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomKeysConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties>
    {
        public CustomKeysConnectionProperties() { }
        public System.Collections.Generic.IDictionary<string, string> CredentialsKeys { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.CustomKeysConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefenderForAISettingState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefenderForAISettingState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState Disabled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState left, Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState left, Azure.ResourceManager.CognitiveServices.Models.DefenderForAISettingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentCapacitySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings>
    {
        public DeploymentCapacitySettings() { }
        public int? DesignatedCapacity { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.DeploymentCapacitySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentModelVersionUpgradeOption : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentModelVersionUpgradeOption(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption NoAutoUpgrade { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption OnceCurrentVersionExpired { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption OnceNewDefaultVersionAvailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption left, Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption left, Azure.ResourceManager.CognitiveServices.Models.DeploymentModelVersionUpgradeOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionScopeProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionScopeProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionScopeState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionScopeState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState left, Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState left, Azure.ResourceManager.CognitiveServices.Models.EncryptionScopeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIdentityAuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties>
    {
        public ManagedIdentityAuthTypeConnectionProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionManagedIdentity Credentials { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ManagedIdentityAuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedPERequirement : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedPERequirement(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement NotRequired { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement left, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement left, Azure.ResourceManager.CognitiveServices.Models.ManagedPERequirement right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedPEStatus : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedPEStatus(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus Active { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus left, Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus left, Azure.ResourceManager.CognitiveServices.Models.ManagedPEStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelCapacityCalculatorWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload>
    {
        public ModelCapacityCalculatorWorkload() { }
        public Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam RequestParameters { get { throw null; } set { } }
        public long? RequestPerMinute { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelCapacityCalculatorWorkloadRequestParam : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam>
    {
        public ModelCapacityCalculatorWorkloadRequestParam() { }
        public long? AvgGeneratedTokens { get { throw null; } set { } }
        public long? AvgPromptTokens { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityCalculatorWorkloadRequestParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelCapacityListResultValueItem : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem>
    {
        public ModelCapacityListResultValueItem() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelCapacityListResultValueItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelLifecycleStatus : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelLifecycleStatus(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus Deprecated { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus Deprecating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus GenerallyAvailable { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus Preview { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus Stable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus left, Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus left, Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelSkuCapacityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties>
    {
        public ModelSkuCapacityProperties() { }
        public float? AvailableCapacity { get { throw null; } set { } }
        public float? AvailableFinetuneCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel Model { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ModelSkuCapacityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterAccessRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule>
    {
        public NetworkSecurityPerimeterAccessRule() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterAccessRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties>
    {
        public NetworkSecurityPerimeterAccessRuleProperties() { }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection? Direction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FullyQualifiedDomainNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter> NetworkSecurityPerimeters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Subscriptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationAssociationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo>
    {
        public NetworkSecurityPerimeterConfigurationAssociationInfo() { }
        public string AccessMode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties>
    {
        public NetworkSecurityPerimeterConfigurationProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkSecurityPerimeter NetworkSecurityPerimeter { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo Profile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue> ProvisioningIssues { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationAssociationInfo ResourceAssociation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterProfileInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo>
    {
        public NetworkSecurityPerimeterProfileInfo() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule> AccessRules { get { throw null; } }
        public long? AccessRulesVersion { get { throw null; } set { } }
        public long? DiagnosticSettingsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnabledLogCategories { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProfileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterProvisioningIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue>
    {
        public NetworkSecurityPerimeterProvisioningIssue() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterProvisioningIssueProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties>
    {
        public NetworkSecurityPerimeterProvisioningIssueProperties() { }
        public string Description { get { throw null; } set { } }
        public string IssueType { get { throw null; } set { } }
        public string Severity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterAccessRule> SuggestedAccessRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SuggestedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoneAuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties>
    {
        public NoneAuthTypeConnectionProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.NoneAuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NspAccessRuleDirection : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NspAccessRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection left, Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection left, Azure.ResourceManager.CognitiveServices.Models.NspAccessRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OAuth2AuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties>
    {
        public OAuth2AuthTypeConnectionProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionOAuth2 Credentials { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.OAuth2AuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatAuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties>
    {
        public PatAuthTypeConnectionProperties() { }
        public string CredentialsPat { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.PatAuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchResourceTagsAndSku : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku>
    {
        public PatchResourceTagsAndSku() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.PatchResourceTagsAndSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiBlocklistConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig>
    {
        public RaiBlocklistConfig() { }
        public bool? Blocking { get { throw null; } set { } }
        public string BlocklistName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiBlocklistItemBulkContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent>
    {
        public RaiBlocklistItemBulkContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemBulkContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiBlocklistItemProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties>
    {
        public RaiBlocklistItemProperties() { }
        public bool? IsRegex { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiBlocklistItemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiContentFilterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties>
    {
        public RaiContentFilterProperties() { }
        public bool? IsMultiLevelFilter { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource? Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiContentFilterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiMonitorConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig>
    {
        public RaiMonitorConfig() { }
        public Azure.Core.ResourceIdentifier AdxStorageResourceId { get { throw null; } set { } }
        public System.Guid? IdentityClientId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiMonitorConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiPolicyContentFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter>
    {
        public RaiPolicyContentFilter() { }
        public bool? Blocking { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel? SeverityThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource? Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RaiPolicyContentLevel : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RaiPolicyContentLevel(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel High { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel Low { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel left, Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel left, Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RaiPolicyContentSource : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RaiPolicyContentSource(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource Completion { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource Prompt { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource left, Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource left, Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RaiPolicyMode : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RaiPolicyMode(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode AsynchronousFilter { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode Blocking { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode Default { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode Deferred { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode left, Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode left, Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RaiPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties>
    {
        public RaiPolicyProperties() { }
        public string BasePolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyContentFilter> ContentFilters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.CustomBlocklistConfig> CustomBlocklists { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.RaiPolicyMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType? PolicyType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RaiPolicyType : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RaiPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType SystemManaged { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType UserManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType left, Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType left, Azure.ResourceManager.CognitiveServices.Models.RaiPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateServiceAccountKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent>
    {
        public RegenerateServiceAccountKeyContent(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountKeyName keyName) { }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountKeyName KeyName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SASAuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties>
    {
        public SASAuthTypeConnectionProperties() { }
        public string CredentialsSas { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.SASAuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAccountApiKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>
    {
        internal ServiceAccountApiKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAccountApiProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties>
    {
        public ServiceAccountApiProperties() { }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? EnableStatistics { get { throw null; } set { } }
        public string EventHubConnectionString { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier QnaAzureSearchEndpointId { get { throw null; } set { } }
        public string QnaAzureSearchEndpointKey { get { throw null; } set { } }
        public string QnaRuntimeEndpoint { get { throw null; } set { } }
        public string StorageAccountConnectionString { get { throw null; } set { } }
        public string SuperUser { get { throw null; } set { } }
        public string WebsiteName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAccountCallRateLimit : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit>
    {
        internal ServiceAccountCallRateLimit() { }
        public float? Count { get { throw null; } }
        public float? RenewalPeriod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> Rules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountEncryptionKeySource : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountEncryptionKeySource(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource MicrosoftCognitiveServices { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource MicrosoftKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAccountEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties>
    {
        public ServiceAccountEncryptionProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Guid? IdentityClientId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource? KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public string KeyVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountHostingModel : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountHostingModel(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel ConnectedContainer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel DisconnectedContainer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel ProvisionedWeb { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ServiceAccountKeyName
    {
        Key1 = 0,
        Key2 = 1,
    }
    public partial class ServiceAccountModelDeprecationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo>
    {
        public ServiceAccountModelDeprecationInfo() { }
        public System.DateTimeOffset? FineTuneOn { get { throw null; } set { } }
        public System.DateTimeOffset? InferenceOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState ResolvingDns { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAccountQuotaLimit : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit>
    {
        internal ServiceAccountQuotaLimit() { }
        public float? Count { get { throw null; } }
        public float? RenewalPeriod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> Rules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountQuotaUsageStatus : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountQuotaUsageStatus(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus Blocked { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus Included { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus InOverage { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAccountThrottlingMatchPattern : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern>
    {
        internal ServiceAccountThrottlingMatchPattern() { }
        public string Method { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAccountThrottlingRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule>
    {
        internal ServiceAccountThrottlingRule() { }
        public float? Count { get { throw null; } }
        public bool? IsDynamicThrottlingEnabled { get { throw null; } }
        public string Key { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern> MatchPatterns { get { throw null; } }
        public float? MinCount { get { throw null; } }
        public float? RenewalPeriod { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAccountUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage>
    {
        internal ServiceAccountUsage() { }
        public double? CurrentValue { get { throw null; } }
        public double? Limit { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName Name { get { throw null; } }
        public string NextResetTime { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus? Status { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAccountUsageMetricName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName>
    {
        internal ServiceAccountUsageMetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountUsageUnitType : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountUsageUnitType(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Bytes { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Count { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Milliseconds { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Percent { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAccountUserOwnedStorage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage>
    {
        public ServiceAccountUserOwnedStorage() { }
        public System.Guid? IdentityClientId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePrincipalAuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties>
    {
        public ServicePrincipalAuthTypeConnectionProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionServicePrincipal Credentials { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.ServicePrincipalAuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrustedServicesByPassSelection : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrustedServicesByPassSelection(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection AzureServices { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection left, Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection left, Azure.ResourceManager.CognitiveServices.Models.TrustedServicesByPassSelection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UsernamePasswordAuthTypeConnectionProperties : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties>
    {
        public UsernamePasswordAuthTypeConnectionProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesConnectionUsernamePassword Credentials { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.UsernamePasswordAuthTypeConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserOwnedAmlWorkspace : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace>
    {
        public UserOwnedAmlWorkspace() { }
        public System.Guid? IdentityClientId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CognitiveServices.Models.UserOwnedAmlWorkspace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
