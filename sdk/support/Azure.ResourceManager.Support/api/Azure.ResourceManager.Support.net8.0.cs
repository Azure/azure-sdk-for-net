namespace Azure.ResourceManager.Support
{
    public partial class AzureResourceManagerSupportContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSupportContext() { }
        public static Azure.ResourceManager.Support.AzureResourceManagerSupportContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ChatTranscriptDetailData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>
    {
        public ChatTranscriptDetailData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties> Messages { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.ChatTranscriptDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.ChatTranscriptDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileWorkspaceDetailData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>
    {
        public FileWorkspaceDetailData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.FileWorkspaceDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.FileWorkspaceDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProblemClassificationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.ProblemClassificationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.ProblemClassificationResource>, System.Collections.IEnumerable
    {
        protected ProblemClassificationCollection() { }
        public virtual Azure.Response<bool> Exists(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource> Get(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.ProblemClassificationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.ProblemClassificationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource>> GetAsync(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.ProblemClassificationResource> GetIfExists(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.ProblemClassificationResource>> GetIfExistsAsync(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.ProblemClassificationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.ProblemClassificationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.ProblemClassificationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.ProblemClassificationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProblemClassificationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ProblemClassificationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ProblemClassificationData>
    {
        internal ProblemClassificationData() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Support.Models.SecondaryConsentEnabled> SecondaryConsentEnabled { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.ProblemClassificationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ProblemClassificationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ProblemClassificationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.ProblemClassificationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ProblemClassificationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ProblemClassificationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ProblemClassificationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProblemClassificationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ProblemClassificationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ProblemClassificationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProblemClassificationResource() { }
        public virtual Azure.ResourceManager.Support.ProblemClassificationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceName, string problemClassificationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Support.ProblemClassificationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ProblemClassificationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ProblemClassificationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.ProblemClassificationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ProblemClassificationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ProblemClassificationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ProblemClassificationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionFileWorkspaceCollection : Azure.ResourceManager.ArmCollection
    {
        protected SubscriptionFileWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource> Get(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource>> GetAsync(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource> GetIfExists(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource>> GetIfExistsAsync(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionFileWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionFileWorkspaceResource() { }
        public virtual Azure.ResourceManager.Support.FileWorkspaceDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string fileWorkspaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketFileResource> GetSupportTicketFile(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketFileResource>> GetSupportTicketFileAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketFileCollection GetSupportTicketFiles() { throw null; }
        Azure.ResourceManager.Support.FileWorkspaceDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.FileWorkspaceDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionSupportTicketCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>, System.Collections.IEnumerable
    {
        protected SubscriptionSupportTicketCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string supportTicketName, Azure.ResourceManager.Support.SupportTicketData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string supportTicketName, Azure.ResourceManager.Support.SupportTicketData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> Get(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>> GetAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> GetIfExists(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>> GetIfExistsAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionSupportTicketResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionSupportTicketResource() { }
        public virtual Azure.ResourceManager.Support.SupportTicketData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult> CheckCommunicationNameAvailability(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>> CheckCommunicationNameAvailabilityAsync(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string supportTicketName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource> GetSupportTicketChatTranscript(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource>> GetSupportTicketChatTranscriptAsync(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketChatTranscriptCollection GetSupportTicketChatTranscripts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource> GetSupportTicketCommunication(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> GetSupportTicketCommunicationAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketCommunicationCollection GetSupportTicketCommunications() { throw null; }
        Azure.ResourceManager.Support.SupportTicketData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportTicketData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> Update(Azure.ResourceManager.Support.Models.UpdateSupportTicket updateSupportTicket, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>> UpdateAsync(Azure.ResourceManager.Support.Models.UpdateSupportTicket updateSupportTicket, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SupportAzureServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportAzureServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportAzureServiceResource>, System.Collections.IEnumerable
    {
        protected SupportAzureServiceCollection() { }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportAzureServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportAzureServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.SupportAzureServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.SupportAzureServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportAzureServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportAzureServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportAzureServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportAzureServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportAzureServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportAzureServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportAzureServiceData>
    {
        internal SupportAzureServiceData() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourceTypes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportAzureServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportAzureServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportAzureServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportAzureServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportAzureServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportAzureServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportAzureServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportAzureServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportAzureServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportAzureServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportAzureServiceResource() { }
        public virtual Azure.ResourceManager.Support.SupportAzureServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource> GetProblemClassification(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource>> GetProblemClassificationAsync(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.ProblemClassificationCollection GetProblemClassifications() { throw null; }
        Azure.ResourceManager.Support.SupportAzureServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportAzureServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportAzureServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportAzureServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportAzureServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportAzureServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportAzureServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SupportExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult> CheckNameAvailabilitySupportTicketsNoSubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>> CheckNameAvailabilitySupportTicketsNoSubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult> CheckSupportTicketNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>> CheckSupportTicketNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.ProblemClassificationResource GetProblemClassificationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource> GetSubscriptionFileWorkspace(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource>> GetSubscriptionFileWorkspaceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource GetSubscriptionFileWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SubscriptionFileWorkspaceCollection GetSubscriptionFileWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> GetSubscriptionSupportTicket(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>> GetSubscriptionSupportTicketAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.SubscriptionSupportTicketResource GetSubscriptionSupportTicketResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SubscriptionSupportTicketCollection GetSubscriptionSupportTickets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource> GetSupportAzureService(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource>> GetSupportAzureServiceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.SupportAzureServiceResource GetSupportAzureServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportAzureServiceCollection GetSupportAzureServices(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketChatTranscriptResource GetSupportTicketChatTranscriptResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketCommunicationResource GetSupportTicketCommunicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketFileResource GetSupportTicketFileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource GetSupportTicketNoSubChatTranscriptResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource GetSupportTicketNoSubCommunicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketNoSubFileResource GetSupportTicketNoSubFileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.TenantFileWorkspaceResource> GetTenantFileWorkspace(this Azure.ResourceManager.Resources.TenantResource tenantResource, string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.TenantFileWorkspaceResource>> GetTenantFileWorkspaceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.TenantFileWorkspaceResource GetTenantFileWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.TenantFileWorkspaceCollection GetTenantFileWorkspaces(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource> GetTenantSupportTicket(this Azure.ResourceManager.Resources.TenantResource tenantResource, string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource>> GetTenantSupportTicketAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.TenantSupportTicketResource GetTenantSupportTicketResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.TenantSupportTicketCollection GetTenantSupportTickets(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class SupportFileDetailData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportFileDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>
    {
        public SupportFileDetailData() { }
        public int? ChunkSize { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? FileSize { get { throw null; } set { } }
        public int? NumberOfChunks { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportFileDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportFileDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportFileDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportFileDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportTicketChatTranscriptCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource>, System.Collections.IEnumerable
    {
        protected SupportTicketChatTranscriptCollection() { }
        public virtual Azure.Response<bool> Exists(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource> Get(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource>> GetAsync(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource> GetIfExists(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource>> GetIfExistsAsync(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportTicketChatTranscriptResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportTicketChatTranscriptResource() { }
        public virtual Azure.ResourceManager.Support.ChatTranscriptDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string supportTicketName, string chatTranscriptName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketChatTranscriptResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Support.ChatTranscriptDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.ChatTranscriptDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportTicketCommunicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketCommunicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketCommunicationResource>, System.Collections.IEnumerable
    {
        protected SupportTicketCommunicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketCommunicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communicationName, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communicationName, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource> Get(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportTicketCommunicationResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportTicketCommunicationResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> GetAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketCommunicationResource> GetIfExists(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> GetIfExistsAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportTicketCommunicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketCommunicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportTicketCommunicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketCommunicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportTicketCommunicationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>
    {
        public SupportTicketCommunicationData(string subject, string body) { }
        public string Body { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection? CommunicationDirection { get { throw null; } }
        public Azure.ResourceManager.Support.Models.SupportTicketCommunicationType? CommunicationType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Sender { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportTicketCommunicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportTicketCommunicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportTicketCommunicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportTicketCommunicationResource() { }
        public virtual Azure.ResourceManager.Support.SupportTicketCommunicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string supportTicketName, string communicationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Support.SupportTicketCommunicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportTicketCommunicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketCommunicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SupportTicketData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>
    {
        public SupportTicketData(string description, string problemClassificationId, Azure.ResourceManager.Support.Models.SupportSeverityLevel severity, Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent advancedDiagnosticConsent, Azure.ResourceManager.Support.Models.SupportContactProfile contactDetails, string title, string serviceId) { }
        public Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent AdvancedDiagnosticConsent { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportContactProfile ContactDetails { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string EnrollmentId { get { throw null; } set { } }
        public string FileWorkspaceName { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.IsTemporaryTicket? IsTemporaryTicket { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string ProblemClassificationDisplayName { get { throw null; } }
        public string ProblemClassificationId { get { throw null; } set { } }
        public string ProblemScopingQuestions { get { throw null; } set { } }
        public System.DateTimeOffset? ProblemStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.QuotaTicketDetails QuotaTicketDetails { get { throw null; } set { } }
        public bool? Require24X7Response { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Support.Models.SecondaryConsent> SecondaryConsent { get { throw null; } }
        public string ServiceDisplayName { get { throw null; } }
        public string ServiceId { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement ServiceLevelAgreement { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportSeverityLevel Severity { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public string SupportEngineerEmailAddress { get { throw null; } }
        public string SupportPlanDisplayName { get { throw null; } }
        public string SupportPlanId { get { throw null; } set { } }
        public string SupportPlanType { get { throw null; } }
        public string SupportTicketId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TechnicalTicketDetailsResourceId { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportTicketData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportTicketData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportTicketFileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketFileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketFileResource>, System.Collections.IEnumerable
    {
        protected SupportTicketFileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketFileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fileName, Azure.ResourceManager.Support.SupportFileDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketFileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fileName, Azure.ResourceManager.Support.SupportFileDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketFileResource> Get(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportTicketFileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportTicketFileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketFileResource>> GetAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketFileResource> GetIfExists(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketFileResource>> GetIfExistsAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportTicketFileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketFileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportTicketFileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketFileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportTicketFileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportFileDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportTicketFileResource() { }
        public virtual Azure.ResourceManager.Support.SupportFileDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string fileWorkspaceName, string fileName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketFileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketFileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Support.SupportFileDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportFileDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportFileDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportFileDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketFileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportFileDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketFileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportFileDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Upload(Azure.ResourceManager.Support.Models.UploadFileContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync(Azure.ResourceManager.Support.Models.UploadFileContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SupportTicketNoSubChatTranscriptCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource>, System.Collections.IEnumerable
    {
        protected SupportTicketNoSubChatTranscriptCollection() { }
        public virtual Azure.Response<bool> Exists(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource> Get(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource>> GetAsync(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource> GetIfExists(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource>> GetIfExistsAsync(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportTicketNoSubChatTranscriptResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportTicketNoSubChatTranscriptResource() { }
        public virtual Azure.ResourceManager.Support.ChatTranscriptDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string supportTicketName, string chatTranscriptName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Support.ChatTranscriptDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.ChatTranscriptDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.ChatTranscriptDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportTicketNoSubCommunicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>, System.Collections.IEnumerable
    {
        protected SupportTicketNoSubCommunicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communicationName, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communicationName, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> Get(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>> GetAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> GetIfExists(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>> GetIfExistsAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportTicketNoSubCommunicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportTicketNoSubCommunicationResource() { }
        public virtual Azure.ResourceManager.Support.SupportTicketCommunicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string supportTicketName, string communicationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Support.SupportTicketCommunicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportTicketCommunicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketCommunicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SupportTicketNoSubFileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>, System.Collections.IEnumerable
    {
        protected SupportTicketNoSubFileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fileName, Azure.ResourceManager.Support.SupportFileDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fileName, Azure.ResourceManager.Support.SupportFileDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> Get(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>> GetAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> GetIfExists(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>> GetIfExistsAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportTicketNoSubFileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportFileDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportTicketNoSubFileResource() { }
        public virtual Azure.ResourceManager.Support.SupportFileDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string fileWorkspaceName, string fileName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Support.SupportFileDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportFileDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportFileDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportFileDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportFileDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportFileDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportFileDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Upload(Azure.ResourceManager.Support.Models.UploadFileContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync(Azure.ResourceManager.Support.Models.UploadFileContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantFileWorkspaceCollection : Azure.ResourceManager.ArmCollection
    {
        protected TenantFileWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.TenantFileWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.TenantFileWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.TenantFileWorkspaceResource> Get(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.TenantFileWorkspaceResource>> GetAsync(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.TenantFileWorkspaceResource> GetIfExists(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.TenantFileWorkspaceResource>> GetIfExistsAsync(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantFileWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantFileWorkspaceResource() { }
        public virtual Azure.ResourceManager.Support.FileWorkspaceDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string fileWorkspaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.TenantFileWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.TenantFileWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubFileResource> GetSupportTicketNoSubFile(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubFileResource>> GetSupportTicketNoSubFileAsync(string fileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketNoSubFileCollection GetSupportTicketNoSubFiles() { throw null; }
        Azure.ResourceManager.Support.FileWorkspaceDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.FileWorkspaceDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.FileWorkspaceDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.TenantFileWorkspaceResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.TenantFileWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantSupportTicketCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.TenantSupportTicketResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.TenantSupportTicketResource>, System.Collections.IEnumerable
    {
        protected TenantSupportTicketCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.TenantSupportTicketResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string supportTicketName, Azure.ResourceManager.Support.SupportTicketData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.TenantSupportTicketResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string supportTicketName, Azure.ResourceManager.Support.SupportTicketData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource> Get(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.TenantSupportTicketResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.TenantSupportTicketResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource>> GetAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Support.TenantSupportTicketResource> GetIfExists(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Support.TenantSupportTicketResource>> GetIfExistsAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.TenantSupportTicketResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.TenantSupportTicketResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.TenantSupportTicketResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.TenantSupportTicketResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantSupportTicketResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantSupportTicketResource() { }
        public virtual Azure.ResourceManager.Support.SupportTicketData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult> CheckNameAvailabilityCommunicationsNoSubscription(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>> CheckNameAvailabilityCommunicationsNoSubscriptionAsync(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string supportTicketName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource> GetSupportTicketNoSubChatTranscript(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource>> GetSupportTicketNoSubChatTranscriptAsync(string chatTranscriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptCollection GetSupportTicketNoSubChatTranscripts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource> GetSupportTicketNoSubCommunication(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource>> GetSupportTicketNoSubCommunicationAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketNoSubCommunicationCollection GetSupportTicketNoSubCommunications() { throw null; }
        Azure.ResourceManager.Support.SupportTicketData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.SupportTicketData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.SupportTicketData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.SupportTicketData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource> Update(Azure.ResourceManager.Support.Models.UpdateSupportTicket updateSupportTicket, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource>> UpdateAsync(Azure.ResourceManager.Support.Models.UpdateSupportTicket updateSupportTicket, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Support.Mocking
{
    public partial class MockableSupportArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSupportArmClient() { }
        public virtual Azure.ResourceManager.Support.ProblemClassificationResource GetProblemClassificationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource GetSubscriptionFileWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.SubscriptionSupportTicketResource GetSubscriptionSupportTicketResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportAzureServiceResource GetSupportAzureServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketChatTranscriptResource GetSupportTicketChatTranscriptResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketCommunicationResource GetSupportTicketCommunicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketFileResource GetSupportTicketFileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketNoSubChatTranscriptResource GetSupportTicketNoSubChatTranscriptResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketNoSubCommunicationResource GetSupportTicketNoSubCommunicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketNoSubFileResource GetSupportTicketNoSubFileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.TenantFileWorkspaceResource GetTenantFileWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Support.TenantSupportTicketResource GetTenantSupportTicketResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSupportSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSupportSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult> CheckSupportTicketNameAvailability(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>> CheckSupportTicketNameAvailabilityAsync(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource> GetSubscriptionFileWorkspace(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SubscriptionFileWorkspaceResource>> GetSubscriptionFileWorkspaceAsync(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SubscriptionFileWorkspaceCollection GetSubscriptionFileWorkspaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource> GetSubscriptionSupportTicket(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SubscriptionSupportTicketResource>> GetSubscriptionSupportTicketAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SubscriptionSupportTicketCollection GetSubscriptionSupportTickets() { throw null; }
    }
    public partial class MockableSupportTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSupportTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult> CheckNameAvailabilitySupportTicketsNoSubscription(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>> CheckNameAvailabilitySupportTicketsNoSubscriptionAsync(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource> GetSupportAzureService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource>> GetSupportAzureServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportAzureServiceCollection GetSupportAzureServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.TenantFileWorkspaceResource> GetTenantFileWorkspace(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.TenantFileWorkspaceResource>> GetTenantFileWorkspaceAsync(string fileWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.TenantFileWorkspaceCollection GetTenantFileWorkspaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource> GetTenantSupportTicket(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.TenantSupportTicketResource>> GetTenantSupportTicketAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.TenantSupportTicketCollection GetTenantSupportTickets() { throw null; }
    }
}
namespace Azure.ResourceManager.Support.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvancedDiagnosticConsent : System.IEquatable<Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvancedDiagnosticConsent(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent No { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent left, Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent left, Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmSupportModelFactory
    {
        public static Azure.ResourceManager.Support.ChatTranscriptDetailData ChatTranscriptDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties> messages = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties ChatTranscriptMessageProperties(Azure.ResourceManager.Support.Models.TranscriptContentType? contentType = default(Azure.ResourceManager.Support.Models.TranscriptContentType?), Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection? communicationDirection = default(Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection?), string sender = null, string body = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Support.FileWorkspaceDetailData FileWorkspaceDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Support.ProblemClassificationData ProblemClassificationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.Models.SecondaryConsentEnabled> secondaryConsentEnabled = null) { throw null; }
        public static Azure.ResourceManager.Support.Models.SecondaryConsentEnabled SecondaryConsentEnabled(string description = null, string secondaryConsentEnabledType = null) { throw null; }
        public static Azure.ResourceManager.Support.SupportAzureServiceData SupportAzureServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Support.SupportFileDetailData SupportFileDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), int? chunkSize = default(int?), int? fileSize = default(int?), int? numberOfChunks = default(int?)) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult SupportNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement SupportServiceLevelAgreement(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), int? slaInMinutes = default(int?)) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketCommunicationData SupportTicketCommunicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Support.Models.SupportTicketCommunicationType? communicationType = default(Azure.ResourceManager.Support.Models.SupportTicketCommunicationType?), Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection? communicationDirection = default(Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection?), string sender = null, string subject = null, string body = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketData SupportTicketData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string supportTicketId = null, string description = null, string problemClassificationId = null, string problemClassificationDisplayName = null, Azure.ResourceManager.Support.Models.SupportSeverityLevel severity = default(Azure.ResourceManager.Support.Models.SupportSeverityLevel), string enrollmentId = null, bool? require24X7Response = default(bool?), Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent advancedDiagnosticConsent = default(Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent), string problemScopingQuestions = null, string supportPlanId = null, Azure.ResourceManager.Support.Models.SupportContactProfile contactDetails = null, Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement serviceLevelAgreement = null, string supportEngineerEmailAddress = null, string supportPlanType = null, string supportPlanDisplayName = null, string title = null, System.DateTimeOffset? problemStartOn = default(System.DateTimeOffset?), string serviceId = null, string serviceDisplayName = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string fileWorkspaceName = null, Azure.ResourceManager.Support.Models.IsTemporaryTicket? isTemporaryTicket = default(Azure.ResourceManager.Support.Models.IsTemporaryTicket?), Azure.Core.ResourceIdentifier technicalTicketDetailsResourceId = null, Azure.ResourceManager.Support.Models.QuotaTicketDetails quotaTicketDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.Models.SecondaryConsent> secondaryConsent = null) { throw null; }
    }
    public partial class ChatTranscriptMessageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties>
    {
        public ChatTranscriptMessageProperties() { }
        public string Body { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection? CommunicationDirection { get { throw null; } }
        public Azure.ResourceManager.Support.Models.TranscriptContentType? ContentType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Sender { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.ChatTranscriptMessageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsTemporaryTicket : System.IEquatable<Azure.ResourceManager.Support.Models.IsTemporaryTicket>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsTemporaryTicket(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.IsTemporaryTicket No { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.IsTemporaryTicket Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.IsTemporaryTicket other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.IsTemporaryTicket left, Azure.ResourceManager.Support.Models.IsTemporaryTicket right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.IsTemporaryTicket (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.IsTemporaryTicket left, Azure.ResourceManager.Support.Models.IsTemporaryTicket right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreferredContactMethod : System.IEquatable<Azure.ResourceManager.Support.Models.PreferredContactMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreferredContactMethod(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.PreferredContactMethod Email { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.PreferredContactMethod Phone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.PreferredContactMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.PreferredContactMethod left, Azure.ResourceManager.Support.Models.PreferredContactMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.PreferredContactMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.PreferredContactMethod left, Azure.ResourceManager.Support.Models.PreferredContactMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaTicketDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.QuotaTicketDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.QuotaTicketDetails>
    {
        public QuotaTicketDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Support.Models.SupportQuotaChangeContent> QuotaChangeRequests { get { throw null; } }
        public string QuotaChangeRequestSubType { get { throw null; } set { } }
        public string QuotaChangeRequestVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.QuotaTicketDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.QuotaTicketDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.QuotaTicketDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.QuotaTicketDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.QuotaTicketDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.QuotaTicketDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.QuotaTicketDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecondaryConsent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SecondaryConsent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SecondaryConsent>
    {
        public SecondaryConsent() { }
        public string SecondaryConsentType { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.UserConsent? UserConsent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SecondaryConsent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SecondaryConsent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SecondaryConsent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SecondaryConsent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SecondaryConsent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SecondaryConsent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SecondaryConsent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecondaryConsentEnabled : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SecondaryConsentEnabled>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SecondaryConsentEnabled>
    {
        internal SecondaryConsentEnabled() { }
        public string Description { get { throw null; } }
        public string SecondaryConsentEnabledType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SecondaryConsentEnabled System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SecondaryConsentEnabled>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SecondaryConsentEnabled>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SecondaryConsentEnabled System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SecondaryConsentEnabled>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SecondaryConsentEnabled>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SecondaryConsentEnabled>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportContactProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportContactProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportContactProfile>
    {
        public SupportContactProfile(string firstName, string lastName, Azure.ResourceManager.Support.Models.PreferredContactMethod preferredContactMethod, string primaryEmailAddress, string preferredTimeZone, string country, string preferredSupportLanguage) { }
        public System.Collections.Generic.IList<string> AdditionalEmailAddresses { get { throw null; } }
        public string Country { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.PreferredContactMethod PreferredContactMethod { get { throw null; } set { } }
        public string PreferredSupportLanguage { get { throw null; } set { } }
        public string PreferredTimeZone { get { throw null; } set { } }
        public string PrimaryEmailAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportContactProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportContactProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportContactProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportContactProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportContactProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportContactProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportContactProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportContactProfileContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportContactProfileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportContactProfileContent>
    {
        public SupportContactProfileContent() { }
        public System.Collections.Generic.IList<string> AdditionalEmailAddresses { get { throw null; } }
        public string Country { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.PreferredContactMethod? PreferredContactMethod { get { throw null; } set { } }
        public string PreferredSupportLanguage { get { throw null; } set { } }
        public string PreferredTimeZone { get { throw null; } set { } }
        public string PrimaryEmailAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportContactProfileContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportContactProfileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportContactProfileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportContactProfileContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportContactProfileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportContactProfileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportContactProfileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent>
    {
        public SupportNameAvailabilityContent(string name, Azure.ResourceManager.Support.Models.SupportResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Support.Models.SupportResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>
    {
        internal SupportNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportQuotaChangeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportQuotaChangeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportQuotaChangeContent>
    {
        public SupportQuotaChangeContent() { }
        public string Payload { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportQuotaChangeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportQuotaChangeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportQuotaChangeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportQuotaChangeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportQuotaChangeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportQuotaChangeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportQuotaChangeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SupportResourceType
    {
        MicrosoftSupportSupportTickets = 0,
        MicrosoftSupportCommunications = 1,
    }
    public partial class SupportServiceLevelAgreement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement>
    {
        public SupportServiceLevelAgreement() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public int? SlaInMinutes { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportSeverityLevel : System.IEquatable<Azure.ResourceManager.Support.Models.SupportSeverityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportSeverityLevel(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportSeverityLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportSeverityLevel Highestcriticalimpact { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportSeverityLevel Minimal { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportSeverityLevel Moderate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.SupportSeverityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.SupportSeverityLevel left, Azure.ResourceManager.Support.Models.SupportSeverityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.SupportSeverityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.SupportSeverityLevel left, Azure.ResourceManager.Support.Models.SupportSeverityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportTicketCommunicationDirection : System.IEquatable<Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportTicketCommunicationDirection(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection left, Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection left, Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportTicketCommunicationType : System.IEquatable<Azure.ResourceManager.Support.Models.SupportTicketCommunicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportTicketCommunicationType(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportTicketCommunicationType Phone { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportTicketCommunicationType Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.SupportTicketCommunicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.SupportTicketCommunicationType left, Azure.ResourceManager.Support.Models.SupportTicketCommunicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.SupportTicketCommunicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.SupportTicketCommunicationType left, Azure.ResourceManager.Support.Models.SupportTicketCommunicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportTicketStatus : System.IEquatable<Azure.ResourceManager.Support.Models.SupportTicketStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportTicketStatus(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportTicketStatus Closed { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportTicketStatus Open { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.SupportTicketStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.SupportTicketStatus left, Azure.ResourceManager.Support.Models.SupportTicketStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.SupportTicketStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.SupportTicketStatus left, Azure.ResourceManager.Support.Models.SupportTicketStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TranscriptContentType : System.IEquatable<Azure.ResourceManager.Support.Models.TranscriptContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TranscriptContentType(string value) { throw null; }
        public bool Equals(Azure.ResourceManager.Support.Models.TranscriptContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.TranscriptContentType left, Azure.ResourceManager.Support.Models.TranscriptContentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.TranscriptContentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.TranscriptContentType left, Azure.ResourceManager.Support.Models.TranscriptContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateSupportTicket : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.UpdateSupportTicket>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.UpdateSupportTicket>
    {
        public UpdateSupportTicket() { }
        public Azure.ResourceManager.Support.Models.AdvancedDiagnosticConsent? AdvancedDiagnosticConsent { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportContactProfileContent ContactDetails { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Support.Models.SecondaryConsent> SecondaryConsent { get { throw null; } }
        public Azure.ResourceManager.Support.Models.SupportSeverityLevel? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportTicketStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.UpdateSupportTicket System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.UpdateSupportTicket>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.UpdateSupportTicket>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.UpdateSupportTicket System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.UpdateSupportTicket>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.UpdateSupportTicket>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.UpdateSupportTicket>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UploadFileContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.UploadFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.UploadFileContent>
    {
        public UploadFileContent() { }
        public int? ChunkIndex { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.UploadFileContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.UploadFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Support.Models.UploadFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Support.Models.UploadFileContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.UploadFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.UploadFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Support.Models.UploadFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserConsent : System.IEquatable<Azure.ResourceManager.Support.Models.UserConsent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserConsent(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.UserConsent No { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.UserConsent Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.UserConsent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.UserConsent left, Azure.ResourceManager.Support.Models.UserConsent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.UserConsent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.UserConsent left, Azure.ResourceManager.Support.Models.UserConsent right) { throw null; }
        public override string ToString() { throw null; }
    }
}
