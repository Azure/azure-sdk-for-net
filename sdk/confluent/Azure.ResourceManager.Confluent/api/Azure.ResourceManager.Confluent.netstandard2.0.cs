namespace Azure.ResourceManager.Confluent
{
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
        public static Azure.Pageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreements(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreementsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> ValidateOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> ValidateOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Confluent.Models.ValidationResponse> ValidateOrganizationV2Validation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ValidationResponse>> ValidateOrganizationV2ValidationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        Azure.ResourceManager.Confluent.ConfluentOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.ConfluentOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentOrganizationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfluentOrganizationResource() { }
        public virtual Azure.ResourceManager.Confluent.ConfluentOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.APIKeyRecord> CreateAPIKey(string environmentId, string clusterId, Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.APIKeyRecord>> CreateAPIKeyAsync(string environmentId, string clusterId, Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.RoleBindingRecord> CreateRoleBindingAccess(Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.RoleBindingRecord>> CreateRoleBindingAccessAsync(Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteClusterAPIKey(string apiKeyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClusterAPIKeyAsync(string apiKeyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoleBindingAccess(string roleBindingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleBindingAccessAsync(string roleBindingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.APIKeyRecord> GetClusterAPIKey(string apiKeyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.APIKeyRecord>> GetClusterAPIKeyAsync(string apiKeyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.SCClusterRecord> GetClusterById(string environmentId, string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.SCClusterRecord>> GetClusterByIdAsync(string environmentId, string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.Models.SCClusterRecord> GetClusters(string environmentId, int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse> GetClustersAccess(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse>> GetClustersAccessAsync(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.SCClusterRecord> GetClustersAsync(string environmentId, int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord> GetEnvironmentById(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord>> GetEnvironmentByIdAsync(string environmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord> GetEnvironments(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse> GetEnvironmentsAccess(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse>> GetEnvironmentsAccessAsync(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord> GetEnvironmentsAsync(int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse> GetInvitationsAccess(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse>> GetInvitationsAccessAsync(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse> GetRegions(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse>> GetRegionsAsync(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse> GetRoleBindingNameListAccess(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse>> GetRoleBindingNameListAccessAsync(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse> GetRoleBindingsAccess(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse>> GetRoleBindingsAccessAsync(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord> GetSchemaRegistryClusterById(string environmentId, string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord>> GetSchemaRegistryClusterByIdAsync(string environmentId, string clusterId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord> GetSchemaRegistryClusters(string environmentId, int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord> GetSchemaRegistryClustersAsync(string environmentId, int? pageSize = default(int?), string pageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse> GetServiceAccountsAccess(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse>> GetServiceAccountsAccessAsync(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse> GetUsersAccess(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse>> GetUsersAccessAsync(Azure.ResourceManager.Confluent.Models.ListAccessRequestModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.InvitationRecord> InviteUserAccess(Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.InvitationRecord>> InviteUserAccessAsync(Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> Update(Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> UpdateAsync(Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Confluent.Mocking
{
    public partial class MockableConfluentArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableConfluentArmClient() { }
        public virtual Azure.ResourceManager.Confluent.ConfluentOrganizationResource GetConfluentOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableConfluentResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConfluentResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetConfluentOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Confluent.ConfluentOrganizationCollection GetConfluentOrganizations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> ValidateOrganization(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> ValidateOrganizationAsync(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.ValidationResponse> ValidateOrganizationV2Validation(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ValidationResponse>> ValidateOrganizationV2ValidationAsync(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AccessCreateRoleBindingRequestModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel>
    {
        public AccessCreateRoleBindingRequestModel() { }
        public string CrnPattern { get { throw null; } set { } }
        public string Principal { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
        Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessCreateRoleBindingRequestModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessInvitedUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>
    {
        public AccessInvitedUserDetails() { }
        public string AuthType { get { throw null; } set { } }
        public string InvitedEmail { get { throw null; } set { } }
        Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessInviteUserAccountModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel>
    {
        public AccessInviteUserAccountModel() { }
        public string Email { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.AccessInvitedUserDetails InvitedUserDetails { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessInviteUserAccountModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessListClusterSuccessResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse>
    {
        internal AccessListClusterSuccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.ClusterRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessListEnvironmentsSuccessResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse>
    {
        internal AccessListEnvironmentsSuccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.EnvironmentRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessListInvitationsSuccessResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse>
    {
        internal AccessListInvitationsSuccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.InvitationRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessListRoleBindingsSuccessResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse>
    {
        internal AccessListRoleBindingsSuccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.RoleBindingRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessListServiceAccountsSuccessResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse>
    {
        internal AccessListServiceAccountsSuccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.ServiceAccountRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessListUsersSuccessResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse>
    {
        internal AccessListUsersSuccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.UserRecord> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessRoleBindingNameListSuccessResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse>
    {
        internal AccessRoleBindingNameListSuccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<string> Data { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentListMetadata Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class APIKeyOwnerEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity>
    {
        internal APIKeyOwnerEntity() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class APIKeyRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeyRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyRecord>
    {
        internal APIKeyRecord() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCMetadataEntity Metadata { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.APIKeySpecEntity Spec { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.APIKeyRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeyRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeyRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.APIKeyRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class APIKeyResourceEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity>
    {
        internal APIKeyResourceEntity() { }
        public string Environment { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class APIKeySpecEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeySpecEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeySpecEntity>
    {
        internal APIKeySpecEntity() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity Owner { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity Resource { get { throw null; } }
        public string Secret { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.APIKeySpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeySpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.APIKeySpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.APIKeySpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeySpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeySpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.APIKeySpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmConfluentModelFactory
    {
        public static Azure.ResourceManager.Confluent.Models.AccessListClusterSuccessResponse AccessListClusterSuccessResponse(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.ClusterRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessListEnvironmentsSuccessResponse AccessListEnvironmentsSuccessResponse(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.EnvironmentRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessListInvitationsSuccessResponse AccessListInvitationsSuccessResponse(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.InvitationRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessListRoleBindingsSuccessResponse AccessListRoleBindingsSuccessResponse(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.RoleBindingRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessListServiceAccountsSuccessResponse AccessListServiceAccountsSuccessResponse(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.ServiceAccountRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessListUsersSuccessResponse AccessListUsersSuccessResponse(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.UserRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.AccessRoleBindingNameListSuccessResponse AccessRoleBindingNameListSuccessResponse(string kind = null, Azure.ResourceManager.Confluent.Models.ConfluentListMetadata metadata = null, System.Collections.Generic.IEnumerable<string> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity APIKeyOwnerEntity(string id = null, string related = null, string resourceName = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.APIKeyRecord APIKeyRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null, Azure.ResourceManager.Confluent.Models.APIKeySpecEntity spec = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity APIKeyResourceEntity(string id = null, string environment = null, string related = null, string resourceName = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.APIKeySpecEntity APIKeySpecEntity(string description = null, string name = null, string secret = null, Azure.ResourceManager.Confluent.Models.APIKeyResourceEntity resource = null, Azure.ResourceManager.Confluent.Models.APIKeyOwnerEntity owner = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterByokEntity ClusterByokEntity(string id = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity ClusterEnvironmentEntity(string id = null, string environment = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity ClusterNetworkEntity(string id = null, string environment = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterRecord ClusterRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string displayName = null, Azure.ResourceManager.Confluent.Models.ClusterSpecEntity spec = null, Azure.ResourceManager.Confluent.Models.ClusterStatusEntity status = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterSpecEntity ClusterSpecEntity(string displayName = null, string availability = null, string cloud = null, string zone = null, string region = null, string kafkaBootstrapEndpoint = null, string httpEndpoint = null, string apiEndpoint = null, string configKind = null, Azure.ResourceManager.Confluent.Models.ClusterEnvironmentEntity environment = null, Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity network = null, Azure.ResourceManager.Confluent.Models.ClusterByokEntity byok = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ClusterStatusEntity ClusterStatusEntity(string phase = null, int? cku = default(int?)) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentAgreement ConfluentAgreement(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string product = null, string plan = null, string licenseTextLink = null, string privacyPolicyLink = null, System.DateTimeOffset? retrieveOn = default(System.DateTimeOffset?), string signature = null, bool? isAccepted = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentListMetadata ConfluentListMetadata(string first = null, string last = null, string prev = null, string next = null, int? totalSize = default(int?)) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail ConfluentOfferDetail(string publisherId, string id, string planId, string planName, string termUnit, Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus? status) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Confluent.ConfluentOrganizationData ConfluentOrganizationData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.DateTimeOffset? createdOn, Azure.ResourceManager.Confluent.Models.ConfluentProvisionState? provisioningState, System.Guid? organizationId, System.Uri ssoUri, Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail offerDetail, Azure.ResourceManager.Confluent.Models.ConfluentUserDetail userDetail) { throw null; }
        public static Azure.ResourceManager.Confluent.ConfluentOrganizationData ConfluentOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Confluent.Models.ConfluentProvisionState? provisioningState = default(Azure.ResourceManager.Confluent.Models.ConfluentProvisionState?), System.Guid? organizationId = default(System.Guid?), System.Uri ssoUri = null, Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail offerDetail = null, Azure.ResourceManager.Confluent.Models.ConfluentUserDetail userDetail = null, string linkOrganizationToken = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.EnvironmentRecord EnvironmentRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.InvitationRecord InvitationRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string email = null, string authType = null, string status = null, string acceptedAt = null, string expiresAt = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse ListRegionsSuccessResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.Models.RegionRecord> data = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.MetadataEntity MetadataEntity(string self = null, string resourceName = null, string createdAt = null, string updatedAt = null, string deletedAt = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.RegionRecord RegionRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null, Azure.ResourceManager.Confluent.Models.RegionSpecEntity spec = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.RegionSpecEntity RegionSpecEntity(string name = null, string cloud = null, string regionName = null, System.Collections.Generic.IEnumerable<string> packages = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.RoleBindingRecord RoleBindingRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string principal = null, string roleName = null, string crnPattern = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SCClusterByokEntity SCClusterByokEntity(string id = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity SCClusterNetworkEnvironmentEntity(string id = null, string environment = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SCClusterRecord SCClusterRecord(string kind = null, string id = null, string name = null, Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null, Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity spec = null, Azure.ResourceManager.Confluent.Models.ClusterStatusEntity status = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity SCClusterSpecEntity(string name = null, string availability = null, string cloud = null, string zone = null, string region = null, string kafkaBootstrapEndpoint = null, string httpEndpoint = null, string apiEndpoint = null, string configKind = null, Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity environment = null, Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity network = null, Azure.ResourceManager.Confluent.Models.SCClusterByokEntity byok = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord SCEnvironmentRecord(string kind = null, string id = null, string name = null, Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity SchemaRegistryClusterEnvironmentRegionEntity(string id = null, string related = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterRecord SchemaRegistryClusterRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.SCMetadataEntity metadata = null, Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity spec = null, string statusPhase = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity SchemaRegistryClusterSpecEntity(string name = null, string httpEndpoint = null, string package = null, Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity region = null, Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity environment = null, string cloud = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SCMetadataEntity SCMetadataEntity(string self = null, string resourceName = null, string createdTimestamp = null, string updatedTimestamp = null, string deletedTimestamp = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ServiceAccountRecord ServiceAccountRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string displayName = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.UserRecord UserRecord(string kind = null, string id = null, Azure.ResourceManager.Confluent.Models.MetadataEntity metadata = null, string email = null, string fullName = null, string authType = null) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ValidationResponse ValidationResponse(System.Collections.Generic.IReadOnlyDictionary<string, string> info = null) { throw null; }
    }
    public partial class ClusterByokEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterByokEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterByokEntity>
    {
        internal ClusterByokEntity() { }
        public string Id { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
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
        Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterNetworkEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterRecord>
    {
        internal ClusterRecord() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ClusterSpecEntity Spec { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ClusterStatusEntity Status { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.ClusterRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.Confluent.Models.ClusterSpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ClusterSpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterSpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterStatusEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ClusterStatusEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ClusterStatusEntity>
    {
        internal ClusterStatusEntity() { }
        public int? Cku { get { throw null; } }
        public string Phase { get { throw null; } }
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
        Azure.ResourceManager.Confluent.Models.ConfluentAgreement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentAgreement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentListMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentListMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentListMetadata>
    {
        internal ConfluentListMetadata() { }
        public string First { get { throw null; } }
        public string Last { get { throw null; } }
        public string Next { get { throw null; } }
        public string Prev { get { throw null; } }
        public int? TotalSize { get { throw null; } }
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
        Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.Confluent.Models.ConfluentUserDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentUserDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAPIKeyModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel>
    {
        public CreateAPIKeyModel() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.CreateAPIKeyModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnvironmentRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.EnvironmentRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.EnvironmentRecord>
    {
        internal EnvironmentRecord() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.EnvironmentRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.EnvironmentRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.EnvironmentRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.EnvironmentRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.EnvironmentRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.EnvironmentRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.EnvironmentRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InvitationRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.InvitationRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.InvitationRecord>
    {
        internal InvitationRecord() { }
        public string AcceptedAt { get { throw null; } }
        public string AuthType { get { throw null; } }
        public string Email { get { throw null; } }
        public string ExpiresAt { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.InvitationRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.InvitationRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.InvitationRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.InvitationRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.InvitationRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.InvitationRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.InvitationRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListAccessRequestModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ListAccessRequestModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ListAccessRequestModel>
    {
        public ListAccessRequestModel() { }
        public System.Collections.Generic.IDictionary<string, string> SearchFilters { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.ListAccessRequestModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ListAccessRequestModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ListAccessRequestModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ListAccessRequestModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ListAccessRequestModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ListAccessRequestModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ListAccessRequestModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListRegionsSuccessResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse>
    {
        internal ListRegionsSuccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Confluent.Models.RegionRecord> Data { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ListRegionsSuccessResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>
    {
        internal MetadataEntity() { }
        public string CreatedAt { get { throw null; } }
        public string DeletedAt { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string Self { get { throw null; } }
        public string UpdatedAt { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.MetadataEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.MetadataEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.MetadataEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RegionRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionRecord>
    {
        internal RegionRecord() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCMetadataEntity Metadata { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.RegionSpecEntity Spec { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.RegionRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RegionRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RegionRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.RegionRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionSpecEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>
    {
        internal RegionSpecEntity() { }
        public string Cloud { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Packages { get { throw null; } }
        public string RegionName { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.RegionSpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.RegionSpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RegionSpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleBindingRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RoleBindingRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RoleBindingRecord>
    {
        internal RoleBindingRecord() { }
        public string CrnPattern { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        public string Principal { get { throw null; } }
        public string RoleName { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.RoleBindingRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RoleBindingRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.RoleBindingRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.RoleBindingRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RoleBindingRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RoleBindingRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.RoleBindingRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCClusterByokEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>
    {
        internal SCClusterByokEntity() { }
        public string Id { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.SCClusterByokEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterByokEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterByokEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCClusterNetworkEnvironmentEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>
    {
        internal SCClusterNetworkEnvironmentEntity() { }
        public string Environment { get { throw null; } }
        public string Id { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCClusterRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterRecord>
    {
        internal SCClusterRecord() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCMetadataEntity Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity Spec { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ClusterStatusEntity Status { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.SCClusterRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCClusterSpecEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>
    {
        internal SCClusterSpecEntity() { }
        public string ApiEndpoint { get { throw null; } }
        public string Availability { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCClusterByokEntity Byok { get { throw null; } }
        public string Cloud { get { throw null; } }
        public string ConfigKind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity Environment { get { throw null; } }
        public string HttpEndpoint { get { throw null; } }
        public string KafkaBootstrapEndpoint { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCClusterNetworkEnvironmentEntity Network { get { throw null; } }
        public string Region { get { throw null; } }
        public string Zone { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCClusterSpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCEnvironmentRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord>
    {
        internal SCEnvironmentRecord() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.SCMetadataEntity Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCEnvironmentRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaRegistryClusterEnvironmentRegionEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterEnvironmentRegionEntity>
    {
        internal SchemaRegistryClusterEnvironmentRegionEntity() { }
        public string Id { get { throw null; } }
        public string Related { get { throw null; } }
        public string ResourceName { get { throw null; } }
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
        Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SchemaRegistryClusterSpecEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SCMetadataEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>
    {
        internal SCMetadataEntity() { }
        public string CreatedTimestamp { get { throw null; } }
        public string DeletedTimestamp { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string Self { get { throw null; } }
        public string UpdatedTimestamp { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.SCMetadataEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.SCMetadataEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.SCMetadataEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAccountRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ServiceAccountRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ServiceAccountRecord>
    {
        internal ServiceAccountRecord() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.ServiceAccountRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ServiceAccountRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ServiceAccountRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ServiceAccountRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ServiceAccountRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ServiceAccountRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ServiceAccountRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.UserRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.UserRecord>
    {
        internal UserRecord() { }
        public string AuthType { get { throw null; } }
        public string Email { get { throw null; } }
        public string FullName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.MetadataEntity Metadata { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.UserRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.UserRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.UserRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.UserRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.UserRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.UserRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.UserRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ValidationResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ValidationResponse>
    {
        internal ValidationResponse() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Info { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.ValidationResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ValidationResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ValidationResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ValidationResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ValidationResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ValidationResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ValidationResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
