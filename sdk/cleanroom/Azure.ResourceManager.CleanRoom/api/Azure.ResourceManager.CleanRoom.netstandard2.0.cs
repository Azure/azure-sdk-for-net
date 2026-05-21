namespace Azure.ResourceManager.CleanRoom
{
    public partial class AzureResourceManagerCleanRoomContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCleanRoomContext() { }
        public static Azure.ResourceManager.CleanRoom.AzureResourceManagerCleanRoomContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class CleanRoomExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource> GetCollaboration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource>> GetCollaborationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CleanRoom.CollaborationResource GetCollaborationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CleanRoom.CollaborationCollection GetCollaborations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CleanRoom.CollaborationResource> GetCollaborations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.CollaborationResource> GetCollaborationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CleanRoom.ConsortiumCollection GetConsortia(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CleanRoom.ConsortiumResource> GetConsortia(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.ConsortiumResource> GetConsortiaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource> GetConsortium(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource>> GetConsortiumAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CleanRoom.ConsortiumResource GetConsortiumResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> GetConsortiumView(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>> GetConsortiumViewAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource GetConsortiumViewContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CleanRoom.ConsortiumViewResource GetConsortiumViewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CleanRoom.ConsortiumViewCollection GetConsortiumViews(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> GetConsortiumViews(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> GetConsortiumViewsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CollaborationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CleanRoom.CollaborationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.CollaborationResource>, System.Collections.IEnumerable
    {
        protected CollaborationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CleanRoom.CollaborationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string collaborationName, Azure.ResourceManager.CleanRoom.CollaborationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CleanRoom.CollaborationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string collaborationName, Azure.ResourceManager.CleanRoom.CollaborationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource> Get(string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CleanRoom.CollaborationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.CollaborationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource>> GetAsync(string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CleanRoom.CollaborationResource> GetIfExists(string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CleanRoom.CollaborationResource>> GetIfExistsAsync(string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CleanRoom.CollaborationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CleanRoom.CollaborationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CleanRoom.CollaborationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.CollaborationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CollaborationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.CollaborationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.CollaborationData>
    {
        public CollaborationData(Azure.Core.AzureLocation location) { }
        public string ClusterEndpoint { get { throw null; } }
        public Azure.ResourceManager.CleanRoom.Models.CollaborationState? CollaborationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CleanRoom.Models.Collaborator> Collaborators { get { throw null; } }
        public Azure.Core.ResourceIdentifier ConsortiumArmId { get { throw null; } }
        public Azure.ResourceManager.CleanRoom.Models.Health Health { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.ResourceManager.CleanRoom.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CleanRoom.Models.Workload> Workloads { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.CollaborationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.CollaborationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.CollaborationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.CollaborationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.CollaborationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.CollaborationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.CollaborationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CollaborationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.CollaborationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.CollaborationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CollaborationResource() { }
        public virtual Azure.ResourceManager.CleanRoom.CollaborationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddCollaborator(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddCollaboratorAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string collaborationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableWorkload(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableWorkloadAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult> GetReadonlyKubeConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult>> GetReadonlyKubeConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Pause(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PauseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Recover(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RecoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CleanRoom.CollaborationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.CollaborationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.CollaborationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.CollaborationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.CollaborationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.CollaborationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.CollaborationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.ResourceTags body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.ResourceTags body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConsortiumCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumResource>, System.Collections.IEnumerable
    {
        protected ConsortiumCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CleanRoom.ConsortiumResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string consortiumName, Azure.ResourceManager.CleanRoom.ConsortiumData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CleanRoom.ConsortiumResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string consortiumName, Azure.ResourceManager.CleanRoom.ConsortiumData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource> Get(string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CleanRoom.ConsortiumResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.ConsortiumResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource>> GetAsync(string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CleanRoom.ConsortiumResource> GetIfExists(string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CleanRoom.ConsortiumResource>> GetIfExistsAsync(string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CleanRoom.ConsortiumResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CleanRoom.ConsortiumResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConsortiumData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumData>
    {
        public ConsortiumData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.CleanRoom.Models.ConsortiumState? ConsortiumState { get { throw null; } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.CleanRoom.Models.GovernanceType? GovernanceType { get { throw null; } }
        public Azure.ResourceManager.CleanRoom.Models.Health Health { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CleanRoom.Models.ConsortiumMember> Members { get { throw null; } }
        public Azure.ResourceManager.CleanRoom.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } set { } }
        public string ServiceCertificatePem { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.ConsortiumData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.ConsortiumData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsortiumResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConsortiumResource() { }
        public virtual Azure.ResourceManager.CleanRoom.ConsortiumData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string consortiumName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Pause(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PauseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Recover(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RecoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CleanRoom.ConsortiumData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.ConsortiumData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.ResourceTags body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.ResourceTags body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConsortiumViewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>, System.Collections.IEnumerable
    {
        protected ConsortiumViewCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string consortiumViewName, Azure.ResourceManager.CleanRoom.ConsortiumViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string consortiumViewName, Azure.ResourceManager.CleanRoom.ConsortiumViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> Get(string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>> GetAsync(string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> GetIfExists(string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>> GetIfExistsAsync(string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConsortiumViewContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource>, System.Collections.IEnumerable
    {
        protected ConsortiumViewContractCollection() { }
        public virtual Azure.Response<bool> Exists(string contractName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contractName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource> Get(string contractName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource>> GetAsync(string contractName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource> GetIfExists(string contractName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource>> GetIfExistsAsync(string contractName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConsortiumViewContractData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>
    {
        internal ConsortiumViewContractData() { }
        public string ContractId { get { throw null; } }
        public string DeploymentPolicy { get { throw null; } }
        public string DeploymentTemplate { get { throw null; } }
        public string Kind { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.ConsortiumViewContractData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.ConsortiumViewContractData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsortiumViewContractResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConsortiumViewContractResource() { }
        public virtual Azure.ResourceManager.CleanRoom.ConsortiumViewContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string consortiumViewName, string contractName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ProposeTemplate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ProposeTemplateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CleanRoom.ConsortiumViewContractData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.ConsortiumViewContractData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewContractData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsortiumViewData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>
    {
        public ConsortiumViewData(Azure.Core.AzureLocation location, string consortiumEndpoint, string consortiumServiceCertificatePem, Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember member) { }
        public string ConsortiumEndpoint { get { throw null; } set { } }
        public string ConsortiumServiceCertificatePem { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember Member { get { throw null; } set { } }
        public Azure.ResourceManager.CleanRoom.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.ConsortiumViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.ConsortiumViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsortiumViewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConsortiumViewResource() { }
        public virtual Azure.ResourceManager.CleanRoom.ConsortiumViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string consortiumViewName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource> GetConsortiumViewContract(string contractName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource>> GetConsortiumViewContractAsync(string contractName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CleanRoom.ConsortiumViewContractCollection GetConsortiumViewContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CleanRoom.ConsortiumViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.ConsortiumViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.ConsortiumViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.ResourceTags body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CleanRoom.Models.ResourceTags body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CleanRoom.Mocking
{
    public partial class MockableCleanRoomArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCleanRoomArmClient() { }
        public virtual Azure.ResourceManager.CleanRoom.CollaborationResource GetCollaborationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CleanRoom.ConsortiumResource GetConsortiumResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CleanRoom.ConsortiumViewContractResource GetConsortiumViewContractResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CleanRoom.ConsortiumViewResource GetConsortiumViewResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCleanRoomResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCleanRoomResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource> GetCollaboration(string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.CollaborationResource>> GetCollaborationAsync(string collaborationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CleanRoom.CollaborationCollection GetCollaborations() { throw null; }
        public virtual Azure.ResourceManager.CleanRoom.ConsortiumCollection GetConsortia() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource> GetConsortium(string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumResource>> GetConsortiumAsync(string consortiumName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> GetConsortiumView(string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CleanRoom.ConsortiumViewResource>> GetConsortiumViewAsync(string consortiumViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CleanRoom.ConsortiumViewCollection GetConsortiumViews() { throw null; }
    }
    public partial class MockableCleanRoomSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCleanRoomSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.CleanRoom.CollaborationResource> GetCollaborations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.CollaborationResource> GetCollaborationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CleanRoom.ConsortiumResource> GetConsortia(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.ConsortiumResource> GetConsortiaAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> GetConsortiumViews(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CleanRoom.ConsortiumViewResource> GetConsortiumViewsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CleanRoom.Models
{
    public partial class AddCollaboratorContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent>
    {
        public AddCollaboratorContent() { }
        public bool? IsCollaborationOwner { get { throw null; } }
        public string ObjectId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public string UserIdentifier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmCleanRoomModelFactory
    {
        public static Azure.ResourceManager.CleanRoom.Models.AddCollaboratorContent AddCollaboratorContent(string userIdentifier = null, string tenantId = null, string objectId = null, bool? isCollaborationOwner = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CleanRoom.CollaborationData CollaborationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string clusterEndpoint = null, Azure.Core.ResourceIdentifier consortiumArmId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.Models.Workload> workloads = null, Azure.ResourceManager.CleanRoom.Models.CollaborationState? collaborationState = default(Azure.ResourceManager.CleanRoom.Models.CollaborationState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.Models.Collaborator> collaborators = null, Azure.ResourceManager.CleanRoom.Models.Health health = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> managedOnBehalfOfMoboBrokerResources = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.CleanRoom.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CleanRoom.Models.ProvisioningState?), string kind = null) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.Collaborator Collaborator(string userIdentifier = null, string tenantId = null, string objectId = null, bool? isCollaborationOwner = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CleanRoom.ConsortiumData ConsortiumData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string endpoint = null, string serviceCertificatePem = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.Models.ConsortiumMember> members = null, Azure.ResourceManager.CleanRoom.Models.Health health = null, Azure.ResourceManager.CleanRoom.Models.GovernanceType? governanceType = default(Azure.ResourceManager.CleanRoom.Models.GovernanceType?), Azure.ResourceManager.CleanRoom.Models.ConsortiumState? consortiumState = default(Azure.ResourceManager.CleanRoom.Models.ConsortiumState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> managedOnBehalfOfMoboBrokerResources = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.CleanRoom.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CleanRoom.Models.ProvisioningState?), string kind = null) { throw null; }
        public static Azure.ResourceManager.CleanRoom.ConsortiumViewContractData ConsortiumViewContractData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string contractId = null, string deploymentPolicy = null, string deploymentTemplate = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.CleanRoom.ConsortiumViewData ConsortiumViewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string consortiumEndpoint = null, string consortiumServiceCertificatePem = null, Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember member = null, Azure.ResourceManager.CleanRoom.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CleanRoom.Models.ProvisioningState?), string kind = null) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember ConsortiumViewMember(string identifier = null, string signedPayload = null, string certificatePem = null) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.Health Health(Azure.ResourceManager.CleanRoom.Models.HealthState healthState = default(Azure.ResourceManager.CleanRoom.Models.HealthState), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CleanRoom.Models.HealthIssue> healthIssues = null) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.HealthIssue HealthIssue(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult ReadonlyKubeConfigResult(string kubeconfig = null) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.Workload Workload(Azure.ResourceManager.CleanRoom.Models.WorkloadType workloadType = Azure.ResourceManager.CleanRoom.Models.WorkloadType.AnalyticsStrict, string endpoint = null, string @namespace = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CollaborationState : System.IEquatable<Azure.ResourceManager.CleanRoom.Models.CollaborationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CollaborationState(string value) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState Deprovisioned { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState Paused { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState PauseFailed { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState PauseInitiated { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState Resumed { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState ResumeFailed { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.CollaborationState ResumeInitiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CleanRoom.Models.CollaborationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CleanRoom.Models.CollaborationState left, Azure.ResourceManager.CleanRoom.Models.CollaborationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CleanRoom.Models.CollaborationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CleanRoom.Models.CollaborationState left, Azure.ResourceManager.CleanRoom.Models.CollaborationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Collaborator : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.Collaborator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Collaborator>
    {
        public Collaborator() { }
        public bool? IsCollaborationOwner { get { throw null; } }
        public string ObjectId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public string UserIdentifier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.Collaborator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.Collaborator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.Collaborator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.Collaborator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Collaborator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Collaborator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Collaborator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsortiumMember : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumMember>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumMember>
    {
        public ConsortiumMember(string identifier, string certificatePem, string encryptionKeyPem, bool isOperator) { }
        public string CertificatePem { get { throw null; } set { } }
        public string EncryptionKeyPem { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public bool IsOperator { get { throw null; } set { } }
        public string RecoveryRole { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.ConsortiumMember System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumMember>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumMember>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.ConsortiumMember System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumMember>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumMember>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumMember>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsortiumState : System.IEquatable<Azure.ResourceManager.CleanRoom.Models.ConsortiumState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsortiumState(string value) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState Deprovisioned { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState Paused { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState PauseFailed { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState PauseInitiated { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState Resumed { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState ResumeFailed { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ConsortiumState ResumeInitiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CleanRoom.Models.ConsortiumState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CleanRoom.Models.ConsortiumState left, Azure.ResourceManager.CleanRoom.Models.ConsortiumState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CleanRoom.Models.ConsortiumState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CleanRoom.Models.ConsortiumState left, Azure.ResourceManager.CleanRoom.Models.ConsortiumState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsortiumViewMember : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember>
    {
        public ConsortiumViewMember(string signedPayload, string certificatePem) { }
        public string CertificatePem { get { throw null; } set { } }
        public string Identifier { get { throw null; } }
        public string SignedPayload { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ConsortiumViewMember>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnableWorkloadContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent>
    {
        public EnableWorkloadContent(Azure.ResourceManager.CleanRoom.Models.WorkloadType workloadType) { }
        public Azure.ResourceManager.CleanRoom.Models.WorkloadType WorkloadType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.EnableWorkloadContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GovernanceType : System.IEquatable<Azure.ResourceManager.CleanRoom.Models.GovernanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GovernanceType(string value) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.GovernanceType CGS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CleanRoom.Models.GovernanceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CleanRoom.Models.GovernanceType left, Azure.ResourceManager.CleanRoom.Models.GovernanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CleanRoom.Models.GovernanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CleanRoom.Models.GovernanceType left, Azure.ResourceManager.CleanRoom.Models.GovernanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Health : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.Health>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Health>
    {
        internal Health() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CleanRoom.Models.HealthIssue> HealthIssues { get { throw null; } }
        public Azure.ResourceManager.CleanRoom.Models.HealthState HealthState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.Health System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.Health>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.Health>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.Health System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Health>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Health>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Health>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.HealthIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.HealthIssue>
    {
        internal HealthIssue() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.HealthIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.HealthIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.HealthIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.HealthIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.HealthIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.HealthIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.HealthIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthState : System.IEquatable<Azure.ResourceManager.CleanRoom.Models.HealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthState(string value) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.HealthState Error { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.HealthState Ok { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CleanRoom.Models.HealthState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CleanRoom.Models.HealthState left, Azure.ResourceManager.CleanRoom.Models.HealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CleanRoom.Models.HealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CleanRoom.Models.HealthState left, Azure.ResourceManager.CleanRoom.Models.HealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.CleanRoom.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CleanRoom.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.CleanRoom.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CleanRoom.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CleanRoom.Models.ProvisioningState left, Azure.ResourceManager.CleanRoom.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CleanRoom.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CleanRoom.Models.ProvisioningState left, Azure.ResourceManager.CleanRoom.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReadonlyKubeConfigResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult>
    {
        internal ReadonlyKubeConfigResult() { }
        public string Kubeconfig { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ReadonlyKubeConfigResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoverCollaborationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent>
    {
        public RecoverCollaborationContent(bool forceRecover) { }
        public bool ForceRecover { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.RecoverCollaborationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoverConsortiumContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent>
    {
        public RecoverConsortiumContent(bool forceRecover) { }
        public bool ForceRecover { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.RecoverConsortiumContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ResourceTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ResourceTags>
    {
        public ResourceTags() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.ResourceTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ResourceTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.ResourceTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.ResourceTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ResourceTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ResourceTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.ResourceTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Workload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.Workload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Workload>
    {
        internal Workload() { }
        public string Endpoint { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.CleanRoom.Models.WorkloadType WorkloadType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.Workload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.Workload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CleanRoom.Models.Workload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CleanRoom.Models.Workload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Workload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Workload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CleanRoom.Models.Workload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WorkloadType
    {
        AnalyticsStrict = 0,
    }
}
