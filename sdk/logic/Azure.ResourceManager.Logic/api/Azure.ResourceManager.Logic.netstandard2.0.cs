namespace Azure.ResourceManager.Logic
{
    public partial class IntegrationAccountAgreementCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountAgreementCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agreementName, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agreementName, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> Get(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> GetAsync(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> GetIfExists(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> GetIfExistsAsync(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountAgreementData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountAgreementData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountAgreementData>
    {
        public IntegrationAccountAgreementData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementType agreementType, string hostPartner, string guestPartner, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity hostIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity guestIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent content) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementType AgreementType { get { throw null; } set { } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity GuestIdentity { get { throw null; } set { } }
        public string GuestPartner { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity HostIdentity { get { throw null; } set { } }
        public string HostPartner { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        Azure.ResourceManager.Logic.IntegrationAccountAgreementData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountAgreementData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountAgreementData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationAccountAgreementData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountAgreementData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountAgreementData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountAgreementData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountAgreementResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountAgreementResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAgreementData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string agreementName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountAssemblyDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountAssemblyDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assemblyArtifactName, Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assemblyArtifactName, Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> Get(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> GetAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> GetIfExists(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> GetIfExistsAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountAssemblyDefinitionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData>
    {
        public IntegrationAccountAssemblyDefinitionData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties properties) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountAssemblyDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountAssemblyDefinitionResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string assemblyArtifactName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountBatchConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountBatchConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string batchConfigurationName, Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string batchConfigurationName, Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> Get(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> GetAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> GetIfExists(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> GetIfExistsAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountBatchConfigurationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData>
    {
        public IntegrationAccountBatchConfigurationData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties properties) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountBatchConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountBatchConfigurationResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string batchConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Logic.IntegrationAccountCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Logic.IntegrationAccountCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> GetIfExists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> GetIfExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountCertificateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountCertificateData>
    {
        public IntegrationAccountCertificateData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference Key { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.BinaryData PublicCertificate { get { throw null; } set { } }
        Azure.ResourceManager.Logic.IntegrationAccountCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationAccountCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountCertificateResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationAccountName, Azure.ResourceManager.Logic.IntegrationAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationAccountName, Azure.ResourceManager.Logic.IntegrationAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> Get(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetAsync(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIfExists(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetIfExistsAsync(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountData>
    {
        public IntegrationAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } set { } }
        Azure.ResourceManager.Logic.IntegrationAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountMapCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountMapResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountMapResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountMapCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountMapResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mapName, Azure.ResourceManager.Logic.IntegrationAccountMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mapName, Azure.ResourceManager.Logic.IntegrationAccountMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> Get(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountMapResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountMapResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> GetAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountMapResource> GetIfExists(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> GetIfExistsAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountMapResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountMapResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountMapResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountMapResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountMapData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountMapData>
    {
        public IntegrationAccountMapData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountMapType mapType) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.BinaryData Content { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink ContentLink { get { throw null; } }
        public Azure.Core.ContentType? ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountMapType MapType { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string ParametersSchemaRef { get { throw null; } set { } }
        Azure.ResourceManager.Logic.IntegrationAccountMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationAccountMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountMapResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountMapResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountMapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string mapName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountMapResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountPartnerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountPartnerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerName, Azure.ResourceManager.Logic.IntegrationAccountPartnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerName, Azure.ResourceManager.Logic.IntegrationAccountPartnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> Get(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> GetAsync(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> GetIfExists(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> GetIfExistsAsync(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountPartnerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountPartnerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountPartnerData>
    {
        public IntegrationAccountPartnerData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType partnerType, Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent content) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity> B2BBusinessIdentities { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType PartnerType { get { throw null; } set { } }
        Azure.ResourceManager.Logic.IntegrationAccountPartnerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountPartnerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountPartnerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationAccountPartnerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountPartnerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountPartnerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountPartnerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountPartnerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountPartnerResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountPartnerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string partnerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountPartnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountPartnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri> GetCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri>> GetCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> GetIntegrationAccountAgreement(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> GetIntegrationAccountAgreementAsync(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAgreementCollection GetIntegrationAccountAgreements() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> GetIntegrationAccountAssemblyDefinition(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> GetIntegrationAccountAssemblyDefinitionAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionCollection GetIntegrationAccountAssemblyDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> GetIntegrationAccountBatchConfiguration(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> GetIntegrationAccountBatchConfigurationAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationCollection GetIntegrationAccountBatchConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> GetIntegrationAccountCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> GetIntegrationAccountCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountCertificateCollection GetIntegrationAccountCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> GetIntegrationAccountMap(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> GetIntegrationAccountMapAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountMapCollection GetIntegrationAccountMaps() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> GetIntegrationAccountPartner(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> GetIntegrationAccountPartnerAsync(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountPartnerCollection GetIntegrationAccountPartners() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> GetIntegrationAccountSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> GetIntegrationAccountSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSchemaCollection GetIntegrationAccountSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> GetIntegrationAccountSession(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> GetIntegrationAccountSessionAsync(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSessionCollection GetIntegrationAccountSessions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey> GetKeyVaultKeys(Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey> GetKeyVaultKeysAsync(Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response LogTrackingEvents(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> LogTrackingEventsAsync(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> RegenerateAccessKey(Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> RegenerateAccessKeyAsync(Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> Update(Azure.ResourceManager.Logic.IntegrationAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> UpdateAsync(Azure.ResourceManager.Logic.IntegrationAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.Logic.IntegrationAccountSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.Logic.IntegrationAccountSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> GetIfExists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> GetIfExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountSchemaData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountSchemaData>
    {
        public IntegrationAccountSchemaData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType schemaType) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.BinaryData Content { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink ContentLink { get { throw null; } }
        public Azure.Core.ContentType? ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DocumentName { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType SchemaType { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
        Azure.ResourceManager.Logic.IntegrationAccountSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationAccountSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountSchemaResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string schemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountSessionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountSessionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sessionName, Azure.ResourceManager.Logic.IntegrationAccountSessionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sessionName, Azure.ResourceManager.Logic.IntegrationAccountSessionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> Get(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> GetAsync(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> GetIfExists(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> GetIfExistsAsync(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountSessionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountSessionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountSessionData>
    {
        public IntegrationAccountSessionData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.BinaryData Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        Azure.ResourceManager.Logic.IntegrationAccountSessionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountSessionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationAccountSessionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationAccountSessionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountSessionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountSessionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationAccountSessionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountSessionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountSessionResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSessionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string sessionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountSessionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountSessionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>, System.Collections.IEnumerable
    {
        protected IntegrationServiceEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationServiceEnvironmentName, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationServiceEnvironmentName, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> Get(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> GetAsync(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIfExists(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> GetIfExistsAsync(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData>
    {
        public IntegrationServiceEnvironmentData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku Sku { get { throw null; } set { } }
        Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentManagedApiCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>, System.Collections.IEnumerable
    {
        protected IntegrationServiceEnvironmentManagedApiCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> Get(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> GetAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> GetIfExists(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> GetIfExistsAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentManagedApiData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData>
    {
        public IntegrationServiceEnvironmentManagedApiData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions ApiDefinitions { get { throw null; } }
        public System.Uri ApiDefinitionUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiTier? Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ConnectionParameters { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink DeploymentParametersContentLinkDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation GeneralInformation { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata Metadata { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies Policies { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Uri> RuntimeUris { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } }
        Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentManagedApiResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationServiceEnvironmentManagedApiResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroup, string integrationServiceEnvironmentName, string apiName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo> GetIntegrationServiceEnvironmentManagedApiOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo> GetIntegrationServiceEnvironmentManagedApiOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationServiceEnvironmentResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroup, string integrationServiceEnvironmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> GetIntegrationServiceEnvironmentManagedApi(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> GetIntegrationServiceEnvironmentManagedApiAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiCollection GetIntegrationServiceEnvironmentManagedApis() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>> GetIntegrationServiceEnvironmentNetworkHealth(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>>> GetIntegrationServiceEnvironmentNetworkHealthAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition> GetIntegrationServiceEnvironmentSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition> GetIntegrationServiceEnvironmentSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restart(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class LogicExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountAgreementResource GetIntegrationAccountAgreementResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource GetIntegrationAccountAssemblyDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetIntegrationAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource GetIntegrationAccountBatchConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountCertificateResource GetIntegrationAccountCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountMapResource GetIntegrationAccountMapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountPartnerResource GetIntegrationAccountPartnerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountResource GetIntegrationAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountCollection GetIntegrationAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountSchemaResource GetIntegrationAccountSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountSessionResource GetIntegrationAccountSessionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIntegrationServiceEnvironment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> GetIntegrationServiceEnvironmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource GetIntegrationServiceEnvironmentManagedApiResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource GetIntegrationServiceEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationServiceEnvironmentCollection GetIntegrationServiceEnvironments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIntegrationServiceEnvironments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIntegrationServiceEnvironmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> GetLogicWorkflow(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> GetLogicWorkflowAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowResource GetLogicWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource GetLogicWorkflowRunActionRepetitionRequestHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource GetLogicWorkflowRunActionRepetitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource GetLogicWorkflowRunActionRequestHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionResource GetLogicWorkflowRunActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource GetLogicWorkflowRunActionScopeRepetitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource GetLogicWorkflowRunOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunResource GetLogicWorkflowRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowCollection GetLogicWorkflows(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetLogicWorkflows(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetLogicWorkflowsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource GetLogicWorkflowTriggerHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowTriggerResource GetLogicWorkflowTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowVersionResource GetLogicWorkflowVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response ValidateByLocationWorkflow(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ValidateByLocationWorkflowAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.LogicWorkflowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.LogicWorkflowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> Get(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> GetAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowResource> GetIfExists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowResource>> GetIfExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowData>
    {
        public LogicWorkflowData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration AccessControl { get { throw null; } set { } }
        public string AccessEndpoint { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.BinaryData Definition { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationAccount { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo> Parameters { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicSku Sku { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } set { } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.Logic.LogicWorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.LogicWorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRequestHistoryData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData>
    {
        public LogicWorkflowRequestHistoryData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Enable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GenerateUpgradedDefinition(Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GenerateUpgradedDefinitionAsync(Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource> GetLogicWorkflowRun(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource>> GetLogicWorkflowRunAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunCollection GetLogicWorkflowRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> GetLogicWorkflowTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>> GetLogicWorkflowTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerCollection GetLogicWorkflowTriggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> GetLogicWorkflowVersion(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>> GetLogicWorkflowVersionAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowVersionCollection GetLogicWorkflowVersions() { throw null; }
        public virtual Azure.Response<System.BinaryData> GetSwagger(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetSwaggerAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Move(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.Models.LogicWorkflowReference move, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.Models.LogicWorkflowReference move, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateAccessKey(Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateAccessKeyAsync(Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.LogicWorkflowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use Update(WaitUntil waitUntil, LogicWorkflowData data, CancellationToken cancellationToken = default) instead.", false)]
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> Update(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.LogicWorkflowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use UpdateAsync(WaitUntil waitUntil, LogicWorkflowData data, CancellationToken cancellationToken = default) instead.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> UpdateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ValidateByResourceGroup(Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateByResourceGroupAsync(Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionCollection() { }
        public virtual Azure.Response<bool> Exists(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> Get(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>> GetAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> GetIfExists(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>> GetIfExistsAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionData>
    {
        internal LogicWorkflowRunActionData() { }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation Correlation { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink InputsLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink OutputsLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory> RetryHistory { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public System.BinaryData TrackedProperties { get { throw null; } }
        public System.Guid? TrackingId { get { throw null; } }
        Azure.ResourceManager.Logic.LogicWorkflowRunActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.LogicWorkflowRunActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRunActionRepetitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionRepetitionCollection() { }
        public virtual Azure.Response<bool> Exists(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> Get(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>> GetAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> GetIfExists(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>> GetIfExistsAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionRepetitionDefinitionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData>
    {
        public LogicWorkflowRunActionRepetitionDefinitionData(Azure.Core.AzureLocation location) { }
        public string Code { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation Correlation { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.BinaryData Error { get { throw null; } set { } }
        public System.BinaryData Inputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink InputsLink { get { throw null; } }
        public int? IterationCount { get { throw null; } set { } }
        public System.BinaryData Outputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink OutputsLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex> RepetitionIndexes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory> RetryHistory { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } set { } }
        public System.BinaryData TrackedProperties { get { throw null; } }
        public System.Guid? TrackingId { get { throw null; } }
        Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRunActionRepetitionRequestHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionRepetitionRequestHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> Get(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>> GetAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> GetIfExists(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>> GetIfExistsAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionRepetitionRequestHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionRepetitionRequestHistoryResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string repetitionName, string requestHistoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunActionRepetitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionRepetitionResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string repetitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.LogicExpressionRoot> GetExpressionTraces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.LogicExpressionRoot> GetExpressionTracesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryCollection GetLogicWorkflowRunActionRepetitionRequestHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> GetLogicWorkflowRunActionRepetitionRequestHistory(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>> GetLogicWorkflowRunActionRepetitionRequestHistoryAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunActionRequestHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionRequestHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> Get(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>> GetAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> GetIfExists(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>> GetIfExistsAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionRequestHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionRequestHistoryResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string requestHistoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunActionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.LogicExpressionRoot> GetExpressionTraces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.LogicExpressionRoot> GetExpressionTracesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> GetLogicWorkflowRunActionRepetition(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>> GetLogicWorkflowRunActionRepetitionAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionCollection GetLogicWorkflowRunActionRepetitions() { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryCollection GetLogicWorkflowRunActionRequestHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> GetLogicWorkflowRunActionRequestHistory(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>> GetLogicWorkflowRunActionRequestHistoryAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> GetLogicWorkflowRunActionScopeRepetition(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>> GetLogicWorkflowRunActionScopeRepetitionAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionCollection GetLogicWorkflowRunActionScopeRepetitions() { throw null; }
    }
    public partial class LogicWorkflowRunActionScopeRepetitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionScopeRepetitionCollection() { }
        public virtual Azure.Response<bool> Exists(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> Get(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>> GetAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> GetIfExists(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>> GetIfExistsAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionScopeRepetitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionScopeRepetitionResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string repetitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunCollection() { }
        public virtual Azure.Response<bool> Exists(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource> Get(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource>> GetAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunResource> GetIfExists(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunResource>> GetIfExistsAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunData>
    {
        internal LogicWorkflowRunData() { }
        public string Code { get { throw null; } }
        public string CorrelationClientTrackingId { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo> Outputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger Response { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger Trigger { get { throw null; } }
        public System.DateTimeOffset? WaitEndOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference Workflow { get { throw null; } }
        Azure.ResourceManager.Logic.LogicWorkflowRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.LogicWorkflowRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRunOperationCollection : Azure.ResourceManager.ArmCollection
    {
        protected LogicWorkflowRunOperationCollection() { }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource> GetIfExists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource>> GetIfExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunOperationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunOperationResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> GetLogicWorkflowRunAction(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>> GetLogicWorkflowRunActionAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionCollection GetLogicWorkflowRunActions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource> GetLogicWorkflowRunOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource>> GetLogicWorkflowRunOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunOperationCollection GetLogicWorkflowRunOperations() { throw null; }
    }
    public partial class LogicWorkflowTriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowTriggerCollection() { }
        public virtual Azure.Response<bool> Exists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> Get(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>> GetAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> GetIfExists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>> GetIfExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowTriggerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerData>
    {
        internal LogicWorkflowTriggerData() { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastExecutionOn { get { throw null; } }
        public System.DateTimeOffset? NextExecutionOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence Recurrence { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference Workflow { get { throw null; } }
        Azure.ResourceManager.Logic.LogicWorkflowTriggerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.LogicWorkflowTriggerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowTriggerHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowTriggerHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> Get(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>> GetAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> GetIfExists(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>> GetIfExistsAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowTriggerHistoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData>
    {
        internal LogicWorkflowTriggerHistoryData() { }
        public string Code { get { throw null; } }
        public string CorrelationClientTrackingId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink InputsLink { get { throw null; } }
        public bool? IsFired { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink OutputsLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference Run { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public System.Guid? TrackingId { get { throw null; } }
        Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowTriggerHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowTriggerHistoryResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string triggerName, string historyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resubmit(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResubmitAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowTriggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowTriggerResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string triggerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetCallbackUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetCallbackUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryCollection GetLogicWorkflowTriggerHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> GetLogicWorkflowTriggerHistory(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>> GetLogicWorkflowTriggerHistoryAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicJsonSchema> GetSchemaJson(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicJsonSchema>> GetSchemaJsonAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reset(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Run(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetState(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetStateAsync(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> Get(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>> GetAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> GetIfExists(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>> GetIfExistsAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowVersionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowVersionData>
    {
        public LogicWorkflowVersionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration AccessControl { get { throw null; } set { } }
        public string AccessEndpoint { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.BinaryData Definition { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationAccount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo> Parameters { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicSku Sku { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } set { } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.Logic.LogicWorkflowVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.LogicWorkflowVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.LogicWorkflowVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.LogicWorkflowVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowVersionResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string versionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetCallbackUrlWorkflowVersionTrigger(string triggerName, Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetCallbackUrlWorkflowVersionTriggerAsync(string triggerName, Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Logic.Mocking
{
    public partial class MockableLogicArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableLogicArmClient() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAgreementResource GetIntegrationAccountAgreementResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource GetIntegrationAccountAssemblyDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource GetIntegrationAccountBatchConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountCertificateResource GetIntegrationAccountCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountMapResource GetIntegrationAccountMapResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountPartnerResource GetIntegrationAccountPartnerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountResource GetIntegrationAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSchemaResource GetIntegrationAccountSchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSessionResource GetIntegrationAccountSessionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource GetIntegrationServiceEnvironmentManagedApiResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource GetIntegrationServiceEnvironmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowResource GetLogicWorkflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource GetLogicWorkflowRunActionRepetitionRequestHistoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource GetLogicWorkflowRunActionRepetitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource GetLogicWorkflowRunActionRequestHistoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionResource GetLogicWorkflowRunActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource GetLogicWorkflowRunActionScopeRepetitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource GetLogicWorkflowRunOperationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunResource GetLogicWorkflowRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource GetLogicWorkflowTriggerHistoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerResource GetLogicWorkflowTriggerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowVersionResource GetLogicWorkflowVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableLogicResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLogicResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccount(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetIntegrationAccountAsync(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountCollection GetIntegrationAccounts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIntegrationServiceEnvironment(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> GetIntegrationServiceEnvironmentAsync(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationServiceEnvironmentCollection GetIntegrationServiceEnvironments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> GetLogicWorkflow(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> GetLogicWorkflowAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowCollection GetLogicWorkflows() { throw null; }
        public virtual Azure.Response ValidateByLocationWorkflow(Azure.Core.AzureLocation location, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateByLocationWorkflowAsync(Azure.Core.AzureLocation location, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableLogicSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLogicSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccounts(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccountsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIntegrationServiceEnvironments(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIntegrationServiceEnvironmentsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetLogicWorkflows(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetLogicWorkflowsAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Logic.Models
{
    public static partial class ArmLogicModelFactory
    {
        public static Azure.ResourceManager.Logic.IntegrationAccountAgreementData IntegrationAccountAgreementData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), System.BinaryData metadata = null, Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementType agreementType = Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementType.NotSpecified, string hostPartner = null, string guestPartner = null, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity hostIdentity = null, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity guestIdentity = null, Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent content = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData IntegrationAccountAssemblyDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData IntegrationAccountBatchConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountCertificateData IntegrationAccountCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), System.BinaryData metadata = null, Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference key = null, System.BinaryData publicCertificate = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountData IntegrationAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName? skuName = default(Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName?), Azure.ResourceManager.Logic.Models.LogicResourceReference integrationServiceEnvironment = null, Azure.ResourceManager.Logic.Models.LogicWorkflowState? state = default(Azure.ResourceManager.Logic.Models.LogicWorkflowState?)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey IntegrationAccountKeyVaultKey(System.Uri keyId = null, bool? isEnabled = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference IntegrationAccountKeyVaultKeyReference(string keyName = null, string keyVersion = null, Azure.Core.ResourceIdentifier resourceId = null, string resourceName = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference IntegrationAccountKeyVaultNameReference(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent IntegrationAccountListKeyVaultKeyContent(Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference keyVault = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountMapData IntegrationAccountMapData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.IntegrationAccountMapType mapType = default(Azure.ResourceManager.Logic.Models.IntegrationAccountMapType), string parametersSchemaRef = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), System.BinaryData content = null, Azure.Core.ContentType? contentType = default(Azure.Core.ContentType?), Azure.ResourceManager.Logic.Models.LogicContentLink contentLink = null, System.BinaryData metadata = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountPartnerData IntegrationAccountPartnerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType partnerType = default(Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), System.BinaryData metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity> b2bBusinessIdentities = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountSchemaData IntegrationAccountSchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType schemaType = default(Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType), string targetNamespace = null, string documentName = null, string fileName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), System.BinaryData metadata = null, System.BinaryData content = null, Azure.Core.ContentType? contentType = default(Azure.Core.ContentType?), Azure.ResourceManager.Logic.Models.LogicContentLink contentLink = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountSessionData IntegrationAccountSessionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent IntegrationAccountTrackingEvent(Azure.ResourceManager.Logic.Models.IntegrationAccountEventLevel eventLevel = Azure.ResourceManager.Logic.Models.IntegrationAccountEventLevel.LogAlways, System.DateTimeOffset eventOn = default(System.DateTimeOffset), Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType recordType = default(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType), System.BinaryData record = null, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo error = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent IntegrationAccountTrackingEventsContent(string sourceType = null, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption? trackEventsOptions = default(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent> events = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData IntegrationServiceEnvironmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties properties = null, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData IntegrationServiceEnvironmentManagedApiData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string namePropertiesName = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> connectionParameters = null, Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata metadata = null, System.Collections.Generic.IEnumerable<System.Uri> runtimeUris = null, Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation generalInformation = null, System.Collections.Generic.IEnumerable<string> capabilities = null, System.Uri serviceUri = null, Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies policies = null, System.Uri apiDefinitionUri = null, Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions apiDefinitions = null, Azure.ResourceManager.Logic.Models.LogicResourceReference integrationServiceEnvironment = null, Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? provisioningState = default(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState?), Azure.ResourceManager.Logic.Models.LogicApiTier? category = default(Azure.ResourceManager.Logic.Models.LogicApiTier?), Azure.ResourceManager.Logic.Models.LogicContentLink deploymentParametersContentLinkDefinition = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency IntegrationServiceEnvironmentNetworkDependency(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType? category = default(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType?), string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint> endpoints = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth IntegrationServiceEnvironmentNetworkDependencyHealth(Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo error = null, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState? state = default(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState?)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint IntegrationServiceEnvironmentNetworkEndpoint(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState? accessibility = default(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState?), string domainName = null, System.Collections.Generic.IEnumerable<string> ports = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity IntegrationServiceEnvironmentSkuCapacity(int? minimum = default(int?), int? maximum = default(int?), int? @default = default(int?), Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType? scaleType = default(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType?)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition IntegrationServiceEnvironmentSkuDefinition(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku sku = null, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku IntegrationServiceEnvironmentSkuDefinitionSku(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName? name = default(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName?), string tier = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth IntegrationServiceEnvironmentSubnetNetworkHealth(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency> outboundNetworkDependencies = null, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth outboundNetworkHealth = null, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState networkDependencyHealthState = default(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo IntegrationServiceErrorInfo(Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode code = default(Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo> details = null, System.BinaryData innerError = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.ListOperationCallbackUri ListOperationCallbackUri(System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata LogicApiDeploymentParameterMetadata(string apiDeploymentParameterMetadataType = null, bool? isRequired = default(bool?), string displayName = null, string description = null, Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility? visibility = default(Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility?)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet LogicApiDeploymentParameterMetadataSet(Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata packageContentLink = null, Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata redisCacheConnectionString = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiOperationInfo LogicApiOperationInfo(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.LogicApiOperationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiReference LogicApiReference(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string displayName = null, string description = null, System.Uri iconUri = null, System.BinaryData swagger = null, string brandColor = null, Azure.ResourceManager.Logic.Models.LogicApiTier? category = default(Azure.ResourceManager.Logic.Models.LogicApiTier?), Azure.ResourceManager.Logic.Models.LogicResourceReference integrationServiceEnvironment = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions LogicApiResourceDefinitions(System.Uri originalSwaggerUri = null, System.Uri modifiedSwaggerUri = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation LogicApiResourceGeneralInformation(System.Uri iconUri = null, string displayName = null, string description = null, System.Uri termsOfUseUri = null, string releaseTag = null, Azure.ResourceManager.Logic.Models.LogicApiTier? tier = default(Azure.ResourceManager.Logic.Models.LogicApiTier?)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata LogicApiResourceMetadata(string source = null, string brandColor = null, string hideKey = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.ResourceManager.Logic.Models.LogicApiType? apiType = default(Azure.ResourceManager.Logic.Models.LogicApiType?), Azure.ResourceManager.Logic.Models.LogicWsdlService wsdlService = null, Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod? wsdlImportMethod = default(Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod?), string connectionType = null, Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? provisioningState = default(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState?), Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet deploymentParameters = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies LogicApiResourcePolicies(System.BinaryData content = null, string contentLink = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicContentHash LogicContentHash(string algorithm = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicContentLink LogicContentLink(System.Uri uri = null, string contentVersion = null, long? contentSize = default(long?), Azure.ResourceManager.Logic.Models.LogicContentHash contentHash = null, System.BinaryData metadata = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicErrorInfo LogicErrorInfo(string code = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicExpression LogicExpression(string text = null, System.BinaryData value = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.LogicExpression> subexpressions = null, Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo error = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo LogicExpressionErrorInfo(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo> details = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicExpressionRoot LogicExpressionRoot(string text = null, System.BinaryData value = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.LogicExpression> subexpressions = null, Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo error = null, string path = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicJsonSchema LogicJsonSchema(string title = null, System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicResourceReference LogicResourceReference(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicSku LogicSku(Azure.ResourceManager.Logic.Models.LogicSkuName name = default(Azure.ResourceManager.Logic.Models.LogicSkuName), Azure.ResourceManager.Logic.Models.LogicResourceReference plan = null) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowData LogicWorkflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? provisioningState = default(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Logic.Models.LogicWorkflowState? state = default(Azure.ResourceManager.Logic.Models.LogicWorkflowState?), string version = null, string accessEndpoint = null, Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration endpointsConfiguration = null, Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration accessControl = null, Azure.ResourceManager.Logic.Models.LogicSku sku = null, Azure.ResourceManager.Logic.Models.LogicResourceReference integrationAccount = null, Azure.ResourceManager.Logic.Models.LogicResourceReference integrationServiceEnvironment = null, System.BinaryData definition = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo> parameters = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo LogicWorkflowOutputParameterInfo(Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType? parameterType = default(Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType?), System.BinaryData value = null, System.BinaryData metadata = null, string description = null, System.BinaryData error = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowReference LogicWorkflowReference(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData LogicWorkflowRequestHistoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionData LogicWorkflowRunActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? status = default(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus?), string code = null, System.BinaryData error = null, System.Guid? trackingId = default(System.Guid?), Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation correlation = null, Azure.ResourceManager.Logic.Models.LogicContentLink inputsLink = null, Azure.ResourceManager.Logic.Models.LogicContentLink outputsLink = null, System.BinaryData trackedProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory> retryHistory = null) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData LogicWorkflowRunActionRepetitionDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation correlation = null, Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? status = default(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus?), string code = null, System.BinaryData error = null, System.Guid? trackingId = default(System.Guid?), System.BinaryData inputs = null, Azure.ResourceManager.Logic.Models.LogicContentLink inputsLink = null, System.BinaryData outputs = null, Azure.ResourceManager.Logic.Models.LogicContentLink outputsLink = null, System.BinaryData trackedProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory> retryHistory = null, int? iterationCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex> repetitionIndexes = null) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunData LogicWorkflowRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? waitEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? status = default(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus?), string code = null, System.BinaryData error = null, string correlationId = null, string correlationClientTrackingId = null, Azure.ResourceManager.Logic.Models.LogicResourceReference workflow = null, Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger trigger = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo> outputs = null, Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger response = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger LogicWorkflowRunTrigger(string name = null, System.BinaryData inputs = null, Azure.ResourceManager.Logic.Models.LogicContentLink inputsLink = null, System.BinaryData outputs = null, Azure.ResourceManager.Logic.Models.LogicContentLink outputsLink = null, System.DateTimeOffset? scheduledOn = default(System.DateTimeOffset?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Guid? trackingId = default(System.Guid?), string correlationClientTrackingId = null, string code = null, Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? status = default(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus?), System.BinaryData error = null, System.BinaryData trackedProperties = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo LogicWorkflowTriggerCallbackQueryParameterInfo(string apiVersion = null, string sp = null, string sv = null, string sig = null, string se = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri LogicWorkflowTriggerCallbackUri(string value = null, Azure.Core.RequestMethod? method = default(Azure.Core.RequestMethod?), string basePath = null, string relativePath = null, System.Collections.Generic.IEnumerable<string> relativePathParameters = null, Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo queries = null) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowTriggerData LogicWorkflowTriggerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState? provisioningState = default(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Logic.Models.LogicWorkflowState? state = default(Azure.ResourceManager.Logic.Models.LogicWorkflowState?), Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? status = default(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus?), System.DateTimeOffset? lastExecutionOn = default(System.DateTimeOffset?), System.DateTimeOffset? nextExecutionOn = default(System.DateTimeOffset?), Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence recurrence = null, Azure.ResourceManager.Logic.Models.LogicResourceReference workflow = null) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData LogicWorkflowTriggerHistoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledOn = default(System.DateTimeOffset?), Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? status = default(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus?), string code = null, System.BinaryData error = null, System.Guid? trackingId = default(System.Guid?), string correlationClientTrackingId = null, Azure.ResourceManager.Logic.Models.LogicContentLink inputsLink = null, Azure.ResourceManager.Logic.Models.LogicContentLink outputsLink = null, bool? isFired = default(bool?), Azure.ResourceManager.Logic.Models.LogicResourceReference run = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference LogicWorkflowTriggerReference(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string flowName = null, string triggerName = null) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowVersionData LogicWorkflowVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? provisioningState = default(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Logic.Models.LogicWorkflowState? state = default(Azure.ResourceManager.Logic.Models.LogicWorkflowState?), string version = null, string accessEndpoint = null, Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration endpointsConfiguration = null, Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration accessControl = null, Azure.ResourceManager.Logic.Models.LogicSku sku = null, Azure.ResourceManager.Logic.Models.LogicResourceReference integrationAccount = null, System.BinaryData definition = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo> parameters = null) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWsdlService LogicWsdlService(string qualifiedName = null, System.Collections.Generic.IEnumerable<string> endpointQualifiedNames = null) { throw null; }
    }
    public partial class ArtifactContentProperties : Azure.ResourceManager.Logic.Models.ArtifactProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ArtifactContentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ArtifactContentProperties>
    {
        public ArtifactContentProperties() { }
        public System.BinaryData Content { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink ContentLink { get { throw null; } set { } }
        public Azure.Core.ContentType? ContentType { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.ArtifactContentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ArtifactContentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ArtifactContentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.ArtifactContentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ArtifactContentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ArtifactContentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ArtifactContentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArtifactProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ArtifactProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ArtifactProperties>
    {
        public ArtifactProperties() { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.ArtifactProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ArtifactProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ArtifactProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.ArtifactProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ArtifactProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ArtifactProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ArtifactProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AS2AcknowledgementConnectionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings>
    {
        public AS2AcknowledgementConnectionSettings(bool ignoreCertificateNameMismatch, bool supportHttpStatusCodeContinue, bool keepHttpConnectionAlive, bool unfoldHttpHeaders) { }
        public bool IgnoreCertificateNameMismatch { get { throw null; } set { } }
        public bool KeepHttpConnectionAlive { get { throw null; } set { } }
        public bool SupportHttpStatusCodeContinue { get { throw null; } set { } }
        public bool UnfoldHttpHeaders { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AS2AgreementContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2AgreementContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2AgreementContent>
    {
        public AS2AgreementContent(Azure.ResourceManager.Logic.Models.AS2OneWayAgreement receiveAgreement, Azure.ResourceManager.Logic.Models.AS2OneWayAgreement sendAgreement) { }
        public Azure.ResourceManager.Logic.Models.AS2OneWayAgreement ReceiveAgreement { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2OneWayAgreement SendAgreement { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2AgreementContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2AgreementContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2AgreementContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2AgreementContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2AgreementContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2AgreementContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2AgreementContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AS2EncryptionAlgorithm : System.IEquatable<Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AS2EncryptionAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm Aes128 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm Aes192 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm Aes256 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm Des3 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm RC2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm left, Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm left, Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AS2EnvelopeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings>
    {
        public AS2EnvelopeSettings(Azure.Core.ContentType messageContentType, bool transmitFileNameInMimeHeader, string fileNameTemplate, bool suspendMessageOnFileNameGenerationError, bool autoGenerateFileName) { }
        public bool AutoGenerateFileName { get { throw null; } set { } }
        public string FileNameTemplate { get { throw null; } set { } }
        public Azure.Core.ContentType MessageContentType { get { throw null; } set { } }
        public bool SuspendMessageOnFileNameGenerationError { get { throw null; } set { } }
        public bool TransmitFileNameInMimeHeader { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AS2ErrorSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2ErrorSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ErrorSettings>
    {
        public AS2ErrorSettings(bool suspendDuplicateMessage, bool resendIfMdnNotReceived) { }
        public bool ResendIfMdnNotReceived { get { throw null; } set { } }
        public bool SuspendDuplicateMessage { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2ErrorSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2ErrorSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2ErrorSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2ErrorSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ErrorSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ErrorSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ErrorSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AS2HashingAlgorithm : System.IEquatable<Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AS2HashingAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm MD5 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm Sha1 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm Sha2256 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm Sha2384 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm Sha2512 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm left, Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm left, Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AS2MdnSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2MdnSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2MdnSettings>
    {
        public AS2MdnSettings(bool needMdn, bool signMdn, bool sendMdnAsynchronously, bool signOutboundMdnIfOptional, bool sendInboundMdnToMessageBox, Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm micHashingAlgorithm) { }
        public string DispositionNotificationTo { get { throw null; } set { } }
        public string MdnText { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm MicHashingAlgorithm { get { throw null; } set { } }
        public bool NeedMdn { get { throw null; } set { } }
        public System.Uri ReceiptDeliveryUri { get { throw null; } set { } }
        public bool SendInboundMdnToMessageBox { get { throw null; } set { } }
        public bool SendMdnAsynchronously { get { throw null; } set { } }
        public bool SignMdn { get { throw null; } set { } }
        public bool SignOutboundMdnIfOptional { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2MdnSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2MdnSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2MdnSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2MdnSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2MdnSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2MdnSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2MdnSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AS2MessageConnectionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings>
    {
        public AS2MessageConnectionSettings(bool ignoreCertificateNameMismatch, bool supportHttpStatusCodeContinue, bool keepHttpConnectionAlive, bool unfoldHttpHeaders) { }
        public bool IgnoreCertificateNameMismatch { get { throw null; } set { } }
        public bool KeepHttpConnectionAlive { get { throw null; } set { } }
        public bool SupportHttpStatusCodeContinue { get { throw null; } set { } }
        public bool UnfoldHttpHeaders { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AS2OneWayAgreement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2OneWayAgreement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2OneWayAgreement>
    {
        public AS2OneWayAgreement(Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity senderBusinessIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity receiverBusinessIdentity, Azure.ResourceManager.Logic.Models.AS2ProtocolSettings protocolSettings) { }
        public Azure.ResourceManager.Logic.Models.AS2ProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2OneWayAgreement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2OneWayAgreement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2OneWayAgreement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2OneWayAgreement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2OneWayAgreement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2OneWayAgreement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2OneWayAgreement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AS2ProtocolSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2ProtocolSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ProtocolSettings>
    {
        public AS2ProtocolSettings(Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings messageConnectionSettings, Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings acknowledgementConnectionSettings, Azure.ResourceManager.Logic.Models.AS2MdnSettings mdnSettings, Azure.ResourceManager.Logic.Models.AS2SecuritySettings securitySettings, Azure.ResourceManager.Logic.Models.AS2ValidationSettings validationSettings, Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings envelopeSettings, Azure.ResourceManager.Logic.Models.AS2ErrorSettings errorSettings) { }
        public Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings AcknowledgementConnectionSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings EnvelopeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2ErrorSettings ErrorSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2MdnSettings MdnSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings MessageConnectionSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2SecuritySettings SecuritySettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2ValidationSettings ValidationSettings { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2ProtocolSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2ProtocolSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2ProtocolSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2ProtocolSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ProtocolSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ProtocolSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ProtocolSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AS2SecuritySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2SecuritySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2SecuritySettings>
    {
        public AS2SecuritySettings(bool overrideGroupSigningCertificate, bool enableNrrForInboundEncodedMessages, bool enableNrrForInboundDecodedMessages, bool enableNrrForOutboundMdn, bool enableNrrForOutboundEncodedMessages, bool enableNrrForOutboundDecodedMessages, bool enableNrrForInboundMdn) { }
        public bool EnableNrrForInboundDecodedMessages { get { throw null; } set { } }
        public bool EnableNrrForInboundEncodedMessages { get { throw null; } set { } }
        public bool EnableNrrForInboundMdn { get { throw null; } set { } }
        public bool EnableNrrForOutboundDecodedMessages { get { throw null; } set { } }
        public bool EnableNrrForOutboundEncodedMessages { get { throw null; } set { } }
        public bool EnableNrrForOutboundMdn { get { throw null; } set { } }
        public string EncryptionCertificateName { get { throw null; } set { } }
        public bool OverrideGroupSigningCertificate { get { throw null; } set { } }
        public string Sha2AlgorithmFormat { get { throw null; } set { } }
        public string SigningCertificateName { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2SecuritySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2SecuritySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2SecuritySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2SecuritySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2SecuritySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2SecuritySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2SecuritySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AS2SigningAlgorithm : System.IEquatable<Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AS2SigningAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Default { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Sha1 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Sha2256 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Sha2384 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Sha2512 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm left, Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm left, Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AS2ValidationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2ValidationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ValidationSettings>
    {
        public AS2ValidationSettings(bool overrideMessageProperties, bool encryptMessage, bool signMessage, bool compressMessage, bool checkDuplicateMessage, int interchangeDuplicatesValidityDays, bool checkCertificateRevocationListOnSend, bool checkCertificateRevocationListOnReceive, Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm encryptionAlgorithm) { }
        public bool CheckCertificateRevocationListOnReceive { get { throw null; } set { } }
        public bool CheckCertificateRevocationListOnSend { get { throw null; } set { } }
        public bool CheckDuplicateMessage { get { throw null; } set { } }
        public bool CompressMessage { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm EncryptionAlgorithm { get { throw null; } set { } }
        public bool EncryptMessage { get { throw null; } set { } }
        public int InterchangeDuplicatesValidityDays { get { throw null; } set { } }
        public bool OverrideMessageProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm? SigningAlgorithm { get { throw null; } set { } }
        public bool SignMessage { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.AS2ValidationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2ValidationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.AS2ValidationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.AS2ValidationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ValidationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ValidationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.AS2ValidationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactAcknowledgementSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings>
    {
        public EdifactAcknowledgementSettings(bool needTechnicalAcknowledgement, bool batchTechnicalAcknowledgement, bool needFunctionalAcknowledgement, bool batchFunctionalAcknowledgement, bool needLoopForValidMessages, bool sendSynchronousAcknowledgement, int acknowledgementControlNumberLowerBound, int acknowledgementControlNumberUpperBound, bool rolloverAcknowledgementControlNumber) { }
        public int AcknowledgementControlNumberLowerBound { get { throw null; } set { } }
        public string AcknowledgementControlNumberPrefix { get { throw null; } set { } }
        public string AcknowledgementControlNumberSuffix { get { throw null; } set { } }
        public int AcknowledgementControlNumberUpperBound { get { throw null; } set { } }
        public bool BatchFunctionalAcknowledgement { get { throw null; } set { } }
        public bool BatchTechnicalAcknowledgement { get { throw null; } set { } }
        public bool NeedFunctionalAcknowledgement { get { throw null; } set { } }
        public bool NeedLoopForValidMessages { get { throw null; } set { } }
        public bool NeedTechnicalAcknowledgement { get { throw null; } set { } }
        public bool RolloverAcknowledgementControlNumber { get { throw null; } set { } }
        public bool SendSynchronousAcknowledgement { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactAgreementContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactAgreementContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactAgreementContent>
    {
        public EdifactAgreementContent(Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement receiveAgreement, Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement sendAgreement) { }
        public Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement ReceiveAgreement { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement SendAgreement { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactAgreementContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactAgreementContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactAgreementContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactAgreementContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactAgreementContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactAgreementContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactAgreementContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdifactCharacterSet : System.IEquatable<Azure.ResourceManager.Logic.Models.EdifactCharacterSet>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdifactCharacterSet(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Keca { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoa { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unob { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoc { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unod { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoe { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unof { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unog { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoh { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoi { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoj { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unok { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unox { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.EdifactCharacterSet other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.EdifactCharacterSet left, Azure.ResourceManager.Logic.Models.EdifactCharacterSet right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.EdifactCharacterSet (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.EdifactCharacterSet left, Azure.ResourceManager.Logic.Models.EdifactCharacterSet right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum EdifactDecimalIndicator
    {
        NotSpecified = 0,
        Comma = 1,
        Decimal = 2,
    }
    public partial class EdifactDelimiterOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride>
    {
        public EdifactDelimiterOverride(int dataElementSeparator, int componentSeparator, int segmentTerminator, int repetitionSeparator, Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix segmentTerminatorSuffix, Azure.ResourceManager.Logic.Models.EdifactDecimalIndicator decimalPointIndicator, int releaseIndicator) { }
        public int ComponentSeparator { get { throw null; } set { } }
        public int DataElementSeparator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactDecimalIndicator DecimalPointIndicator { get { throw null; } set { } }
        public string MessageAssociationAssignedCode { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string MessageRelease { get { throw null; } set { } }
        public string MessageVersion { get { throw null; } set { } }
        public int ReleaseIndicator { get { throw null; } set { } }
        public int RepetitionSeparator { get { throw null; } set { } }
        public int SegmentTerminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix SegmentTerminatorSuffix { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactEnvelopeOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride>
    {
        public EdifactEnvelopeOverride() { }
        public string ApplicationPassword { get { throw null; } set { } }
        public string AssociationAssignedCode { get { throw null; } set { } }
        public string ControllingAgencyCode { get { throw null; } set { } }
        public string FunctionalGroupId { get { throw null; } set { } }
        public string GroupHeaderMessageRelease { get { throw null; } set { } }
        public string GroupHeaderMessageVersion { get { throw null; } set { } }
        public string MessageAssociationAssignedCode { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string MessageRelease { get { throw null; } set { } }
        public string MessageVersion { get { throw null; } set { } }
        public string ReceiverApplicationId { get { throw null; } set { } }
        public string ReceiverApplicationQualifier { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
        public string SenderApplicationQualifier { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactEnvelopeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings>
    {
        public EdifactEnvelopeSettings(bool applyDelimiterStringAdvice, bool createGroupingSegments, bool enableDefaultGroupHeaders, long interchangeControlNumberLowerBound, long interchangeControlNumberUpperBound, bool rolloverInterchangeControlNumber, long groupControlNumberLowerBound, long groupControlNumberUpperBound, bool rolloverGroupControlNumber, bool overwriteExistingTransactionSetControlNumber, long transactionSetControlNumberLowerBound, long transactionSetControlNumberUpperBound, bool rolloverTransactionSetControlNumber, bool isTestInterchange) { }
        public string ApplicationReferenceId { get { throw null; } set { } }
        public bool ApplyDelimiterStringAdvice { get { throw null; } set { } }
        public string CommunicationAgreementId { get { throw null; } set { } }
        public bool CreateGroupingSegments { get { throw null; } set { } }
        public bool EnableDefaultGroupHeaders { get { throw null; } set { } }
        public string FunctionalGroupId { get { throw null; } set { } }
        public string GroupApplicationPassword { get { throw null; } set { } }
        public string GroupApplicationReceiverId { get { throw null; } set { } }
        public string GroupApplicationReceiverQualifier { get { throw null; } set { } }
        public string GroupApplicationSenderId { get { throw null; } set { } }
        public string GroupApplicationSenderQualifier { get { throw null; } set { } }
        public string GroupAssociationAssignedCode { get { throw null; } set { } }
        public string GroupControllingAgencyCode { get { throw null; } set { } }
        public long GroupControlNumberLowerBound { get { throw null; } set { } }
        public string GroupControlNumberPrefix { get { throw null; } set { } }
        public string GroupControlNumberSuffix { get { throw null; } set { } }
        public long GroupControlNumberUpperBound { get { throw null; } set { } }
        public string GroupMessageRelease { get { throw null; } set { } }
        public string GroupMessageVersion { get { throw null; } set { } }
        public long InterchangeControlNumberLowerBound { get { throw null; } set { } }
        public string InterchangeControlNumberPrefix { get { throw null; } set { } }
        public string InterchangeControlNumberSuffix { get { throw null; } set { } }
        public long InterchangeControlNumberUpperBound { get { throw null; } set { } }
        public bool IsTestInterchange { get { throw null; } set { } }
        public bool OverwriteExistingTransactionSetControlNumber { get { throw null; } set { } }
        public string ProcessingPriorityCode { get { throw null; } set { } }
        public string ReceiverInternalIdentification { get { throw null; } set { } }
        public string ReceiverInternalSubIdentification { get { throw null; } set { } }
        public string ReceiverReverseRoutingAddress { get { throw null; } set { } }
        public string RecipientReferencePasswordQualifier { get { throw null; } set { } }
        public string RecipientReferencePasswordValue { get { throw null; } set { } }
        public bool RolloverGroupControlNumber { get { throw null; } set { } }
        public bool RolloverInterchangeControlNumber { get { throw null; } set { } }
        public bool RolloverTransactionSetControlNumber { get { throw null; } set { } }
        public string SenderInternalIdentification { get { throw null; } set { } }
        public string SenderInternalSubIdentification { get { throw null; } set { } }
        public string SenderReverseRoutingAddress { get { throw null; } set { } }
        public long TransactionSetControlNumberLowerBound { get { throw null; } set { } }
        public string TransactionSetControlNumberPrefix { get { throw null; } set { } }
        public string TransactionSetControlNumberSuffix { get { throw null; } set { } }
        public long TransactionSetControlNumberUpperBound { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactFramingSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactFramingSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactFramingSettings>
    {
        public EdifactFramingSettings(int protocolVersion, int dataElementSeparator, int componentSeparator, int segmentTerminator, int releaseIndicator, int repetitionSeparator, Azure.ResourceManager.Logic.Models.EdifactCharacterSet characterSet, Azure.ResourceManager.Logic.Models.EdifactDecimalIndicator decimalPointIndicator, Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix segmentTerminatorSuffix) { }
        public string CharacterEncoding { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactCharacterSet CharacterSet { get { throw null; } set { } }
        public int ComponentSeparator { get { throw null; } set { } }
        public int DataElementSeparator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactDecimalIndicator DecimalPointIndicator { get { throw null; } set { } }
        public int ProtocolVersion { get { throw null; } set { } }
        public int ReleaseIndicator { get { throw null; } set { } }
        public int RepetitionSeparator { get { throw null; } set { } }
        public int SegmentTerminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix SegmentTerminatorSuffix { get { throw null; } set { } }
        public string ServiceCodeListDirectoryVersion { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactFramingSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactFramingSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactFramingSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactFramingSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactFramingSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactFramingSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactFramingSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactMessageFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactMessageFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactMessageFilter>
    {
        public EdifactMessageFilter(Azure.ResourceManager.Logic.Models.MessageFilterType messageFilterType) { }
        public Azure.ResourceManager.Logic.Models.MessageFilterType MessageFilterType { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactMessageFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactMessageFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactMessageFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactMessageFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactMessageFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactMessageFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactMessageFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactMessageIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier>
    {
        public EdifactMessageIdentifier(string messageId) { }
        public string MessageId { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactOneWayAgreement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement>
    {
        public EdifactOneWayAgreement(Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity senderBusinessIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity receiverBusinessIdentity, Azure.ResourceManager.Logic.Models.EdifactProtocolSettings protocolSettings) { }
        public Azure.ResourceManager.Logic.Models.EdifactProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactProcessingSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactProcessingSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactProcessingSettings>
    {
        public EdifactProcessingSettings(bool maskSecurityInfo, bool preserveInterchange, bool suspendInterchangeOnError, bool createEmptyXmlTagsForTrailingSeparators, bool useDotAsDecimalSeparator) { }
        public bool CreateEmptyXmlTagsForTrailingSeparators { get { throw null; } set { } }
        public bool MaskSecurityInfo { get { throw null; } set { } }
        public bool PreserveInterchange { get { throw null; } set { } }
        public bool SuspendInterchangeOnError { get { throw null; } set { } }
        public bool UseDotAsDecimalSeparator { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactProcessingSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactProcessingSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactProcessingSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactProcessingSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactProcessingSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactProcessingSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactProcessingSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactProtocolSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactProtocolSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactProtocolSettings>
    {
        public EdifactProtocolSettings(Azure.ResourceManager.Logic.Models.EdifactValidationSettings validationSettings, Azure.ResourceManager.Logic.Models.EdifactFramingSettings framingSettings, Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings envelopeSettings, Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings acknowledgementSettings, Azure.ResourceManager.Logic.Models.EdifactMessageFilter messageFilter, Azure.ResourceManager.Logic.Models.EdifactProcessingSettings processingSettings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.EdifactSchemaReference> schemaReferences) { }
        public Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings AcknowledgementSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride> EdifactDelimiterOverrides { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride> EnvelopeOverrides { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings EnvelopeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactFramingSettings FramingSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier> MessageFilterList { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.MessageFilterType? MessageFilterType { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactProcessingSettings ProcessingSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactSchemaReference> SchemaReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactValidationOverride> ValidationOverrides { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.EdifactValidationSettings ValidationSettings { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactProtocolSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactProtocolSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactProtocolSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactProtocolSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactProtocolSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactProtocolSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactProtocolSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactSchemaReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactSchemaReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactSchemaReference>
    {
        public EdifactSchemaReference(string messageId, string messageVersion, string messageRelease, string schemaName) { }
        public string AssociationAssignedCode { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string MessageRelease { get { throw null; } set { } }
        public string MessageVersion { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
        public string SenderApplicationQualifier { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactSchemaReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactSchemaReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactSchemaReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactSchemaReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactSchemaReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactSchemaReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactSchemaReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactValidationOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactValidationOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactValidationOverride>
    {
        public EdifactValidationOverride(string messageId, bool enforceCharacterSet, bool validateEdiTypes, bool validateXsdTypes, bool allowLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy, bool trimLeadingAndTrailingSpacesAndZeroes) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool EnforceCharacterSet { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateEdiTypes { get { throw null; } set { } }
        public bool ValidateXsdTypes { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactValidationOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactValidationOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactValidationOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactValidationOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactValidationOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactValidationOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactValidationOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdifactValidationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactValidationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactValidationSettings>
    {
        public EdifactValidationSettings(bool validateCharacterSet, bool checkDuplicateInterchangeControlNumber, int interchangeControlNumberValidityDays, bool checkDuplicateGroupControlNumber, bool checkDuplicateTransactionSetControlNumber, bool validateEdiTypes, bool validateXsdTypes, bool allowLeadingAndTrailingSpacesAndZeroes, bool trimLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool CheckDuplicateGroupControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateInterchangeControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateTransactionSetControlNumber { get { throw null; } set { } }
        public int InterchangeControlNumberValidityDays { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateCharacterSet { get { throw null; } set { } }
        public bool ValidateEdiTypes { get { throw null; } set { } }
        public bool ValidateXsdTypes { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.EdifactValidationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactValidationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.EdifactValidationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.EdifactValidationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactValidationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactValidationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.EdifactValidationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlowAccessControlConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration>
    {
        public FlowAccessControlConfiguration() { }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy Actions { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy Contents { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy Triggers { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy WorkflowManagement { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlowAccessControlConfigurationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy>
    {
        public FlowAccessControlConfigurationPolicy() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy> AccessPolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange> AllowedCallerIPAddresses { get { throw null; } }
        Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlowAccessControlIPAddressRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange>
    {
        public FlowAccessControlIPAddressRange() { }
        public string AddressRange { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlowEndpointIPAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress>
    {
        public FlowEndpointIPAddress() { }
        public string CidrAddress { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlowEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpoints>
    {
        public FlowEndpoints() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress> AccessEndpointIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress> OutgoingIPAddresses { get { throw null; } }
        Azure.ResourceManager.Logic.Models.FlowEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.FlowEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlowEndpointsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration>
    {
        public FlowEndpointsConfiguration() { }
        public Azure.ResourceManager.Logic.Models.FlowEndpoints Connector { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpoints Workflow { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateUpgradedDefinitionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent>
    {
        public GenerateUpgradedDefinitionContent() { }
        public string TargetSchemaVersion { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountAgreementContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent>
    {
        public IntegrationAccountAgreementContent() { }
        public Azure.ResourceManager.Logic.Models.AS2AgreementContent AS2 { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactAgreementContent Edifact { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12AgreementContent X12 { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum IntegrationAccountAgreementType
    {
        NotSpecified = 0,
        AS2 = 1,
        X12 = 2,
        Edifact = 3,
    }
    public partial class IntegrationAccountAssemblyProperties : Azure.ResourceManager.Logic.Models.ArtifactContentProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties>
    {
        public IntegrationAccountAssemblyProperties(string assemblyName) { }
        public string AssemblyCulture { get { throw null; } set { } }
        public string AssemblyName { get { throw null; } set { } }
        public string AssemblyPublicKeyToken { get { throw null; } set { } }
        public string AssemblyVersion { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountBatchConfigurationProperties : Azure.ResourceManager.Logic.Models.ArtifactProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties>
    {
        public IntegrationAccountBatchConfigurationProperties(string batchGroupName, Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria releaseCriteria) { }
        public string BatchGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria ReleaseCriteria { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountBatchReleaseCriteria : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria>
    {
        public IntegrationAccountBatchReleaseCriteria() { }
        public int? BatchSize { get { throw null; } set { } }
        public int? MessageCount { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence Recurrence { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountBusinessIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity>
    {
        public IntegrationAccountBusinessIdentity(string qualifier, string value) { }
        public string Qualifier { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum IntegrationAccountEventLevel
    {
        LogAlways = 0,
        Critical = 1,
        Error = 2,
        Warning = 3,
        Informational = 4,
        Verbose = 5,
    }
    public partial class IntegrationAccountKeyVaultKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey>
    {
        internal IntegrationAccountKeyVaultKey() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public System.Uri KeyId { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountKeyVaultKeyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference>
    {
        public IntegrationAccountKeyVaultKeyReference(string keyName) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountKeyVaultNameReference : Azure.ResourceManager.Logic.Models.LogicResourceReference, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference>
    {
        public IntegrationAccountKeyVaultNameReference() { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountListKeyVaultKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent>
    {
        public IntegrationAccountListKeyVaultKeyContent(Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference keyVault) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference KeyVault { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountMapType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountMapType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountMapType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType Liquid { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType Xslt { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType Xslt20 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType Xslt30 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountMapType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountMapType left, Azure.ResourceManager.Logic.Models.IntegrationAccountMapType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountMapType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountMapType left, Azure.ResourceManager.Logic.Models.IntegrationAccountMapType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationAccountPartnerContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent>
    {
        public IntegrationAccountPartnerContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity> B2BBusinessIdentities { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountPartnerType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountPartnerType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType B2B { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType left, Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType left, Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountSchemaType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountSchemaType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType left, Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType left, Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountSkuName : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName left, Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName left, Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountTrackEventOperationOption : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountTrackEventOperationOption(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption DisableSourceInfoEnrich { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption left, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption left, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationAccountTrackingEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent>
    {
        public IntegrationAccountTrackingEvent(Azure.ResourceManager.Logic.Models.IntegrationAccountEventLevel eventLevel, System.DateTimeOffset eventOn, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType recordType) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo Error { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountEventLevel EventLevel { get { throw null; } }
        public System.DateTimeOffset EventOn { get { throw null; } }
        public System.BinaryData Record { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType RecordType { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountTrackingEventErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo>
    {
        public IntegrationAccountTrackingEventErrorInfo() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationAccountTrackingEventsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent>
    {
        public IntegrationAccountTrackingEventsContent(string sourceType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent> events) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent> Events { get { throw null; } }
        public string SourceType { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption? TrackEventsOptions { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountTrackingRecordType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountTrackingRecordType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType AS2Mdn { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType AS2Message { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType Custom { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactFunctionalGroup { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactFunctionalGroupAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactInterchange { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactInterchangeAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactTransactionSet { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactTransactionSetAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12FunctionalGroup { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12FunctionalGroupAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12Interchange { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12InterchangeAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12TransactionSet { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12TransactionSetAcknowledgment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType left, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType left, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmenEncryptionKeyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference>
    {
        public IntegrationServiceEnvironmenEncryptionKeyReference() { }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference KeyVault { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentAccessEndpointType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentAccessEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType External { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType Internal { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentNetworkDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency>
    {
        internal IntegrationServiceEnvironmentNetworkDependency() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType? Category { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint> Endpoints { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentNetworkDependencyCategoryType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentNetworkDependencyCategoryType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType AccessEndpoints { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType AzureActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType AzureManagement { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType AzureStorage { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType DiagnosticLogsAndMetrics { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType IntegrationServiceEnvironmentConnectors { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType RecoveryService { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType RedisCache { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType RegionalService { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType Sql { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType SslCertificateVerification { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentNetworkDependencyHealth : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth>
    {
        internal IntegrationServiceEnvironmentNetworkDependencyHealth() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo Error { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState? State { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentNetworkDependencyHealthState : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentNetworkDependencyHealthState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentNetworkEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint>
    {
        internal IntegrationServiceEnvironmentNetworkEndpoint() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState? Accessibility { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Ports { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentNetworkEndPointAccessibilityState : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentNetworkEndPointAccessibilityState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState Available { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState NotAvailable { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties>
    {
        public IntegrationServiceEnvironmentProperties() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference EncryptionKeyReference { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public string IntegrationServiceEnvironmentId { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku>
    {
        public IntegrationServiceEnvironmentSku() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName? Name { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity>
    {
        internal IntegrationServiceEnvironmentSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType? ScaleType { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentSkuDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition>
    {
        internal IntegrationServiceEnvironmentSkuDefinition() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku Sku { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentSkuDefinitionSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku>
    {
        internal IntegrationServiceEnvironmentSkuDefinitionSku() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName? Name { get { throw null; } }
        public string Tier { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentSkuName : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName Developer { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentSkuScaleType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentSkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentSubnetNetworkHealth : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>
    {
        internal IntegrationServiceEnvironmentSubnetNetworkHealth() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState NetworkDependencyHealthState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency> OutboundNetworkDependencies { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth OutboundNetworkHealth { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceErrorCode : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceErrorCode(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode IntegrationServiceEnvironmentNotFound { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode InternalServerError { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode InvalidOperationId { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode left, Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode left, Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo>
    {
        internal IntegrationServiceErrorInfo() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo> Details { get { throw null; } }
        public System.BinaryData InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IntegrationServiceNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration>
    {
        public IntegrationServiceNetworkConfiguration() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType? EndpointType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicResourceReference> Subnets { get { throw null; } }
        public string VirtualNetworkAddressSpace { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListOperationCallbackUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri>
    {
        internal ListOperationCallbackUri() { }
        public System.Uri Uri { get { throw null; } }
        Azure.ResourceManager.Logic.Models.ListOperationCallbackUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.ListOperationCallbackUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListOperationCallbackUrlParameterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo>
    {
        public ListOperationCallbackUrlParameterInfo() { }
        public Azure.ResourceManager.Logic.Models.LogicKeyType? KeyType { get { throw null; } set { } }
        public System.DateTimeOffset? NotAfter { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicApiDeploymentParameterMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata>
    {
        internal LogicApiDeploymentParameterMetadata() { }
        public string ApiDeploymentParameterMetadataType { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility? Visibility { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicApiDeploymentParameterMetadataSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet>
    {
        internal LogicApiDeploymentParameterMetadataSet() { }
        public Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata PackageContentLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata RedisCacheConnectionString { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicApiDeploymentParameterVisibility : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicApiDeploymentParameterVisibility(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility Default { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility Internal { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility left, Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility left, Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicApiOperationAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation>
    {
        public LogicApiOperationAnnotation() { }
        public string Family { get { throw null; } set { } }
        public int? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicApiOperationAnnotationStatus : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicApiOperationAnnotationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus Preview { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus left, Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus left, Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicApiOperationInfo : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo>
    {
        public LogicApiOperationInfo(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Logic.Models.LogicApiOperationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicApiOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicApiOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationProperties>
    {
        public LogicApiOperationProperties() { }
        public Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiReference Api { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerSchema InputsDefinition { get { throw null; } set { } }
        public bool? IsNotification { get { throw null; } set { } }
        public bool? IsPageable { get { throw null; } set { } }
        public bool? IsWebhook { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerSchema> ResponsesDefinition { get { throw null; } }
        public string Summary { get { throw null; } set { } }
        public string Trigger { get { throw null; } set { } }
        public string TriggerHint { get { throw null; } set { } }
        public string Visibility { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicApiOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicApiReference : Azure.ResourceManager.Logic.Models.LogicResourceReference, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiReference>
    {
        public LogicApiReference() { }
        public string BrandColor { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiTier? Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri IconUri { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public System.BinaryData Swagger { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicApiReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicApiResourceDefinitions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions>
    {
        internal LogicApiResourceDefinitions() { }
        public System.Uri ModifiedSwaggerUri { get { throw null; } }
        public System.Uri OriginalSwaggerUri { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicApiResourceGeneralInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation>
    {
        internal LogicApiResourceGeneralInformation() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public string ReleaseTag { get { throw null; } }
        public System.Uri TermsOfUseUri { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiTier? Tier { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicApiResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata>
    {
        internal LogicApiResourceMetadata() { }
        public Azure.ResourceManager.Logic.Models.LogicApiType? ApiType { get { throw null; } }
        public string BrandColor { get { throw null; } }
        public string ConnectionType { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet DeploymentParameters { get { throw null; } }
        public string HideKey { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod? WsdlImportMethod { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWsdlService WsdlService { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicApiResourcePolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies>
    {
        internal LogicApiResourcePolicies() { }
        public System.BinaryData Content { get { throw null; } }
        public string ContentLink { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicApiTier : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicApiTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicApiTier(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiTier Enterprise { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiTier NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiTier Premium { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicApiTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicApiTier left, Azure.ResourceManager.Logic.Models.LogicApiTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicApiTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicApiTier left, Azure.ResourceManager.Logic.Models.LogicApiTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicApiType : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicApiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicApiType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiType Rest { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiType Soap { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicApiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicApiType left, Azure.ResourceManager.Logic.Models.LogicApiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicApiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicApiType left, Azure.ResourceManager.Logic.Models.LogicApiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicContentHash : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicContentHash>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicContentHash>
    {
        internal LogicContentHash() { }
        public string Algorithm { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicContentHash System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicContentHash>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicContentHash>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicContentHash System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicContentHash>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicContentHash>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicContentHash>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicContentLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicContentLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicContentLink>
    {
        public LogicContentLink() { }
        public Azure.ResourceManager.Logic.Models.LogicContentHash ContentHash { get { throw null; } }
        public long? ContentSize { get { throw null; } }
        public string ContentVersion { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicContentLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicContentLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicContentLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicContentLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicContentLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicContentLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicContentLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicErrorInfo>
    {
        internal LogicErrorInfo() { }
        public string Code { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicErrorResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicErrorResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicErrorResponse>
    {
        public LogicErrorResponse() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicErrorResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicErrorResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicErrorResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicErrorResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicErrorResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicErrorResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicErrorResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicExpression : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpression>
    {
        internal LogicExpression() { }
        public Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.LogicExpression> Subexpressions { get { throw null; } }
        public string Text { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicExpression System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicExpression System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicExpressionErrorInfo : Azure.ResourceManager.Logic.Models.LogicErrorInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo>
    {
        internal LogicExpressionErrorInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo> Details { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicExpressionRoot : Azure.ResourceManager.Logic.Models.LogicExpression, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicExpressionRoot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpressionRoot>
    {
        internal LogicExpressionRoot() { }
        public string Path { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicExpressionRoot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicExpressionRoot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicExpressionRoot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicExpressionRoot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpressionRoot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpressionRoot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicExpressionRoot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicJsonSchema : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicJsonSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicJsonSchema>
    {
        internal LogicJsonSchema() { }
        public System.BinaryData Content { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicJsonSchema System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicJsonSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicJsonSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicJsonSchema System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicJsonSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicJsonSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicJsonSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicKeyType : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicKeyType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicKeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicKeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicKeyType left, Azure.ResourceManager.Logic.Models.LogicKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicKeyType left, Azure.ResourceManager.Logic.Models.LogicKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicResourceReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicResourceReference>
    {
        public LogicResourceReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicSku>
    {
        internal LogicSku() { }
        public Azure.ResourceManager.Logic.Models.LogicSkuName Name { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference Plan { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicSkuName : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Shared { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicSkuName left, Azure.ResourceManager.Logic.Models.LogicSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicSkuName left, Azure.ResourceManager.Logic.Models.LogicSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum LogicWorkflowDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class LogicWorkflowOutputParameterInfo : Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo>
    {
        public LogicWorkflowOutputParameterInfo() { }
        public System.BinaryData Error { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowParameterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo>
    {
        public LogicWorkflowParameterInfo() { }
        public string Description { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType? ParameterType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowParameterType : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType SecureObject { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType SecureString { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType left, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType left, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowProvisioningState : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Registered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Registering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Renewing { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Unregistering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState left, Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState left, Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowRecurrenceFrequency : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowRecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Second { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Week { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency left, Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency left, Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicWorkflowRecurrenceSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule>
    {
        public LogicWorkflowRecurrenceSchedule() { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence> MonthlyOccurrences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicWorkflowDayOfWeek> WeekDays { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRecurrenceScheduleOccurrence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence>
    {
        public LogicWorkflowRecurrenceScheduleOccurrence() { }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowDayOfWeek? Day { get { throw null; } set { } }
        public int? Occurrence { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowReference : Azure.ResourceManager.Logic.Models.LogicResourceReference, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowReference>
    {
        public LogicWorkflowReference() { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRegenerateActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent>
    {
        public LogicWorkflowRegenerateActionContent() { }
        public Azure.ResourceManager.Logic.Models.LogicKeyType? KeyType { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRepetitionIndex : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex>
    {
        public LogicWorkflowRepetitionIndex(int itemIndex) { }
        public int ItemIndex { get { throw null; } set { } }
        public string ScopeName { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequest>
    {
        public LogicWorkflowRequest() { }
        public System.BinaryData Headers { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRequestHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties>
    {
        public LogicWorkflowRequestHistoryProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRequest Request { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowResponse Response { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowResponse>
    {
        public LogicWorkflowResponse() { }
        public Azure.ResourceManager.Logic.Models.LogicContentLink BodyLink { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public int? StatusCode { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRunActionCorrelation : Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation>
    {
        public LogicWorkflowRunActionCorrelation() { }
        public System.Guid? ActionTrackingId { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRunCorrelation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation>
    {
        public LogicWorkflowRunCorrelation() { }
        public System.Collections.Generic.IList<string> ClientKeywords { get { throw null; } }
        public string ClientTrackingId { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowRunTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger>
    {
        internal LogicWorkflowRunTrigger() { }
        public string Code { get { throw null; } }
        public string CorrelationClientTrackingId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public System.BinaryData Inputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink InputsLink { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink OutputsLink { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public System.BinaryData TrackedProperties { get { throw null; } }
        public System.Guid? TrackingId { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowState : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Completed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowState left, Azure.ResourceManager.Logic.Models.LogicWorkflowState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowState left, Azure.ResourceManager.Logic.Models.LogicWorkflowState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowStatus : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowStatus(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Aborted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Faulted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Ignored { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Skipped { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus TimedOut { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus left, Azure.ResourceManager.Logic.Models.LogicWorkflowStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus left, Azure.ResourceManager.Logic.Models.LogicWorkflowStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicWorkflowTriggerCallbackQueryParameterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo>
    {
        internal LogicWorkflowTriggerCallbackQueryParameterInfo() { }
        public string ApiVersion { get { throw null; } }
        public string Se { get { throw null; } }
        public string Sig { get { throw null; } }
        public string Sp { get { throw null; } }
        public string Sv { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowTriggerCallbackUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>
    {
        internal LogicWorkflowTriggerCallbackUri() { }
        public string BasePath { get { throw null; } }
        public Azure.Core.RequestMethod? Method { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo Queries { get { throw null; } }
        public string RelativePath { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RelativePathParameters { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowTriggerProvisioningState : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowTriggerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Registered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Registering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Unregistering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState left, Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState left, Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicWorkflowTriggerRecurrence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence>
    {
        public LogicWorkflowTriggerRecurrence() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowTriggerReference : Azure.ResourceManager.Logic.Models.LogicResourceReference, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference>
    {
        public LogicWorkflowTriggerReference() { }
        public string FlowName { get { throw null; } set { } }
        public string TriggerName { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkflowTriggerStateActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent>
    {
        public LogicWorkflowTriggerStateActionContent(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference source) { }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference Source { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicWorkRetryHistory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory>
    {
        public LogicWorkRetryHistory() { }
        public string ClientRequestId { get { throw null; } set { } }
        public string Code { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicErrorResponse Error { get { throw null; } set { } }
        public string ServiceRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWsdlImportMethod : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWsdlImportMethod(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod SoapPassThrough { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod SoapToRest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod left, Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod left, Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicWsdlService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWsdlService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWsdlService>
    {
        internal LogicWsdlService() { }
        public System.Collections.Generic.IReadOnlyList<string> EndpointQualifiedNames { get { throw null; } }
        public string QualifiedName { get { throw null; } }
        Azure.ResourceManager.Logic.Models.LogicWsdlService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWsdlService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.LogicWsdlService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.LogicWsdlService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWsdlService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWsdlService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.LogicWsdlService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageFilterType : System.IEquatable<Azure.ResourceManager.Logic.Models.MessageFilterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageFilterType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.MessageFilterType Exclude { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.MessageFilterType Include { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.MessageFilterType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.MessageFilterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.MessageFilterType left, Azure.ResourceManager.Logic.Models.MessageFilterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.MessageFilterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.MessageFilterType left, Azure.ResourceManager.Logic.Models.MessageFilterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenAuthenticationAccessPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy>
    {
        public OpenAuthenticationAccessPolicy() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim> Claims { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType? ProviderType { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAuthenticationPolicyClaim : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim>
    {
        public OpenAuthenticationPolicyClaim() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenAuthenticationProviderType : System.IEquatable<Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAuthenticationProviderType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType AAD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType left, Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType left, Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SegmentTerminatorSuffix
    {
        None = 0,
        NotSpecified = 1,
        CR = 2,
        LF = 3,
        Crlf = 4,
    }
    public partial class SwaggerCustomDynamicList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList>
    {
        public SwaggerCustomDynamicList() { }
        public string BuiltInOperation { get { throw null; } set { } }
        public string ItemsPath { get { throw null; } set { } }
        public string ItemTitlePath { get { throw null; } set { } }
        public string ItemValuePath { get { throw null; } set { } }
        public string OperationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties> Parameters { get { throw null; } }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwaggerCustomDynamicProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties>
    {
        public SwaggerCustomDynamicProperties() { }
        public string OperationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties> Parameters { get { throw null; } }
        public string ValuePath { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwaggerCustomDynamicSchema : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema>
    {
        public SwaggerCustomDynamicSchema() { }
        public string OperationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ValuePath { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwaggerCustomDynamicTree : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree>
    {
        public SwaggerCustomDynamicTree() { }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand Browse { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand Open { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings Settings { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwaggerCustomDynamicTreeCommand : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand>
    {
        public SwaggerCustomDynamicTreeCommand() { }
        public string ItemFullTitlePath { get { throw null; } set { } }
        public string ItemIsParent { get { throw null; } set { } }
        public string ItemsPath { get { throw null; } set { } }
        public string ItemTitlePath { get { throw null; } set { } }
        public string ItemValuePath { get { throw null; } set { } }
        public string OperationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo> Parameters { get { throw null; } }
        public string SelectableFilter { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwaggerCustomDynamicTreeParameterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo>
    {
        public SwaggerCustomDynamicTreeParameterInfo() { }
        public bool? IsRequired { get { throw null; } set { } }
        public string ParameterReference { get { throw null; } set { } }
        public string SelectedItemValuePath { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwaggerCustomDynamicTreeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings>
    {
        public SwaggerCustomDynamicTreeSettings() { }
        public bool? CanSelectLeafNodes { get { throw null; } set { } }
        public bool? CanSelectParentNodes { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwaggerExternalDocumentation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation>
    {
        public SwaggerExternalDocumentation() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Extensions { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SwaggerSchema : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerSchema>
    {
        public SwaggerSchema() { }
        public System.BinaryData AdditionalProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.SwaggerSchema> AllOf { get { throw null; } }
        public string Discriminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList DynamicListNew { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties DynamicSchemaNew { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema DynamicSchemaOld { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree DynamicTree { get { throw null; } set { } }
        public System.BinaryData Example { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation ExternalDocs { get { throw null; } set { } }
        public bool? IsNotificationUrlExtension { get { throw null; } set { } }
        public bool? IsReadOnly { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerSchema Items { get { throw null; } set { } }
        public int? MaxProperties { get { throw null; } set { } }
        public int? MinProperties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerSchema> Properties { get { throw null; } }
        public string Reference { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredProperties { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.SwaggerSchemaType? SchemaType { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerXml Xml { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.SwaggerSchema System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerSchema System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SwaggerSchemaType : System.IEquatable<Azure.ResourceManager.Logic.Models.SwaggerSchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SwaggerSchemaType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Array { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType File { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Integer { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Null { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Number { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Object { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.SwaggerSchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.SwaggerSchemaType left, Azure.ResourceManager.Logic.Models.SwaggerSchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.SwaggerSchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.SwaggerSchemaType left, Azure.ResourceManager.Logic.Models.SwaggerSchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SwaggerXml : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerXml>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerXml>
    {
        public SwaggerXml() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Extensions { get { throw null; } }
        public bool? IsAttribute { get { throw null; } set { } }
        public bool? IsWrapped { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.SwaggerXml System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerXml>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.SwaggerXml>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.SwaggerXml System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerXml>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerXml>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.SwaggerXml>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrailingSeparatorPolicy : System.IEquatable<Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrailingSeparatorPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy Mandatory { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy NotAllowed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy Optional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy left, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy left, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageIndicator : System.IEquatable<Azure.ResourceManager.Logic.Models.UsageIndicator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageIndicator(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.UsageIndicator Information { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.UsageIndicator NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.UsageIndicator Production { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.UsageIndicator Test { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.UsageIndicator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.UsageIndicator left, Azure.ResourceManager.Logic.Models.UsageIndicator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.UsageIndicator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.UsageIndicator left, Azure.ResourceManager.Logic.Models.UsageIndicator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X12AcknowledgementSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings>
    {
        public X12AcknowledgementSettings(bool needTechnicalAcknowledgement, bool batchTechnicalAcknowledgement, bool needFunctionalAcknowledgement, bool batchFunctionalAcknowledgement, bool needImplementationAcknowledgement, bool batchImplementationAcknowledgement, bool needLoopForValidMessages, bool sendSynchronousAcknowledgement, int acknowledgementControlNumberLowerBound, int acknowledgementControlNumberUpperBound, bool rolloverAcknowledgementControlNumber) { }
        public int AcknowledgementControlNumberLowerBound { get { throw null; } set { } }
        public string AcknowledgementControlNumberPrefix { get { throw null; } set { } }
        public string AcknowledgementControlNumberSuffix { get { throw null; } set { } }
        public int AcknowledgementControlNumberUpperBound { get { throw null; } set { } }
        public bool BatchFunctionalAcknowledgement { get { throw null; } set { } }
        public bool BatchImplementationAcknowledgement { get { throw null; } set { } }
        public bool BatchTechnicalAcknowledgement { get { throw null; } set { } }
        public string FunctionalAcknowledgementVersion { get { throw null; } set { } }
        public string ImplementationAcknowledgementVersion { get { throw null; } set { } }
        public bool NeedFunctionalAcknowledgement { get { throw null; } set { } }
        public bool NeedImplementationAcknowledgement { get { throw null; } set { } }
        public bool NeedLoopForValidMessages { get { throw null; } set { } }
        public bool NeedTechnicalAcknowledgement { get { throw null; } set { } }
        public bool RolloverAcknowledgementControlNumber { get { throw null; } set { } }
        public bool SendSynchronousAcknowledgement { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12AgreementContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12AgreementContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12AgreementContent>
    {
        public X12AgreementContent(Azure.ResourceManager.Logic.Models.X12OneWayAgreement receiveAgreement, Azure.ResourceManager.Logic.Models.X12OneWayAgreement sendAgreement) { }
        public Azure.ResourceManager.Logic.Models.X12OneWayAgreement ReceiveAgreement { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12OneWayAgreement SendAgreement { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12AgreementContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12AgreementContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12AgreementContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12AgreementContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12AgreementContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12AgreementContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12AgreementContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct X12CharacterSet : System.IEquatable<Azure.ResourceManager.Logic.Models.X12CharacterSet>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public X12CharacterSet(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.X12CharacterSet Basic { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12CharacterSet Extended { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12CharacterSet NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12CharacterSet Utf8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.X12CharacterSet other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.X12CharacterSet left, Azure.ResourceManager.Logic.Models.X12CharacterSet right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.X12CharacterSet (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.X12CharacterSet left, Azure.ResourceManager.Logic.Models.X12CharacterSet right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct X12DateFormat : System.IEquatable<Azure.ResourceManager.Logic.Models.X12DateFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public X12DateFormat(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.X12DateFormat Ccyymmdd { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12DateFormat NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12DateFormat Yymmdd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.X12DateFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.X12DateFormat left, Azure.ResourceManager.Logic.Models.X12DateFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.X12DateFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.X12DateFormat left, Azure.ResourceManager.Logic.Models.X12DateFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X12DelimiterOverrides : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12DelimiterOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12DelimiterOverrides>
    {
        public X12DelimiterOverrides(int dataElementSeparator, int componentSeparator, int segmentTerminator, Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix segmentTerminatorSuffix, int replaceCharacter, bool replaceSeparatorsInPayload) { }
        public int ComponentSeparator { get { throw null; } set { } }
        public int DataElementSeparator { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string ProtocolVersion { get { throw null; } set { } }
        public int ReplaceCharacter { get { throw null; } set { } }
        public bool ReplaceSeparatorsInPayload { get { throw null; } set { } }
        public int SegmentTerminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix SegmentTerminatorSuffix { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12DelimiterOverrides System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12DelimiterOverrides>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12DelimiterOverrides>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12DelimiterOverrides System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12DelimiterOverrides>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12DelimiterOverrides>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12DelimiterOverrides>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12EnvelopeOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12EnvelopeOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12EnvelopeOverride>
    {
        public X12EnvelopeOverride(string targetNamespace, string protocolVersion, string messageId, string responsibleAgencyCode, string headerVersion, string senderApplicationId, string receiverApplicationId, Azure.ResourceManager.Logic.Models.X12DateFormat dateFormat, Azure.ResourceManager.Logic.Models.X12TimeFormat timeFormat) { }
        public Azure.ResourceManager.Logic.Models.X12DateFormat DateFormat { get { throw null; } set { } }
        public string FunctionalIdentifierCode { get { throw null; } set { } }
        public string HeaderVersion { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string ProtocolVersion { get { throw null; } set { } }
        public string ReceiverApplicationId { get { throw null; } set { } }
        public string ResponsibleAgencyCode { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12TimeFormat TimeFormat { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12EnvelopeOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12EnvelopeOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12EnvelopeOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12EnvelopeOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12EnvelopeOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12EnvelopeOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12EnvelopeOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12EnvelopeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12EnvelopeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12EnvelopeSettings>
    {
        public X12EnvelopeSettings(int controlStandardsId, bool useControlStandardsIdAsRepetitionCharacter, string senderApplicationId, string receiverApplicationId, string controlVersionNumber, int interchangeControlNumberLowerBound, int interchangeControlNumberUpperBound, bool rolloverInterchangeControlNumber, bool enableDefaultGroupHeaders, int groupControlNumberLowerBound, int groupControlNumberUpperBound, bool rolloverGroupControlNumber, string groupHeaderAgencyCode, string groupHeaderVersion, int transactionSetControlNumberLowerBound, int transactionSetControlNumberUpperBound, bool rolloverTransactionSetControlNumber, bool overwriteExistingTransactionSetControlNumber, Azure.ResourceManager.Logic.Models.X12DateFormat groupHeaderDateFormat, Azure.ResourceManager.Logic.Models.X12TimeFormat groupHeaderTimeFormat, Azure.ResourceManager.Logic.Models.UsageIndicator usageIndicator) { }
        public int ControlStandardsId { get { throw null; } set { } }
        public string ControlVersionNumber { get { throw null; } set { } }
        public bool EnableDefaultGroupHeaders { get { throw null; } set { } }
        public string FunctionalGroupId { get { throw null; } set { } }
        public int GroupControlNumberLowerBound { get { throw null; } set { } }
        public int GroupControlNumberUpperBound { get { throw null; } set { } }
        public string GroupHeaderAgencyCode { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12DateFormat GroupHeaderDateFormat { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12TimeFormat GroupHeaderTimeFormat { get { throw null; } set { } }
        public string GroupHeaderVersion { get { throw null; } set { } }
        public int InterchangeControlNumberLowerBound { get { throw null; } set { } }
        public int InterchangeControlNumberUpperBound { get { throw null; } set { } }
        public bool OverwriteExistingTransactionSetControlNumber { get { throw null; } set { } }
        public string ReceiverApplicationId { get { throw null; } set { } }
        public bool RolloverGroupControlNumber { get { throw null; } set { } }
        public bool RolloverInterchangeControlNumber { get { throw null; } set { } }
        public bool RolloverTransactionSetControlNumber { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
        public int TransactionSetControlNumberLowerBound { get { throw null; } set { } }
        public string TransactionSetControlNumberPrefix { get { throw null; } set { } }
        public string TransactionSetControlNumberSuffix { get { throw null; } set { } }
        public int TransactionSetControlNumberUpperBound { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.UsageIndicator UsageIndicator { get { throw null; } set { } }
        public bool UseControlStandardsIdAsRepetitionCharacter { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12EnvelopeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12EnvelopeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12EnvelopeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12EnvelopeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12EnvelopeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12EnvelopeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12EnvelopeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12FramingSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12FramingSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12FramingSettings>
    {
        public X12FramingSettings(int dataElementSeparator, int componentSeparator, bool replaceSeparatorsInPayload, int replaceCharacter, int segmentTerminator, Azure.ResourceManager.Logic.Models.X12CharacterSet characterSet, Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix segmentTerminatorSuffix) { }
        public Azure.ResourceManager.Logic.Models.X12CharacterSet CharacterSet { get { throw null; } set { } }
        public int ComponentSeparator { get { throw null; } set { } }
        public int DataElementSeparator { get { throw null; } set { } }
        public int ReplaceCharacter { get { throw null; } set { } }
        public bool ReplaceSeparatorsInPayload { get { throw null; } set { } }
        public int SegmentTerminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix SegmentTerminatorSuffix { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12FramingSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12FramingSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12FramingSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12FramingSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12FramingSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12FramingSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12FramingSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12MessageFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12MessageFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12MessageFilter>
    {
        public X12MessageFilter(Azure.ResourceManager.Logic.Models.MessageFilterType messageFilterType) { }
        public Azure.ResourceManager.Logic.Models.MessageFilterType MessageFilterType { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12MessageFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12MessageFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12MessageFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12MessageFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12MessageFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12MessageFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12MessageFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12MessageIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12MessageIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12MessageIdentifier>
    {
        public X12MessageIdentifier(string messageId) { }
        public string MessageId { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12MessageIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12MessageIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12MessageIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12MessageIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12MessageIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12MessageIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12MessageIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12OneWayAgreement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12OneWayAgreement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12OneWayAgreement>
    {
        public X12OneWayAgreement(Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity senderBusinessIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity receiverBusinessIdentity, Azure.ResourceManager.Logic.Models.X12ProtocolSettings protocolSettings) { }
        public Azure.ResourceManager.Logic.Models.X12ProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12OneWayAgreement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12OneWayAgreement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12OneWayAgreement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12OneWayAgreement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12OneWayAgreement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12OneWayAgreement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12OneWayAgreement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12ProcessingSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ProcessingSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ProcessingSettings>
    {
        public X12ProcessingSettings(bool maskSecurityInfo, bool convertImpliedDecimal, bool preserveInterchange, bool suspendInterchangeOnError, bool createEmptyXmlTagsForTrailingSeparators, bool useDotAsDecimalSeparator) { }
        public bool ConvertImpliedDecimal { get { throw null; } set { } }
        public bool CreateEmptyXmlTagsForTrailingSeparators { get { throw null; } set { } }
        public bool MaskSecurityInfo { get { throw null; } set { } }
        public bool PreserveInterchange { get { throw null; } set { } }
        public bool SuspendInterchangeOnError { get { throw null; } set { } }
        public bool UseDotAsDecimalSeparator { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12ProcessingSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ProcessingSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ProcessingSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12ProcessingSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ProcessingSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ProcessingSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ProcessingSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12ProtocolSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ProtocolSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ProtocolSettings>
    {
        public X12ProtocolSettings(Azure.ResourceManager.Logic.Models.X12ValidationSettings validationSettings, Azure.ResourceManager.Logic.Models.X12FramingSettings framingSettings, Azure.ResourceManager.Logic.Models.X12EnvelopeSettings envelopeSettings, Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings acknowledgementSettings, Azure.ResourceManager.Logic.Models.X12MessageFilter messageFilter, Azure.ResourceManager.Logic.Models.X12SecuritySettings securitySettings, Azure.ResourceManager.Logic.Models.X12ProcessingSettings processingSettings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.X12SchemaReference> schemaReferences) { }
        public Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings AcknowledgementSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12EnvelopeOverride> EnvelopeOverrides { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.X12EnvelopeSettings EnvelopeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12FramingSettings FramingSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12MessageIdentifier> MessageFilterList { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.MessageFilterType? MessageFilterType { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12ProcessingSettings ProcessingSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12SchemaReference> SchemaReferences { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.X12SecuritySettings SecuritySettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12ValidationOverride> ValidationOverrides { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.X12ValidationSettings ValidationSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12DelimiterOverrides> X12DelimiterOverrides { get { throw null; } }
        Azure.ResourceManager.Logic.Models.X12ProtocolSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ProtocolSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ProtocolSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12ProtocolSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ProtocolSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ProtocolSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ProtocolSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12SchemaReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12SchemaReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12SchemaReference>
    {
        public X12SchemaReference(string messageId, string schemaVersion, string schemaName) { }
        public string MessageId { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12SchemaReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12SchemaReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12SchemaReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12SchemaReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12SchemaReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12SchemaReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12SchemaReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12SecuritySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12SecuritySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12SecuritySettings>
    {
        public X12SecuritySettings(string authorizationQualifier, string securityQualifier) { }
        public string AuthorizationQualifier { get { throw null; } set { } }
        public string AuthorizationValue { get { throw null; } set { } }
        public string PasswordValue { get { throw null; } set { } }
        public string SecurityQualifier { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12SecuritySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12SecuritySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12SecuritySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12SecuritySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12SecuritySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12SecuritySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12SecuritySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct X12TimeFormat : System.IEquatable<Azure.ResourceManager.Logic.Models.X12TimeFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public X12TimeFormat(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat Hhmm { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat Hhmmss { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat HhmmsSd { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat HhmmsSdd { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.X12TimeFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.X12TimeFormat left, Azure.ResourceManager.Logic.Models.X12TimeFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.X12TimeFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.X12TimeFormat left, Azure.ResourceManager.Logic.Models.X12TimeFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X12ValidationOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ValidationOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ValidationOverride>
    {
        public X12ValidationOverride(string messageId, bool validateEdiTypes, bool validateXsdTypes, bool allowLeadingAndTrailingSpacesAndZeroes, bool validateCharacterSet, bool trimLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateCharacterSet { get { throw null; } set { } }
        public bool ValidateEdiTypes { get { throw null; } set { } }
        public bool ValidateXsdTypes { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12ValidationOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ValidationOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ValidationOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12ValidationOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ValidationOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ValidationOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ValidationOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X12ValidationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ValidationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ValidationSettings>
    {
        public X12ValidationSettings(bool validateCharacterSet, bool checkDuplicateInterchangeControlNumber, int interchangeControlNumberValidityDays, bool checkDuplicateGroupControlNumber, bool checkDuplicateTransactionSetControlNumber, bool validateEdiTypes, bool validateXsdTypes, bool allowLeadingAndTrailingSpacesAndZeroes, bool trimLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool CheckDuplicateGroupControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateInterchangeControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateTransactionSetControlNumber { get { throw null; } set { } }
        public int InterchangeControlNumberValidityDays { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateCharacterSet { get { throw null; } set { } }
        public bool ValidateEdiTypes { get { throw null; } set { } }
        public bool ValidateXsdTypes { get { throw null; } set { } }
        Azure.ResourceManager.Logic.Models.X12ValidationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ValidationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Logic.Models.X12ValidationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Logic.Models.X12ValidationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ValidationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ValidationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Logic.Models.X12ValidationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
