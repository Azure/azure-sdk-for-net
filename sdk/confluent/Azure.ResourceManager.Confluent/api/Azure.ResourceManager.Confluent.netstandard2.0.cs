namespace Azure.ResourceManager.Confluent
{
    public partial class AzureResourceManagerConfluentContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerConfluentContext() { }
        public static Azure.ResourceManager.Confluent.AzureResourceManagerConfluentContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ConfluentExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> CreateMarketplaceAgreement(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Confluent.Models.ConfluentAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>> CreateMarketplaceAgreementAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Confluent.Models.ConfluentAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetConfluentOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Confluent.ConfluentOrganizationResource GetConfluentOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Confluent.ConfluentOrganizationCollection GetConfluentOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Confluent.ConnectorResource GetConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreements(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreementsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Confluent.SCClusterRecordResource GetSCClusterRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Confluent.SCEnvironmentRecordResource GetSCEnvironmentRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Confluent.TopicRecordResource GetTopicRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> ValidateOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> ValidateOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult> ValidateOrganizationV2(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult>> ValidateOrganizationV2Async(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfluentOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>, System.Collections.IEnumerable
    {
        protected ConfluentOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfluentOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>
    {
        public ConfluentOrganizationData(Azure.Core.AzureLocation location, Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail offerDetail, Azure.ResourceManager.Confluent.Models.ConfluentUserDetail userDetail) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string LinkOrganizationToken { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail OfferDetail { get { throw null; } set { } }
        public System.Guid? OrganizationId { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentProvisionState? ProvisioningState { get { throw null; } }
        public System.Uri SsoUri { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentUserDetail UserDetail { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.ConfluentOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.ConfluentOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfluentOrganizationResource() { }
        public virtual Azure.ResourceManager.Confluent.ConfluentOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord> CreateAccessRoleBinding(Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord>> CreateAccessRoleBindingAsync(Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAccessRoleBinding(string roleBindingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAccessRoleBindingAsync(string roleBindingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteClusterApiKey(string apiKeyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClusterApiKeyAsync(string apiKeyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessClusterListResult> GetAccessClusters(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessClusterListResult>> GetAccessClustersAsync(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult> GetAccessEnvironments(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult>> GetAccessEnvironmentsAsync(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessInvitationListResult> GetAccessInvitations(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessInvitationListResult>> GetAccessInvitationsAsync(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult> GetAccessRoleBindingNames(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult>> GetAccessRoleBindingNamesAsync(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult> GetAccessRoleBindings(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult>> GetAccessRoleBindingsAsync(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult> GetAccessServiceAccounts(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult>> GetAccessServiceAccountsAsync(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessUserListResult> GetAccessUsers(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessUserListResult>> GetAccessUsersAsync(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord> GetClusterApiKey(string apiKeyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord>> GetClusterApiKeyAsync(string apiKeyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult> GetRegions(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult>> GetRegionsAsync(Azure.ResourceManager.Confluent.Models.AccessListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> GetSCEnvironmentRecord(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>> GetSCEnvironmentRecordAsync(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Confluent.SCEnvironmentRecordCollection GetSCEnvironmentRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord> InviteUser(Azure.ResourceManager.Confluent.Models.AccessInvitationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord>> InviteUserAsync(Azure.ResourceManager.Confluent.Models.AccessInvitationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Confluent.ConfluentOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.ConfluentOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> Update(Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> UpdateAsync(Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConnectorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConnectorResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectorResource() { }
        public virtual Azure.ResourceManager.Confluent.ConnectorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string environmentId, string clusterId, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Confluent.ConnectorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.ConnectorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.ConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Confluent.ConnectorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.ConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Confluent.ConnectorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConnectorResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.ConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.ConnectorResource>, System.Collections.IEnumerable
    {
        protected ConnectorResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.ConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.Confluent.ConnectorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.ConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.Confluent.ConnectorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.ConnectorResource> GetAll(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.ConnectorResource> GetAllAsync(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Confluent.ConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Confluent.ConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Confluent.ConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.ConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Confluent.ConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.ConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectorResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConnectorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConnectorResourceData>
    {
        public ConnectorResourceData() { }
        public Azure.ResourceManager.Confluent.Models.ConnectorInfoBase ConnectorBasicInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase ConnectorServiceTypeInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.PartnerInfoBase PartnerConnectorInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.ConnectorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.ConnectorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConnectorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCClusterRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.SCClusterRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.SCClusterRecordResource>, System.Collections.IEnumerable
    {
        protected SCClusterRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.SCClusterRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterId, Azure.ResourceManager.Confluent.SCClusterRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.SCClusterRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterId, Azure.ResourceManager.Confluent.SCClusterRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.SCClusterRecordResource> Get(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.SCClusterRecordResource> GetAll(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.SCClusterRecordResource> GetAllAsync(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.SCClusterRecordResource>> GetAsync(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Confluent.SCClusterRecordResource> GetIfExists(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Confluent.SCClusterRecordResource>> GetIfExistsAsync(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Confluent.SCClusterRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.SCClusterRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Confluent.SCClusterRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.SCClusterRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SCClusterRecordData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCClusterRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCClusterRecordData>
    {
        public SCClusterRecordData() { }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.SCMetadataEntity Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity Spec { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.ClusterStatusEntity Status { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.SCClusterRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.SCClusterRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCClusterRecordResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCClusterRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCClusterRecordData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SCClusterRecordResource() { }
        public virtual Azure.ResourceManager.Confluent.SCClusterRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord> CreateApiKey(Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord>> CreateApiKeyAsync(Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string environmentId, string clusterId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.SCClusterRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.SCClusterRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConnectorResource> GetConnectorResource(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConnectorResource>> GetConnectorResourceAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Confluent.ConnectorResourceCollection GetConnectorResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.TopicRecordResource> GetTopicRecord(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.TopicRecordResource>> GetTopicRecordAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Confluent.TopicRecordCollection GetTopicRecords() { throw null; }
        Azure.ResourceManager.Confluent.SCClusterRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.SCClusterRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCClusterRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.SCClusterRecordResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Confluent.SCClusterRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.SCClusterRecordResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Confluent.SCClusterRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SCEnvironmentRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>, System.Collections.IEnumerable
    {
        protected SCEnvironmentRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentId, Azure.ResourceManager.Confluent.SCEnvironmentRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentId, Azure.ResourceManager.Confluent.SCEnvironmentRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> Get(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> GetAll(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> GetAllAsync(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>> GetAsync(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> GetIfExists(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>> GetIfExistsAsync(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SCEnvironmentRecordData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>
    {
        public SCEnvironmentRecordData() { }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.SCMetadataEntity Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.Package? StreamGovernanceConfigPackage { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.SCEnvironmentRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.SCEnvironmentRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCEnvironmentRecordResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SCEnvironmentRecordResource() { }
        public virtual Azure.ResourceManager.Confluent.SCEnvironmentRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string environmentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.SCClusterRecordResource> GetSCClusterRecord(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.SCClusterRecordResource>> GetSCClusterRecordAsync(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Confluent.SCClusterRecordCollection GetSCClusterRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord> GetSchemaRegistryCluster(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord>> GetSchemaRegistryClusterAsync(string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord> GetSchemaRegistryClusters(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord> GetSchemaRegistryClustersAsync(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Confluent.SCEnvironmentRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.SCEnvironmentRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.SCEnvironmentRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Confluent.SCEnvironmentRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.SCEnvironmentRecordResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Confluent.SCEnvironmentRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopicRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.TopicRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.TopicRecordResource>, System.Collections.IEnumerable
    {
        protected TopicRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.TopicRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.Confluent.TopicRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.TopicRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.Confluent.TopicRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.TopicRecordResource> Get(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.TopicRecordResource> GetAll(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.TopicRecordResource> GetAllAsync(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.TopicRecordResource>> GetAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Confluent.TopicRecordResource> GetIfExists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Confluent.TopicRecordResource>> GetIfExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Confluent.TopicRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.TopicRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Confluent.TopicRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.TopicRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopicRecordData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.TopicRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.TopicRecordData>
    {
        public TopicRecordData() { }
        public string ConfigsRelated { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Confluent.Models.TopicsInputConfig> InputConfigs { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.TopicMetadataEntity Metadata { get { throw null; } set { } }
        public string PartitionsCount { get { throw null; } set { } }
        public string PartitionsReassignmentsRelated { get { throw null; } set { } }
        public string PartitionsRelated { get { throw null; } set { } }
        public string ReplicationFactor { get { throw null; } set { } }
        public string TopicId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.TopicRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.TopicRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.TopicRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.TopicRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.TopicRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.TopicRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.TopicRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopicRecordResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.TopicRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.TopicRecordData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopicRecordResource() { }
        public virtual Azure.ResourceManager.Confluent.TopicRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string environmentId, string clusterId, string topicName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.TopicRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.TopicRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Confluent.TopicRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.TopicRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.TopicRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.TopicRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.TopicRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.TopicRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.TopicRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.TopicRecordResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Confluent.TopicRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.TopicRecordResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Confluent.TopicRecordData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Confluent.Mocking
{
    public partial class MockableConfluentArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableConfluentArmClient() { }
        public virtual Azure.ResourceManager.Confluent.ConfluentOrganizationResource GetConfluentOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Confluent.ConnectorResource GetConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Confluent.SCClusterRecordResource GetSCClusterRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Confluent.SCEnvironmentRecordResource GetSCEnvironmentRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Confluent.TopicRecordResource GetTopicRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableConfluentResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConfluentResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetConfluentOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Confluent.ConfluentOrganizationCollection GetConfluentOrganizations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> ValidateOrganization(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> ValidateOrganizationAsync(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult> ValidateOrganizationV2(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult>> ValidateOrganizationV2Async(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableConfluentSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConfluentSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> CreateMarketplaceAgreement(Azure.ResourceManager.Confluent.Models.ConfluentAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>> CreateMarketplaceAgreementAsync(Azure.ResourceManager.Confluent.Models.ConfluentAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreements(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreementsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Confluent.Models
{
    public partial class AccessClusterListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessClusterListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessClusterListResult>
    {
        internal AccessClusterListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.AccessClusterRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessClusterListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessClusterListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessClusterListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessClusterListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessClusterListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessClusterListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessClusterListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessClusterRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessClusterRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessClusterRecord>
    {
        internal AccessClusterRecord() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ClusterSpecEntity Spec { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ClusterStatusEntity Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessClusterRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessClusterRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessClusterRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessClusterRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessClusterRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessClusterRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessClusterRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessEnvironmentListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult>
    {
        internal AccessEnvironmentListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessEnvironmentRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord>
    {
        internal AccessEnvironmentRecord() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessInvitationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationContent>
    {
        public AccessInvitationContent() { }
        public string Email { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails InvitedUserDetails { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInvitationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInvitationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessInvitationListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitationListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationListResult>
    {
        internal AccessInvitationListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInvitationListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitationListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitationListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInvitationListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessInvitationRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord>
    {
        internal AccessInvitationRecord() { }
        public System.DateTimeOffset? AcceptedOn { get { throw null; } }
        public string AuthType { get { throw null; } }
        public string Email { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInvitationRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInvitationRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessInvitedUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>
    {
        public AccessInvitedUserDetails() { }
        public string AuthType { get { throw null; } set { } }
        public string InvitedEmail { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessListContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListContent>
    {
        public AccessListContent() { }
        public System.Collections.Generic.IDictionary<string, string> SearchFilters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessListContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessListContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessRoleBindingCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent>
    {
        public AccessRoleBindingCreateContent() { }
        public string CrnPattern { get { throw null; } set { } }
        public string Principal { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessRoleBindingListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult>
    {
        internal AccessRoleBindingListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessRoleBindingNameListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult>
    {
        internal AccessRoleBindingNameListResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessRoleBindingRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord>
    {
        internal AccessRoleBindingRecord() { }
        public string CrnPattern { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        public string Principal { get { throw null; } }
        public string RoleName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessServiceAccountListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult>
    {
        internal AccessServiceAccountListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessServiceAccountRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord>
    {
        internal AccessServiceAccountRecord() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessUserListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessUserListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessUserListResult>
    {
        internal AccessUserListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.AccessUserRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessUserListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessUserListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessUserListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessUserListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessUserListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessUserListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessUserListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessUserRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessUserRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessUserRecord>
    {
        internal AccessUserRecord() { }
        public string AuthType { get { throw null; } }
        public string Email { get { throw null; } }
        public string FullName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessUserRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessUserRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessUserRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessUserRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessUserRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessUserRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessUserRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiKeyOwnerEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity>
    {
        internal ApiKeyOwnerEntity() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiKeyResourceEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity>
    {
        internal ApiKeyResourceEntity() { }
        public string Environment { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiKeySpecEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity>
    {
        internal ApiKeySpecEntity() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity Owner { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity Resource { get { throw null; } }
        public string Secret { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmConfluentModelFactory
    {
        public static Azure.ResourceManager.Confluent.Models.AccessClusterListResult AccessClusterListResult(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.AccessClusterRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessClusterRecord AccessClusterRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string displayName = null, Azure.ResourceManager.Confluent.Models.ClusterSpecEntity spec = null, Azure.ResourceManager.Confluent.Models.ClusterStatusEntity status = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessEnvironmentListResult AccessEnvironmentListResult(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessEnvironmentRecord AccessEnvironmentRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessInvitationListResult AccessInvitationListResult(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.AccessInvitationRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessInvitationRecord AccessInvitationRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string email = null, string authType = null, string status = null, System.DateTimeOffset? acceptedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessRoleBindingListResult AccessRoleBindingListResult(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListResult AccessRoleBindingNameListResult(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<string> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessRoleBindingRecord AccessRoleBindingRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string principal = null, string roleName = null, string crnPattern = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessServiceAccountListResult AccessServiceAccountListResult(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessServiceAccountRecord AccessServiceAccountRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string displayName = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessUserListResult AccessUserListResult(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.AccessUserRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessUserRecord AccessUserRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string email = null, string fullName = null, string authType = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity ApiKeyOwnerEntity(string id = null, string related = null, string resourceName = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity ApiKeyResourceEntity(string id = null, string environment = null, string related = null, string resourceName = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity ApiKeySpecEntity(string description = null, string name = null, string secret = null, Azure.ResourceManager.Confluent.Models.ApiKeyResourceEntity resource = null, Azure.ResourceManager.Confluent.Models.ApiKeyOwnerEntity owner = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterByokEntity ClusterByokEntity(string id = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity ClusterEnvironmentEntity(string id = null, string environment = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity ClusterNetworkEntity(string id = null, string environment = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterSpecEntity ClusterSpecEntity(string displayName = null, string availability = null, string cloud = null, string zone = null, string region = null, string kafkaBootstrapEndpoint = null, string httpEndpoint = null, string apiEndpoint = null, string configKind = null, Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity environment = null, Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity network = null, Azure.ResourceManager.Confluent.Models.ClusterByokEntity byok = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentAgreement ConfluentAgreement(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string product = null, string plan = null, string licenseTextLink = null, string privacyPolicyLink = null, System.DateTimeOffset? retrieveOn = default(System.DateTimeOffset?), string signature = null, bool? isAccepted = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord ConfluentApiKeyRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null, Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity spec = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentListMetadata ConfluentListMetadata(string first = null, string last = null, string prev = null, string next = null, int? totalSize = default(int?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail ConfluentOfferDetail(string publisherId, string id, string planId, string planName, string termUnit, Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus? status) { throw null; }
        public static Azure.ResourceManager.Confluent.ConfluentOrganizationData ConfluentOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Confluent.Models.ConfluentProvisionState? provisioningState = default(Azure.ResourceManager.Confluent.Models.ConfluentProvisionState?), System.Guid? organizationId = default(System.Guid?), System.Uri ssoUri = null, Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail offerDetail = null, Azure.ResourceManager.Confluent.Models.ConfluentUserDetail userDetail = null, string linkOrganizationToken = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult ConfluentOrganizationValidationResult(System.Collections.Generic.IReadOnlyDictionary<string, string> info = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult ConfluentRegionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord ConfluentRegionRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null, Azure.ResourceManager.Confluent.Models.RegionSpecEntity spec = null) { throw null; }
        public static Azure.ResourceManager.Confluent.ConnectorResourceData ConnectorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Confluent.Models.ConnectorInfoBase connectorBasicInfo = null, Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase connectorServiceTypeInfo = null, Azure.ResourceManager.Confluent.Models.PartnerInfoBase partnerConnectorInfo = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.MetadataEntity MetadataEntity(string self = null, string resourceName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.RegionSpecEntity RegionSpecEntity(string name = null, string cloud = null, string regionName = null, System.Collections.Generic.IEnumerable<string> packages = null) { throw null; }
        public static Azure.ResourceManager.Confluent.SCClusterRecordData SCClusterRecordData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null, Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity spec = null, Azure.ResourceManager.Confluent.Models.ClusterStatusEntity status = null) { throw null; }
        public static Azure.ResourceManager.Confluent.SCEnvironmentRecordData SCEnvironmentRecordData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, Azure.ResourceManager.Confluent.Models.Package? streamGovernanceConfigPackage = default(Azure.ResourceManager.Confluent.Models.Package?), Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity SchemaRegistryClusterEnvironmentRegionEntity(string id = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord SchemaRegistryClusterRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null, Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity spec = null, string statusPhase = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity SchemaRegistryClusterSpecEntity(string name = null, string httpEndpoint = null, string package = null, Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity region = null, Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity environment = null, string cloud = null) { throw null; }
        public static Azure.ResourceManager.Confluent.TopicRecordData TopicRecordData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, string topicId = null, Azure.ResourceManager.Confluent.Models.TopicMetadataEntity metadata = null, string partitionsRelated = null, string configsRelated = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.TopicsInputConfig> inputConfigs = null, string partitionsReassignmentsRelated = null, string partitionsCount = null, string replicationFactor = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthType : System.IEquatable<Azure.ResourceManager.Confluent.Models.AuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthType(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AuthType KAFKAAPIKEY { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.AuthType SERVICEACCOUNT { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.AuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.AuthType left, Azure.ResourceManager.Confluent.Models.AuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.AuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.AuthType left, Azure.ResourceManager.Confluent.Models.AuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureBlobStorageSinkConnectorServiceInfo : Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSinkConnectorServiceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSinkConnectorServiceInfo>
    {
        public AzureBlobStorageSinkConnectorServiceInfo() { }
        public string StorageAccountKey { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string StorageContainerName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureBlobStorageSinkConnectorServiceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSinkConnectorServiceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSinkConnectorServiceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureBlobStorageSinkConnectorServiceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSinkConnectorServiceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSinkConnectorServiceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSinkConnectorServiceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlobStorageSourceConnectorServiceInfo : Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSourceConnectorServiceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSourceConnectorServiceInfo>
    {
        public AzureBlobStorageSourceConnectorServiceInfo() { }
        public string StorageAccountKey { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string StorageContainerName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureBlobStorageSourceConnectorServiceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSourceConnectorServiceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSourceConnectorServiceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureBlobStorageSourceConnectorServiceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSourceConnectorServiceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSourceConnectorServiceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureBlobStorageSourceConnectorServiceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureCosmosDBSinkConnectorServiceInfo : Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSinkConnectorServiceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSinkConnectorServiceInfo>
    {
        public AzureCosmosDBSinkConnectorServiceInfo() { }
        public string CosmosConnectionEndpoint { get { throw null; } set { } }
        public string CosmosContainersTopicMapping { get { throw null; } set { } }
        public string CosmosDatabaseName { get { throw null; } set { } }
        public string CosmosIdStrategy { get { throw null; } set { } }
        public string CosmosMasterKey { get { throw null; } set { } }
        public string CosmosWriteDetails { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureCosmosDBSinkConnectorServiceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSinkConnectorServiceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSinkConnectorServiceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureCosmosDBSinkConnectorServiceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSinkConnectorServiceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSinkConnectorServiceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSinkConnectorServiceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureCosmosDBSourceConnectorServiceInfo : Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSourceConnectorServiceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSourceConnectorServiceInfo>
    {
        public AzureCosmosDBSourceConnectorServiceInfo() { }
        public string CosmosConnectionEndpoint { get { throw null; } set { } }
        public string CosmosContainersTopicMapping { get { throw null; } set { } }
        public string CosmosDatabaseName { get { throw null; } set { } }
        public string CosmosIncludeAllContainers { get { throw null; } set { } }
        public string CosmosMasterKey { get { throw null; } set { } }
        public bool? CosmosMessageKeyEnabled { get { throw null; } set { } }
        public string CosmosMessageKeyField { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureCosmosDBSourceConnectorServiceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSourceConnectorServiceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSourceConnectorServiceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureCosmosDBSourceConnectorServiceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSourceConnectorServiceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSourceConnectorServiceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureCosmosDBSourceConnectorServiceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureSynapseAnalyticsSinkConnectorServiceInfo : Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureSynapseAnalyticsSinkConnectorServiceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureSynapseAnalyticsSinkConnectorServiceInfo>
    {
        public AzureSynapseAnalyticsSinkConnectorServiceInfo() { }
        public string SynapseSqlDatabaseName { get { throw null; } set { } }
        public string SynapseSqlPassword { get { throw null; } set { } }
        public string SynapseSqlServerName { get { throw null; } set { } }
        public string SynapseSqlUser { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureSynapseAnalyticsSinkConnectorServiceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureSynapseAnalyticsSinkConnectorServiceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AzureSynapseAnalyticsSinkConnectorServiceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AzureSynapseAnalyticsSinkConnectorServiceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureSynapseAnalyticsSinkConnectorServiceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureSynapseAnalyticsSinkConnectorServiceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AzureSynapseAnalyticsSinkConnectorServiceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterByokEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterByokEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterByokEntity>
    {
        internal ClusterByokEntity() { }
        public string Id { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterByokEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterByokEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterByokEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterByokEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterByokEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterByokEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterByokEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterEnvironmentEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity>
    {
        internal ClusterEnvironmentEntity() { }
        public string Environment { get { throw null; } }
        public string Id { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterNetworkEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>
    {
        internal ClusterNetworkEntity() { }
        public string Environment { get { throw null; } }
        public string Id { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterSpecEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>
    {
        internal ClusterSpecEntity() { }
        public string ApiEndpoint { get { throw null; } }
        public string Availability { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ClusterByokEntity Byok { get { throw null; } }
        public string Cloud { get { throw null; } }
        public string ConfigKind { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity Environment { get { throw null; } }
        public string HttpEndpoint { get { throw null; } }
        public string KafkaBootstrapEndpoint { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity Network { get { throw null; } }
        public string Region { get { throw null; } }
        public string Zone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterSpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterSpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterStatusEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterStatusEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterStatusEntity>
    {
        public ClusterStatusEntity() { }
        public int? Cku { get { throw null; } set { } }
        public string Phase { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterStatusEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterStatusEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterStatusEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterStatusEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterStatusEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterStatusEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterStatusEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentAgreement : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>
    {
        public ConfluentAgreement() { }
        public bool? IsAccepted { get { throw null; } set { } }
        public string LicenseTextLink { get { throw null; } set { } }
        public string Plan { get { throw null; } set { } }
        public string PrivacyPolicyLink { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.DateTimeOffset? RetrieveOn { get { throw null; } set { } }
        public string Signature { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentAgreement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentAgreement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentApiKeyCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent>
    {
        public ConfluentApiKeyCreateContent() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentApiKeyRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord>
    {
        internal ConfluentApiKeyRecord() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCMetadataEntity Metadata { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ApiKeySpecEntity Spec { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentApiKeyRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentListMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentListMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentListMetadata>
    {
        internal ConfluentListMetadata() { }
        public string First { get { throw null; } }
        public string Last { get { throw null; } }
        public string Next { get { throw null; } }
        public string Prev { get { throw null; } }
        public int? TotalSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentListMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentListMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentListMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentListMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentListMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentListMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentListMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentOfferDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>
    {
        public ConfluentOfferDetail(string publisherId, string id, string planId, string planName, string termUnit) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ConfluentOfferDetail(string publisherId, string id, string planId, string planName, string termUnit, Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus? status) { }
        public string Id { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PrivateOfferId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrivateOfferIds { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus? Status { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentOrganizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>
    {
        public ConfluentOrganizationPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentOrganizationValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult>
    {
        internal ConfluentOrganizationValidationResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Info { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfluentProvisionState : System.IEquatable<Azure.ResourceManager.Confluent.Models.ConfluentProvisionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfluentProvisionState(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Creating { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.ConfluentProvisionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.ConfluentProvisionState left, Azure.ResourceManager.Confluent.Models.ConfluentProvisionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.ConfluentProvisionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.ConfluentProvisionState left, Azure.ResourceManager.Confluent.Models.ConfluentProvisionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfluentRegionListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult>
    {
        internal ConfluentRegionListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord> Data { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentRegionRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord>
    {
        internal ConfluentRegionRecord() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCMetadataEntity Metadata { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.RegionSpecEntity Spec { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentRegionRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfluentSaaSOfferStatus : System.IEquatable<Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfluentSaaSOfferStatus(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Reinstated { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Started { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Unsubscribed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus left, Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus left, Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfluentUserDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>
    {
        public ConfluentUserDetail(string emailAddress) { }
        public string AadEmail { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentUserDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentUserDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectorClass : System.IEquatable<Azure.ResourceManager.Confluent.Models.ConnectorClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectorClass(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConnectorClass AZUREBLOBSINK { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConnectorClass AZUREBLOBSOURCE { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConnectorClass AZURECOSMOSV2SINK { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConnectorClass AZURECOSMOSV2SOURCE { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.ConnectorClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.ConnectorClass left, Azure.ResourceManager.Confluent.Models.ConnectorClass right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.ConnectorClass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.ConnectorClass left, Azure.ResourceManager.Confluent.Models.ConnectorClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectorInfoBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConnectorInfoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConnectorInfoBase>
    {
        public ConnectorInfoBase() { }
        public Azure.ResourceManager.Confluent.Models.ConnectorClass? ConnectorClass { get { throw null; } set { } }
        public string ConnectorId { get { throw null; } set { } }
        public string ConnectorName { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.ConnectorStatus? ConnectorState { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.ConnectorType? ConnectorType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConnectorInfoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConnectorInfoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConnectorInfoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConnectorInfoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConnectorInfoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConnectorInfoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConnectorInfoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ConnectorServiceTypeInfoBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase>
    {
        protected ConnectorServiceTypeInfoBase() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConnectorServiceTypeInfoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectorStatus : System.IEquatable<Azure.ResourceManager.Confluent.Models.ConnectorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectorStatus(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConnectorStatus FAILED { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConnectorStatus PAUSED { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConnectorStatus PROVISIONING { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConnectorStatus RUNNING { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.ConnectorStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.ConnectorStatus left, Azure.ResourceManager.Confluent.Models.ConnectorStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.ConnectorStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.ConnectorStatus left, Azure.ResourceManager.Confluent.Models.ConnectorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectorType : System.IEquatable<Azure.ResourceManager.Confluent.Models.ConnectorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectorType(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConnectorType SINK { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConnectorType SOURCE { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.ConnectorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.ConnectorType left, Azure.ResourceManager.Confluent.Models.ConnectorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.ConnectorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.ConnectorType left, Azure.ResourceManager.Confluent.Models.ConnectorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFormatType : System.IEquatable<Azure.ResourceManager.Confluent.Models.DataFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFormatType(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.DataFormatType AVRO { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.DataFormatType BYTES { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.DataFormatType JSON { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.DataFormatType PROTOBUF { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.DataFormatType STRING { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.DataFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.DataFormatType left, Azure.ResourceManager.Confluent.Models.DataFormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.DataFormatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.DataFormatType left, Azure.ResourceManager.Confluent.Models.DataFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KafkaAzureBlobStorageSinkConnectorInfo : Azure.ResourceManager.Confluent.Models.PartnerInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSinkConnectorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSinkConnectorInfo>
    {
        public KafkaAzureBlobStorageSinkConnectorInfo() { }
        public string ApiKey { get { throw null; } set { } }
        public string ApiSecret { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.AuthType? AuthType { get { throw null; } set { } }
        public string FlushSize { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? InputFormat { get { throw null; } set { } }
        public string MaxTasks { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? OutputFormat { get { throw null; } set { } }
        public string ServiceAccountId { get { throw null; } set { } }
        public string TimeInterval { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Topics { get { throw null; } }
        public string TopicsDir { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSinkConnectorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSinkConnectorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSinkConnectorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSinkConnectorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSinkConnectorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSinkConnectorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSinkConnectorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KafkaAzureBlobStorageSourceConnectorInfo : Azure.ResourceManager.Confluent.Models.PartnerInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSourceConnectorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSourceConnectorInfo>
    {
        public KafkaAzureBlobStorageSourceConnectorInfo() { }
        public string ApiKey { get { throw null; } set { } }
        public string ApiSecret { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.AuthType? AuthType { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? InputFormat { get { throw null; } set { } }
        public string MaxTasks { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? OutputFormat { get { throw null; } set { } }
        public string ServiceAccountId { get { throw null; } set { } }
        public string TopicRegex { get { throw null; } set { } }
        public string TopicsDir { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSourceConnectorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSourceConnectorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSourceConnectorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSourceConnectorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSourceConnectorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSourceConnectorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureBlobStorageSourceConnectorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KafkaAzureCosmosDBSinkConnectorInfo : Azure.ResourceManager.Confluent.Models.PartnerInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSinkConnectorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSinkConnectorInfo>
    {
        public KafkaAzureCosmosDBSinkConnectorInfo() { }
        public string ApiKey { get { throw null; } set { } }
        public string ApiSecret { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.AuthType? AuthType { get { throw null; } set { } }
        public string FlushSize { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? InputFormat { get { throw null; } set { } }
        public string MaxTasks { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? OutputFormat { get { throw null; } set { } }
        public string ServiceAccountId { get { throw null; } set { } }
        public string TimeInterval { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Topics { get { throw null; } }
        public string TopicsDir { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSinkConnectorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSinkConnectorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSinkConnectorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSinkConnectorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSinkConnectorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSinkConnectorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSinkConnectorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KafkaAzureCosmosDBSourceConnectorInfo : Azure.ResourceManager.Confluent.Models.PartnerInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSourceConnectorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSourceConnectorInfo>
    {
        public KafkaAzureCosmosDBSourceConnectorInfo() { }
        public string ApiKey { get { throw null; } set { } }
        public string ApiSecret { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.AuthType? AuthType { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? InputFormat { get { throw null; } set { } }
        public string MaxTasks { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? OutputFormat { get { throw null; } set { } }
        public string ServiceAccountId { get { throw null; } set { } }
        public string TopicRegex { get { throw null; } set { } }
        public string TopicsDir { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSourceConnectorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSourceConnectorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSourceConnectorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSourceConnectorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSourceConnectorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSourceConnectorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureCosmosDBSourceConnectorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KafkaAzureSynapseAnalyticsSinkConnectorInfo : Azure.ResourceManager.Confluent.Models.PartnerInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureSynapseAnalyticsSinkConnectorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureSynapseAnalyticsSinkConnectorInfo>
    {
        public KafkaAzureSynapseAnalyticsSinkConnectorInfo() { }
        public string ApiKey { get { throw null; } set { } }
        public string ApiSecret { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.AuthType? AuthType { get { throw null; } set { } }
        public string FlushSize { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? InputFormat { get { throw null; } set { } }
        public string MaxTasks { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.DataFormatType? OutputFormat { get { throw null; } set { } }
        public string ServiceAccountId { get { throw null; } set { } }
        public string TimeInterval { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Topics { get { throw null; } }
        public string TopicsDir { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureSynapseAnalyticsSinkConnectorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureSynapseAnalyticsSinkConnectorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.KafkaAzureSynapseAnalyticsSinkConnectorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.KafkaAzureSynapseAnalyticsSinkConnectorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureSynapseAnalyticsSinkConnectorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureSynapseAnalyticsSinkConnectorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.KafkaAzureSynapseAnalyticsSinkConnectorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>
    {
        internal MetadataEntity() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string Self { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.MetadataEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.MetadataEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Package : System.IEquatable<Azure.ResourceManager.Confluent.Models.Package>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Package(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.Package ADVANCED { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.Package ESSENTIALS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.Package other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.Package left, Azure.ResourceManager.Confluent.Models.Package right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.Package (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.Package left, Azure.ResourceManager.Confluent.Models.Package right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class PartnerInfoBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.PartnerInfoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.PartnerInfoBase>
    {
        protected PartnerInfoBase() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.PartnerInfoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.PartnerInfoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.PartnerInfoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.PartnerInfoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.PartnerInfoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.PartnerInfoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.PartnerInfoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionSpecEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>
    {
        internal RegionSpecEntity() { }
        public string Cloud { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Packages { get { throw null; } }
        public string RegionName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.RegionSpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.RegionSpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCClusterByokEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>
    {
        public SCClusterByokEntity() { }
        public string Id { get { throw null; } set { } }
        public string Related { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterByokEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterByokEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCClusterNetworkEnvironmentEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>
    {
        public SCClusterNetworkEnvironmentEntity() { }
        public string Environment { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Related { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCClusterSpecEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>
    {
        public SCClusterSpecEntity() { }
        public string ApiEndpoint { get { throw null; } set { } }
        public string Availability { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.SCClusterByokEntity Byok { get { throw null; } set { } }
        public string Cloud { get { throw null; } set { } }
        public string ConfigKind { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity Environment { get { throw null; } set { } }
        public string HttpEndpoint { get { throw null; } set { } }
        public string KafkaBootstrapEndpoint { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity Network { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.Package? Package { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string Zone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaRegistryClusterEnvironmentRegionEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity>
    {
        internal SchemaRegistryClusterEnvironmentRegionEntity() { }
        public string Id { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaRegistryClusterRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord>
    {
        internal SchemaRegistryClusterRecord() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCMetadataEntity Metadata { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity Spec { get { throw null; } }
        public string StatusPhase { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaRegistryClusterSpecEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>
    {
        internal SchemaRegistryClusterSpecEntity() { }
        public string Cloud { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity Environment { get { throw null; } }
        public string HttpEndpoint { get { throw null; } }
        public string Name { get { throw null; } }
        public string Package { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity Region { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCMetadataEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>
    {
        public SCMetadataEntity() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string Self { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCMetadataEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCMetadataEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopicMetadataEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.TopicMetadataEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.TopicMetadataEntity>
    {
        public TopicMetadataEntity() { }
        public string ResourceName { get { throw null; } set { } }
        public string Self { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.TopicMetadataEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.TopicMetadataEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.TopicMetadataEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.TopicMetadataEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.TopicMetadataEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.TopicMetadataEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.TopicMetadataEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopicsInputConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.TopicsInputConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.TopicsInputConfig>
    {
        public TopicsInputConfig() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.TopicsInputConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.TopicsInputConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.TopicsInputConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.TopicsInputConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.TopicsInputConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.TopicsInputConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.TopicsInputConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
